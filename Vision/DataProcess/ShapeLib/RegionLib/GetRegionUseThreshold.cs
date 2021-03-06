﻿using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
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

        Rectangle2 ROI;

        public GetRegionUseThreshold()//构造函数
        {
            //初始化字段默认值
            this.parameter = new Threshold();
            Exist = false;
            function = "缺陷检测";
        }

        public GetRegionUseThreshold(Threshold parameter)//带参数的构造函数
        {
            this.parameter = parameter;
            Exist = false;
            function = "缺陷检测";
        }

        /// <summary>
        /// 设置定位
        /// </summary>
        public override void SetPosition()
        {
            parameter.rectangle2.position_Horizontal = position_Horizontal;
            parameter.rectangle2.position_Vertical_L = position_Vertical_L;
            parameter.rectangle2.position_Vertical_R = position_Vertical_R;
        }

        public override int Measure(HObject ho_Image)//测量
        {
            base.Measure(ho_Image);//调用基类的测量方法
            measureResult = Result.OK;
            color = "green";
            ROI = parameter.rectangle2.GetShapePositioned() as Rectangle2;//获取ROI矩形

            HObject ho_ROI = Func_HalconFunction.GenRectangle2(ROI);//创建ROI矩形形状


            ho_Shape = Func_ImageProcessing.Threshold_SelectMaxRegion(ho_Image, ho_ROI, parameter.hv_MinGray, parameter.hv_MaxGray);//创建结果形状
            HOperatorSet.AreaCenter(ho_Shape, out hv_Area, out centerPoint.hv_Row, out centerPoint.hv_Column);//求取区域面积
            ho_ROI.Dispose();
            if (minValue > hv_Area || hv_Area > maxValue)//？面积在设定范围内
            {
                measureResult = Result.NG;
                if (Exist)//？无料
                { 
                    measureResult = Result.无料;
                    function = "产品有无";
                }
                color = "red";
            }
            MeasureDone = true;//已测量标志为true
            return Convert.ToInt32(measureResult);
        }

        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            base.DisplayDetail(window);
            HObject ho_Rectangle = Func_HalconFunction.GenRectangle1(Func_Mathematics.ToRectangle1(ROI));
            window.DispObj(ho_Rectangle, color, "margin");
        }

        public override void DisplayResult(HWindow_Final window)//显示简单信息
        {
            HObject ho_Rectangle = Func_HalconFunction.GenRectangle1(Func_Mathematics.ToRectangle1(ROI));
            window.DispObj(ho_Rectangle, color, "margin");
        }

        /// <summary>
        /// 返回详细信息
        /// </summary>
        /// <returns></returns>
        public override object[] GetResultDetail()
        {
            return new object[] { name, function, minValue.ToString(), maxValue.ToString(), hv_Area.D.ToString("f0") };
        }
    }
}
