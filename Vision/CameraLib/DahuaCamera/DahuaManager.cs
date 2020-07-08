using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThridLibray;

namespace Vision.CameraLib
{
    public  class DahuaManager:CameraManager
    {
        List<IDeviceInfo> li = new List<IDeviceInfo>();

        public void EnumDevice()
        {
            // 设备搜索 
            // device search 
            li = Enumerator.EnumerateDevices();

            for (int i = 0; i < li.Count; i++)
            {
                Dahua objCamera = new Dahua();
                objCamera.strName = li[i].Key;
                listCamera.Add(objCamera);

            }
        }
    }
}
