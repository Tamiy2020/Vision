﻿using HalconDotNet;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Vision.CameraLib;

namespace Vision.Forms
{
    public partial class Frm_Main : Form
    {
        /// <summary>
        /// 相机管理器
        /// </summary>
        public CameraManager cameraManager = null;

        /// <summary>
        /// 文件配置管理器
        /// </summary>
        public ConfigManager configManager = null;

        /// <summary>
        /// 相机显示窗体
        /// </summary>
        public Form cameraWin = null;

        /// <summary>
        /// 编辑窗体列队
        /// </summary>
        private List<Frm_Edit> edits = new List<Frm_Edit>();

        /// <summary>
        /// 注册表
        /// </summary>
        private RegistryKey regkey = null;

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


            bool temp;//是否有相机
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
                try
                {
                    cameraManager = new DahuaManager();
                    temp = (cameraManager as DahuaManager).EnumDevice();
                }
                catch (Exception)
                {
                    temp = false;
                }
                if (temp) { }
                else
                {
                    //cameraManager = new FileManager();
                    MessageBox.Show("未发现设备");
                    Environment.Exit(0);
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
                Frm_Edit edit = new Frm_Edit(tabControl1.TabPages[1 + i], configManager.ExecutionManager.listMeasureManager[i]);
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

            this.BeginInvoke(new Action(() => {
                this.Hide();
                this.Opacity = 1;
            }));

            cameraWin.Show();//会报异常

            configManager = new ConfigManager(cameraManager);

            AddEditForm();//添加编辑窗体

            ///解决区域为空的方法
            #region 解决方法1：读取一张比区域还大的图像 
            //HOperatorSet.OpenFramegrabber("File", 0, 1, 0, 0, 0, 0, "default", -1, "default", 1, "false", "TANGMING", "default",-1, -1, out HTuple hv_AcqHandle);
            //HOperatorSet.GrabImage(out HObject ho_Image, hv_AcqHandle);  
            #endregion

            #region 解决方法2：重置DataBase为指导缓存大小
            //  HOperatorSet.ResetObjDb(5000, 5000, 1);//参数1：图像宽度 参数2：图像高度 参数3:通道   
            #endregion

            #region 解决方法3：设置系统是否裁剪区域为false 
            HOperatorSet.SetSystem("clip_region", "false");//设置系统是否裁剪区域为false 
            #endregion


            regkey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("HRDVision").OpenSubKey("FilePath", true);
            if (regkey.GetValue("Path") == null)
            {
                regkey.SetValue("Path", "");
            }
            else
            {
                string str = regkey.GetValue("Path").ToString();
                if (str != "")
                {
                    this.Text = "HRDVison" + "--" + str.Substring(str.LastIndexOf("\\") + 1).Replace(".fpc", string.Empty);
                }

            }
            configManager.ExecutionManager.GradAll();
            tsmi_Clear.PerformClick();
            new Frm_Start().ShowDialog();
            this.Show();
           

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


        #region 实时图像
        private void btn_Live_Click(object sender, EventArgs e)
        {
            configManager.ExecutionManager.LiveAll(true);
            btn_Live.Enabled = false;
            btn_Test.Enabled = false;
            btn_Auto.Enabled = true;
            if (label1.Text == "管理员" || label1.Text == "程序员")
            {
                EditAdmin(false);
            }
        
        }
        #endregion

        #region 自动测试
        private void btn_Auto_Click(object sender, EventArgs e)
        {
            configManager.ExecutionManager.LiveAll(false);
            btn_Live.Enabled = true;
            btn_Test.Enabled = true;
            btn_Auto.Enabled = false;
            if (label1.Text == "管理员" || label1.Text == "程序员")
            {
                EditAdmin(true);
            }
        }
        #endregion

        #region 手动测试
        private void btn_Test_Click(object sender, EventArgs e)
        {
            configManager.ExecutionManager.GradAll();
        }
        #endregion

        #region 计数清零
        private void tsmi_Clear_Click(object sender, EventArgs e)
        {
            foreach (var item in configManager.ExecutionManager.listMeasureManager)
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
            this.Hide();
            cameraManager.CloseAll();
            new Frm_CloseTip().ShowDialog();
            Environment.Exit(0);
        }

        #region 程序员测试
        private void timer1_Tick(object sender, EventArgs e)
        {
            configManager.ExecutionManager.GradAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        #endregion



        #region 新建
        private void tsmi_New_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要新建吗？\n\r请确保您之前编辑的项目已保存。", "新建项目", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)//？确定新建
            {
                configManager.ExecutionManager.ClearMUMList();//清空数据
                regkey.SetValue("Path", "");

                foreach (var item in edits)
                {
                    item.UpdateDataGridView();
                }
                this.Text = "HRDVison";
                configManager.ExecutionManager.GradAll();//运行一次测试


            }
        }
        #endregion

        #region 打开
        private void tsmi_Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//选择路径
            {
                regkey.SetValue("Path", openFileDialog1.FileName);//保存路径
                configManager.ExecutionManager.Dispose();
                try
                {
                    configManager.LoadUnitData(cameraManager);//加载数据
                }
                catch (Exception)
                {
                    MessageBox.Show("文件错误");
                    regkey.SetValue("Path", "");
                    Close();
                }
                configManager.ExecutionManager.GradAll();//运行一次测试

                this.Text = "HRDVison" + "--" + openFileDialog1.SafeFileName.Replace(".fpc", string.Empty);
                for (int i = 0; i < edits.Count; i++)
                {
                    edits[i].SetExecutionUnit(configManager.ExecutionManager.listMeasureManager[i]);
                }

            }
        }
        #endregion

        #region 保存
        private void tsmi_Save_Click(object sender, EventArgs e)
        {
            if (regkey.GetValue("Path").ToString() != "")
            {
                configManager.SaveMeasureData(regkey.GetValue("Path").ToString());
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)//选择路径
            {
                regkey.SetValue("Path", saveFileDialog1.FileName);//保存路径
                configManager.SaveMeasureData(regkey.GetValue("Path").ToString());

                string str = saveFileDialog1.FileName.ToString().Substring(saveFileDialog1.FileName.LastIndexOf("\\") + 1);
                this.Text = "HRDVison" + "--" + str.Replace(".fpc", string.Empty);
            }

        }
        #endregion

        #region 另存为
        private void tsmi_SaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)//选择路径
            {
                configManager.SaveMeasureData(saveFileDialog1.FileName);
            }
        }
        #endregion

        #region 退出
        private void tsmi_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 导出数据到表格
        private void tsmi_Excel_Click(object sender, EventArgs e)
        {
            if (fbd_Excel.ShowDialog() == DialogResult.OK)
            {
                string path = fbd_Excel.SelectedPath + "\\" + DateTime.Now.Year.ToString()
                      + "年" + DateTime.Now.Month.ToString()
                      + "月" + DateTime.Now.Day.ToString()
                      + "日——" + DateTime.Now.Hour.ToString()
                      + "时" + DateTime.Now.Minute.ToString()
                      + "分" + DateTime.Now.Second.ToString()
                      + ".xls";
                configManager.ExecutionManager.DataExport(path);
            }
        }
        #endregion

        #region IO控制
        private void tsmi_IO_Click(object sender, EventArgs e)
        {
            Frm_IOControl frm_IOControl = new Frm_IOControl(this);
            frm_IOControl.ShowDialog();
        } 
        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                tsmi_SaveImage.Enabled = false;
                tsmi_SaveResultImage.Enabled = false;
            }
            else
            {
                tsmi_SaveImage.Enabled = true;
                tsmi_SaveResultImage.Enabled = true;
            }
        }


        //保存当前采集图片
        private void tsmi_SaveImage_Click(object sender, EventArgs e)
        {

            switch (tabControl1.SelectedIndex)
            {

                case 1:
                    SaveImage(1);
                    break;
                case 2:
                    SaveImage(2);
                    break;
                case 3:
                    SaveImage(3);
                    break;
                case 4:
                    SaveImage(4);
                    break;
                case 5:
                    SaveImage(5);
                    break;
                default:
                    break;
            }


        }

        //保存当前结果图片
        private void tsmi_SaveResultImage_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {

                case 1:
                    SaveResultImage(1);
                    break;
                case 2:
                    SaveResultImage(2);
                    break;
                case 3:
                    SaveResultImage(3);
                    break;
                case 4:
                    SaveResultImage(4);
                    break;
                case 5:
                    SaveResultImage(5);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 保存采集图片
        /// </summary>
        /// <param name="index"></param>
        private void SaveImage(int index)
        {
            if (sfd_Image.ShowDialog() == DialogResult.OK)
            {
                HOperatorSet.WriteImage(edits[index - 1].GetImage(), "tiff", 0, sfd_Image.FileName);
            }
        }

        /// <summary>
        /// 保存结果图像
        /// </summary>
        /// <param name="index"></param>
        private void SaveResultImage(int index)
        {
            if (sfd_Image.ShowDialog() == DialogResult.OK)
            {
                HOperatorSet.DumpWindowImage(out HObject ho_Image, edits[index - 1].GetHWindow());
                HOperatorSet.WriteImage(ho_Image, "tiff", 0, sfd_Image.FileName);
            }
        }

        private void tsmi_Login_Click(object sender, EventArgs e)
        {
            new Frm_User_Login(this).ShowDialog();
        }

        private void tsmi_Password_Click(object sender, EventArgs e)
        {
            new Frm_User_ChangePassword(this).ShowDialog();
        }

        private void tsmi_LogOut_Click(object sender, EventArgs e)
        {
            Admin(User.操作员);
        }

        //软键盘
        private void tsmi_osk_Click(object sender, EventArgs e)
        {
            Process.Start("osk.exe");

        }

        //关于软件
        private void tsmi_About_Click(object sender, EventArgs e)
        {
            new Frm_About().ShowDialog();
        }

        //软件说明
        private void tsmi_Instruction_Click(object sender, EventArgs e)
        {
            MessageBox.Show("没有说明");
        }

        private void EditAdmin(bool status)
        {
            foreach (var item in edits)
            {
                item.AdminMod(status);
            }
        }

        /// <summary>
        /// 管理员状态
        /// </summary>
        /// <param name="status"></param>
        private void AdminMod(bool status)
        {
            tsmi_New.Enabled = status;
            tsmi_Open.Enabled = status;
            tsmi_Save.Enabled = status;
            tsmi_SaveAs.Enabled = status;

            tsmi_Login.Enabled = !status;
            tsmi_LogOut.Enabled = status;


        }

        /// <summary>
        /// 用户
        /// </summary>
        /// <param name="user"></param>
        public void Admin(User user)
        {
            switch (user)
            {

                case User.操作员:
                    EditAdmin(false);
                    AdminMod(false);

                    tsmi_Test.Enabled = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    label1.Text = "操作员";


                    break;
                case User.管理员:
                    EditAdmin(true);
                    AdminMod(true);
                    tsmi_Test.Enabled = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    label1.Text = "管理员";

                    break;
                case User.程序员:
                    EditAdmin(true);
                    AdminMod(true);
                    tsmi_Test.Enabled = true;
                    button1.Visible = true;
                    button2.Visible = true;
                    label1.Text = "程序员";

                    break;
                default:

                    break;
            }
        }


        private void tsmi_Test_Click(object sender, EventArgs e)
        {
            btn_Test.PerformClick();
        }
    }
}
