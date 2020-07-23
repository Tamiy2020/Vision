using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DataProcess.ShapeLib
{  /// <summary>
   /// 矩形2类
   /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class Rectangle2 : BaseShape
    {
        /// <summary>
        /// x
        /// </summary>
        public HTuple hv_Column;

        /// <summary>
        /// y
        /// </summary>
        public HTuple hv_Row;

        /// <summary>
        /// 角度
        /// </summary>
        public HTuple hv_Phi;

        /// <summary>
        /// 长
        /// </summary>
        public HTuple hv_Length1;

        /// <summary>
        /// 宽
        /// </summary>
        public HTuple hv_Length2;

        public Rectangle2()//默认构造函数
        {
            hv_Row = 0;
            hv_Column = 0;
            hv_Phi = 0;
            hv_Length1 = 0;
            hv_Length2 = 0;
        }

        public Rectangle2(HTuple hv_Row, HTuple hv_Column, HTuple hv_Phi, HTuple hv_Length1, HTuple hv_Length2)//带参数的构造函数
        {
            this.hv_Row = hv_Row;
            this.hv_Column = hv_Column;
            this.hv_Phi = hv_Phi;
            this.hv_Length1 = hv_Length1;
            this.hv_Length2 = hv_Length2;
        }

        /// <summary>
        /// 获取逆变后的实例
        /// </summary>
        /// <returns></returns>
        public override BaseShape GetShapeInvert()
        {
            base.GetShapeInvert();
            HOperatorSet.AffineTransPixel(hv_HomMat2DInvert, hv_Row, hv_Column, out hv_Row, out hv_Column);
            HTuple h1, h2, hv_phi, h4, h5, h6;
            HOperatorSet.HomMat2dToAffinePar(hv_HomMat2DInvert, out h1, out h2, out hv_phi, out h4, out h5, out h6);
            hv_Phi += hv_phi;
            return this;
        }

        /// <summary>
        /// 获取还原后的实例
        /// </summary>
        /// <returns></returns>
        public override BaseShape GetShapeReset()
        {
            base.GetShapeReset();
          //  HOperatorSet.AffineTransPixel(hv_HomMat2DTranslate, hv_Row, hv_Column, out hv_Row, out hv_Column);
            HTuple h1, h2, hv_phi, h4, h5, h6;
          //  HOperatorSet.HomMat2dToAffinePar(hv_HomMat2DTranslate, out h1, out h2, out hv_phi, out h4, out h5, out h6);
        //    hv_Phi += hv_phi;
            return this;
        }

        public override BaseShape GetShapePositioned()//获取定位后的实例
        {
            Rectangle2 rectangle2 = new Rectangle2(hv_Row, hv_Column, hv_Phi, hv_Length1, hv_Length2);//要返回的对象
            GetHomMat2D();
           // HOperatorSet.AffineTransPixel(hv_HomMat2DTranslate, rectangle2.hv_Row, rectangle2.hv_Column, out rectangle2.hv_Row, out rectangle2.hv_Column);
            HTuple h1, h2, hv_phi, h4, h5, h6;
           // HOperatorSet.HomMat2dToAffinePar(hv_HomMat2DTranslate, out h1, out h2, out hv_phi, out h4, out h5, out h6);
           // rectangle2.hv_Phi += hv_phi;
            return rectangle2;
        }

        public override int Measure(HObject ho_Image)
        {
            base.Measure(ho_Image);//调用基类的测量方法
            ho_Shape = Func_HalconFunction.GenRectangle2(GetShapePositioned() as Rectangle2);//创建定位后的形状
            return 1;
        }

    }
}
