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
                (camera as Daheng).eventImage += MeasureManager_eventImage;
            }
            if (camera is File)
            {
                (camera as File).eventImage += MeasureManager_eventImage;
            }
        }

        private void MeasureManager_eventImage(HObject ho_Image)
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
        }
    }
}
