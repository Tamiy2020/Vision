using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.DataProcess.ParameterLib;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess
{
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class GetCircleUseMetrology : Circle
    {

        public Metrology parameter = new Metrology();

        [NonSerialized]//不序列化该字段
        HXLDCont contours, cross;

        public GetCircleUseMetrology()
        {
            function = "拟合圆";
        }

        public override int Measure(HObject ho_Image)
        {
            SetCircle(Func_ImageProcessing.getCircle_FromMetrology(ho_Image, parameter, parameter.Circle, out contours, out cross));
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
            ho_Shape = Func_HalconFunction.GenCircle(this);
            window.DispObj(ho_Shape, shapeColor);//显示形状
        }
    }
}
