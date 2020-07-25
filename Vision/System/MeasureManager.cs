using ChoiceTech.Halcon.Control;
using HalconDotNet;
using Rabbit.InvokeHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vision.CameraLib;
using Vision.DataProcess;
using Vision.DataProcess.PositionLib;
using Vision.DataProcess.ShapeLib;

namespace Vision
{
    /// <summary>
    /// 测量单元管理器
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class MeasureManager : IDisposable, ICloneable
    {

        private int _num_OK;

        private int _sum;


        /// <summary>
        /// OK数目
        /// </summary>
        public int Num_OK { get { return _num_OK; } private set { if (value >= 0) { this._num_OK = value; } } }

        /// <summary>
        /// 总数
        /// </summary>
        public int Sum { get { return _sum; } private set { if (value >= 0) this._sum = value; } }


        /// <summary>
        /// 最后一次结果
        /// </summary>
        public Result LastResult { get; set; }

        /// <summary>
        /// 良率
        /// </summary>
        public string Yield { get; private set; }

        /// <summary>
        /// 测量单元列队
        /// </summary>
        private ArrayList measuringUnits;

        /// <summary>
        /// 测量结果
        /// </summary>
        private bool measureResult;

        /// <summary>
        /// k值
        /// </summary>
        public double k;

        /// <summary>
        /// 数据表格
        /// </summary>
        [NonSerialized]//不序列化该字段
        public DataTable dataTable;


        /// <summary>
        /// 相机
        /// </summary>
        [NonSerialized]//不序列化该字段
        public Camera camera;

        /// <summary>
        /// 是否开始测试
        /// </summary>
        public bool bisTest = false;

        /// <summary>
        /// 测量完成
        /// </summary>
        public event Func<int, int, int> MeasureFinish;//声明事件

        /// <summary>
        /// measuringUnits项中ID的最大的值
        /// </summary>
        private int maxId;

        /// <summary>
        /// 修改完成事件
        /// </summary>
        public event Func<object, object, int> ModificationCompleted;


        /// <summary>
        /// 添加完成事件
        /// </summary>
        public event Func<object, object, int> AddCompleted;
      

        public MeasureManager(Camera camera)//构造函数
        {
            this.camera = camera;
            Initialize();//初始化
          
           // camera.ImageAcqed += Camera_ImageAcqed;

        }

        public void ImageAcqed()
        {
            camera.ImageAcqed += Camera_ImageAcqed;
        }

     

        public MeasureManager(MeasureManager data)//用于克隆副本的构造函数
        {
            FieldInfo[] fields = data.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var item in fields)
            {
                Type type = this.GetType();
                FieldInfo fieldInfo = type.GetField(item.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (fieldInfo.FieldType == typeof(Func<object, object, int>) || fieldInfo.FieldType == typeof(Func<int, int, int>))
                {
                    continue;
                }
                Type type2 = data.GetType();
                FieldInfo fieldInfo2 = type2.GetField(item.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                object value = fieldInfo2.GetValue(data);
                fieldInfo.SetValue(this, value);
            }

        }


        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
            Sum = 0;
            Num_OK = 0;
            LastResult = Result.OK;
            k = 1;
            maxId = 1;
            measuringUnits = new ArrayList();//测量列队
        }

        /// <summary>
        /// 开始测量
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <returns></returns>
        private bool MeasureStart(HObject ho_Image)
        {
            int final = 1;
            int result = 1;
            foreach (IDataProcess item in measuringUnits)
            {
                item.MeasureDone = false;
            }
            foreach (IDataProcess item in measuringUnits)
            {
                if (item is BasePosition)
                {
                    (item as TranslationTracking).line.MeasureDone = false;//新加的
                    if (!item.MeasureDone)
                    {
                        result = item.Measure(ho_Image);
                    }
                }
            }
            foreach (IDataProcess item in measuringUnits)
            {
                if (!item.MeasureDone)
                {
                    result = item.Measure(ho_Image);
                }
                if (result == -1)
                {
                    //最后一次结果
                    LastResult = (Result)(-1);
                    return false;
                }
                final *= result;
            }
            Sum += 1;//总数
            Num_OK += final;//OK数
            LastResult = (Result)final;//最后一次结果
            Yield = ((double)Num_OK / Sum * 100).ToString("f1") + "%";//良率
            if (final == 1) return true;
            return false;
        }

        /// <summary>
        /// 开始测量
        /// </summary>
        /// <param name="ho_Image"></param>
        public void MeasureStartDetail(HObject ho_Image)
        {
            int final = 1;
            int result = 1;
            foreach (IDataProcess item in measuringUnits)
            {
                item.MeasureDone = false;
            }
            foreach (IDataProcess item in measuringUnits)
            {
                if (item is BasePosition)
                {
                    (item as TranslationTracking).line.MeasureDone = false;//新加的
                    if (!item.MeasureDone)
                    {
                        result = item.Measure(ho_Image);
                    }
                }
            }
            foreach (IDataProcess item in measuringUnits)
            {
                if (!item.MeasureDone)
                {
                    result = item.Measure(ho_Image);
                }
                if (result == -1)
                {
                    //最后一次结果
                    LastResult = (Result)(-1);
                    return;
                }
                final *= result;
            }
        }

        /// <summary>
        /// 显示结果
        /// </summary>
        /// <param name="window"></param>
        public void DisplayResult(HWindow_Final window)
        {
            for (int i = 0; i < measuringUnits.Count; i++)
            {
                IDataProcess item = (IDataProcess)measuringUnits[i];
                if (item.MeasureDone)
                {
                    if (item is TranslationTracking)
                    {
                        (item as TranslationTracking).line.DisplayResult(window);//新加的
                    }
                    item.DisplayResult(window);//显示简单信息
                }
            }
        }

        /// <summary>
        /// 计数清零
        /// </summary>
        public void ClearCount()
        {
            Num_OK = 0;
            Sum = 0;
            Yield = ((double)Num_OK / Sum * 100).ToString("f1") + "%";//良率
            Display();
        }

        /// <summary>
        /// 清空并新建项目
        /// </summary>
        public void CreateNewMUM()
        {
            Dispose();
            Initialize();
        }



        /// <summary>
        /// 图像处理
        /// </summary>
        /// <param name="ho_Image"></param>
        private void Camera_ImageAcqed(HObject ho_Image)
        {

            if (bisTest)
            {
                measureResult = MeasureStart(ho_Image);//测量
                MeasureFinish(Convert.ToInt32(!measureResult) + 2 * camera.Index, 0);//发结果信号  亮灯
                Thread.Sleep(200);
                camera.displayWin.HobjectToHimage(ho_Image);
                DisplayResult(camera.displayWin);//字符串
                Display();
                MeasureFinish(Convert.ToInt32(!measureResult) + 2 * camera.Index, 1);//发结果信号 灭灯
            }
            else//实时
            {
                camera.displayWin.HobjectToHimage(ho_Image);
            }

        }

        /// <summary>
        /// Label显示
        /// </summary>
        private void Display()
        {
            if (LastResult == Result.OK)
            {
                camera.Label_OK.BackColor = System.Drawing.Color.Green;
                InvokeHelper.Set(camera.Label_OK, "Text", "OK");
            }
            if (LastResult == Result.NG)
            {
                camera.Label_OK.BackColor = System.Drawing.Color.Red;
                InvokeHelper.Set(camera.Label_OK, "Text", "NG");
            }
            if (LastResult == Result.无料)
            {
                camera.Label_OK.BackColor = System.Drawing.Color.White;
                InvokeHelper.Set(camera.Label_OK, "Text", "WT");
            }
            InvokeHelper.Set(camera.Label_Sum, "Text", Sum.ToString());
            InvokeHelper.Set(camera.Label_Num, "Text", Num_OK.ToString());
            InvokeHelper.Set(camera.Label_Yield, "Text", Yield);
        }


        /// <summary>
        /// 测试
        /// </summary>
        public void Grad()
        {
            bisTest = true;
          
            camera.Grad();
        }

        /// <summary>
        /// 实时
        /// </summary>
        /// <param name="live"></param>
        public void Live(bool live)
        {
            bisTest = false;
            if (camera is Daheng)
            {
                (camera as Daheng).ChangeTriggerMode(live);
            }
            if (camera is Dahua)
            {
                (camera as Dahua).ChangeTriggerMode(live);
            }
        }

        /// <summary>
        /// 列出所有测量单元
        /// </summary>
        /// <returns></returns>
        public List<object[]> ListAllUnit()
        {
            List<object[]> Rows = new List<object[]>();
            foreach (var item in measuringUnits)
            {
                Rows.Add((item as MeasuringUnit).GetViewRow());
            }
            return Rows;
        }

        public List<object[]> ListAllData()
        {
            List<object[]> Rows = new List<object[]>();
            foreach (var item in measuringUnits)
            {
                Rows.Add((item as MeasuringUnit).GetResultDetail());
            }
            return Rows;

        }

       

        /// <summary>
        /// 列出所有线
        /// </summary>
        /// <returns></returns>
        public List<MeasuringUnit> ListAllLine()
        {
            List<MeasuringUnit> lines = new List<MeasuringUnit>();
            foreach (MeasuringUnit item in measuringUnits)
            {
                if (item is Line)
                {
                    lines.Add(item);
                }
            }
            return lines;
        }

        /// <summary>
        /// 列出所有线组
        /// </summary>
        /// <returns></returns>
        public List<MeasuringUnit> ListAllLineGroup()
        {
            List<MeasuringUnit> lineGroups = new List<MeasuringUnit>();
            foreach (MeasuringUnit item in measuringUnits)
            {
                if (item is GetSetOfLines)
                {
                    lineGroups.Add(item);
                }
            }
            return lineGroups;
        }

        /// <summary>
        /// 列出所有点
        /// </summary>
        /// <returns></returns>
        public List<MeasuringUnit> ListAllPoint()
        {
            List<MeasuringUnit> points = new List<MeasuringUnit>();
            foreach (MeasuringUnit item in measuringUnits)
            {
                if (item is Circle || item is Point)
                {
                    points.Add(item);
                }
            }
            return points;
        }

        /// <summary>
        /// 列出所有圆
        /// </summary>
        /// <returns></returns>
        public List<MeasuringUnit> ListAllCircle()
        {
            List<MeasuringUnit> circles = new List<MeasuringUnit>();
            foreach (MeasuringUnit item in measuringUnits)
            {
                if (item is Circle)
                {
                    circles.Add(item);
                }
            }
            return circles;
        }

        /// <summary>
        /// 列出所有平移跟踪
        /// </summary>
        /// <returns></returns>
        public List<MeasuringUnit> ListAllTranslation()
        {
            List<MeasuringUnit> translationTransformation = new List<MeasuringUnit>();
            foreach (MeasuringUnit item in measuringUnits)
            {
                if (item is TranslationTracking)
                {
                    translationTransformation.Add(item);
                }
            }
            return translationTransformation;
        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="measuringUnit"></param>
        public void AddMeasuringUnit(object measuringUnit)
        {
            (measuringUnit as MeasuringUnit).iD = maxId++;//分配ID
            measuringUnits.Add(measuringUnit);//加入检测列队
            AddCompleted(this, (measuringUnit as MeasuringUnit).GetViewRow());//发送添加完成事件
        }

        /// <summary>
        /// 删
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string RemoveMeasuringUnit(int id)
        {
            for (int i = measuringUnits.Count - 1; i >= 0; i--)
            {
                if ((measuringUnits[i] as MeasuringUnit).iD == id)
                {
                    measuringUnits.Remove(measuringUnits[i]);
                    return null;
                }
            }
            return "未找到要删除的项目";
        }

        /// <summary>
        /// 获取测量单元列队的名字集合
        /// </summary>
        /// <returns></returns>
        public List<string> GetMeasuringUnitListName()
        {
            List<string> s = new List<string>();
            for (int i = measuringUnits.Count - 1; i >= 0; i--)
            {
                s.Add((measuringUnits[i] as MeasuringUnit).name);
            }
            return s;
        }

        /// <summary>
        /// 改
        /// </summary>
        /// <param name="measuringUnit"></param>
        /// <returns></returns>
        public string ModifyMeasuringUnit(object measuringUnit)
        {
            for (int i = measuringUnits.Count - 1; i >= 0; i--)
            {
                if ((measuringUnits[i] as MeasuringUnit).iD == (measuringUnit as MeasuringUnit).iD)
                {
                    measuringUnits[i] = measuringUnit;
                    ModificationCompleted(this, (measuringUnit as MeasuringUnit).GetViewRow());
                    EventArgs eventArgs = new EventArgs();

                    return null;
                }
            }
            return "未找到该项";
        }

        /// <summary>
        /// 查
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object GetMeasuringUnit(int id)
        {
            for (int i = measuringUnits.Count - 1; i >= 0; i--)
            {
                if ((measuringUnits[i] as MeasuringUnit).iD == id)
                {
                    return measuringUnits[i];
                }
            }
            return null;
        }




        public void Dispose()
        {
            foreach (var item in measuringUnits)
            {
                (item as IDisposable).Dispose();
            }
         
        }

        public void ClearImageAcqed()
        {
            camera.ImageAcqed -= Camera_ImageAcqed;
        }

        public object Clone()
        {
            MeasureManager mUM = new MeasureManager(this);
            return mUM;
        }
    }
}
