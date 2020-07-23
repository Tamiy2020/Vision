using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DataProcess.ShapeLib
{
    /// <summary>
    /// 圆类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class Circle : Point
    {
        /// <summary>
        /// 半径
        /// </summary>
        public HTuple hv_Radius;

        public Circle()//默认构造函数
        {
            hv_Column = 0;
            hv_Row = 0;
            hv_Radius = 0;
            function = "画圆";
            name = "圆";
        }

        public Circle(HTuple hv_Row, HTuple hv_Column, HTuple hv_Radius)//带参数的构造函数
        {
            this.hv_Row = hv_Row;
            this.hv_Column = hv_Column;
            this.hv_Radius = hv_Radius;
            function = "画圆";
            name = "圆";
        }

        /// <summary>
        /// 设置圆
        /// </summary>
        /// <param name="circle"></param>
        public void SetCircle(Circle circle)
        {
            hv_Column = circle.hv_Column;
            hv_Row = circle.hv_Row;
            hv_Radius = circle.hv_Radius;
        }

        /// <summary>
        /// 获取逆变后的实例
        /// </summary>
        /// <returns></returns>
        public override BaseShape GetShapeInvert()
        {
            base.GetShapeInvert();
            HOperatorSet.AffineTransPixel(hv_HomMat2DInvert, hv_Row, hv_Column, out hv_Row, out hv_Column);
            return this;
        }


        /// <summary>
        /// 获取还原后的实例
        /// </summary>
        /// <returns></returns>
        public override BaseShape GetShapeReset()
        {
            base.GetShapeReset();
            HOperatorSet.AffineTransPixel(hv_HomMat2DTranslate, hv_Row, hv_Column, out hv_Row, out hv_Column);
            return this;
        }

        /// <summary>
        /// 获取定位后的实例
        /// </summary>
        /// <returns></returns>
        public override BaseShape GetShapePositioned()
        {
            Circle circle = new Circle(hv_Row, hv_Column, hv_Radius);
            GetHomMat2D();
            HOperatorSet.AffineTransPixel(hv_HomMat2DTranslate, circle.hv_Row, circle.hv_Column, out circle.hv_Row, out circle.hv_Column);
            return circle;
        }

        /// <summary>
        /// 测量
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <returns></returns>
        public override int Measure(HObject ho_Image)
        {
            base.Measure(ho_Image);//调用基类的测量方法
            ho_Shape = Func_HalconFunction.GenCircle(GetShapePositioned() as Circle);
            return 1;
        }

        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            try { ho_Shape.Dispose(); } catch (Exception) { }
            Circle circlePositioned = GetShapePositioned() as Circle;
            ho_Shape = Func_HalconFunction.GenCircle(circlePositioned);
            try
            {
                DP.SetPoint(circlePositioned);

            }
            catch (Exception)
            {
                DP = new Point(circlePositioned.hv_Column, circlePositioned.hv_Row);
            }
            base.DisplayDetail(window);
            HOperatorSet.GenRegionPoints(out HObject ho_Point, hv_Row, hv_Column);
            window.DispObj(ho_Point, "red", "fill");
            ho_Point.Dispose();
            window.DispString(DP.hv_Column - StringHeight, DP.hv_Row, name, "orange");
        }



    }
}
