using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.CameraLib;

namespace Vision
{
    public class ExecutionManager
    {
        public List<MeasureManager> listMeasureManager = new List<MeasureManager>();
        public ExecutionManager(CameraManager cameraManager)
        {
            foreach (var camera in cameraManager.listCamera)
            {
                MeasureManager measureManager = new MeasureManager(camera);
                listMeasureManager.Add(measureManager);
            }
        }


        public void GradAll()
        {
            foreach (var measureManager in listMeasureManager)
            {
                measureManager.Grad();
            }
        }

        public void  LiveAll(bool live)
        {
            foreach (var measureManager in listMeasureManager)
            {
                measureManager.Live(live);
            }
            
        }
    }
}
