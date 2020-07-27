/*using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basler.Pylon;
using ChoiceTech.Halcon.Control;
using HalconDotNet;

namespace Vision.CameraLib
{
    public class BaslerCam : Camera
    {
        /// <summary>
        /// 设备对象
        /// </summary>
        public Basler.Pylon.Camera objDev =null;

        /// <summary>
        /// 图像宽
        /// </summary>
        private long imageWidth = 0;         // 图像宽

        /// <summary>
        /// 图像高
        /// </summary>
        private long imageHeight = 0;        // 图像高

        /// <summary>
        ///  采集图像时间
        /// </summary>
        private long grabTime = 0;          // 采集图像时间


        private PixelDataConverter converter = new PixelDataConverter();

        private IntPtr latestFrameAddress = IntPtr.Zero;
        private Stopwatch stopWatch = new Stopwatch();


        /// <summary>
        /// 计算采集图像时间自定义委托
        /// </summary>
        /// <param name="time">采集图像时间</param>
        public delegate void delegateComputeGrabTime(long time);
        /// <summary>
        /// 计算采集图像时间委托事件
        /// </summary>
        public event delegateComputeGrabTime eventComputeGrabTime;

        /// <summary>
        /// if >= Sfnc2_0_0,说明是ＵＳＢ３的相机
        /// </summary>
        static Version Sfnc2_0_0 = new Version(2, 0, 0);

        public override void Open()
        {
            try
            {
                objDev.Open();
                SetHeartBeatTime(5000);
                //objDev.Parameters[PLCamera.AcquisitionFrameRateEnable].SetValue(true);  // 限制相机帧率
                //objDev.Parameters[PLCamera.AcquisitionFrameRateAbs].SetValue(90);
                //objDev.Parameters[PLCameraInstance.MaxNumBuffer].SetValue(10);          // 设置内存中接收图像缓冲区大小

                imageWidth = objDev.Parameters[PLCamera.Width].GetValue();               // 获取图像宽 
                imageHeight = objDev.Parameters[PLCamera.Height].GetValue();              // 获取图像高
               // GetMinMaxExposureTime();
              //  GetMinMaxGain();
                objDev.StreamGrabber.ImageGrabbed += OnImageGrabbed;                      // 注册采集回调函数
                objDev.ConnectionLost += OnConnectionLost;
            }
            catch (Exception e )
            {
                ShowException(e);
            }
        }

        public override void Close()
        {
            try
            {
                objDev.Close();
                objDev.Dispose();
                if (latestFrameAddress != null)
                {
                    Marshal.FreeHGlobal(latestFrameAddress);
                    latestFrameAddress = IntPtr.Zero;
                }
            }
            catch (Exception e)
            {
                ShowException(e);
            }
        }

      

        public override void Grad()
        {
           
            try
            {
                if (objDev.WaitForFrameTriggerReady(1000, TimeoutHandling.ThrowException))
                {
                    objDev.ExecuteSoftwareTrigger(); //发送软触发命令
                    stopWatch.Restart();    // ****  重启采集时间计时器   ****
                }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }

        public void ChangeTriggerMode(bool live)
        {

            try
            {
                // Set an enum parameter.
                if (objDev.GetSfncVersion() < Sfnc2_0_0)
                {
                    if (objDev.Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.AcquisitionStart))
                    {
                        if (objDev.Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.FrameStart))
                        {
                            objDev.Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.AcquisitionStart);
                            objDev.Parameters[PLCamera.TriggerMode].TrySetValue(PLCamera.TriggerMode.Off);

                            objDev.Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.FrameStart);
                            objDev.Parameters[PLCamera.TriggerMode].TrySetValue(PLCamera.TriggerMode.On);
                            objDev.Parameters[PLCamera.TriggerSource].TrySetValue(PLCamera.TriggerSource.Software);
                        }
                        else
                        {
                            objDev.Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.AcquisitionStart);
                            objDev.Parameters[PLCamera.TriggerMode].TrySetValue(PLCamera.TriggerMode.On);
                            objDev.Parameters[PLCamera.TriggerSource].TrySetValue(PLCamera.TriggerSource.Software);
                        }
                    }
                }
                else // For SFNC 2.0 cameras, e.g. USB3 Vision cameras
                {
                    if (objDev.Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.FrameBurstStart))
                    {
                        if (objDev.Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.FrameStart))
                        {
                            objDev.Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.FrameBurstStart);
                            objDev.Parameters[PLCamera.TriggerMode].TrySetValue(PLCamera.TriggerMode.Off);

                            objDev.Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.FrameStart);
                            objDev.Parameters[PLCamera.TriggerMode].TrySetValue(PLCamera.TriggerMode.On);
                            objDev.Parameters[PLCamera.TriggerSource].TrySetValue(PLCamera.TriggerSource.Software);
                        }
                        else
                        {
                            objDev.Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.FrameBurstStart);
                            objDev.Parameters[PLCamera.TriggerMode].TrySetValue(PLCamera.TriggerMode.On);
                            objDev.Parameters[PLCamera.TriggerSource].TrySetValue(PLCamera.TriggerSource.Software);
                        }
                    }
                }
                stopWatch.Reset();    // ****  重置采集时间计时器   ****
            }
            catch (Exception e)
            {
                ShowException(e);
            }
        }



        /// <summary>
        ///  相机取像回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnImageGrabbed(object sender, ImageGrabbedEventArgs e)
        {
            try
            {
                // Acquire the image from the camera. Only show the latest image. The camera may acquire images faster than the images can be displayed.

                // Get the grab result.
                IGrabResult grabResult = e.GrabResult;

                // Check if the image can be displayed.
                if (grabResult.GrabSucceeded)
                {
                    grabTime = stopWatch.ElapsedMilliseconds;
                    eventComputeGrabTime(grabTime);
                    HObject ho_Image = null;
                    // Reduce the number of displayed images to a reasonable amount if the camera is acquiring images very fast.
                    // ****  降低显示帧率，减少CPU占用率  **** //
                    //if (!stopWatch.IsRunning || stopWatch.ElapsedMilliseconds > 33)

                    {
                        //stopWatch.Restart();
                        // 判断是否是黑白图片格式
                        if (grabResult.PixelTypeValue == PixelType.Mono8)
                        {
                            //allocate the m_stream_size amount of bytes in non-managed environment 
                            if (latestFrameAddress == IntPtr.Zero)
                            {
                                latestFrameAddress = Marshal.AllocHGlobal((Int32)grabResult.PayloadSize);
                            }
                            converter.OutputPixelFormat = PixelType.Mono8;
                            converter.Convert(latestFrameAddress, grabResult.PayloadSize, grabResult);

                            // 转换为Halcon图像显示
                            HOperatorSet.GenImage1(out ho_Image, "byte", (HTuple)grabResult.Width, (HTuple)grabResult.Height, (HTuple)latestFrameAddress);

                        }
                        else if (grabResult.PixelTypeValue == PixelType.BayerBG8 || grabResult.PixelTypeValue == PixelType.BayerGB8
                                    || grabResult.PixelTypeValue == PixelType.BayerRG8 || grabResult.PixelTypeValue == PixelType.BayerGR8)
                        {
                            int imageWidth = grabResult.Width - 1;
                            int imageHeight = grabResult.Height - 1;
                            int payloadSize = imageWidth * imageHeight;

                            //allocate the m_stream_size amount of bytes in non-managed environment 
                            if (latestFrameAddress == IntPtr.Zero)
                            {
                                latestFrameAddress = Marshal.AllocHGlobal((Int32)(3 * payloadSize));
                            }
                            converter.OutputPixelFormat = PixelType.BGR8packed;     // 根据bayer格式不同切换以下代码
                            //converter.OutputPixelFormat = PixelType.RGB8packed;
                            converter.Parameters[PLPixelDataConverter.InconvertibleEdgeHandling].SetValue("Clip");
                            converter.Convert(latestFrameAddress, 3 * payloadSize, grabResult);

                            HOperatorSet.GenImageInterleaved(out ho_Image, latestFrameAddress, "bgr",
                                     (HTuple)imageWidth, (HTuple)imageHeight, -1, "byte", (HTuple)imageWidth, (HTuple)imageHeight, 0, 0, -1, 0);

                        }

                        // 抛出图像处理事件
                        OnImageAcqed(ho_Image);
                        ho_Image.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Grab faild!\n" + grabResult.ErrorDescription, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
            finally
            {
                // Dispose the grab result if needed for returning it to the grab loop.
                e.DisposeGrabResultIfClone();
            }


        }

        /// <summary>
        /// 掉线重连回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnConnectionLost(object sender, EventArgs e)
        {
            try
            {
                objDev.Close();

                for (int i = 0; i < 100; i++)
                {
                    try
                    {
                        objDev.Open();
                        if (objDev.IsOpen)
                        {
                            MessageBox.Show("已重新连接上UserID为“" + strName + "”的相机！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        Thread.Sleep(200);
                    }
                    catch
                    {
                        MessageBox.Show("请重新连接UserID为“" + strName + "”的相机！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (objDev == null)
                {
                    MessageBox.Show("重连超时20s:未识别到UserID为“" + strName + "”的相机！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                SetHeartBeatTime(5000);
                //camera.Parameters[PLCamera.AcquisitionFrameRateEnable].SetValue(true);  // 限制相机帧率
                //camera.Parameters[PLCamera.AcquisitionFrameRateAbs].SetValue(90);
                //camera.Parameters[PLCameraInstance.MaxNumBuffer].SetValue(10);          // 设置内存中接收图像缓冲区大小

                imageWidth = objDev.Parameters[PLCamera.Width].GetValue();               // 获取图像宽 
                imageHeight = objDev.Parameters[PLCamera.Height].GetValue();              // 获取图像高
                //GetMinMaxExposureTime();
               // GetMinMaxGain();
                objDev.StreamGrabber.ImageGrabbed += OnImageGrabbed;                      // 注册采集回调函数
                objDev.ConnectionLost += OnConnectionLost;

            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }

        /// <summary>
        /// 设置Gige相机心跳时间
        /// </summary>
        /// <param name="v"></param>
        private void SetHeartBeatTime(int v)
        {
            try
            {
                // 判断是否是网口相机
                if (objDev.GetSfncVersion() < Sfnc2_0_0)
                {
                    objDev.Parameters[PLGigECamera.GevHeartbeatTimeout].SetValue(v);
                }
            }
            catch (Exception e)
            {
                ShowException(e);
            }
        }

        // Shows exceptions in a message box.
        private void ShowException(Exception exception)
        {
            MessageBox.Show("Exception caught:\n" + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
*/