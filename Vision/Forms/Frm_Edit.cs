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
        /// <summary>
        ///  测量单元管理器
        /// </summary>
        public MeasureManager measureManager;

        /// <summary>
        /// 采集的图片
        /// </summary>
        public HObject ho_Image;


        /// <summary>
        /// 单元窗体
        /// </summary>
        //private Frm_Unit frm_Unit;

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
            HOperatorSet.GenEmptyObj(out ho_Image);//ho_Image赋空值
            TopLevel = false;//设为非顶级窗体
            Parent = parent;//设置控件的父容器
            Dock = DockStyle.Fill;//停靠模式填充
            this.measureManager = measureManager;
            measureManager.camera.ImageAcqed += Camera_ImageAcqed;//挂载图像接收完成事件

        }

        //图像处理
        private void Camera_ImageAcqed(HObject ho_Image)
        {
            this.ho_Image = ho_Image;

            if (measureManager.bisTest)
            {
                measureManager.MeasureStartDetail(ho_Image);//测量
                hWindow_Final1.HobjectToHimage(ho_Image);
                measureManager.DisplayResult(hWindow_Final1);//字符串
            }
            else
            {
                hWindow_Final1.HobjectToHimage(ho_Image);
            }
        }


        /// <summary>
        /// 编辑模式
        /// </summary>
        /// <param name="sign"></param>
        public void EditMod(bool sign)
        {
            toolStrip1.Enabled = !sign;
            dgv_Data.Enabled = !sign;
        }

        private void Frm_Edit_Shown(object sender, EventArgs e)
        {

        }
    }
}
