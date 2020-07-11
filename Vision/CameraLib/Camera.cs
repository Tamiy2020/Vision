using ChoiceTech.Halcon.Control;
using GxIAPINET;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision.CameraLib
{
    /// <summary>
    /// 图像接受事件委托
    /// </summary>
    /// <param name="ho_Image"></param>
    public delegate void ImageAcqedEventHandle(HObject ho_Image);

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
        /// OK/NG
        /// </summary>
        public Label Label_OK=null;

        /// <summary>
        /// 总数
        /// </summary>
        public Label Label_Sum = null;

        /// <summary>
        /// 良品
        /// </summary>
        public Label Label_Num=null;

        /// <summary>
        /// 良率
        /// </summary>
        public Label Label_Yield=null;

        /// <summary>
        /// 排序索引
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 打开相机
        /// </summary>
        public virtual void Open() { }

        /// <summary>
        /// 关闭相机
        /// </summary>
        public virtual void Close() { }

        /// <summary>
        /// 采集
        /// </summary>
        public virtual void Grad() { }

        /// <summary>
        /// 图像接收事件
        /// </summary>
        public event ImageAcqedEventHandle ImageAcqed;

        /// <summary>
        /// 触发图像接收事件的方法
        /// </summary>
        /// <param name="ho_Image"></param>
        protected void OnImageAcqed(HObject ho_Image)
        {
            ImageAcqed?.Invoke(ho_Image);
        }

      
        /// <summary>
        /// 设置窗体
        /// </summary>
        /// <param name="name">相机序列号</param>
        /// <param name="window">相机窗体</param>
        /// <param name="lbl_OK">相机OK/NG标签</param>
        /// <param name="lbl_Sum">相机产量标签</param>
        /// <param name="lbl_Num">相机良品标签</param>
        /// <param name="lbl_Yield">相机良率标签</param>
        public virtual void SetWindow(string name, HWindow_Final window,Label lbl_OK,Label lbl_Sum,Label lbl_Num,Label lbl_Yield)
        {
            if (strName == name)
            {
                displayWin = window;
                Label_OK = lbl_OK;
                Label_Sum = lbl_Sum;
                Label_Num = lbl_Num;
                Label_Yield = lbl_Yield;
            }
        }
    }
}
