using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Vision
{
    /// <summary>
    /// IO卡管理
    /// </summary>
    public class IOManager : IDisposable
    {
        public int bitNum = 6;// 需要处理的输入数据位数
        Queue IOOut;
        Queue IOIn;
        Queue ManagerOut;
        Queue ManagerIn;
        private readonly object balanceLock_IOOut = new object();
        private readonly object balanceLock_IOIn = new object();
        private readonly object balanceLock_ManagerOut = new object();
        private readonly object balanceLock_ManagerIn = new object();
        Task TaskOperationIOCard;
        Task TaskProcessInPutData;
        Task TaskEventNotification;
        private WY_hDevice DeviceID0;  //定义板卡句柄参数

        bool TaskControl = true;

        /// <summary>
        /// IO卡接收到触发采集信号的事件
        /// </summary>
        public event Func<int, int> eventOneSignal;


        public IOManager()//构造函数
        {
            IOOut = new Queue();
            IOIn = new Queue();
            ManagerOut = new Queue();
            ManagerIn = new Queue();
            int Result = WENYU_PIO32P.WY_Open(0, ref DeviceID0);//打开IO卡
            if (Result == 0)
            {
                OperationIOCard();
                ProcessData();
                EventNotification();
            }
        }

        private void EventNotification()
        {
            TaskEventNotification = new Task(() =>
            {
                while (TaskControl)
                {

                    if (ManagerOut.Count > 0)//IO输出列队中有值？
                    {
                        int value;
                        lock (balanceLock_ManagerOut)
                        {
                            value = (int)ManagerOut.Dequeue();//取出值
                        }
                        eventOneSignal(value);//引发事件
                    }


                    Thread.Sleep(1);
                }
            });
            TaskEventNotification.Start();//开始线程
        }

        private void ProcessData()
        {
            TaskProcessInPutData = new Task(() =>
            {
                /// <summary>
                ///  高八位   低八位
                /// 00000000 00000000
                ///   15-8   76543210
                /// </summary>
                int OutPutDataOld = 65535;
                /// <summary>
                /// InPutData_Bit[n,0]当前值InPutData_Bit[n,1]上次值InPutData_Bit[n,2]计数
                /// </summary>
                int[,] InPutData_Bit = new int[16, 3];
                while (TaskControl)
                {
                    if (IOIn.Count > 0)//IO输入列队中有值?
                    {
                        int InPutData;

                        InPutData = (int)IOIn.Dequeue();//取出值

                        for (int i = 0; i < bitNum; i++)
                        {
                            InPutData_Bit[i, 1] = InPutData_Bit[i, 0];
                            InPutData_Bit[i, 0] = GetInPutData_Bit(i, InPutData);
                            if (InPutData_Bit[i, 1] > InPutData_Bit[i, 0])//来了一次信号?
                            {
                                InPutData_Bit[i, 2] = InPutData_Bit[i, 2] + 1;
                                lock (balanceLock_ManagerOut)
                                {
                                    ManagerOut.Enqueue(i);
                                }
                            }
                        }
                    }
                    if (ManagerIn.Count > 0)
                    {
                        int[] n_BitValue = (int[])ManagerIn.Dequeue();//拿到输出信号
                        OutPutDataOld = SetOutPutData_Bit(n_BitValue[0], n_BitValue[1], OutPutDataOld);//转换为IO卡可用的输出信号
                        lock (balanceLock_IOOut)
                        {
                            IOOut.Enqueue((long)OutPutDataOld);//压入io卡输出队列
                        }
                    }
                    Thread.Sleep(1);
                }
            });
            TaskProcessInPutData.Start();//开始线程
        }

        private void OperationIOCard()
        {
            TaskOperationIOCard = new Task(() =>
            {
                /// <summary>
                ///  高八位   低八位
                /// 00000000 00000000
                ///   15-8   76543210
                /// </summary>
                long InPutData = 0;
                long InPutDataOld = 0;
                while (TaskControl)
                {
                    lock (balanceLock_IOOut)
                    {
                        if (IOOut.Count > 0)//IO输出列队中有值？
                        {
                            long OutPutData = (long)IOOut.Dequeue();//取出值
                            WENYU_PIO32P.WY_SetOutPutData(DeviceID0, OutPutData);//io输出值
                        }
                    }

                    WENYU_PIO32P.WY_GetInPutData(DeviceID0, ref InPutData);//io读取值
                    if (InPutDataOld != InPutData)//输入值变化了？
                    {
                        InPutDataOld = InPutData;//将变化后的值更新到InPutDataOld
                        IOIn.Enqueue((int)InPutDataOld);//将值加入输入列队

                    }
                    Thread.Sleep(1);
                }
            });
            TaskOperationIOCard.Start();//开始线程
        }


        /// <summary>
        /// 得到InPutData以二进制形式某一位的值
        /// </summary>
        /// <param name="n_Bit"></param>
        /// <returns></returns>
        private int GetInPutData_Bit(int n_Bit, int InPutData)
        {
            int _InPutData = InPutData;
            _InPutData >>= n_Bit;
            _InPutData &= 1;
            return _InPutData;
        }

        private int SetOutPutData_Bit(int n_Bit, int value, int outPutDataOld)
        {
            if (value > 1) value = 1;
            if (value < 0) value = 0;
            int _value = 1;                     //0000 0001
            _value <<= n_Bit;                   //0000 1000
            _value = ~_value;                   //1111 0111
            int _OutPutData = outPutDataOld;    //XXXX XXXX
            _OutPutData &= _value;              //XXXX XXXX & 1111 0111= XXXX 0XXX            
            value <<= n_Bit;                    //0000 000V <<=n 0000 V000
            _OutPutData |= value;               //XXXX 0XXX | 0000 V000= XXXX nXXX
            return _OutPutData;
        }

        public void SetOutPutData_Bit(int n_Bit, int value)
        {
            lock (balanceLock_ManagerIn)
            {
                ManagerIn.Enqueue(new int[] { n_Bit, value });
            }
        }


        public void Dispose()
        {
            TaskControl = false;
        loop:
            if (TaskOperationIOCard.IsCompleted && TaskProcessInPutData.IsCompleted && TaskEventNotification.IsCompleted)
            {
                TaskOperationIOCard.Dispose();
                TaskProcessInPutData.Dispose();
                TaskEventNotification.Dispose();
            }
            else
            {
                Thread.Sleep(2);
                goto loop;
            }
        }
    }


    public static class WENYU_PIO32P
    {

        /****************************************************************************
                函数名称: WY_Open
                功能描述: 打开当前板卡，获取当前板卡句柄等DeviceID参数。打开获取DeviceID
                          参数值后，才能对板卡相关操作。在关闭系统前，必须用WY_Close函数关闭。
                          打开成功，所有输出端口16路为关闭状态，5路计数器清零0。
                参数列表:
                  CardNo：板卡编号，对应PCI槽0,1,2,3....
                DeviceID: 反回当前板卡DeviceID参数值;
                  返回值: 表示函数返状态  0:正确    1:板卡打开操作失败
        技术支持联系电话：13510401592
        *****************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_Open", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_Open(int CardNo, ref WY_hDevice DeviceID);



        /***************************************************************************
                函数名称: WY_GetInPutData
                功能描述: 获取开关量控制卡输入端数据
                参数列表:
		        DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
               InPutData: 输入端口数据，低位在前，高位在后。
                  返回值: 表示函数返状态  0:正确    1:板卡连接失败
        技术支持联系电话：13510401592
        ****************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_GetInPutData", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_GetInPutData(WY_hDevice DeviceID, ref long InPutData);



        /************************************************************************
                函数名称: WY_SetOutPutData
                功能描述: 设置开关量控制卡输出端口16位数据
                参数列表:
                DeviceID: 当前板卡DeviceID参数值。（从WY_Open函数获取）。
              OutPutData: 输出端口数据。
                  返回值: 表示函数返状态   0:正确    1:板卡连接失败   
                                           3：输入参数错误,OutPutData输入数值超出范围0x0000~0xffff
        技术支持联系电话：13510401592
        **************************************************************************/
        [DllImport("WENYU_PIO32P.dll", EntryPoint = "WY_SetOutPutData", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int WY_SetOutPutData(WY_hDevice DeviceID, long OutPutData);
    }

    public struct WY_hDevice { IntPtr hDevice; UInt32 Ar; };

}
