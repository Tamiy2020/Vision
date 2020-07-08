using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.CameraLib;

namespace Vision.Forms
{
    public partial class Frm_Edit : Form
    {
       public  MeasureManager measureManager;

        /// <summary>
        /// 采集的图片
        /// </summary>
        public HObject ho_Image;

        public Frm_Edit(Control parent, MeasureManager measureManager)
        {
            InitializeComponent();
            Initialize(parent, measureManager);//初始化
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize(Control parent, MeasureManager measureManager)
        {
            //HOperatorSet.GenEmptyObj(out ho_Image);//ho_Image赋空值
            TopLevel = false;//设为非顶级窗体
            Parent = parent;//设置控件的父容器
            Dock = DockStyle.Fill;//停靠模式填充
            this.measureManager = measureManager;
            if (measureManager.camera is Daheng)
            {
                (measureManager.camera as Daheng).eventImage += Frm_Edit_eventImage;
            }
            if (measureManager.camera is File)
            {
                (measureManager.camera as File).eventImage += Frm_Edit_eventImage;
            }



        }

        private void Frm_Edit_eventImage(HObject ho_Image)
        {
            hWindow_Final1.HobjectToHimage(ho_Image);
        }

        private void Frm_Edit_Shown(object sender, EventArgs e)
        {
         
        }

    }
}
