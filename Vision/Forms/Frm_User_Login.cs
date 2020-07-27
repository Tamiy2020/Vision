using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision.Forms
{
    public partial class Frm_User_Login : Form
    {
        private Frm_Main mainForm;

        RegistryKey regkey = Registry.CurrentUser.OpenSubKey("System").OpenSubKey("HRD");
        public Frm_User_Login(Frm_Main form)
        {
            InitializeComponent();
            mainForm = form;

            comboBox1.SelectedIndex = 0;//默认选择管理员
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (Regex.IsMatch(textBox1.Text, @"\D"))//正则表达式匹配（文本框textBox1为任意非数字返回true）
                {
                    lbl_Tips.Text = "请输入纯数字密码";
                    return;
                }
            }
            lbl_Tips.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                lbl_Tips.Text = "请输入密码";
                return;
            }

            if (comboBox1.SelectedIndex == 0)
            {
                Username(regkey.GetValue("Password").ToString(), User.管理员);
            }
            if (comboBox1.SelectedIndex == 1)
            {
               Username(regkey .GetValue ("SeniorPassword").ToString (), User.程序员);

            }
        }

        private void Username(string password, User user)
        {
            if (textBox1.Text == password)
            {
                MessageBox.Show("登录成功");
                mainForm.Admin(user);
                Thread.Sleep(500);
                Close();
            }
            else
            {
                MessageBox.Show("密码错误");
                textBox1.Clear();
                textBox1.Focus();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.MaxLength = 6;
            }
            else
            {
                textBox1.MaxLength = 8;
            }
        }
    }


}
