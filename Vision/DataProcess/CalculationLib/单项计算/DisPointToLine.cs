using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess.CalculationLib
{
    /// <summary>
    /// 点到线的距离计算
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class DisPointToLine : BaseCal_Single
    {
        public DisPointToLine(double k, Point point, Line line) : base(k)//构造函数
        {
            this.unit1 = point;
            this.unit2 = line;
            function = "点线距离";
            DP.hv_Column = line.hv_Column1;//设置数据显示点横坐标
            DP.hv_Row = line.hv_Row1;//设置数据显示点纵坐标
        }

        public override int Measure(HObject ho_Image)
        {
            base.Measure(ho_Image);//调用父类的测量方法
            pStart = (Point)(unit1 as Point).GetShapePositioned();//获取测量起点
            if (!(unit2 as Line).AxByC0.IsLine)//unit2是否为线
            {//不是
                pEnd = new Point((unit2 as Line).hv_Column1, (unit2 as Line).hv_Row1);//设置测量终点
            }
            else
            {//是
                Line _line2 = Func_Mathematics.LineVerticalLine(unit2 as Line, pStart);//求已知直线过已知点的垂线
                pEnd = Func_Mathematics.TwoLineIntersection(unit2 as Line, _line2);//两条直线交点作为测量终点
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
            dataRows[0]["功能"] = "点线距离";
            return dataRows;
        }
    }
}
