using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Data;

namespace Vision.DataProcess.CalculationLib
{
    /// <summary>
    /// Pin距计算类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class PinDistance : BaseCal_Multi
    {
        public PinDistance(double k) : base(k) //构造函数
        {
            function = "Pin距";
        }
       
        public override int Measure(HObject ho_Image)//测量
        {
            base.Measure(ho_Image);//调用父类的测量方法
            int measureresult = 0;
            foreach (var item in calList)
            {
                measureresult += item.Measure(ho_Image);//测量每一项
            }
            if (measureresult < calList.Count)
            {
                MeasureDone = true;//已测量标志为true
                measureResult = Result.NG;
                return 0;
            }
            MeasureDone = true;//已测量标志为true
            measureResult = Result.OK;
            return 1;
        }

        /// <summary>
        /// 创建计算列队
        /// </summary>
        /// <returns></returns>
        public override bool CreateDistanceList()
        {
            if (baseLine != null && lines != null)
            {
                calList.Clear();
                for (int i = 0; i < lines.LineList.Count - 1; i++)
                {
                    calList.Add(new DisLineToLine(kCx, lines.LineList[i], lines.LineList[i + 1]));
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
        public override bool CreateDistanceList(List<BaseCal_Single> calculates)
        {
            if (baseLine != null && lines != null)
            {
                this.calList.Clear();
                for (int i = 0; i < lines.LineList.Count - 1; i++)
                {
                    DisLineToLine disLineToLine = new DisLineToLine(kCx, lines.LineList[i], lines.LineList[i + 1]);
                    if (i < calculates.Count)
                    {
                        disLineToLine.SetData(calculates[i]);
                        disLineToLine.unit1 = lines.LineList[i];
                        disLineToLine.unit2 = lines.LineList[i + 1];
                    }
                    this.calList.Add(disLineToLine);
                }
                return true;
            }
            return false;
        }

        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            base.DisplayDetail(window);
            foreach (var item in calList)
            {
                item.StringHeight = this.StringHeight;
                item.DisplayDetail(window);
            }
        }

        public override void DisplayResult(HWindow_Final window)//显示简单信息
        {
            base.DisplayResult(window);
            foreach (var item in calList)
            {
                item.StringHeight = this.StringHeight;
                item.DisplayResult(window);
            }
        }

        public override object[] GetResultDetail()//返回详细信息
        {
            List<object> list = GetListResult();
            object[] vs = new object[] { name, function, minValue.ToString(), maxValue.ToString(), list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7], list[8], list[9], list[10], list[11], list[12], list[13], list[14], list[15], list[16], list[17], list[18], list[19] };
            return vs;
        }

        private List<object> GetListResult()
        {
            List<object> list = new List<object>();
            foreach (var item in calList)
            {
                list.Add(item.hv_RealDistance.D.ToString("f3"));
            }
            for (int i = calList.Count; i < 20; i++)
            {
                list.Add("");
            }

            return list;
        }

        public override List<DataRow> GetDataTableRows(DataTable dataTable)//返回数据表格
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
    }
}
