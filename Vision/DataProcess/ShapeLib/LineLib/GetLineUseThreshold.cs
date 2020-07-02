using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.DataProcess.ParameterLib;

namespace Vision.DataProcess.ShapeLib
{
    /// <summary>
    /// 灰度抓取线
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class GetLineUseThreshold: Line
    {
        /// <summary>
        /// 参数
        /// </summary>
        public Threshold parameter;

        /// <summary>
        /// 上下左右
        /// </summary>
        public HTuple TPLR;

        /// <summary>
        /// 补偿值
        /// </summary>
        public HTuple b;

        /// <summary>
        /// 是否启用角点
        /// </summary>
        public bool AngularPoint;

        /// <summary>
        /// 📕ROI区域(用来显示)
        /// </summary>
        [NonSerialized]//不序列化该字段
        private HObject ho_ROI;

        /// <summary>
        /// //📕选择的区域(用来显示)
        /// </summary>
        [NonSerialized]//不序列化该字段
        private HObject ho_SelectedRegions;

        public GetLineUseThreshold()//默认构造函数
        {
            //初始化字段默认值
            parameter = new Threshold();
            TPLR = 1;
            b = 0;
            HOperatorSet.GenEmptyObj(out ho_ROI);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
        }

        public GetLineUseThreshold(Threshold parameter)//带参数的构造函数
        {
            this.parameter = parameter;
            TPLR = 1;
            b = 0;
            HOperatorSet.GenEmptyObj(out ho_ROI);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
        }


        /// <summary>
        /// 获取逆变后的实例
        /// </summary>
        /// <returns></returns>
        public override BaseShape GetShapeInvert()
        {
            base.GetShapeInvert();
            parameter.rectangle2.GetHomMat2D();
            parameter.rectangle2.GetShapeInvert();
            return this;
        }

        /// <summary>
        /// 获取还原后的实例
        /// </summary>
        /// <returns></returns>
        public override BaseShape GetShapeReset()
        {
            base.GetShapeReset();
            parameter.rectangle2.GetShapeReset();
            return this;
        }

        /// <summary>
        /// 设置定位
        /// </summary>
        public override void SetPosition()
        {
            parameter.rectangle2.position_Horizontal = position_Horizontal;
            parameter.rectangle2.position_Vertical = position_Vertical;
        }


        public override int Measure(HObject ho_Image)//测量
        {
            measureResult = Result.OK;//测量结果初始OK
            try { ho_ROI.Dispose(); } catch (Exception) { }//释放ho_ROI资源
            Rectangle2 ROI = parameter.rectangle2.GetShapePositioned() as Rectangle2;//获取ROI矩形
            ho_ROI = Func_HalconFunction.GenRectangle2(ROI);//创建ROI
            //灰度处理,并选出最大面积
            try { ho_SelectedRegions.Dispose(); } catch (Exception) { }//释放ho_SelectedRegions资源
            ho_SelectedRegions = Func_ImageProcessing.Threshold_SelectMaxRegion(ho_Image, ho_ROI, parameter.hv_MinGray, parameter.hv_MaxGray);
            if (ROI.hv_Phi.D != 0)//角度不为零?
            {
               //hv_HomMat2D;//变换矩阵
                HOperatorSet.VectorAngleToRigid(ROI.hv_Row, ROI.hv_Column, 0, ROI.hv_Row, ROI.hv_Column, -ROI.hv_Phi, out HTuple hv_HomMat2D);//将区域旋转为水平的变换矩阵
               // ho_RegionRotate;//水平后的Region
                HOperatorSet.AffineTransRegion(ho_SelectedRegions, out HObject ho_RegionRotate, hv_HomMat2D, "nearest_neighbor");//应用变换
                SetLine(Func_ImageProcessing.getLine_FromRegion(ho_RegionRotate, TPLR, b, AngularPoint));//从区域获取线
                HOperatorSet.VectorAngleToRigid(ROI.hv_Row, ROI.hv_Column, 0, ROI.hv_Row, ROI.hv_Column, ROI.hv_Phi, out hv_HomMat2D);//将线从水平变回原角度的变换矩阵
                HOperatorSet.AffineTransPixel(hv_HomMat2D, hv_Row1, hv_Column1, out hv_Row1, out hv_Column1);//应用变换
                HOperatorSet.AffineTransPixel(hv_HomMat2D, hv_Row2, hv_Column2, out hv_Row2, out hv_Column2);//应用变换
            }
            else
            {
                SetLine(Func_ImageProcessing.getLine_FromRegion(ho_SelectedRegions, TPLR, b, AngularPoint));//从区域获取线
            }
            if (DP == null) DP = new Point(0, 0);
            DP.hv_Column = (hv_Column1);
            DP.hv_Row = (hv_Row1);
            AxByC0 = AxByC0.GetAxByC(this);//求该线的一半直线方程
            MeasureDone = true;//已测量标志为true
            return Convert.ToInt32(measureResult);
        }

        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            window.DispObj(ho_ROI, "blue", "margin");
            window.DispObj(ho_SelectedRegions, "green", "fill");
            HObject ho_Line = Func_HalconFunction.GenRegionLine(this);
            window.DispObj(ho_Line, "red", "fill");
            ho_Line.Dispose();
            window.DispString(DP.hv_Column, DP.hv_Row, name, "orange");//显示文字
        }

        public override void DisplayResult(HWindow_Final window)//显示简单信息
        {
            try { ho_Shape.Dispose(); } catch (Exception) { }
            ho_Shape = Func_HalconFunction.GenRegionLine(this);
            window.DispObj(ho_Shape, shapeColor);//显示形状
        }

        public override void Dispose()//释放资源
        {
            base.Dispose();
            try { ho_ROI.Dispose(); } catch (Exception) { }
            try { ho_SelectedRegions.Dispose(); } catch (Exception) { }
        }



    }
}
