using HalconDotNet;
using System;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess.ParameterLib
{
    /// <summary>
    /// 边缘检测参数类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class Measure_Pos
    {
        /// <summary>
        /// 最小边缘幅度0-255        默认40
        /// </summary>
        public HTuple hv_AmplitudeThreshold;

        /// <summary>
        /// ROI宽0-127          默认5
        /// </summary>
        public HTuple hv_RoiWidthLen2;

        /// <summary>
        /// 平滑  (4-320)÷10     默认10÷10=>1
        /// </summary>
        public HTuple hv_Sigma;

        /// <summary>
        /// ROI线
        /// </summary>
        public Line line=null;

        /// <summary>
        /// 'positive'或'negative'
        /// </summary>
        public HTuple hv_Transition;


        public Measure_Pos()//默认构造函数
        {
            this.line = new Line();
            Inilisalize();
        }

        public Measure_Pos(Line line)//带参数的构造函数
        {
            this.line = line;
            Inilisalize();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Inilisalize()
        {
            line.shapeColor = "red";
            hv_AmplitudeThreshold = 40;
            hv_RoiWidthLen2 = 5;
            hv_Sigma = 4;
            hv_Transition = "positive";
        }
    }
}
