namespace Vision.Forms
{
    partial class Frm_User_ChangePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Confirm = new System.Windows.Forms.Label();
            this.lbl_New = new System.Windows.Forms.Label();
            this.lbl_Old = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_Confirm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_New = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Old = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Confirm
            // 
            this.lbl_Confirm.AutoSize = true;
            this.lbl_Confirm.ForeColor = System.Drawing.Color.Red;
            this.lbl_Confirm.Location = new System.Drawing.Point(31, 213);
            this.lbl_Confirm.Name = "lbl_Confirm";
            this.lbl_Confirm.Size = new System.Drawing.Size(0, 17);
            this.lbl_Confirm.TabIndex = 28;
            // 
            // lbl_New
            // 
            this.lbl_New.AutoSize = true;
            this.lbl_New.ForeColor = System.Drawing.Color.Red;
            this.lbl_New.Location = new System.Drawing.Point(45, 147);
            this.lbl_New.Name = "lbl_New";
            this.lbl_New.Size = new System.Drawing.Size(0, 17);
            this.lbl_New.TabIndex = 27;
            // 
            // lbl_Old
            // 
            this.lbl_Old.AutoSize = true;
            this.lbl_Old.ForeColor = System.Drawing.Color.Red;
            this.lbl_Old.Location = new System.Drawing.Point(45, 81);
            this.lbl_Old.Name = "lbl_Old";
            this.lbl_Old.Size = new System.Drawing.Size(0, 17);
            this.lbl_Old.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 49);
            this.button1.TabIndex = 25;
            this.button1.Text = "修改密码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_Confirm
            // 
            this.txt_Confirm.Location = new System.Drawing.Point(126, 174);
            this.txt_Confirm.MaxLength = 6;
            this.txt_Confirm.Name = "txt_Confirm";
            this.txt_Confirm.PasswordChar = '●';
            this.txt_Confirm.Size = new System.Drawing.Size(128, 23);
            this.txt_Confirm.TabIndex = 24;
            this.txt_Confirm.TextChanged += new System.EventHandler(this.txt_Confirm_TextChanged);
            this.txt_Confirm.Enter += new System.EventHandler(this.txt_Confirm_Enter);
            this.txt_Confirm.Leave += new System.EventHandler(this.txt_Confirm_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "确认密码：";
            // 
            // txt_New
            // 
            this.txt_New.Location = new System.Drawing.Point(126, 108);
            this.txt_New.MaxLength = 6;
            this.txt_New.Name = "txt_New";
            this.txt_New.PasswordChar = '●';
            this.txt_New.Size = new System.Drawing.Size(128, 23);
            this.txt_New.TabIndex = 22;
            this.txt_New.TextChanged += new System.EventHandler(this.txt_New_TextChanged);
            this.txt_New.Enter += new System.EventHandler(this.txt_New_Enter);
            this.txt_New.Leave += new System.EventHandler(this.txt_New_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "新密码：";
            // 
            // txt_Old
            // 
            this.txt_Old.Location = new System.Drawing.Point(126, 42);
            this.txt_Old.MaxLength = 6;
            this.txt_Old.Name = "txt_Old";
            this.txt_Old.PasswordChar = '●';
            this.txt_Old.Size = new System.Drawing.Size(128, 23);
            this.txt_Old.TabIndex = 20;
            this.txt_Old.TextChanged += new System.EventHandler(this.txt_Old_TextChanged);
            this.txt_Old.Enter += new System.EventHandler(this.txt_Old_Enter);
            this.txt_Old.Leave += new System.EventHandler(this.txt_Old_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "旧密码：";
            // 
            // Frm_User_ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 331);
            this.Controls.Add(this.lbl_Confirm);
            this.Controls.Add(this.lbl_New);
            this.Controls.Add(this.lbl_Old);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_Confirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_New);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Old);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_User_ChangePassword";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理员密码修改";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Confirm;
        private System.Windows.Forms.Label lbl_New;
        private System.Windows.Forms.Label lbl_Old;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_Confirm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_New;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Old;
        private System.Windows.Forms.Label label1;
    }
}