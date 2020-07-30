using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess.CalculationLib
{
    /// <summary>
    /// 点到点的距离
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class DisPointToPoint : BaseCal_Single
    {
        public DisPointToPoint(double k, Point point1, Point point2) : base(k)//构造函数
        {
            this.unit1 = point1;
            this.unit2 = point2;
            function = "点点距离";
            DP = point1;//设置数据显示点
        }

        public override int Measure(HObject ho_Image)//测量
        {
            base.Measure(ho_Image);//调用父类的测量方法
            pStart = (Point)(unit1 as Point).GetShapePositioned();//将点1作为测量起点
            pEnd = (Point)(unit2 as Point).GetShapePositioned();//将点2作为测量终点
            hv_PxDistance = Func_Mathematics.P1_P2_To_Distance(pStart.hv_Column, pStart.hv_Row, pEnd.hv_Column, pEnd.hv_Row);//计算两点距离
            hv_RealDistance = hv_PxDistance * kCx;//计算实际距离
            ComparingResults();//比较结果
            DP.hv_Column = (pStart.hv_Column + pEnd.hv_Column) / 2;//设置数据显示点横坐标
            DP.hv_Row = (pStart.hv_Row + pEnd.hv_Row) / 2;//设置数据显示点纵坐标
            MeasureDone = true;//已测量标志为true
            return Convert.ToInt32(measureResult);
        }

        /// <summary>
        /// 返回数据表格
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public override List<DataRow> GetDataTableRows(DataTable dataTable)
        {
            List<DataRow> dataRows = base.GetDataTableRows(dataTable);
            dataRows[0]["功能"] = "点点距离";
            return dataRows;
        }
    }
}
