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
        }

        public void Grad()
        {
            camera.Grad();
            if ( camera is Daheng )
            {
                while (!(camera as Daheng).bIsOver )
                {
                    Thread.Sleep(1);
                }
            }
            camera.displayWin.HobjectToHimage(camera.ho_Image);
            try
            {
                camera.ho_Image.Dispose();
                GC.Collect();
            }
            catch (Exception) { }
          
        }
    }
}
