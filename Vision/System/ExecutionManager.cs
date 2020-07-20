using Rabbit.InvokeHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.CameraLib;

namespace Vision
{
    /// <summary>
    /// 执行管理器
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class ExecutionManager : IDisposable
    {
        /// <summary>
        /// 测量单元管理器列队
        /// </summary>
        public List<MeasureManager> listMeasureManager;

        /// <summary>
        /// IO卡
        /// </summary>
        [NonSerialized]//不序列化该字段
        private IOManager iOManager;

        public ExecutionManager(CameraManager cameraManager)
        {
            listMeasureManager = new List<MeasureManager>();
            foreach (var camera in cameraManager.listCamera)
            {
                MeasureManager measureManager = new MeasureManager(camera);
                measureManager.ImageAcqed();
                measureManager.MeasureFinish += MeasureManager_MeasureFinish;//
                listMeasureManager.Add(measureManager);
            }
            Initialize();
        }

        public ExecutionManager(CameraManager cameraManager, List<MeasureManager> measureManagers)
        {
            for (int i = 0; i < cameraManager.listCamera.Count; i++)
            {
                this.listMeasureManager = measureManagers;//赋值测量单元管理器
                this.listMeasureManager[i].camera = cameraManager.listCamera[i];//赋值测量单元管理器的相机
                this.listMeasureManager[i].ImageAcqed();
                this.listMeasureManager[i].MeasureFinish += MeasureManager_MeasureFinish;//挂载测量单元管理器测量完成事件
            }
            Initialize();
        }




        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
            iOManager = new IOManager();
            iOManager.eventOneSignal += IOManager_eventOneSignal;
        }

        private int IOManager_eventOneSignal(int arg)
        {
            if (arg >= listMeasureManager.Count)
                return 0;
            listMeasureManager[arg].Grad();//开始一次测量
            return 0;
        }

        //测量完成
        private int MeasureManager_MeasureFinish(int bit_number, int value)
        {
            iOManager.SetOutPutData_Bit(bit_number, value);//io卡管理器发结果信号
            return 0;
        }

        public void GradAll()
        {
            foreach (var measureManager in listMeasureManager)
            {
                measureManager.Grad();
            }
        }

        public void LiveAll(bool live)
        {
            foreach (var measureManager in listMeasureManager)
            {
                measureManager.Live(live);
            }

        }

        /// <summary>
        /// 获取用以保存的数据克隆副本
        /// </summary>
        /// <returns></returns>
        public List<MeasureManager> GetMeasureManagerListClone()
        {
            List<MeasureManager> listMeasureManager = new List<MeasureManager>();
            foreach (var item in this.listMeasureManager)
            {
                listMeasureManager.Add((MeasureManager)(item as ICloneable).Clone());
            }
            return listMeasureManager;
        }


        /// <summary>
        /// 清空并新建数据
        /// </summary>
        public void ClearMUMList()
        {
            foreach (var item in listMeasureManager)
            {
                item.CreateNewMUM();
            }
        }


        public void Dispose()
        {
            foreach (var item in listMeasureManager)
            {
                item.Dispose();
                item.ClearImageAcqed();
            }
        }
    }
}
