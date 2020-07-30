using Microsoft.Win32;
using System;
using System.Collections.Generic;
using Vision.CameraLib;

namespace Vision
{
    /// <summary>
    /// 配置管理类
    /// </summary>
    public class ConfigManager
    {
        /// <summary>
        /// 执行管理器
        /// </summary>
        public ExecutionManager ExecutionManager;

        public ConfigManager(CameraManager cameraManager)//构造函数
        {
            try
            {
                LoadUnitData(cameraManager);//加载数据
            }
            catch (Exception)
            {
                ExecutionManager = new ExecutionManager(cameraManager);//实例化
            }
        }

        /// <summary>
        ///  保存测量数据
        /// </summary>
        /// <param name="path"></param>
        public void SaveMeasureData(string path)
        {
            SystemData.Write(path, ExecutionManager.GetMeasureManagerListClone());
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="cameraManager"></param>
        public void LoadUnitData(CameraManager cameraManager)
        {
            List<MeasureManager> measureManagers = SystemData.Read(Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("HRDVision").OpenSubKey("FilePath").GetValue("Path").ToString()) as List<MeasureManager>;//读取本地文件
            ExecutionManager = new ExecutionManager(cameraManager, measureManagers);

        }
    }
}
