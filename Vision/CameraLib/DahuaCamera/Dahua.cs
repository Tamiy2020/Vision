using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThridLibray;

namespace Vision.CameraLib
{
    public class Dahua : Camera
    {
        /// <summary>
        /// 设备对象 device object
        /// </summary>
        private IDevice objDev;

        /// <summary>
        /// 图像缓存列表
        /// </summary>
        private List<IGrabbedRawData> frameList = new List<IGrabbedRawData>();

        /// <summary>
        /// 显示线程
        /// </summary>
        private Thread renderThread = null;

        /// <summary>
        /// 锁，保证多线程安全
        /// </summary>
        Mutex mutex = new Mutex();

        /// <summary>
        ///  时间统计器
        /// </summary>
        Stopwatch stopWatch = new Stopwatch();

        private const int DEFAULT_INTERVAL = 40;

        /// <summary>
        /// 图像采集函数 ,线程
        /// </summary>
        private void ShowThread()
        {
            while (true)
            {
                if (frameList.Count == 0)
                {
                    Thread.Sleep(10);
                    continue;
                }

                /* 图像队列取最新帧 */
                mutex.WaitOne();
                IGrabbedRawData frame = frameList.ElementAt(frameList.Count - 1);
                frameList.Clear();
                mutex.ReleaseMutex();

                /* 主动调用回收垃圾 */
                GC.Collect();

                /* 控制显示最高帧率为25FPS */
                if (false == IsTimeToDisplay())
                {
                    continue;
                }

                try
                {
                    /* 图像转码成bitmap图像 */
                    var bitmap = frame.ToBitmap(false);
                    HObject image = BitmapToHImage(bitmap);
                    OnImageAcqed(image);//触发事件
                    try
                    {
                        image.Dispose();
                        image = null;
                    }
                    catch { }
                    try
                    {
                        bitmap.Dispose();
                        bitmap = null;
                    }
                    catch { }

                }
                catch (Exception exception)
                {
                    Catcher.Show(exception);
                   /* MessageBox.Show("Dahua:系统异常");
                    Environment.Exit(0);*/
                }
            }
        }

        /// <summary>
        /// 图像转换
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        private HObject BitmapToHImage(Bitmap bitmap)
        {
            HObject ho_Image = null;
            HOperatorSet.GenEmptyObj(out ho_Image);
            try
            {
                Point po = new Point(0, 0);
                Size so = new Size(bitmap.Width, bitmap.Height);
                //template.Width, template.Height        
                Rectangle ro = new Rectangle(po, so);
                Bitmap DstImage = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format8bppIndexed);
                DstImage = bitmap.Clone(ro, PixelFormat.Format8bppIndexed);
                int width = DstImage.Width;
                int height = DstImage.Height;
                Rectangle rect = new Rectangle(0, 0, width, height);
                BitmapData dstBmpData = DstImage.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
                //pImage.PixelFormat     
                int PixelSize = Bitmap.GetPixelFormatSize(dstBmpData.PixelFormat) / 8;
                int stride = dstBmpData.Stride;
                //重点在此       
                unsafe
                {
                    int count = height * width;
                    byte[] data = new byte[count];
                    byte* bptr = (byte*)dstBmpData.Scan0;
                    fixed (byte* pData = data)
                    {
                        for (int i = 0; i < height; i++)
                            for (int j = 0; j < width; j++)
                            {
                                data[i * width + j] = bptr[i * stride + j];
                            }
                        HOperatorSet.GenImage1(out ho_Image, "byte", width, height, new IntPtr(pData));
                    }
                }
                DstImage.UnlockBits(dstBmpData);
            }
            catch { }
            return ho_Image;
        }

        /// <summary>
        /// 判断是否应该做显示操作
        /// </summary>
        /// <returns></returns>
        private bool IsTimeToDisplay()
        {
            stopWatch.Stop();
            long lDisplayInterval = stopWatch.ElapsedMilliseconds;
            if (lDisplayInterval <= DEFAULT_INTERVAL)
            {
                stopWatch.Start();
                return false;
            }
            else
            {
                stopWatch.Reset();
                stopWatch.Start();
                return true;
            }
        }

        public override void Open()
        {

            objDev = Enumerator.GetDeviceByKey(strName);

            // 注册链接事件
            objDev.CameraOpened += OnCameraOpen;
            objDev.ConnectionLost += OnConnectLoss;
            objDev.CameraClosed += OnCameraClose;

            // 打开设备 
            // open device 
            if (!objDev.Open())
            {
                MessageBox.Show("Open camera failed");
                return;
            }

            // 打开Software Trigger 
            objDev.TriggerSet.Open(TriggerSourceEnum.Software);

            // 设置图像格式 
            // set PixelFormat 
            using (IEnumParameter p = objDev.ParameterCollection[ParametrizeNameSet.ImagePixelFormat])
            {
                p.SetValue("Mono8");
            }

          /*  // 设置曝光 
            // set ExposureTime 
            using (IFloatParameter p = objDev.ParameterCollection[ParametrizeNameSet.ExposureTime])
            {
                p.SetValue(1000);
            }

            // 设置增益 
            // set Gain 
            using (IFloatParameter p = objDev.ParameterCollection[ParametrizeNameSet.GainRaw])
            {
                p.SetValue(1.0);
            }*/

            // 开启图像采集函数线程
            renderThread = new Thread(new ThreadStart(ShowThread));
            renderThread.IsBackground = true;
            renderThread.Start();

            // 设置缓存个数为8（默认值为16） 
            objDev.StreamGrabber.SetBufferCount(8);

            // 注册码流回调事件
            objDev.StreamGrabber.ImageGrabbed += OnImageGrabbed;

            // 开启码流 
            // start grabbing 
            if (!objDev.GrabUsingGrabLoopThread())
            {
                MessageBox.Show(@"Start grabbing failed");
                return;
            }


        }


        // 码流数据回调 
        private void OnImageGrabbed(object sender, GrabbedEventArgs e)
        {
            mutex.WaitOne();
            frameList.Add(e.GrabResult.Clone());
            mutex.ReleaseMutex();
        }

        // 相机打开回调 
        // camera open event callback 
        private void OnCameraOpen(object sender, EventArgs e)
        {

        }


        // 相机丢失回调 
        // camera disconnect event callback 
        private void OnConnectLoss(object sender, EventArgs e)
        {
            objDev.ShutdownGrab();
            objDev.Dispose();
            objDev = null;
        }


        // 相机关闭回调 
        // camera close event callback 
        private void OnCameraClose(object sender, EventArgs e)
        {
          
        }


        public override void Grad()
        {
            objDev.ExecuteSoftwareTrigger();// 发送软触发命令
        }

        /// <summary>
        /// 切换触发模式
        /// </summary>
        /// <param name="isOn"></param>
        public void ChangeTriggerMode(bool live)
        {

            if (live)
            {
                objDev.TriggerSet.Close();//实时
            }
            else
            {
                objDev.TriggerSet.Open(TriggerSourceEnum.Software);//单张
            }
        }

        public override void Close()
        {
            try
            {
                if (objDev == null)
                {
                    throw new InvalidOperationException("Device is invalid");
                }

                objDev.StreamGrabber.ImageGrabbed -= OnImageGrabbed;         // 反注册回调 | unregister grab event callback 
                objDev.ShutdownGrab();                                       // 停止码流 | stop grabbing 
                objDev.Close();                                              // 关闭相机 | close camera 
            }
            catch (Exception exception)
            {
                Catcher.Show(exception);
            }
        }

        /// <summary>
        /// 获取曝光时间
        /// </summary>
        /// <returns></returns>
        public string GetExposureTime()
        {
            /* ExposureTime */
            {
                using (IFloatParameter p = objDev.ParameterCollection[new FloatName("ExposureTime")])
                {
                    Trace.WriteLine(string.Format("ExposureTime value: {0}", p.GetValue()));
                    return p.GetValue().ToString();
                }
            }

        }

        /// <summary>
        /// 获取增益
        /// </summary>
        /// <returns></returns>
        public string GetGainRaw()
        {
            {
                using (IFloatParameter p = objDev.ParameterCollection[new FloatName("GainRaw")])
                {
                    Trace.WriteLine(string.Format("ExposureTime value: {0}", p.GetValue()));
                    return p.GetValue().ToString();
                }
            }
        }

        /// <summary>
        /// 设置曝光
        /// </summary>
        /// <param name="et"></param>
        public void SetExposureTime(string et)
        {
            using (IFloatParameter p = objDev.ParameterCollection[ParametrizeNameSet.ExposureTime])
            {
                p.SetValue(double.Parse(et));
            }
        }

        /// <summary>
        /// 设置增益
        /// </summary>
        /// <param name="gainRaw"></param>
        public void SetGainRaw(string gainRaw)
        {
            using (IFloatParameter p = objDev.ParameterCollection[ParametrizeNameSet.GainRaw])
            {
                p.SetValue(double.Parse(gainRaw));
            }
        }

       


    }
}
