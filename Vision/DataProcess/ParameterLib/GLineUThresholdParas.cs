using HalconDotNet;
using System;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess.ParameterLib
{
    /// <summary>
    /// 灰度抓取线参数类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class GLineUThresholdParas
    {
        /// <summary>
        /// ROI矩形
        /// </summary>
        public Rectangle1 Rectangle1;

        /// <summary>
        /// 定位偏移量
        /// </summary>
        public Point deltaPoint;

        /// <summary>
        /// 最小灰度
        /// </summary>
        public HTuple hv_MinGray;

        /// <summary>
        /// 最大灰度
        /// </summary>
        public HTuple hv_MaxGray;

        /// <summary>
        /// 上下左右1234
        /// </summary>
        public HTuple TDLR;

        /// <summary>
        /// 补偿值
        /// </summary>
        public HTuple b;

        /// <summary>
        /// 是否启用角点
        /// </summary>
        public bool AngularPoint;

        public GLineUThresholdParas()
        {
            //初始化字段默认值
            Rectangle1 = new Rectangle1();
            deltaPoint = new Point(0, 0);
            hv_MinGray = 0;
            hv_MaxGray = 255;
            TDLR = 1;
            b = 0;
            AngularPoint = false;
        }
    }
}
