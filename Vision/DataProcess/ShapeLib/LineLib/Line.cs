using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;

namespace Vision.DataProcess.ShapeLib
{
    /// <summary>
    /// 直线类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class Line : BaseShape
    {
        /// <summary>
        /// 起点x
        /// </summary>
        public HTuple hv_Column1;

        /// <summary>
        /// 起点y
        /// </summary>
        public HTuple hv_Row1;

        /// <summary>
        /// 终点x
        /// </summary>
        public HTuple hv_Column2;

        /// <summary>
        /// 终点y
        /// </summary>
        public HTuple hv_Row2;


        /// <summary>
        /// 直线方程
        /// </summary>
        public AxByC AxByC0 = new AxByC();


        public Line()//默认构造函数
        {
            this.hv_Column1 = 0;
            this.hv_Row1 = 0;
            this.hv_Column2 = 0;
            this.hv_Row2 = 0;
          
        }

        public Line(HTuple hv_Column1, HTuple hv_Row1, HTuple hv_Column2, HTuple hv_Row2)//带参数的构造函数
        {
            this.hv_Column1 = hv_Column1;
            this.hv_Row1 = hv_Row1;
            this.hv_Column2 = hv_Column2;
            this.hv_Row2 = hv_Row2;
          
        }

        /// <summary>
        /// 设置当前直线的位置
        /// </summary>
        /// <param name="line"></param>
        public void SetLine(Line line)
        {
            hv_Column1 = line.hv_Column1;
            hv_Row1 = line.hv_Row1;
            hv_Column2 = line.hv_Column2;
            hv_Row2 = line.hv_Row2;
        }

        /// <summary>
        /// 获取逆变后的实例
        /// </summary>
        /// <returns></returns>
        public override BaseShape GetShapeInvert()
        {
            base.GetShapeInvert();
            GetHomMat2D();
            HOperatorSet.AffineTransPixel(hv_HomMat2DInvert, hv_Row1, hv_Column1, out hv_Row1, out hv_Column1);
            HOperatorSet.AffineTransPixel(hv_HomMat2DInvert, hv_Row2, hv_Column2, out hv_Row2, out hv_Column2);
            return this;
        }

        /// <summary>
        /// 获取还原后的实例
        /// </summary>
        /// <returns></returns>
        public override BaseShape GetShapeReset()
        {
            base.GetShapeReset();
           /* HOperatorSet.AffineTransPixel(hv_HomMat2DTranslate , hv_Row1, hv_Column1, out hv_Row1, out hv_Column1);
            HOperatorSet.AffineTransPixel(hv_HomMat2DTranslate, hv_Row2, hv_Column2, out hv_Row2, out hv_Column2);*/
            return this;
        }

        public override BaseShape GetShapePositioned()//获取定位后的实例
        {
            Line line = new Line(hv_Column1, hv_Row1, hv_Column2, hv_Row2);//要返回的对象
            GetHomMat2D();

            HOperatorSet.AffineTransPoint2d(hv_HomMat2DTranslat_H, line.hv_Row1, line.hv_Column1, out line.hv_Row1, out line.hv_Column1);//水平

            HOperatorSet.AffineTransPoint2d(hv_HomMat2DTranslate_VL, line.hv_Row1, line.hv_Column1, out line.hv_Row1, out line.hv_Column1);//垂直左

            HOperatorSet.AffineTransPoint2d(hv_HomMat2DTranslate_VR, line.hv_Row2, line.hv_Column2, out line.hv_Row2, out line.hv_Column2);//垂直右

            line.AxByC0.GetAxByC(line);
            return line;//返回对象
        }

        public override int Measure(HObject ho_Image)//测量
        {
            base.Measure(ho_Image);
            AxByC0.GetAxByC(this);
            Line line = GetShapePositioned() as Line;
            DP.hv_Column = (line.hv_Column1);
            DP.hv_Row = (line.hv_Row1);
            MeasureDone = true;
            return 1;
        }

        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            try { ho_Shape.Dispose(); } catch (Exception) { }
            ho_Shape = Func_HalconFunction.GenRegionLine(GetShapePositioned() as Line);
            window.DispObj(ho_Shape, shapeColor);//显示形状
            window.DispString(DP.hv_Column, DP.hv_Row, name, "orange");//显示文字
        }

        public override void DisplayResult(HWindow_Final window)//显示简单信息
        {
            try { ho_Shape.Dispose(); } catch (Exception) { }
            ho_Shape = Func_HalconFunction.GenRegionLine(GetShapePositioned() as Line);
            window.DispObj(ho_Shape, shapeColor);//显示形状
        }
    }
}
