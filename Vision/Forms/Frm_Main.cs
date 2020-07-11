using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.CameraLib;

namespace Vision.Forms
{
    public partial class Frm_Main : Form
    {

        public CameraManager cameraManager = null;

        private ExecutionManager executionManager = null;

        public Form cameraWin = null;//相机显示窗体

        List<Frm_Edit> edits = new List<Frm_Edit>();//编辑窗体列队

        public Frm_Main()
        {
            InitializeComponent();
            //使用双缓冲，让图像显示不闪烁
            SetStyle(
                     ControlStyles.OptimizedDoubleBuffer
                     | ControlStyles.ResizeRedraw
                     | ControlStyles.Selectable
                     | ControlStyles.AllPaintingInWmPaint
                     | ControlStyles.UserPaint
                     | ControlStyles.SupportsTransparentBackColor,
                     true);
            bool temp;
            try
            {
                cameraManager = new DahengManager();
                temp = (cameraManager as DahengManager).EnumDevice();
            }
            catch (Exception)
            {

                temp = false;
            }
            if (temp) { }
            else
            {
                cameraManager = new DahuaManager();
                if ((cameraManager as DahuaManager).EnumDevice()) { }
                else
                {
                    cameraManager = new FileManager();
                }
            }

        }

        /// <summary>
        /// 添加编辑窗体
        /// </summary>
        private void AddEditForm()
        {
            for (int i = 0; i < cameraManager.listCamera.Count; i++)
            {
                Frm_Edit edit = new Frm_Edit(tabControl1.TabPages[1 + i], executionManager.listMeasureManager[i]);
                edit.Show();
                edits.Add(edit);
            }
        }

        /// <summary>
        /// 窗体加载中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            cameraWin.Show();
            executionManager = new ExecutionManager(cameraManager);
            AddEditForm();//添加编辑窗体
        }

        /// <summary>
        /// 设置相机窗体样式
        /// </summary>
        /// <param name="count"></param>
        public void SetCameraWindows(int count)
        {
            switch (count)
            {
                case 1:
                    cameraWin = new Frm_OneWin(tabControl1.TabPages[0]);
                    tabControl1.TabPages.Remove(tabPage3);
                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage5);
                    tabControl1.TabPages.Remove(tabPage6);
                    break;

                case 2:
                    cameraWin = new Frm_TwoWin(tabControl1.TabPages[0]);
                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage5);
                    tabControl1.TabPages.Remove(tabPage6);
                    break;
                case 3:
                    cameraWin = new Frm_ThreeWin(tabControl1.TabPages[0]);
                    tabControl1.TabPages.Remove(tabPage5);
                    tabControl1.TabPages.Remove(tabPage6);
                    break;
                case 4:
                    cameraWin = new Frm_FourWin(tabControl1.TabPages[0]);
                    tabControl1.TabPages.Remove(tabPage6);
                    break;
                case 5:
                    cameraWin = new Frm_FiveWin(tabControl1.TabPages[0]);
                    break;
                default:
                    break;
            }
            //cameraWin.Show();
        }

        /// <summary>
        /// 窗体显示完成时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Main_Shown(object sender, EventArgs e)
        {
            executionManager.GradAll();
        }



        #region 实时图像
        private void btn_Live_Click(object sender, EventArgs e)
        {
            executionManager.LiveAll(true);
            btn_Live.Enabled = false;
            btn_Test.Enabled = false;
            btn_Auto.Enabled = true;
        }
        #endregion

        #region 自动测试
        private void btn_Auto_Click(object sender, EventArgs e)
        {
            executionManager.LiveAll(false);
            btn_Live.Enabled = true;
            btn_Test.Enabled = true;
            btn_Auto.Enabled = false;
        }
        #endregion

        #region 手动测试
        private void btn_Test_Click(object sender, EventArgs e)
        {
            executionManager.GradAll();
        }
        #endregion

        #region 计数清零
        private void tsmi_Clear_Click(object sender, EventArgs e)
        {
            foreach (var item in executionManager.listMeasureManager)
            {
                item.ClearCount();
            }
        }
        #endregion

        /// <summary>
        /// 窗体关闭中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            cameraManager.CloseAll();
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            executionManager.GradAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }


    }
}
