using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        public void Grad()
        {
            if (camera is File)
            {
                (camera as File).GradImage();
            }
            if (camera is Daheng)
            {
                (camera as Daheng).SoftTrigger();
            }
        }
    }
}
