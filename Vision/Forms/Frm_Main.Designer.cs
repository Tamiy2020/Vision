namespace Vision.Forms
{
    partial class Frm_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_New = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Excel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_IO = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SaveResultImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Password = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_LogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_osk = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_About = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Instruction = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btn_Test = new System.Windows.Forms.Button();
            this.btn_Live = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_Auto = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.sfd_Image = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1264, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_New,
            this.tsmi_Open,
            this.tsmi_Save,
            this.tsmi_SaveAs,
            this.toolStripSeparator1,
            this.tsmi_Exit});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(67, 29);
            this.toolStripMenuItem1.Text = "文件(&F)";
            // 
            // tsmi_New
            // 
            this.tsmi_New.Image = global::Vision.Properties.Resources.新建;
            this.tsmi_New.Name = "tsmi_New";
            this.tsmi_New.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmi_New.Size = new System.Drawing.Size(238, 24);
            this.tsmi_New.Text = "新建(&N)";
            this.tsmi_New.Click += new System.EventHandler(this.tsmi_New_Click);
            // 
            // tsmi_Open
            // 
            this.tsmi_Open.Image = global::Vision.Properties.Resources.打开;
            this.tsmi_Open.Name = "tsmi_Open";
            this.tsmi_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmi_Open.Size = new System.Drawing.Size(238, 24);
            this.tsmi_Open.Text = "打开(&O)";
            this.tsmi_Open.Click += new System.EventHandler(this.tsmi_Open_Click);
            // 
            // tsmi_Save
            // 
            this.tsmi_Save.Image = global::Vision.Properties.Resources.保存;
            this.tsmi_Save.Name = "tsmi_Save";
            this.tsmi_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmi_Save.Size = new System.Drawing.Size(238, 24);
            this.tsmi_Save.Text = "保存(&S)";
            this.tsmi_Save.Click += new System.EventHandler(this.tsmi_Save_Click);
            // 
            // tsmi_SaveAs
            // 
            this.tsmi_SaveAs.Image = global::Vision.Properties.Resources.另存为;
            this.tsmi_SaveAs.Name = "tsmi_SaveAs";
            this.tsmi_SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.tsmi_SaveAs.Size = new System.Drawing.Size(238, 24);
            this.tsmi_SaveAs.Text = "另存为(&A)";
            this.tsmi_SaveAs.Click += new System.EventHandler(this.tsmi_SaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(235, 6);
            // 
            // tsmi_Exit
            // 
            this.tsmi_Exit.Image = global::Vision.Properties.Resources.退出;
            this.tsmi_Exit.Name = "tsmi_Exit";
            this.tsmi_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tsmi_Exit.Size = new System.Drawing.Size(238, 24);
            this.tsmi_Exit.Text = "退出(&X)";
            this.tsmi_Exit.Click += new System.EventHandler(this.tsmi_Exit_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Excel,
            this.tsmi_IO,
            this.tsmi_Clear});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(70, 29);
            this.toolStripMenuItem2.Text = "设置(&O)";
            // 
            // tsmi_Excel
            // 
            this.tsmi_Excel.Name = "tsmi_Excel";
            this.tsmi_Excel.Size = new System.Drawing.Size(160, 24);
            this.tsmi_Excel.Text = "写入Excel";
            this.tsmi_Excel.Click += new System.EventHandler(this.tsmi_Excel_Click);
            // 
            // tsmi_IO
            // 
            this.tsmi_IO.Name = "tsmi_IO";
            this.tsmi_IO.Size = new System.Drawing.Size(160, 24);
            this.tsmi_IO.Text = "IO控制";
            this.tsmi_IO.Click += new System.EventHandler(this.tsmi_IO_Click);
            // 
            // tsmi_Clear
            // 
            this.tsmi_Clear.Name = "tsmi_Clear";
            this.tsmi_Clear.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmi_Clear.Size = new System.Drawing.Size(160, 24);
            this.tsmi_Clear.Text = "计数清零";
            this.tsmi_Clear.Click += new System.EventHandler(this.tsmi_Clear_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_SaveImage,
            this.tsmi_SaveResultImage});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(64, 29);
            this.toolStripMenuItem3.Text = "图像(&I)";
            // 
            // tsmi_SaveImage
            // 
            this.tsmi_SaveImage.Enabled = false;
            this.tsmi_SaveImage.Name = "tsmi_SaveImage";
            this.tsmi_SaveImage.Size = new System.Drawing.Size(190, 24);
            this.tsmi_SaveImage.Text = "保存当前采集图像";
            this.tsmi_SaveImage.Click += new System.EventHandler(this.tsmi_SaveImage_Click);
            // 
            // tsmi_SaveResultImage
            // 
            this.tsmi_SaveResultImage.Enabled = false;
            this.tsmi_SaveResultImage.Name = "tsmi_SaveResultImage";
            this.tsmi_SaveResultImage.Size = new System.Drawing.Size(190, 24);
            this.tsmi_SaveResultImage.Text = "保存当前结果图像";
            this.tsmi_SaveResultImage.Click += new System.EventHandler(this.tsmi_SaveResultImage_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Login,
            this.tsmi_Password,
            this.tsmi_LogOut});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(95, 29);
            this.toolStripMenuItem4.Text = "系统管理(&S)";
            // 
            // tsmi_Login
            // 
            this.tsmi_Login.Name = "tsmi_Login";
            this.tsmi_Login.Size = new System.Drawing.Size(134, 24);
            this.tsmi_Login.Text = "用户登录";
            this.tsmi_Login.Click += new System.EventHandler(this.tsmi_Login_Click);
            // 
            // tsmi_Password
            // 
            this.tsmi_Password.Name = "tsmi_Password";
            this.tsmi_Password.Size = new System.Drawing.Size(134, 24);
            this.tsmi_Password.Text = "密码管理";
            this.tsmi_Password.Click += new System.EventHandler(this.tsmi_Password_Click);
            // 
            // tsmi_LogOut
            // 
            this.tsmi_LogOut.Name = "tsmi_LogOut";
            this.tsmi_LogOut.Size = new System.Drawing.Size(134, 24);
            this.tsmi_LogOut.Text = "退出登录";
            this.tsmi_LogOut.Click += new System.EventHandler(this.tsmi_LogOut_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_osk,
            this.tsmi_About,
            this.tsmi_Instruction});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(71, 29);
            this.toolStripMenuItem5.Text = "帮助(&H)";
            // 
            // tsmi_osk
            // 
            this.tsmi_osk.Name = "tsmi_osk";
            this.tsmi_osk.Size = new System.Drawing.Size(134, 24);
            this.tsmi_osk.Text = "软键盘";
            this.tsmi_osk.Click += new System.EventHandler(this.tsmi_osk_Click);
            // 
            // tsmi_About
            // 
            this.tsmi_About.Name = "tsmi_About";
            this.tsmi_About.Size = new System.Drawing.Size(134, 24);
            this.tsmi_About.Text = "关于软件";
            this.tsmi_About.Click += new System.EventHandler(this.tsmi_About_Click);
            // 
            // tsmi_Instruction
            // 
            this.tsmi_Instruction.Name = "tsmi_Instruction";
            this.tsmi_Instruction.Size = new System.Drawing.Size(134, 24);
            this.tsmi_Instruction.Text = "操作说明";
            this.tsmi_Instruction.Click += new System.EventHandler(this.tsmi_Instruction_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1264, 767);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1256, 735);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "工作界面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1256, 735);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "相机1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1256, 735);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "相机2";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1256, 735);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "相机3";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 28);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1256, 735);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "相机4";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 28);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1256, 735);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "相机5";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btn_Test
            // 
            this.btn_Test.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Test.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Test.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Test.Location = new System.Drawing.Point(749, 0);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(102, 35);
            this.btn_Test.TabIndex = 2;
            this.btn_Test.Text = "手动测试";
            this.btn_Test.UseVisualStyleBackColor = false;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // btn_Live
            // 
            this.btn_Live.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Live.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Live.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Live.Location = new System.Drawing.Point(481, 0);
            this.btn_Live.Name = "btn_Live";
            this.btn_Live.Size = new System.Drawing.Size(102, 35);
            this.btn_Live.TabIndex = 3;
            this.btn_Live.Text = "实时图像";
            this.btn_Live.UseVisualStyleBackColor = false;
            this.btn_Live.Click += new System.EventHandler(this.btn_Live_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(944, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "开始测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(1060, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "停止测试";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 60;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_Auto
            // 
            this.btn_Auto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_Auto.Enabled = false;
            this.btn_Auto.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Auto.Location = new System.Drawing.Point(615, 0);
            this.btn_Auto.Name = "btn_Auto";
            this.btn_Auto.Size = new System.Drawing.Size(102, 35);
            this.btn_Auto.TabIndex = 6;
            this.btn_Auto.Text = "自动测试";
            this.btn_Auto.UseVisualStyleBackColor = true;
            this.btn_Auto.Click += new System.EventHandler(this.btn_Auto_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "FPC文件|*.fpc";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "FPC文件|*.fpc";
            // 
            // sfd_Image
            // 
            this.sfd_Image.Filter = "图片文件(*.tif)|*.tif";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 802);
            this.Controls.Add(this.btn_Auto);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Live);
            this.Controls.Add(this.btn_Test);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Vision.Properties.Resources.Logo;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HRDVision";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.Shown += new System.EventHandler(this.Frm_Main_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.Button btn_Live;
        private System.Windows.Forms.ToolStripMenuItem tsmi_New;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Open;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Save;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Exit;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Excel;
        private System.Windows.Forms.ToolStripMenuItem tsmi_IO;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Clear;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SaveImage;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SaveResultImage;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Login;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Password;
        private System.Windows.Forms.ToolStripMenuItem tsmi_LogOut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem tsmi_osk;
        private System.Windows.Forms.ToolStripMenuItem tsmi_About;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Instruction;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_Auto;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog sfd_Image;
    }
}

