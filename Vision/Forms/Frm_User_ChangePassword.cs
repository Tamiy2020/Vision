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
    public partial class Frm_User_ChangePassword : Form
    {
        Frm_Main mainForm;

        RegistryKey regkey = Registry.CurrentUser.OpenSubKey("System").OpenSubKey("HRD",true);

        public Frm_User_ChangePassword(Frm_Main form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void txt_Old_TextChanged(object sender, EventArgs e)
        {
            lbl_Old.Text = Match(txt_Old.Text);
        }

        private void txt_Old_Leave(object sender, EventArgs e)
        {
            if (txt_Old.Text == string.Empty)
            {
                lbl_Old.Text = "请输入旧密码";
            }
        }

        private void txt_Old_Enter(object sender, EventArgs e)
        {
            if (lbl_Old.Text == "请输入旧密码")
            {
                lbl_Old.Text = string.Empty;
            }
        }


        private void txt_New_TextChanged(object sender, EventArgs e)
        {
            lbl_New.Text = Match(txt_New.Text);
        }

        private void txt_New_Leave(object sender, EventArgs e)
        {
            if (txt_New.Text == string.Empty)
            {
                lbl_New.Text = "不能为空";
            }
        }

        private void txt_New_Enter(object sender, EventArgs e)
        {
            if (lbl_New.Text == "不能为空")
            {
                lbl_New.Text = string.Empty;
            }
        }


        private void txt_Confirm_TextChanged(object sender, EventArgs e)
        {
            lbl_Confirm.Text = Match(txt_Confirm.Text);
        }

        private void txt_Confirm_Leave(object sender, EventArgs e)
        {
            if (txt_Confirm.Text == String.Empty)
            {
                lbl_Confirm.Text = "不能为空";
                return;
            }
            if (txt_Confirm.Text != txt_New.Text)
            {
                lbl_Confirm.Text = "两次输入密码不一致";
            }
        }

        private void txt_Confirm_Enter(object sender, EventArgs e)
        {
            if (lbl_Confirm.Text == "不能为空")
            {
                lbl_Confirm.Text = string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_Old.Text != regkey.GetValue("Password").ToString () && txt_Old.Text != string.Empty)
            {
                lbl_Old.Text = "旧密码错误";
                return;
            }

            if (lbl_Old.Text == string.Empty)
            {
                if (txt_New.Text == string.Empty)
                {
                    lbl_New.Text = "不能为空";
                    return;
                }
                if (txt_Confirm.Text == string.Empty)
                {
                    lbl_Confirm.Text = "不能为空";
                    return;
                }
            }

            if (lbl_Old.Text == string.Empty && lbl_New.Text == string.Empty && lbl_Confirm.Text == string.Empty)
            {
                regkey.SetValue("Password", txt_Confirm.Text);
                MessageBox.Show("修改密码成功！");
                Thread.Sleep(500);
                Close();
            }
        }









        /// <summary>
        /// 密码匹配
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string Match(string text)
        {
            if (Regex.IsMatch(text, @"\D"))
            {
                return "请输入纯数字密码";
            }
            return string.Empty;
        }

       
    }
}
