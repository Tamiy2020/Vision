using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.DataProcess.ShapeLib;

namespace Vision.DataProcess.PositionLib
{
    /// <summary>
    /// 平移跟踪类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public  class TranslationTracking: BasePosition
    {
        /// <summary>
        /// 旧线
        /// </summary>
        public Line oldLline;

        /// <summary>
        /// 移动后的线
        /// </summary>
        public Line line;

        public TranslationTracking()//构造函数
        {
            oldLline = new Line();
        }
        public override int Measure(HObject ho_Image)
        {
            HOperatorSet.HomMat2dIdentity(out HTuple hv_HomMat2D);//创建单位矩阵
            if (!line.MeasureDone)//？线还未进行测量
                line.Measure(ho_Image);//执行测量
            if (line.AxByC0.k == null)//？是垂直线
            {
                hv_Horizontal = line.hv_Column1 - oldLline.hv_Column1;//求水平位移量
                HOperatorSet.HomMat2dTranslate(hv_HomMat2D, 0, hv_Horizontal, out hv_HomMat2DTranslate);//求变换矩阵
            }
            else if (line.AxByC0.k.D == 0)//？是水平线
            {
                hv_Vertical = line.hv_Row1 - oldLline.hv_Row1;//求垂直位移量
                HOperatorSet.HomMat2dTranslate(hv_HomMat2D, hv_Vertical, 0, out hv_HomMat2DTranslate);//求变换矩阵
            }
            //求逆变矩阵
            HOperatorSet.HomMat2dInvert(hv_HomMat2DTranslate, out hv_HomMat2DInvert);
            MeasureDone = true;//已测量标志为true
            return 1;
        }

        public override void DisplayDetail(HWindow_Final window) { }
        

        public override void DisplayResult(HWindow_Final window) { }
       

        public override void Dispose() { }
       
    }
}
