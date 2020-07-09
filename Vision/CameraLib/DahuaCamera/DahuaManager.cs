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
        /// <summary>
        /// 设备信息列表
        /// </summary>
        List<IDeviceInfo> li = new List<IDeviceInfo>();


        public bool EnumDevice()
        {
            // 设备搜索 
            // device search 
            li = Enumerator.EnumerateDevices();

            if (li.Count ==0)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < li.Count; i++)
                {
                    Dahua objCamera = new Dahua();
                    objCamera.strName = li[i].Key;
                    listCamera.Add(objCamera);//添加相机列队
                }
                return true;
            }
            
        }
    }
}
