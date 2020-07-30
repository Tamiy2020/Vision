using HalconDotNet;
using System;

namespace Vision.DataProcess.ShapeLib
{
    /// <summary>
    /// 矩形1类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class Rectangle1 : BaseShape
    {
        /// <summary>
        /// x1
        /// </summary>
        public HTuple hv_Column1;

        /// <summary>
        /// y1
        /// </summary>
        public HTuple hv_Row1;

        /// <summary>
        /// x2
        /// </summary>
        public HTuple hv_Column2;

        /// <summary>
        /// y2
        /// </summary>
        public HTuple hv_Row2;

        public Rectangle1()//默认构造函数
        {
            hv_Row1 = 0;
            hv_Column1 = 0;
            hv_Row2 = 0;
            hv_Column2 = 0;
        }

        public Rectangle1(HTuple hv_Row1, HTuple hv_Column1, HTuple hv_Row2, HTuple hv_Column2)//带参数的构造函数
        {
            this.hv_Row1 = hv_Row1;
            this.hv_Column1 = hv_Column1;
            this.hv_Row2 = hv_Row2;
            this.hv_Column2 = hv_Column2;
        }

        public override BaseShape GetShapePositioned()//获取定位后的实例
        {
            if (position_Horizontal != null)
            {
                hv_Column1 += position_Horizontal.hv_Horizontal;
                hv_Column2 += position_Horizontal.hv_Horizontal;
            }
            return new Rectangle1(hv_Row1, hv_Column1, hv_Row2, hv_Column2);
        }

        /// <summary>
        /// 测量
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <returns></returns>
        public override int Measure(HObject ho_Image)
        {
            base.Measure(ho_Image);//调用基类的测量方法
            ho_Shape = Func_HalconFunction.GenRectangle1(GetShapePositioned() as Rectangle1);//创建定位后的形状
            return 1;
        }

    }
}
