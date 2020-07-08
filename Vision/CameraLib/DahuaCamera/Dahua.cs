using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


        public override void Open()
        {

            objDev = Enumerator.GetDeviceByKey(strName);

            // 注册链接事件 
            // register event callback 
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
            // Set Software Trigger 
            objDev.TriggerSet.Open(TriggerSourceEnum.Software);



            // 设置图像格式 
            // set PixelFormat 
            using (IEnumParameter p = objDev.ParameterCollection[ParametrizeNameSet.ImagePixelFormat])
            {
                p.SetValue("Mono8");
            }

            // 设置曝光 
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
            }

            // 设置缓存个数为8（默认值为16） 
            // set buffer count to 8 (default 16) 
            objDev.StreamGrabber.SetBufferCount(8);

            // 注册码流回调事件 
            // register grab event callback 
            objDev.StreamGrabber.ImageGrabbed += OnImageGrabbed;

            // 开启码流 
            // start grabbing 
            if (!objDev.GrabUsingGrabLoopThread())
            {
                MessageBox.Show(@"Start grabbing failed");
                return;
            }


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
            throw new NotImplementedException();
        }

        // 码流数据回调 
        // grab callback function 
        private void OnImageGrabbed(object sender, GrabbedEventArgs e)
        {
            throw new NotImplementedException();
        }


    }
}
