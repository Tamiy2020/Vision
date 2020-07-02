using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess
{
    /// <summary>
    /// 测量单元
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public abstract class MeasuringUnit : IDataProcess, IDisposable
    {
        /// <summary>
        /// 名字
        /// </summary>
        protected internal string name = "";

        /// <summary>
        /// 唯一标识
        /// </summary>
        protected internal int iD = 1;

        /// <summary>
        /// OK/NG
        /// </summary>
        protected Result measureResult;

        /// <summary>
        /// 单元窗体类型
        /// </summary>
        protected internal Type formType;

        /// <summary>
        /// OK/NG显示颜色
        /// </summary>
        protected string color;

        /// <summary>
        /// 文字显示位置
        /// </summary>
        protected Point DP;

        private int _stringHeight = 100;
        /// <summary>
        /// 打印字符间距
        /// </summary>
        public int StringHeight { get { return _stringHeight; } set { if (value >= -1500 && value <= 1500) _stringHeight = value; } }

        /// <summary>
        /// 测量完成
        /// </summary>
        public bool MeasureDone { get; set; }


        /// <summary>
        /// 返回列表显示信息
        /// </summary>
        public object[] GetViewRow()
        {
            return new object[] { (iD).ToString(), name };
        }


        /// <summary>
        /// 获取当前实例的一个克隆副本
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            BinaryFormatter bf = new BinaryFormatter();//创建序列化器
            MemoryStream ms = new MemoryStream();//创建流
            bf.Serialize(ms, this);//序列化
            ms.Seek(0, SeekOrigin.Begin);
            return bf.Deserialize(ms);//反序列化
        }


        /// <summary>
        /// 按照传来的对象赋值所有字段值
        /// </summary>
        /// <param name="data"></param>
        public virtual void SetData(MeasuringUnit data)
        {
            FieldInfo[] fields = data.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var item in fields)
            {
                Type type = this.GetType();
                FieldInfo fieldInfo = type.GetField(item.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                Type type2 = data.GetType();
                FieldInfo fieldInfo2 = type2.GetField(item.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                object value = fieldInfo2.GetValue(data);
                fieldInfo.SetValue(this, value);
            }
        }



        /// <summary>
        /// 测量
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <returns></returns>
        public virtual int Measure(HObject ho_Image)
        {
            if (DP == null) DP = new Point(0, 0);
            return 1;
        }




        public abstract void DisplayDetail(HWindow_Final window);//显示详细信息


        public abstract void DisplayResult(HWindow_Final window);//显示简单信息



        public virtual string GetResultDetail()//返回详细信息字符串
        {
            return null;
        }


        public List<DataRow> GetDataTableRows(DataTable dataTable)//返回表格数据
        {
            return null;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public abstract void Dispose();

    }
}
