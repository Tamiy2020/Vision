﻿using ChoiceTech.Halcon.Control;
using GxIAPINET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vision.CameraLib
{
    /// <summary>
    /// 相机类
    /// </summary>
    public class Camera
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string strName = "";

        /// <summary>
        /// 显示窗体
        /// </summary>
        public HWindow_Final displayWin = null;

        /// <summary>
        /// 打开相机
        /// </summary>
        public virtual void Open() { }

        /// <summary>
        /// 关闭相机
        /// </summary>
        public virtual void Close() { }

        /// <summary>
        /// 设置窗体
        /// </summary>
        /// <param name="name"></param>
        /// <param name="window"></param>
        public virtual void SetWindow(string name, HWindow_Final window) { }

    }
}
