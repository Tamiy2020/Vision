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
            camera.Grad();
            camera.displayWin.HobjectToHimage(camera.ho_Image);
            try
            {
                camera.ho_Image.Dispose();
            }
            catch (Exception) { }
          
        }
    }
}
