using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using Vision.DataProcess.ParameterLib;

namespace Vision.DataProcess.ShapeLib
{
    /// <summary>
    /// 边缘检测提取线
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class GetLineUseMeasure_Pos : Line
    {
        /// <summary>
        /// 参数
        /// </summary>
        public Measure_Pos parameter;

        public GetLineUseMeasure_Pos()//默认构造函数
        {
            this.parameter = new Measure_Pos();
            function = "边缘检测线";
        }

        public GetLineUseMeasure_Pos(Measure_Pos parameter)//带参数的构造函数
        {
            this.parameter = parameter;
            function = "边缘检测线";
        }

        /// <summary>
        /// 设置定位
        /// </summary>
        public override void SetPosition()
        {
            parameter.line.position_Horizontal = position_Horizontal;
            parameter.line.position_Vertical_L = position_Vertical_L;
            parameter.line.position_Vertical_R = position_Vertical_R;
        }

        public override int Measure(HObject ho_Image)//测量
        {
            parameter.line.Measure(ho_Image);//测量
            Point point = Func_ImageProcessing.getPoint(ho_Image, parameter);//求出检测到的点
            SetLine(Func_Mathematics.Line_Point_Length_To_VerticalLine(parameter.line, point, parameter.hv_RoiWidthLen2 / 2));//根据检测长度生成边缘线
            if (DP == null)
                DP = new Point(0, 0);
            DP.hv_Column = (hv_Column1);
            DP.hv_Row = (hv_Row1);
            AxByC0 = AxByC0.GetAxByC(this);//求该线的一半直线方程
            MeasureDone = true;//已测量标志为true
            return 1;

        }

        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            base.DisplayDetail(window);
            parameter.line.DisplayDetail(window);//边缘线显示
        }

        public override void DisplayResult(HWindow_Final window)//显示简单信息
        {
            try { ho_Shape.Dispose(); } catch (Exception) { }
            ho_Shape = Func_HalconFunction.GenRegionLine(this);
            window.DispObj(ho_Shape, shapeColor);//显示形状
        }
    }
}
