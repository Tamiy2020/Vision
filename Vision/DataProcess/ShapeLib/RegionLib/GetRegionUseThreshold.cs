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
    /// 通过灰度检测区域
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class GetRegionUseThreshold : Region
    {
        /// <summary>
        /// 参数
        /// </summary>
        public Threshold parameter;

        /// <summary>
        /// 最大值
        /// </summary>
        public double maxValue;

        /// <summary>
        /// 最小值
        /// </summary>
        public double minValue;

        /// <summary>
        /// 有无
        /// </summary>
        public bool Exist;

        public GetRegionUseThreshold()//构造函数
        {
            //初始化字段默认值
            this.parameter = new Threshold();
            Exist = false;
        }

        public GetRegionUseThreshold(Threshold parameter)//带参数的构造函数
        {
            this.parameter = parameter;
            Exist = false;
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
            base.Measure(ho_Image);//调用基类的测量方法
            measureResult = Result.OK;
            color = "green";
            Rectangle2 ROI = parameter.rectangle2.GetShapePositioned() as Rectangle2;//获取ROI矩形
            HObject ho_ROI = Func_HalconFunction.GenRectangle2(ROI);//创建ROI矩形形状
            ho_Shape = Func_ImageProcessing.Threshold_SelectMaxRegion(ho_Image, ho_ROI, parameter.hv_MinGray, parameter.hv_MaxGray);//创建结果形状
            HOperatorSet.AreaCenter(ho_Shape, out hv_Area, out centerPoint.hv_Row, out centerPoint.hv_Column);//求取区域面积
            HOperatorSet.RegionFeatures(ho_ROI, "row1", out HTuple hv_Row1);
            HOperatorSet.RegionFeatures(ho_ROI, "column1", out HTuple hv_Column1);
            DP.hv_Column = hv_Column1;
            DP.hv_Row = hv_Row1;
            ho_ROI.Dispose();
            if (minValue > hv_Area || hv_Area > maxValue)//？面积在设定范围内
            {
                measureResult = Result.NG;
                if (Exist) measureResult = Result.无料;//？无料
                color = "red";
            }
            MeasureDone = true;//已测量标志为true
            return Convert.ToInt32(measureResult);
        }

        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
          
            base.DisplayDetail(window);
            HObject ho_Rectangle = Func_HalconFunction.GenRectangle1(Func_Mathematics.ToRectangle1(parameter.rectangle2));
            window.DispObj(ho_Rectangle, color, "margin");
        }

        public override void DisplayResult(HWindow_Final window)//显示简单信息
        {
            base.DisplayResult(window);
            HObject ho_Rectangle = Func_HalconFunction.GenRectangle1(Func_Mathematics.ToRectangle1(parameter.rectangle2));
            window.DispObj(ho_Rectangle, color, "margin");
        }

        /// <summary>
        /// 返回详细信息
        /// </summary>
        /// <returns></returns>
        public override object[] GetResultDetail()
        { 
            string function;
            if (Exist)
            {
                function = "产品有无";
            }
            else
            {
                function = "缺陷检测";
            }
            return new object[] { name,function, minValue.ToString(), maxValue.ToString(), hv_Area.D.ToString("f0") };
        }


    }
}
