using System.Collections.Generic;
using ThridLibray;

namespace Vision.CameraLib
{
    /// <summary>
    /// 大华相机管理器
    /// </summary>
    public class DahuaManager : CameraManager
    {
        /// <summary>
        /// 设备信息列表
        /// </summary>
        private List<IDeviceInfo> li = new List<IDeviceInfo>();

        /// <summary>
        /// 枚举设备
        /// </summary>
        /// <returns></returns>
        public bool EnumDevice()
        {
            // 设备搜索 
            // device search 
            li = Enumerator.EnumerateDevices();

            if (li.Count == 0)
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
