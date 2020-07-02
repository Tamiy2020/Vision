using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DataProcess.ShapeLib
{
    /// <summary>
    /// 点类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class Point : BaseShape
    {
        /// <summary>
        /// x
        /// </summary>
        public HTuple hv_Column;

        /// <summary>
        /// y
        /// </summary>
        public HTuple hv_Row;


        public Point()//默认构造函数
        {
            this.hv_Column = 0;
            this.hv_Row = 0;
        }

        public Point(HTuple hv_Column, HTuple hv_Row)//带参数的构造函数
        {
            this.hv_Column = hv_Column;
            this.hv_Row = hv_Row;
        }

        /// <summary>
        /// 设置点
        /// </summary>
        /// <param name="point"></param>
        public void SetPoint(Point point)
        {
            hv_Column = point.hv_Column;
            hv_Row = point.hv_Row;
        }

        public override BaseShape GetShapePositioned()//获取定位后的实例
        {
            if (position_Horizontal != null)
            {
                hv_Column += position_Horizontal.hv_Horizontal;
            }
            if (position_Vertical != null)
            {
                hv_Row += position_Vertical.hv_Vertical;
            }
            return new Point(hv_Column, hv_Row);
        }

        public override int Measure(HObject ho_Image)
        {
            base.Measure(ho_Image);//调用父类的测量方法
            HOperatorSet.GenRegionPoints(out ho_Shape, hv_Row, hv_Column);//创建定位后的形状  
            return 1;
        }
    }
}
