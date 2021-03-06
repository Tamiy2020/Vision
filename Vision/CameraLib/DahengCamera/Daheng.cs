﻿using System;
using System.Windows.Forms;
using ChoiceTech.Halcon.Control;
using GxIAPINET;
using HalconDotNet;

namespace Vision.CameraLib
{
    /// <summary>
    /// 大恒相机
    /// </summary>
    public class Daheng : Camera
    {
        /// <summary>
        /// 设备对象
        /// </summary>
        private IGXDevice objIGXDevice = null;

        /// <summary>
        /// 流对象
        /// </summary>
        private IGXStream objIGXStream = null;

        /// <summary>
        /// 远端设备属性控制器对象
        /// </summary>
        private IGXFeatureControl objIGXFeatureControl = null;

        /// <summary>
        /// 流层属性控制器对象
        /// </summary>
        private IGXFeatureControl objIGXStreamFeatureControl = null;

        /// <summary>
        /// 发送开采命令标识
        /// </summary>
        private bool bIsSnap = false;

        /// <summary>
        /// 大恒图像
        /// </summary>
        private DahengImage dahengImage = null;

        /// <summary>
        /// 打开相机
        /// </summary>
        public override void Open()
        {
            // 如果设备已经打开则关闭，保证相机在初始化出错情况下能再次打开
            if (null != objIGXDevice)
            {
                objIGXDevice.Close();
                objIGXDevice = null;
            }

            //打开设备
            objIGXDevice = IGXFactory.GetInstance().OpenDeviceBySN(strName, GX_ACCESS_MODE.GX_ACCESS_EXCLUSIVE);
            objIGXFeatureControl = objIGXDevice.GetRemoteFeatureControl();

            //打开流
            objIGXStream = objIGXDevice.OpenStream(0);
            objIGXStreamFeatureControl = objIGXStream.GetFeatureControl();

            // 建议用户在打开网络相机之后，根据当前网络环境设置相机的流通道包长值，
            // 以提高网络相机的采集性能,设置方法参考以下代码。
            GX_DEVICE_CLASS_LIST objDeviceClass = objIGXDevice.GetDeviceInfo().GetDeviceClass();
            if (GX_DEVICE_CLASS_LIST.GX_DEVICE_CLASS_GEV == objDeviceClass)
            {
                // 判断设备是否支持流通道数据包功能
                if (true == objIGXFeatureControl.IsImplemented("GevSCPSPacketSize"))
                {
                    // 获取当前网络环境的最优包长值
                    uint nPacketSize = objIGXStream.GetOptimalPacketSize();
                    // 将最优包长值设置为当前设备的流通道包长值
                    objIGXFeatureControl.GetIntFeature("GevSCPSPacketSize").SetValue(nPacketSize);
                }
            }

            //初始化相机参数
            objIGXFeatureControl.GetEnumFeature("AcquisitionMode").SetValue("Continuous");//设置采集模式连续采集
            objIGXFeatureControl.GetEnumFeature("TriggerSource").SetValue("Software");//设置触发源软触发
            objIGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("On");//默认单张

        }

        /// <summary>
        /// 开始采集
        /// </summary>
        public void StartDevice()
        {
            //设置流层Buffer处理模式为OldestFirst
            objIGXStreamFeatureControl.GetEnumFeature("StreamBufferHandlingMode").SetValue("OldestFirst");

            //开启采集流通道
            if (null != objIGXStream)
            {
                //RegisterCaptureCallback第一个参数属于用户自定参数(类型必须为引用类型)，若用户想用这个参数可以在委托函数中进行使用
                objIGXStream.RegisterCaptureCallback(this, CaptureCallbackPro);
                objIGXStream.StartGrab();
            }

            //发送开采命令
            if (null != objIGXFeatureControl)
            {
                objIGXFeatureControl.GetCommandFeature("AcquisitionStart").Execute();
            }

            //开始采集的标识
            bIsSnap = true;
        }


        /// <summary>
        /// 回调函数,用于获取图像信息和显示图像
        /// </summary>
        /// <param name="obj">用户自定义传入参数</param>
        /// <param name="objIFrameData">图像信息对象</param>
        private void CaptureCallbackPro(object objUserParam, IFrameData objIFrameData)
        {
            try
            {
                Daheng cam = objUserParam as Daheng;
                HObject image = cam.dahengImage.Show(objIFrameData);
                OnImageAcqed(image);//触发事件
                image.Dispose();
                GC.Collect();
            }
            catch (Exception) { }

        }

        public override void SetWindow(string name, HWindow_Final window, Label lbl_OK, Label lbl_Sum, Label lbl_Num, Label lbl_Yield)
        {
            if (strName == name)
            {
                dahengImage = new DahengImage(objIGXDevice);
                displayWin = window;
                Label_OK = lbl_OK;
                Label_Sum = lbl_Sum;
                Label_Num = lbl_Num;
                Label_Yield = lbl_Yield;
            }
        }


        /// <summary>
        /// 切换触发模式
        /// </summary>
        /// <param name="isOn"></param>
        public void ChangeTriggerMode(bool live)
        {
            if (live)
            {
                objIGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("Off");//实时
            }
            else
            {
                objIGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("On");//单张
            }
        }




        public override void Grad()
        {
            objIGXFeatureControl.GetCommandFeature("TriggerSoftware").Execute();// 发送软触发命令
        }

        /// <summary>
        /// 关闭相机
        /// </summary>
        public override void Close()
        {
            // 如果未停采则先停止采集
            if (bIsSnap)
            {
                objIGXFeatureControl.GetCommandFeature("AcquisitionStop").Execute();
                objIGXFeatureControl = null;
            }
            bIsSnap = false;

            //停止流通道、注销采集回调和关闭流
            try
            {
                if (null != objIGXStream)
                {
                    objIGXStream.StopGrab();
                    //注销采集回调函数
                    objIGXStream.UnregisterCaptureCallback();
                    objIGXStream.Close();
                    objIGXStream = null;
                    objIGXStreamFeatureControl = null;
                }
            }
            catch (Exception) { }

            //关闭设备
            if (null != objIGXDevice)
            {
                objIGXDevice.Close();
                objIGXDevice = null;
            }
        }

        /// <summary>
        /// 获取曝光时间
        /// </summary>
        /// <returns></returns>
        public string GetExposureTime()
        {
            return objIGXFeatureControl.GetFloatFeature("ExposureTime").GetValue().ToString();
        }

        /// <summary>
        /// 获取增益
        /// </summary>
        /// <returns></returns>
        public string GetGainRaw()
        {
            return objIGXFeatureControl.GetFloatFeature("Gain").GetValue().ToString();
        }

        /// <summary>
        /// 设置曝光
        /// </summary>
        /// <param name="et"></param>
        public void SetExposureTime(string et)
        {
            objIGXFeatureControl.GetFloatFeature("ExposureTime").SetValue(double.Parse(et));
        }

        /// <summary>
        /// 设置增益
        /// </summary>
        /// <param name="gainRaw"></param>
        public void SetGainRaw(string gainRaw)
        {
            objIGXFeatureControl.GetFloatFeature("Gain").SetValue(double.Parse(gainRaw));
        }
    }
}
