using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess.CalculationLib
{
    /// <summary>
    /// 高低落差计算类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class DropDistance : BaseCal_Multi
    {
        /// <summary>
        /// 顶部线
        /// </summary>
        BaseCal_Single topLine;

        /// <summary>
        /// 底部线
        /// </summary>
        BaseCal_Single bottomLine;

        public DropDistance(double k) : base(k) //构造函数
        {
            function = "高低落差";
        }

        public override int Measure(HObject ho_Image)//测量
        {
            base.Measure(ho_Image);//调用父类的测量方法
            if (calList.Count == 0)
            {
                return -100;
            }
            calList[0].Measure(ho_Image);//测量组0执行测量
            topLine = calList[0];//顶部线赋值
            bottomLine = calList[0];//底部线赋值
            for (int i = 1; i < calList.Count; i++)
            {
                calList[i].Measure(ho_Image);//测量组i执行测量
                if (calList[i].hv_RealDistance.D < bottomLine.hv_RealDistance.D)//比底部线还低
                    bottomLine = calList[i];//底部线赋值
                if (calList[i].hv_RealDistance.D > topLine.hv_RealDistance.D)//比顶部线还高
                    topLine = calList[i];//顶部线赋值
            }
            hv_RealDistance = topLine.hv_RealDistance - bottomLine.hv_RealDistance;//计算实际距离
            DP.hv_Column = (calList[0].unit2 as Line).hv_Column1;//设置数据显示点横坐标
            DP.hv_Row = (calList[0].unit2 as Line).hv_Row1 - 200;//设置数据显示点纵坐标
            ComparingResults();//比较得出结果
            MeasureDone = true;//已测量标志为true
            return Convert.ToInt32(measureResult);
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
        /// <param name="calList"></param>
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

        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            base.DisplayDetail(window);//调用基类的显示详细信息方法
            if (lines != null)//？线组不为空
                lines.DisplayDetail(window);//显示线组详细信息
            window.DispString(DP.hv_Column, DP.hv_Row + StringHeight, ((double)hv_RealDistance).ToString("f3"), color);//显示结果
        }

        public override void DisplayResult(HWindow_Final window)//显示简单信息
        {
            base.DisplayResult(window);//调用基类的显示简单信息方法
            window.DispString(DP.hv_Column, DP.hv_Row + StringHeight, ((double)hv_RealDistance).ToString("f3"), color);//显示结果
        }

        public override object[] GetResultDetail()//返回详细信息
        {
            return new object[] { name,function, minValue.ToString(), maxValue.ToString(), hv_RealDistance.D.ToString("f3") };
        }

        public override List<DataRow> GetDataTableRows(DataTable dataTable)//返回表格数据
        {
            List<DataRow> dataRows = new List<DataRow>();
            string result = "OK";
            if (measureResult == Result.NG) result = "NG";
            DataRow dataRow = dataTable.NewRow();
            dataRow["名称"] = name;
            dataRow["功能"] = function;
            dataRow["下限"] = minValue;
            dataRow["上限"] = maxValue;
            dataRow["测量值"] = hv_RealDistance.D;
            dataRow["结果"] = result;
            dataRow["时间"] = DateTime.Now;
            dataRows.Add(dataRow);
            return dataRows;
        }
    }

}
