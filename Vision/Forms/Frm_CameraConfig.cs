using Microsoft.Win32;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Vision.CameraLib;

namespace Vision.Forms
{
    public partial class Frm_CameraConfig : Form
    {
        /// <summary>
        /// 主窗体
        /// </summary>
        private Frm_Main form = null;

        /// <summary>
        /// 注册表
        /// </summary>
        private RegistryKey regkey = null;

        string str1 = "";
        string str2 = "";
        string str3 = "";
        string str4 = "";
        string str5 = "";

        public Frm_CameraConfig()
        {
            InitializeComponent();
            Registry.ClassesRoot.CreateSubKey(".fpc").SetValue("", "fpcfile"); //创建注册表
            Registry.ClassesRoot.CreateSubKey("fpcfile").CreateSubKey("DefaultIcon").SetValue("", "C:\\Windows\\System32\\HRD.ico");
            Registry.CurrentUser.OpenSubKey("System", true).CreateSubKey("HRD").SetValue("Password", "123456");
            Registry.CurrentUser.OpenSubKey("System", true).CreateSubKey("HRD").SetValue("SeniorPassword", "tangming");
        }

        private void Frm_CameraConfig_Load(object sender, EventArgs e)
        {
            form = new Frm_Main();

            if (form.cameraManager is DahengManager || form.cameraManager is DahuaManager)
            {
                panel2.Visible = false;
                foreach (var camera in form.cameraManager.listCamera)
                {
                    camera.Open();
                    if (camera is Dahua)
                    {
                        camera.Grad();
                    }
                    if (camera is Daheng)
                    {
                        (camera as Daheng).StartDevice();
                    }

                    comboBox1.Items.Add(camera.strName);
                }
            }
            else
            {
                panel1.Visible = false;
            }

        }


        #region 选择相机
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (regkey == null)
            {
                regkey = Registry.CurrentUser.OpenSubKey("Software", true).CreateSubKey("HRDVision"); //创建注册表
                regkey.CreateSubKey("FilePath"); //创建注册表

            }
            if (lbl_C1.Text == string.Empty)
            {
                str1 = comboBox1.SelectedItem.ToString();
                AddStr_Daheng(out string str, 1);
                lbl_C1.Text = str;
                Program.ChangeList(form.cameraManager.listCamera, str1, 0);
            }
            else if (lbl_C2.Text == string.Empty)
            {
                str2 = comboBox1.SelectedItem.ToString();
                AddStr_Daheng(out string str, 2);
                lbl_C2.Text = str;
                Program.ChangeList(form.cameraManager.listCamera, str2, 1);
            }
            else if (lbl_C3.Text == string.Empty)
            {
                str3 = comboBox1.SelectedItem.ToString();
                AddStr_Daheng(out string str, 3);
                lbl_C3.Text = str;
                Program.ChangeList(form.cameraManager.listCamera, str3, 2);

            }
            else if (lbl_C4.Text == string.Empty)
            {
                str4 = comboBox1.SelectedItem.ToString();
                AddStr_Daheng(out string str, 4);
                lbl_C4.Text = str;
                Program.ChangeList(form.cameraManager.listCamera, str4, 3);
            }
            else if (lbl_C5.Text == string.Empty)
            {
                str5 = comboBox1.SelectedItem.ToString();
                AddStr_Daheng(out string str, 5);
                lbl_C5.Text = str;
                Program.ChangeList(form.cameraManager.listCamera, str5, 4);
            }


        }

        private void AddStr_Daheng(out string str, int index)
        {
            str = $"相机{index}：" + comboBox1.SelectedItem.ToString();
            regkey.SetValue($"Camera{index}", comboBox1.SelectedItem.ToString());
            comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
        }


        private void btn_OK1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count != 0)
            {
                MessageBox.Show("您还有相机未选择");
                return;
            }
            form.SetCameraWindows(form.cameraManager.listCamera.Count);
            Program.GetWin(form.cameraWin, form.cameraManager.listCamera, str1, str2, str3, str4, str5);
            regkey.SetValue("Cameras", form.cameraManager.listCamera.Count, RegistryValueKind.DWord);
            foreach (var camera in form.cameraManager.listCamera)
            {
                if (camera is Dahua)
                {
                    regkey.SetValue($"ExposureTime{camera.Index + 1}", (camera as Dahua).GetExposureTime(), RegistryValueKind.DWord);
                    regkey.SetValue($"GainRaw{camera.Index + 1}", (camera as Dahua).GetGainRaw(), RegistryValueKind.DWord);
                }
                if (camera is Daheng)
                {
                    regkey.SetValue($"ExposureTime{camera.Index + 1}", (camera as Daheng).GetExposureTime(), RegistryValueKind.DWord);
                    regkey.SetValue($"GainRaw{camera.Index + 1}", (camera as Daheng).GetGainRaw(), RegistryValueKind.DWord);
                }
            }
            Thread.Sleep(500);
            this.Hide();
            form.Show();
        }
        #endregion


        #region 选择路径
        private void txt_Path_DoubleClick(object sender, EventArgs e)
        {
            if (fbd_Image.ShowDialog() == DialogResult.OK)
            {
                txt_Path.Text = fbd_Image.SelectedPath;
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Path.Text) || !Directory.Exists(txt_Path.Text)) return;
            if (regkey == null)
            {
                regkey = Registry.CurrentUser.OpenSubKey("Software", true).CreateSubKey("HRDVision"); //创建注册表
                regkey.CreateSubKey("FilePath"); //创建注册表
            }

            if (lbl_C1.Text == string.Empty)
            {
                str1 = txt_Path.Text;
                AddStr_File(out string str, 1);
                lbl_C1.Text = str;
            }
            else if (lbl_C2.Text == string.Empty)
            {
                str2 = txt_Path.Text;
                AddStr_File(out string str, 2);
                lbl_C2.Text = str;
            }
            else if (lbl_C3.Text == string.Empty)
            {
                str3 = txt_Path.Text;
                AddStr_File(out string str, 3);
                lbl_C3.Text = str;
            }
            else if (lbl_C4.Text == string.Empty)
            {
                str4 = txt_Path.Text;
                AddStr_File(out string str, 4);
                lbl_C4.Text = str;
            }
            else if (lbl_C5.Text == string.Empty)
            {
                str5 = txt_Path.Text;
                AddStr_File(out string str, 5);
                lbl_C5.Text = str;
            }

        }

        /// <summary>
        /// 文件类添加字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index"></param>
        private void AddStr_File(out string str, int index)
        {
            str = $"相机{index}：" + txt_Path.Text;
            (form.cameraManager as FileManager).AddCamera(txt_Path.Text);
            regkey.SetValue($"Camera{index}", txt_Path.Text);
        }

        private void btn_OK2_Click(object sender, EventArgs e)
        {
            form.SetCameraWindows(form.cameraManager.listCamera.Count);
            Program.GetWin(form.cameraWin, form.cameraManager.listCamera, str1, str2, str3, str4, str5);
            try
            {
                form.cameraManager.OpenAll();
            }
            catch (Exception)
            {

                MessageBox.Show("打开相机失败，请添加图片文件夹");
                if (regkey != null) Registry.CurrentUser.OpenSubKey("Software", true).DeleteSubKeyTree("HRDVision");//删除注册表
                Thread.Sleep(1000);
                Close();
                return;
            }
            regkey.SetValue("Cameras", form.cameraManager.listCamera.Count, RegistryValueKind.DWord);
            Thread.Sleep(500);
            this.Hide();
            form.Show();
        }

        #endregion

        private void Frm_CameraConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (regkey != null) Registry.CurrentUser.OpenSubKey("Software", true).DeleteSubKeyTree("HRDVision");//删除注册表
        }
    }
}
