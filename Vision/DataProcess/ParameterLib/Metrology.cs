using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess.ParameterLib
{
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class Metrology
    {
        /// <summary>
        /// 线
        /// </summary>
        public Line Line;

        public Circle Circle;

        /// <summary>
        /// 宽度
        /// </summary>
        public HTuple measureLength1;

        /// <summary>
        /// 高度
        /// </summary>
        public HTuple measureLength2;

        /// <summary>
        /// 间隔
        /// </summary>
        public HTuple measureDistance;

        /// <summary>
        /// 阈值
        /// </summary>
        public HTuple measureThreshold;

        /// <summary>
        /// 点筛选
        /// </summary>
        public HTuple measureSelect;

        /// <summary>
        /// 颜色模式
        /// </summary>
        public HTuple measureTransition;

        public Metrology()
        {
            Line = new Line();
            Circle = new Circle();
            measureLength1 = 20;
            measureLength2 = 5;
            measureDistance = 10;
            measureThreshold = 30;
            measureSelect = "first";
            measureTransition =  "positive";
        }
    }
}
