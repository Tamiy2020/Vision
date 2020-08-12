using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MVSDK;//使用SDK接口
using MvApi = MVSDK.MvApi;


namespace Vision.CameraLib
{
    public class MindVisionManager:CameraManager
    {
        CameraSdkStatus status;
        tSdkCameraDevInfo[] tCameraDevInfoList;


        public bool EnumDevice()
        {
            status = MvApi.CameraEnumerateDevice(out tCameraDevInfoList);//枚举设备
            int iCameraCounts = (tCameraDevInfoList != null ? tCameraDevInfoList.Length : 0);//设备数量

            if (iCameraCounts==0)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < iCameraCounts; i++)
                {

                    MindVision mindVision = new MindVision();

                    if (MvApi.CameraInit(ref tCameraDevInfoList[i], -1, -1, ref mindVision.m_hCamera) == CameraSdkStatus.CAMERA_STATUS_SUCCESS)//初始化相机
                    {
                        mindVision.strName = Encoding.Default.GetString(tCameraDevInfoList[i].acFriendlyName);//名字
                    }


                    listCamera.Add(mindVision);//添加到相机列队
                }
                return true;
            }
           
         
        }
    }
}
