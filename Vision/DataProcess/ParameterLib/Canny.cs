using HalconDotNet;
using System;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess.ParameterLib
{
    /// <summary>
    /// 边缘拟合参数类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class Canny
    {
        /// <summary>
        /// ROI矩形
        /// </summary>
        public Rectangle2 rectangle2;

        /// <summary>
        /// Alpha
        /// </summary>
        public HTuple hv_Alpha;

        /// <summary>
        /// Low
        /// </summary>
        public HTuple hv_Low;

        /// <summary>
        /// High
        /// </summary>
        public HTuple hv_High;

        public Canny()//构造函数
        {
            rectangle2 = new Rectangle2();
            hv_Alpha = 1.1;
            hv_Low = 30;
            hv_High = 70;
        }
    }
}
