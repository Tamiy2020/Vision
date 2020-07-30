using GxIAPINET;
using System.Collections.Generic;

namespace Vision.CameraLib
{
    public class DahengManager : CameraManager
    {
        /// <summary>
        /// Factory对象
        /// </summary>
        private IGXFactory objIGXFactory = null;

        /// <summary>
        /// 设备信息列表
        /// </summary>
        private List<IGXDeviceInfo> listIGXDeviceInfo = new List<IGXDeviceInfo>();

        /// <summary>
        /// 枚举设备
        /// </summary>
        public bool EnumDevice()
        {
            //初始化
            objIGXFactory = IGXFactory.GetInstance();
            objIGXFactory.Init();

            listIGXDeviceInfo.Clear();
            objIGXFactory.UpdateDeviceList(200, listIGXDeviceInfo);
            if (listIGXDeviceInfo.Count == 0)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < listIGXDeviceInfo.Count; i++)
                {
                    Daheng objCamera = new Daheng();
                    objCamera.strName = listIGXDeviceInfo[i].GetSN();
                    listCamera.Add(objCamera);//添加相机列队
                }
                return true;
            }
        }

    }
}
