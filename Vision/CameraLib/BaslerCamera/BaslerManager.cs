using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basler.Pylon;

namespace Vision.CameraLib
{
    public class BaslerManager : CameraManager
    {
        /// <summary>
        /// 设备信息列表
        /// </summary>
        private List<ICameraInfo> listCameraInfo = new List<ICameraInfo>();

        /// <summary>
        /// 枚举设备
        /// </summary>
        public bool  EnumDevice()
        {
            listCameraInfo= CameraFinder.Enumerate();
            if (listCameraInfo.Count == 0)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < listCameraInfo.Count; i++)
                {
                    BaslerCam objCamera = new BaslerCam();
                    objCamera.strName = listCameraInfo[i][CameraInfoKey.UserDefinedName];
                    objCamera.objDev = new Basler.Pylon.Camera(listCameraInfo[i]);
                    listCamera.Add(objCamera);//添加相机列队
                }
                return true;
            }

        }
    }
}
