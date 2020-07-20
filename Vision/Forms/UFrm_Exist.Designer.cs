namespace Vision.Forms
{
    partial class UFrm_Exist
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.hWindow_Final1 = new ChoiceTech.Halcon.Control.HWindow_Final();
            this.lbl_Area = new System.Windows.Forms.Label();
            this.rdo_ExistTwo = new System.Windows.Forms.RadioButton();
            this.rdo_Exist = new System.Windows.Forms.RadioButton();
            this.nud_MaxValue = new System.Windows.Forms.NumericUpDown();
            this.nud_MinValue = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.trb_MaxGray = new System.Windows.Forms.TrackBar();
            this.nud_MaxGray = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.trb_MinGray = new System.Windows.Forms.TrackBar();
            this.nud_MinGray = new System.Windows.Forms.NumericUpDown();
            this.btn_SelectROI = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinValue)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trb_MaxGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_MinGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinGray)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.hWindow_Final1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbl_Area);
            this.splitContainer1.Panel2.Controls.Add(this.rdo_ExistTwo);
            this.splitContainer1.Panel2.Controls.Add(this.rdo_Exist);
            this.splitContainer1.Panel2.Controls.Add(this.nud_MaxValue);
            this.splitContainer1.Panel2.Controls.Add(this.nud_MinValue);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Cancel);
            this.splitContainer1.Panel2.Controls.Add(this.btn_OK);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Name);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btn_SelectROI);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer1.Size = new System.Drawing.Size(1292, 796);
            this.splitContainer1.SplitterDistance = 842;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // hWindow_Final1
            // 
            this.hWindow_Final1.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hWindow_Final1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindow_Final1.DrawModel = false;
            this.hWindow_Final1.EditModel = true;
            this.hWindow_Final1.Image = null;
            this.hWindow_Final1.Location = new System.Drawing.Point(0, 0);
            this.hWindow_Final1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hWindow_Final1.Name = "hWindow_Final1";
            this.hWindow_Final1.Size = new System.Drawing.Size(842, 796);
            this.hWindow_Final1.TabIndex = 0;
            // 
            // lbl_Area
            // 
            this.lbl_Area.AutoSize = true;
            this.lbl_Area.Location = new System.Drawing.Point(349, 79);
            this.lbl_Area.Name = "lbl_Area";
            this.lbl_Area.Size = new System.Drawing.Size(15, 17);
            this.lbl_Area.TabIndex = 57;
            this.lbl_Area.Text = "0";
            // 
            // rdo_ExistTwo
            // 
            this.rdo_ExistTwo.AutoSize = true;
            this.rdo_ExistTwo.Checked = true;
            this.rdo_ExistTwo.Location = new System.Drawing.Point(27, 409);
            this.rdo_ExistTwo.Name = "rdo_ExistTwo";
            this.rdo_ExistTwo.Size = new System.Drawing.Size(74, 21);
            this.rdo_ExistTwo.TabIndex = 55;
            this.rdo_ExistTwo.TabStop = true;
            this.rdo_ExistTwo.Text = "缺陷检测";
            this.rdo_ExistTwo.UseVisualStyleBackColor = true;
            // 
            // rdo_Exist
            // 
            this.rdo_Exist.AutoSize = true;
            this.rdo_Exist.Location = new System.Drawing.Point(351, 409);
            this.rdo_Exist.Name = "rdo_Exist";
            this.rdo_Exist.Size = new System.Drawing.Size(74, 21);
            this.rdo_Exist.TabIndex = 56;
            this.rdo_Exist.Text = "产品有无";
            this.rdo_Exist.UseVisualStyleBackColor = true;
            this.rdo_Exist.CheckedChanged += new System.EventHandler(this.rdo_Exist_CheckedChanged);
            // 
            // nud_MaxValue
            // 
            this.nud_MaxValue.Location = new System.Drawing.Point(351, 312);
            this.nud_MaxValue.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nud_MaxValue.Name = "nud_MaxValue";
            this.nud_MaxValue.Size = new System.Drawing.Size(88, 23);
            this.nud_MaxValue.TabIndex = 52;
            this.nud_MaxValue.ValueChanged += new System.EventHandler(this.nud_MaxValue_ValueChanged);
            // 
            // nud_MinValue
            // 
            this.nud_MinValue.Location = new System.Drawing.Point(26, 312);
            this.nud_MinValue.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nud_MinValue.Name = "nud_MinValue";
            this.nud_MinValue.Size = new System.Drawing.Size(90, 23);
            this.nud_MinValue.TabIndex = 51;
            this.nud_MinValue.ValueChanged += new System.EventHandler(this.nud_MinValue_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 53;
            this.label5.Text = "最大值";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 54;
            this.label4.Text = "最小值";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(26, 605);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 27);
            this.btn_Cancel.TabIndex = 50;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(352, 605);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 27);
            this.btn_OK.TabIndex = 49;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(131, 73);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(151, 23);
            this.txt_Name.TabIndex = 48;
            this.txt_Name.Text = "有无";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 47;
            this.label1.Text = "请输入名字：";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.trb_MaxGray);
            this.groupBox1.Controls.Add(this.nud_MaxGray);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.trb_MinGray);
            this.groupBox1.Controls.Add(this.nud_MinGray);
            this.groupBox1.Location = new System.Drawing.Point(2, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 130);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "阈值调整";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "上限灰度值";
            // 
            // trb_MaxGray
            // 
            this.trb_MaxGray.AutoSize = false;
            this.trb_MaxGray.BackColor = System.Drawing.Color.LightGreen;
            this.trb_MaxGray.LargeChange = 1;
            this.trb_MaxGray.Location = new System.Drawing.Point(80, 70);
            this.trb_MaxGray.Maximum = 255;
            this.trb_MaxGray.Name = "trb_MaxGray";
            this.trb_MaxGray.Size = new System.Drawing.Size(345, 43);
            this.trb_MaxGray.TabIndex = 15;
            this.trb_MaxGray.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trb_MaxGray.Value = 255;
            this.trb_MaxGray.Scroll += new System.EventHandler(this.trb_MaxGray_Scroll);
            // 
            // nud_MaxGray
            // 
            this.nud_MaxGray.Location = new System.Drawing.Point(9, 90);
            this.nud_MaxGray.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_MaxGray.Name = "nud_MaxGray";
            this.nud_MaxGray.Size = new System.Drawing.Size(48, 23);
            this.nud_MaxGray.TabIndex = 16;
            this.nud_MaxGray.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_MaxGray.ValueChanged += new System.EventHandler(this.nud_MaxGray_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "下限灰度值";
            // 
            // trb_MinGray
            // 
            this.trb_MinGray.AutoSize = false;
            this.trb_MinGray.BackColor = System.Drawing.Color.Wheat;
            this.trb_MinGray.LargeChange = 1;
            this.trb_MinGray.Location = new System.Drawing.Point(80, 26);
            this.trb_MinGray.Maximum = 255;
            this.trb_MinGray.Name = "trb_MinGray";
            this.trb_MinGray.Size = new System.Drawing.Size(345, 43);
            this.trb_MinGray.TabIndex = 12;
            this.trb_MinGray.Scroll += new System.EventHandler(this.trb_MinGray_Scroll);
            // 
            // nud_MinGray
            // 
            this.nud_MinGray.Location = new System.Drawing.Point(9, 46);
            this.nud_MinGray.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_MinGray.Name = "nud_MinGray";
            this.nud_MinGray.Size = new System.Drawing.Size(48, 23);
            this.nud_MinGray.TabIndex = 13;
            this.nud_MinGray.ValueChanged += new System.EventHandler(this.nud_MinGray_ValueChanged);
            // 
            // btn_SelectROI
            // 
            this.btn_SelectROI.Location = new System.Drawing.Point(14, 12);
            this.btn_SelectROI.Name = "btn_SelectROI";
            this.btn_SelectROI.Size = new System.Drawing.Size(130, 37);
            this.btn_SelectROI.TabIndex = 45;
            this.btn_SelectROI.Text = "框选区域";
            this.btn_SelectROI.UseVisualStyleBackColor = true;
            this.btn_SelectROI.Click += new System.EventHandler(this.btn_SelectROI_Click);
            // 
            // UFrm_Exist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 796);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UFrm_Exist";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "缺陷检测窗体";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UFrm_Exist_FormClosing);
            this.Load += new System.EventHandler(this.UFrm_Exist_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinValue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trb_MaxGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_MinGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinGray)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        protected System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trb_MaxGray;
        private System.Windows.Forms.NumericUpDown nud_MaxGray;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trb_MinGray;
        private System.Windows.Forms.NumericUpDown nud_MinGray;
        private System.Windows.Forms.Button btn_SelectROI;
        private ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final1;
        private System.Windows.Forms.RadioButton rdo_ExistTwo;
        private System.Windows.Forms.RadioButton rdo_Exist;
        private System.Windows.Forms.NumericUpDown nud_MaxValue;
        private System.Windows.Forms.NumericUpDown nud_MinValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Area;
    }
}