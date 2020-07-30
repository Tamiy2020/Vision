using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using Vision.DataProcess.ParameterLib;

namespace Vision.DataProcess.ShapeLib
{
    /// <summary>
    /// 边缘拟合线
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class GetLineUseCanny : Line
    {
        /// <summary>
        /// 参数
        /// </summary>
        public Canny parameter;

        /// <summary>
        /// 选择的区域(用来显示)
        /// </summary>
        [NonSerialized]//不序列化该字段
        private HObject ho_SelectedRegions;

        public GetLineUseCanny()//构造函数
        {
            parameter = new Canny();
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            function = "边缘拟合线";
        }

        public GetLineUseCanny(Canny parameter)//带参数的构造函数
        {
            this.parameter = parameter;
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            function = "边缘拟合线";
        }

        /// <summary>
        /// 获取逆变后的实例
        /// </summary>
        /// <returns></returns>
        public override BaseShape GetShapeInvert()
        {
            base.GetShapeInvert();
            parameter.rectangle2.GetHomMat2D();
            parameter.rectangle2.GetShapeInvert();
            return this;
        }

        /// <summary>
        /// 获取还原后的实例
        /// </summary>
        /// <returns></returns>
        public override BaseShape GetShapeReset()
        {
            base.GetShapeReset();
            parameter.rectangle2.GetShapeReset();
            return this;
        }

        /// <summary>
        /// 设置定位
        /// </summary>
        public override void SetPosition()
        {
            parameter.rectangle2.position_Horizontal = position_Horizontal;
            parameter.rectangle2.position_Vertical_L = position_Vertical_L;
            parameter.rectangle2.position_Vertical_R = position_Vertical_R;
        }

        /// <summary>
        /// 测量
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <returns></returns>
        public override int Measure(HObject ho_Image)
        {
            //边缘提取拟合成线
            SetLine(Func_ImageProcessing.getLine_FromCanny(ho_Image, parameter, parameter.rectangle2.GetShapePositioned() as Rectangle2));
            if (DP == null) DP = new Point(0, 0);
            DP.hv_Column = hv_Column1;
            DP.hv_Row = hv_Row1;
            AxByC0 = AxByC0.GetAxByC(this);//求该线的一半直线方程
            MeasureDone = true;//已测量标志为true
            return 1;
        }

        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            HObject ho_Rectangle = Func_HalconFunction.GenRectangle2(parameter.rectangle2.GetShapePositioned() as Rectangle2);
            window.DispObj(ho_Rectangle, "blue", "margin");
            ho_Rectangle.Dispose();
            base.DisplayDetail(window);
        }

        public override void DisplayResult(HWindow_Final window)
        {
            try { ho_Shape.Dispose(); } catch (Exception) { }
            ho_Shape = Func_HalconFunction.GenRegionLine(this);
            window.DispObj(ho_Shape, shapeColor);//显示形状
        }
    }
}
