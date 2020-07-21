using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DataProcess.CalculationLib
{
    /// <summary>
    /// 弹高/平面度计算类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public  class MultipleDistance:BaseCal_Multi
    {
        public MultipleDistance(double k) : base(k) //构造函数
        {
            function = "多边测距";
        }

        public override int Measure(HObject ho_Image)//测量
        {
            base.Measure(ho_Image);//调用父类的测量方法
            int measureresult = 1;
            foreach (var item in calList)
            {
                measureresult *= item.Measure(ho_Image);//每一项执行测量
            }
            MeasureDone = true;//已测量标志为true
            return measureresult;
        }

        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            base.DisplayDetail(window);
            if (baseLine != null)
                baseLine.DisplayDetail(window);//显示基准线详细信息
            if (lines != null)
                lines.DisplayDetail(window);//显示线组详细信息
            foreach (var item in calList)
            {
                item.StringHeight = this.StringHeight;//设置字符间距
                item.DisplayDetail(window);//显示线线测量详细信息
            }
        }

        public override void DisplayResult(HWindow_Final window)//显示简单信息
        {
            base.DisplayResult(window);
            foreach (var item in calList)
            {
                item.StringHeight = this.StringHeight;
                item.DisplayResult(window);//显示线线测量详细信息
            }
        }

        /// <summary>
        /// 创建计算列队
        /// </summary>
        /// <returns></returns>
        public override bool CreateDistanceList()
        {
            if (baseLine == null)
            {
                return false;
            }
            if (lines != null)
            {
                calList.Clear();
                foreach (var item in lines.LineList)
                {
                    calList.Add(new DisLineToLine(kCx, baseLine, item));
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 创建计算列队
        /// </summary>
        /// <param name="calculates"></param>
        /// <returns></returns>
        public override bool CreateDistanceList(List<BaseCal_Single> calList)
        {
            if (baseLine == null)
            {
                return false;
            }
            if (lines != null)
            {
                this.calList.Clear();
                for (int i = 0; i < lines.LineList.Count; i++)
                {
                    DisLineToLine disLineToLine = new DisLineToLine(kCx, baseLine, lines.LineList[i]);
                    if (i < calList.Count)
                    {
                        this.calList[i].SetData(calList[i]);
                        disLineToLine.unit1 = baseLine;
                        disLineToLine.unit2 = lines.LineList[i];
                    }
                    this.calList.Add(disLineToLine);
                }
                return true;
            }
            return false;
        }

        public override object[] GetResultDetail()//返回详细信息
        {
            object[] vs = new object[]{ name, function, minValue.ToString(), maxValue.ToString(), GetListResult()};
            return vs;
        }

        private List<object> GetListResult()
        {
            List<object> list = new List<object>();
            foreach (var item in calList)
            {
                list.Add(item.hv_RealDistance.D.ToString("f3"));
            }
            return list;
        }


        /// <summary>
        /// 返回数据表格
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public override List<DataRow> GetDataTableRows(DataTable dataTable)
        {
            List<DataRow> dataRows = new List<DataRow>();
            foreach (var item in calList)
            {
                List<DataRow> dataRows1 = item.GetDataTableRows(dataTable);
                dataRows1[0]["名称"] = name + "-" + item.name;
                dataRows1[0]["功能"] = function;
                dataRows.AddRange(dataRows1);
            }
            return dataRows;
        }


        /// <summary>
        /// 释放资源
        /// </summary>
        public override void Dispose()
        {
            foreach (var item in calList)
            {
                item.Dispose();
            }
            calList.Clear();
        }

    }
}
