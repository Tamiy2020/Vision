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
            cameraManager = new DahengManager();
            if ((cameraManager as DahengManager).EnumDevice()) { }
            else
            {
                cameraManager = new FileManager();
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


        private void button1_Click(object sender, EventArgs e)
        {
            executionManager.GradAll();
        }

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

        /// <summary>
        /// 窗体显示完成时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Main_Shown(object sender, EventArgs e)
        {
            executionManager.GradAll();
        }

        bool live=false ;
        private void button2_Click(object sender, EventArgs e)
        {
            live = !live;
            if (live)
            {
                executionManager.LiveAll(live);
                button1.Enabled = false;
            }
            else
            {
                executionManager.LiveAll(live);
                button1.Enabled = true;
            }
            
        }
    }
}
