using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.CameraLib
{
    /// <summary>
    /// 文件相机
    /// </summary>
    public class File : Camera
    {
        /// <summary>
        /// 初始化参数
        /// </summary>
        private HTuple[] initpara = null;

        /// <summary>
        /// 采集句柄HTuple 
        /// </summary>
        private HTuple hv_AcqHandle = null;

        public event Action<HObject> eventImage;

        public File(HTuple[] initpara)
        {
            this.initpara = initpara;
        }

        /// <summary>
        /// 打开相机
        /// </summary>
        public override void Open()
        {
            HOperatorSet.OpenFramegrabber(initpara[0], initpara[1], initpara[2], initpara[3], initpara[4],
                        initpara[5], initpara[6], initpara[7], initpara[8], initpara[9], initpara[10], initpara[11],
                        initpara[12], initpara[13], initpara[14], initpara[15], out hv_AcqHandle);

        }

        /// <summary>
        /// 关闭相机
        /// </summary>
        public override void Close()
        {
            HOperatorSet.CloseFramegrabber(hv_AcqHandle);
        }

        /// <summary>
        /// 设置窗体
        /// </summary>
        /// <param name="name"></param>
        /// <param name="window"></param>
        public override void SetWindow(string name, HWindow_Final window)
        {
            if (strName == name)
            {
                this.displayWin = window;
            }
        }

        public override void Grad()
        {
            HOperatorSet.GrabImage(out HObject ho_Image, hv_AcqHandle);
            eventImage?.Invoke(ho_Image);
            ho_Image.Dispose();
        }
    }
}
