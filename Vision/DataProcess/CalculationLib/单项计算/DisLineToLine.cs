using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess.CalculationLib
{
    /// <summary>
    /// 线到线的距离计算
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class DisLineToLine : BaseCal_Single
    {
        public DisLineToLine(double k, Line baseLine, Line line) : base(k)//构造函数
        {
            this.unit1 = baseLine;
            this.unit2 = line;
            function = "线线距离";
            DP.hv_Column = line.hv_Column1;//设置数据显示点横坐标
            DP.hv_Row = line.hv_Row1;//设置数据显示点纵坐标
        }

        public override int Measure(HObject ho_Image)//测量
        {
            base.Measure(ho_Image);//调用父类的测量方法
            Line line2 = unit2 as Line;//获取线2
            Line line1 = (unit1 as BaseShape).GetShapePositioned() as Line;
            if (!line2.AxByC0.IsLine)
            {
                pStart = new Point(9999, 9999);//设置测量起点
            }
            else
            {
                pStart = new Point((line2.hv_Column1 + line2.hv_Column2) / 2, (line2.hv_Row1 + line2.hv_Row2) / 2);//将线2的中点作为测量起点
            }


            if (unit1 is GetLineUseCanny || unit1 is GetLineUseMeasure_Pos || unit1 is GetLineUseThreshold)
                line1 = unit1 as Line;
            line1.AxByC0.GetAxByC(line1);
            if (!line1.AxByC0.IsLine)//line1是否为线
            {//不是
                pEnd = new Point(line1.hv_Column1, line1.hv_Row1);//设置测量终点
            }
            else
            {//是
                Line _line2 = Func_Mathematics.LineVerticalLine(line1, pStart);//求已知直线过已知点的垂线
                pEnd = Func_Mathematics.TwoLineIntersection(line1, _line2);//两条直线交点作为测量终点
            }
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
            dataRows[0]["功能"] = "线线距离";
            return dataRows;
        }
    }
}
