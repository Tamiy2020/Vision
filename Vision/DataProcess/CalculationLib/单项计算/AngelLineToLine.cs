using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess.CalculationLib
{
    /// <summary>
    /// 线线之间的角度计算
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public  class AngelLineToLine: BaseCal_Single
    {
        /// <summary>
        /// 总是锐角
        /// </summary>
        public bool AlwaysMinAngel { get; set; } = true;

        public AngelLineToLine(double k, Line baseLine, Line line) : base(k)//构造函数
        {
            this.unit1 = baseLine;
            this.unit2 = line;
            function = "角度计算";
            DP.hv_Column = line.hv_Column1;//设置数据显示点横坐标
            DP.hv_Row = line.hv_Row1;//设置数据显示点纵坐标
        }

        public override int Measure(HObject ho_Image)//测量
        {
            base.Measure(ho_Image);//调用父类的测量方法
            Line line1 = (unit1 as Line);
            Line line2 = (unit2 as Line);
            HOperatorSet.AngleLl(line1.hv_Row1, line1.hv_Column1, line1.hv_Row2, line1.hv_Column2,
                line2.hv_Row1, line2.hv_Column1, line2.hv_Row2, line2.hv_Column2, out hv_RealDistance);
            hv_RealDistance = hv_RealDistance.TupleDeg().TupleAbs();
            if (AlwaysMinAngel)
                if (hv_RealDistance.D > 90)
                    hv_RealDistance = 180 - hv_RealDistance;
            ComparingResults();
            Point cLine1 = new Point((line1.hv_Column1 + line1.hv_Column2) / 2, (line1.hv_Row1 + line1.hv_Row2) / 2);
            Point cLine2 = new Point((line2.hv_Column1 + line2.hv_Column2) / 2, (line2.hv_Row1 + line2.hv_Row2) / 2);
            DP.hv_Column = (cLine1.hv_Column + cLine2.hv_Column) / 2;
            DP.hv_Row = (cLine1.hv_Row + cLine1.hv_Row) / 2;
            MeasureDone = true;
            return Convert.ToInt32(measureResult);
        }

        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            unit1.DisplayDetail(window);
            unit2.DisplayDetail(window);
            window.DispString(DP.hv_Column, DP.hv_Row, name, color);
            window.DispString(DP.hv_Column, DP.hv_Row - StringHeight, ((double)hv_RealDistance).ToString("f1") + "°", color);//显示字符
        }

        public override void DisplayResult(HWindow_Final window)//显示简单信息
        {
            window.DispString(DP.hv_Column, DP.hv_Row - StringHeight, ((double)hv_RealDistance).ToString("f1") + "°", color);//显示字符
        }

        public override List<DataRow> GetDataTableRows(DataTable dataTable)//返回数据表格
        {
            List<DataRow> dataRows = base.GetDataTableRows(dataTable);
            dataRows[0]["功能"] = "角度计算";
            return dataRows;
        }

    }
}
