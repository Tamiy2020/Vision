using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using MVSDK;//使用SDK接口
using CameraHandle = System.Int32;
using MvApi = MVSDK.MvApi;


namespace Vision.CameraLib
{
    public class MindVision : Camera
    {
        /// <summary>
        /// 句柄
        /// </summary>
        public CameraHandle m_hCamera = 0;             // 句柄

        /// <summary>
        /// 预览通道RGB图像缓存
        /// </summary>
        public IntPtr m_ImageBuffer;             // 预览通道RGB图像缓存

        /// <summary>
        /// 抓拍通道RGB图像缓存
        /// </summary>
        public IntPtr m_ImageBufferSnapshot;     // 抓拍通道RGB图像缓存

        /// <summary>
        /// 相机特性描述
        /// </summary>
        public tSdkCameraCapbility tCameraCapability;  // 相机特性描述

        /// <summary>
        /// 图像回调函数的上下文参数
        /// </summary>
        protected IntPtr m_iCaptureCallbackCtx;     //图像回调函数的上下文参数

        protected CAMERA_SNAP_PROC m_CaptureCallback;



        CAMERA_SNAP_PROC pCaptureCallOld = null;

        protected int m_iDisplayedFrames = 0;    //已经显示的总帧数

        protected tSdkFrameHead m_tFrameHead;

        protected bool m_bEraseBk = false;


        public void InitCamera()
        {
            //获得相机特性描述    (分配内存)
            MvApi.CameraGetCapability(m_hCamera, out tCameraCapability);

            m_ImageBuffer = Marshal.AllocHGlobal(tCameraCapability.sResolutionRange.iWidthMax * tCameraCapability.sResolutionRange.iHeightMax * 3 + 1024);
            m_ImageBufferSnapshot = Marshal.AllocHGlobal(tCameraCapability.sResolutionRange.iWidthMax * tCameraCapability.sResolutionRange.iHeightMax * 3 + 1024);


            if (tCameraCapability.sIspCapacity.bMonoSensor != 0)
            {
                // 黑白相机输出8位灰度数据
                MvApi.CameraSetIspOutFormat(m_hCamera, (uint)MVSDK.emImageFormat.CAMERA_MEDIA_TYPE_MONO8);
            }



            //初始化显示模块，使用SDK内部封装好的显示接口    （初始化显示）
            //  MvApi.CameraDisplayInit(m_hCamera, PreviewBox.Handle);
            // MvApi.CameraSetDisplaySize(m_hCamera, PreviewBox.Width, PreviewBox.Height);

            //注册回调
            m_CaptureCallback = new CAMERA_SNAP_PROC(ImageCaptureCallback);
            MvApi.CameraSetCallbackFunction(m_hCamera, m_CaptureCallback, m_iCaptureCallbackCtx, ref pCaptureCallOld);

            //设置触发模式
            MvApi.CameraSetTriggerMode(m_hCamera, 1);//，0 表示连续采集模式；1 表示软件触发模式；2 表示硬件触发模式。


            //让 SDK 进入图像采集模式
            MvApi.CameraPlay(m_hCamera);
        }


        public void ImageCaptureCallback(CameraHandle hCamera, IntPtr pFrameBuffer, ref tSdkFrameHead pFrameHead, IntPtr pContext)
        {
            //图像处理，将原始输出转换为RGB格式的位图数据，同时叠加白平衡、饱和度、LUT等ISP处理。
            MvApi.CameraImageProcess(hCamera, pFrameBuffer, m_ImageBuffer, ref pFrameHead);


            //叠加十字线、自动曝光窗口、白平衡窗口信息(仅叠加设置为可见状态的)。   
            //   MvApi.CameraImageOverlay(hCamera, m_ImageBuffer, ref pFrameHead);


            //调用SDK封装好的接口，显示预览图像
            // MvApi.CameraDisplayRGB24(hCamera, m_ImageBuffer, ref pFrameHead);//显示
            //m_iDisplayedFrames++;

            //   if (pFrameHead.iWidth != m_tFrameHead.iWidth || pFrameHead.iHeight != m_tFrameHead.iHeight)
            // {
            //  m_bEraseBk = true;
            //  m_tFrameHead = pFrameHead;
            // }

            HObject image;
            HOperatorSet.GenEmptyObj(out image);
            image.Dispose();
         
            byte[] m_pImageData = new byte[pFrameHead.iWidth * pFrameHead.iHeight];

            Marshal.Copy(m_ImageBuffer, m_pImageData, 0, pFrameHead.iWidth * pFrameHead.iHeight);

            unsafe
            {

                fixed (byte* p = m_pImageData)
                {

                    HOperatorSet.GenImage1(out image, "byte", pFrameHead.iWidth, pFrameHead.iHeight, new IntPtr(p));//转Halcon图像变量
                }
            }
            OnImageAcqed(image);//触发事件
            image.Dispose();
            GC.Collect();

        }


        public override void Grad()
        {
            MvApi.CameraSoftTrigger(m_hCamera);//执行一次软触发
        }

        public void ChangeTriggerMode(bool live)
        {
            if (live)
            {
                MvApi.CameraSetTriggerMode(m_hCamera, 0);//实时
            }
            else
            {
                MvApi.CameraSetTriggerMode(m_hCamera, 1); ;//单张
            }
        }

        public override void Close()
        {
            if (m_hCamera!= 0)
            {
                MvApi.CameraUnInit(m_hCamera);
                m_hCamera = 0;
            }

            if (m_ImageBuffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(m_ImageBuffer);
                m_ImageBuffer= IntPtr.Zero;
            }
        }
    }
}
