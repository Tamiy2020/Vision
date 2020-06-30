using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.CameraLib
{
    /// <summary>
    /// 相机管理器
    /// </summary>
    public class CameraManager
    {
        /// <summary>
        /// 相机列队
        /// </summary>
        public List<Camera> listCamera = new List<Camera>();

        /// <summary>
        /// 打开所有相机
        /// </summary>
        public virtual void OpenAll()
        {
            foreach (var camera in listCamera)
            {
                camera.Open();
            }
        }

        /// <summary>
        /// 关闭所有相机
        /// </summary>
        public virtual void CloseAll()
        {
            foreach (var camera in listCamera)
            {
                camera.Close();
            }
        }

    }
}
