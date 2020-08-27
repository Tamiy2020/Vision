using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.DataProcess.ParameterLib;

namespace Vision.DataProcess.ShapeLib
{
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class GetLineUseMetrology : Line
    {
        public Metrology parameter = new Metrology();

        [NonSerialized]//不序列化该字段
        HXLDCont contours, cross;

        public GetLineUseMetrology()
        {
            function = "直线拟合";
        }

        public override int Measure(HObject ho_Image)
        {
            SetLine(Func_ImageProcessing.getLine_FromMetrology(ho_Image, parameter, parameter.Line, out contours, out cross));
            if (DP == null) DP = new Point(0, 0);
            DP.hv_Column = hv_Column1;
            DP.hv_Row = hv_Row1;
            AxByC0 = AxByC0.GetAxByC(this);//求该线的一半直线方程
            MeasureDone = true;//已测量标志为true
            return 1;
        }

        public override void DisplayDetail(HWindow_Final window)
        {
            window.DispObj(contours, "green");
            window.DispObj(cross, "red");
            contours.Dispose();
            cross.Dispose();
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
