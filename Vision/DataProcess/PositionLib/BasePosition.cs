using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DataProcess.PositionLib
{
    /// <summary>
    /// 定位类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public abstract class BasePosition : MeasuringUnit //所有跟踪定位的基类
    {
        /// <summary>
        /// 水平位移量
        /// </summary>
        public HTuple hv_Horizontal;

        /// <summary>
        /// 垂直位移量
        /// </summary>
        public HTuple hv_Vertical;


        /// <summary>
        /// 变换矩阵
        /// </summary>
        public HTuple hv_HomMat2DTranslate;

        /// <summary>
        /// 逆变矩阵
        /// </summary>
        public HTuple hv_HomMat2DInvert;


        public BasePosition()//构造函数
        {
            hv_Horizontal = 0;
            hv_Vertical = 0;
        }

    }
}
