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
            TopLevel = false;//设为非顶级窗体
            Parent = parent;//设置控件的父容器
            Dock = DockStyle.Fill;//停靠模式填充
            this.measureManager = measureManager;

            HOperatorSet.GenEmptyObj(out ho_Image);//ho_Image赋空值
        }

        private void Frm_Edit_Shown(object sender, EventArgs e)
        {
            if (measureManager.camera is File)
            {
                button2.Visible = false;
            }
            GrabAndMeasure();

        }


        //采集按钮
        private void button1_Click(object sender, EventArgs e)
        {
            GrabAndMeasure();

        }

        /// <summary>
        /// 采集测量
        /// </summary>
        private void GrabAndMeasure()
        {

            measureManager.camera.Grad();

            hWindow_Final1.HobjectToHimage(measureManager.camera.ho_Image);
            measureManager.camera.ho_Image.Dispose();
        }

        //实时标志
        bool live = false;

        //实时按钮
        private void button2_Click(object sender, EventArgs e)
        {
            live = !live;
            if (measureManager.camera is Daheng)
            {
                if (live)
                {
                    (measureManager.camera as Daheng).ChangeTriggerMode(live, hWindow_Final1);
                    button1.Enabled = false;
                }
                else
                {
                    (measureManager.camera as Daheng).ChangeTriggerMode(live, hWindow_Final1);
                    button1.Enabled = true;
                }

            }
        }

    }
}
