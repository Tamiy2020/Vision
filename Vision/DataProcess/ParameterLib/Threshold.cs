using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess.ParameterLib
{
    /// <summary>
    /// 灰度提取参数
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class Threshold
    {
        /// <summary>
        /// ROI矩形
        /// </summary>
        public Rectangle2 rectangle2 = null;

        /// <summary>
        /// 最小灰度
        /// </summary>
        public HTuple hv_MinGray=0;

        /// <summary>
        /// 最大灰度
        /// </summary>
        public HTuple hv_MaxGray=255;


        public Threshold()//默认构造函数
        {
            this.rectangle2 = new Rectangle2();
        }

        public Threshold(Rectangle2 rectangle2)//带参数的构造函数
        {
            this.rectangle2 = rectangle2;
        }
    }
}
