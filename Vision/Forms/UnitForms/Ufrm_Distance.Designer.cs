namespace Vision.Forms
{
    partial class Ufrm_Distance
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
            this.nud_Spacing = new System.Windows.Forms.NumericUpDown();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nud_RealValue = new System.Windows.Forms.NumericUpDown();
            this.btn_Calck = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.nud_k = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lab_MinValue = new System.Windows.Forms.Label();
            this.nud_MaxValue = new System.Windows.Forms.NumericUpDown();
            this.lab_MaxValue = new System.Windows.Forms.Label();
            this.nud_MinValue = new System.Windows.Forms.NumericUpDown();
            this.cmb_Item2 = new System.Windows.Forms.ComboBox();
            this.lab_Item2 = new System.Windows.Forms.Label();
            this.cmb_Item1 = new System.Windows.Forms.ComboBox();
            this.lab_Item1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdo_PTP = new System.Windows.Forms.RadioButton();
            this.rdo_LTL = new System.Windows.Forms.RadioButton();
            this.rdo_PTL = new System.Windows.Forms.RadioButton();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Spacing)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RealValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_k)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinValue)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.nud_Spacing);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Cancel);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.btn_OK);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.cmb_Item2);
            this.splitContainer1.Panel2.Controls.Add(this.lab_Item2);
            this.splitContainer1.Panel2.Controls.Add(this.cmb_Item1);
            this.splitContainer1.Panel2.Controls.Add(this.lab_Item1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Name);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1292, 796);
            this.splitContainer1.SplitterDistance = 851;
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
            this.hWindow_Final1.Name = "hWindow_Final1";
            this.hWindow_Final1.Size = new System.Drawing.Size(851, 796);
            this.hWindow_Final1.TabIndex = 0;
            // 
            // nud_Spacing
            // 
            this.nud_Spacing.Location = new System.Drawing.Point(143, 80);
            this.nud_Spacing.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.nud_Spacing.Minimum = new decimal(new int[] {
            1500,
            0,
            0,
            -2147483648});
            this.nud_Spacing.Name = "nud_Spacing";
            this.nud_Spacing.Size = new System.Drawing.Size(61, 23);
            this.nud_Spacing.TabIndex = 5;
            this.nud_Spacing.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_Spacing.ValueChanged += new System.EventHandler(this.nud_Spacing_ValueChanged);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(15, 757);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 27);
            this.btn_Cancel.TabIndex = 63;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "字符间距调整：";
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(353, 757);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 27);
            this.btn_OK.TabIndex = 62;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.nud_RealValue);
            this.groupBox2.Controls.Add(this.btn_Calck);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.nud_k);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lab_MinValue);
            this.groupBox2.Controls.Add(this.nud_MaxValue);
            this.groupBox2.Controls.Add(this.lab_MaxValue);
            this.groupBox2.Controls.Add(this.nud_MinValue);
            this.groupBox2.Location = new System.Drawing.Point(5, 388);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 124);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据管控";
            // 
            // nud_RealValue
            // 
            this.nud_RealValue.DecimalPlaces = 3;
            this.nud_RealValue.Location = new System.Drawing.Point(325, 88);
            this.nud_RealValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_RealValue.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nud_RealValue.Name = "nud_RealValue";
            this.nud_RealValue.Size = new System.Drawing.Size(90, 23);
            this.nud_RealValue.TabIndex = 64;
            // 
            // btn_Calck
            // 
            this.btn_Calck.Location = new System.Drawing.Point(325, 45);
            this.btn_Calck.Name = "btn_Calck";
            this.btn_Calck.Size = new System.Drawing.Size(90, 23);
            this.btn_Calck.TabIndex = 70;
            this.btn_Calck.Text = "计算k值";
            this.btn_Calck.UseVisualStyleBackColor = true;
            this.btn_Calck.Click += new System.EventHandler(this.btn_Calck_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(325, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 17);
            this.label13.TabIndex = 69;
            this.label13.Text = "测量结果（mm）";
            // 
            // nud_k
            // 
            this.nud_k.DecimalPlaces = 8;
            this.nud_k.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nud_k.Location = new System.Drawing.Point(9, 85);
            this.nud_k.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_k.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nud_k.Name = "nud_k";
            this.nud_k.Size = new System.Drawing.Size(108, 23);
            this.nud_k.TabIndex = 68;
            this.nud_k.ValueChanged += new System.EventHandler(this.nud_k_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 66;
            this.label4.Text = "单位像素长度（k）";
            // 
            // lab_MinValue
            // 
            this.lab_MinValue.AutoSize = true;
            this.lab_MinValue.Location = new System.Drawing.Point(174, 30);
            this.lab_MinValue.Name = "lab_MinValue";
            this.lab_MinValue.Size = new System.Drawing.Size(92, 17);
            this.lab_MinValue.TabIndex = 67;
            this.lab_MinValue.Text = "最小值（mm）";
            // 
            // nud_MaxValue
            // 
            this.nud_MaxValue.DecimalPlaces = 3;
            this.nud_MaxValue.Location = new System.Drawing.Point(176, 85);
            this.nud_MaxValue.Margin = new System.Windows.Forms.Padding(0);
            this.nud_MaxValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_MaxValue.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nud_MaxValue.Name = "nud_MaxValue";
            this.nud_MaxValue.Size = new System.Drawing.Size(90, 23);
            this.nud_MaxValue.TabIndex = 63;
            this.nud_MaxValue.ValueChanged += new System.EventHandler(this.nud_MaxValue_ValueChanged);
            // 
            // lab_MaxValue
            // 
            this.lab_MaxValue.AutoSize = true;
            this.lab_MaxValue.Location = new System.Drawing.Point(174, 70);
            this.lab_MaxValue.Name = "lab_MaxValue";
            this.lab_MaxValue.Size = new System.Drawing.Size(92, 17);
            this.lab_MaxValue.TabIndex = 65;
            this.lab_MaxValue.Text = "最大值（mm）";
            // 
            // nud_MinValue
            // 
            this.nud_MinValue.DecimalPlaces = 3;
            this.nud_MinValue.Location = new System.Drawing.Point(176, 46);
            this.nud_MinValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_MinValue.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nud_MinValue.Name = "nud_MinValue";
            this.nud_MinValue.Size = new System.Drawing.Size(90, 23);
            this.nud_MinValue.TabIndex = 62;
            this.nud_MinValue.ValueChanged += new System.EventHandler(this.nud_MinValue_ValueChanged);
            // 
            // cmb_Item2
            // 
            this.cmb_Item2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Item2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_Item2.FormattingEnabled = true;
            this.cmb_Item2.Location = new System.Drawing.Point(295, 275);
            this.cmb_Item2.Name = "cmb_Item2";
            this.cmb_Item2.Size = new System.Drawing.Size(121, 25);
            this.cmb_Item2.TabIndex = 60;
            this.cmb_Item2.SelectedIndexChanged += new System.EventHandler(this.cmb_Item2_SelectedIndexChanged);
            // 
            // lab_Item2
            // 
            this.lab_Item2.AutoSize = true;
            this.lab_Item2.Location = new System.Drawing.Point(295, 255);
            this.lab_Item2.Name = "lab_Item2";
            this.lab_Item2.Size = new System.Drawing.Size(39, 17);
            this.lab_Item2.TabIndex = 59;
            this.lab_Item2.Text = "项目2";
            // 
            // cmb_Item1
            // 
            this.cmb_Item1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Item1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_Item1.FormattingEnabled = true;
            this.cmb_Item1.Location = new System.Drawing.Point(11, 275);
            this.cmb_Item1.Name = "cmb_Item1";
            this.cmb_Item1.Size = new System.Drawing.Size(121, 25);
            this.cmb_Item1.TabIndex = 58;
            this.cmb_Item1.SelectedIndexChanged += new System.EventHandler(this.cmb_Item1_SelectedIndexChanged);
            // 
            // lab_Item1
            // 
            this.lab_Item1.AutoSize = true;
            this.lab_Item1.Location = new System.Drawing.Point(11, 255);
            this.lab_Item1.Name = "lab_Item1";
            this.lab_Item1.Size = new System.Drawing.Size(39, 17);
            this.lab_Item1.TabIndex = 57;
            this.lab_Item1.Text = "项目1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.rdo_PTP);
            this.groupBox1.Controls.Add(this.rdo_LTL);
            this.groupBox1.Controls.Add(this.rdo_PTL);
            this.groupBox1.Location = new System.Drawing.Point(3, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 75);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测量方式";
            // 
            // rdo_PTP
            // 
            this.rdo_PTP.AutoSize = true;
            this.rdo_PTP.Location = new System.Drawing.Point(15, 33);
            this.rdo_PTP.Name = "rdo_PTP";
            this.rdo_PTP.Size = new System.Drawing.Size(62, 21);
            this.rdo_PTP.TabIndex = 55;
            this.rdo_PTP.Text = "点到点";
            this.rdo_PTP.UseVisualStyleBackColor = true;
            this.rdo_PTP.CheckedChanged += new System.EventHandler(this.rdo_PTP_CheckedChanged);
            // 
            // rdo_LTL
            // 
            this.rdo_LTL.AutoSize = true;
            this.rdo_LTL.Location = new System.Drawing.Point(227, 33);
            this.rdo_LTL.Name = "rdo_LTL";
            this.rdo_LTL.Size = new System.Drawing.Size(62, 21);
            this.rdo_LTL.TabIndex = 53;
            this.rdo_LTL.Text = "线到线";
            this.rdo_LTL.UseVisualStyleBackColor = true;
            this.rdo_LTL.CheckedChanged += new System.EventHandler(this.rdo_LTL_CheckedChanged);
            // 
            // rdo_PTL
            // 
            this.rdo_PTL.AutoSize = true;
            this.rdo_PTL.Location = new System.Drawing.Point(121, 33);
            this.rdo_PTL.Name = "rdo_PTL";
            this.rdo_PTL.Size = new System.Drawing.Size(62, 21);
            this.rdo_PTL.TabIndex = 54;
            this.rdo_PTL.Text = "点到线";
            this.rdo_PTL.UseVisualStyleBackColor = true;
            this.rdo_PTL.CheckedChanged += new System.EventHandler(this.rdo_PTL_CheckedChanged);
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(143, 17);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(151, 23);
            this.txt_Name.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 51;
            this.label1.Text = "请输入名字：";
            // 
            // Ufrm_Distance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 796);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ufrm_Distance";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "距离测量窗体";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ufrm_Distance_FormClosing);
            this.Load += new System.EventHandler(this.Ufrm_Distance_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Spacing)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RealValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_k)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinValue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nud_RealValue;
        private System.Windows.Forms.Button btn_Calck;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nud_k;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lab_MinValue;
        private System.Windows.Forms.NumericUpDown nud_MaxValue;
        private System.Windows.Forms.Label lab_MaxValue;
        private System.Windows.Forms.NumericUpDown nud_MinValue;
        private System.Windows.Forms.ComboBox cmb_Item2;
        private System.Windows.Forms.Label lab_Item2;
        private System.Windows.Forms.ComboBox cmb_Item1;
        private System.Windows.Forms.Label lab_Item1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdo_PTP;
        private System.Windows.Forms.RadioButton rdo_LTL;
        private System.Windows.Forms.RadioButton rdo_PTL;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        protected System.Windows.Forms.NumericUpDown nud_Spacing;
        private System.Windows.Forms.Label label3;
    }
}