using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vision.CameraLib;

namespace Vision
{
    public class MeasureManager
    {
        public Camera camera;
        public MeasureManager(Camera camera)
        {
            this.camera = camera;
            if (camera is Daheng)
            {
                (camera as Daheng).StartDevice();
            }
            camera.ImageAcqed += Camera_ImageAcqed;
           
        }

        private void Camera_ImageAcqed(HObject ho_Image)
        {
            camera.displayWin.HobjectToHimage(ho_Image);
        }

        public void Grad()
        {
            camera.Grad();          
        }

        public void Live(bool live)
        {
            if (camera is Daheng)
            {
                (camera as Daheng).ChangeTriggerMode(live);
            }
            if (camera is Dahua)
            {
                (camera as Dahua).ChangeTriggerMode(live);
            }
        }
    }
}
