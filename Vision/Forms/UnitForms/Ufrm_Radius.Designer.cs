namespace Vision.Forms
{
    partial class Ufrm_Radius
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lab_MinValue = new System.Windows.Forms.Label();
            this.nud_RealValue = new System.Windows.Forms.NumericUpDown();
            this.nud_MinValue = new System.Windows.Forms.NumericUpDown();
            this.nud_k = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_MaxValue = new System.Windows.Forms.NumericUpDown();
            this.lab_MaxValue = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_Calck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Circles = new System.Windows.Forms.ComboBox();
            this.nud_Spacing = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RealValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_k)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Spacing)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.btn_Cancel);
            this.splitContainer1.Panel2.Controls.Add(this.btn_OK);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.cmb_Circles);
            this.splitContainer1.Panel2.Controls.Add(this.nud_Spacing);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Name);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1292, 796);
            this.splitContainer1.SplitterDistance = 854;
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
            this.hWindow_Final1.Size = new System.Drawing.Size(854, 796);
            this.hWindow_Final1.TabIndex = 0;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(28, 757);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 27);
            this.btn_Cancel.TabIndex = 83;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(344, 757);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 27);
            this.btn_OK.TabIndex = 82;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.lab_MinValue);
            this.groupBox1.Controls.Add(this.nud_RealValue);
            this.groupBox1.Controls.Add(this.nud_MinValue);
            this.groupBox1.Controls.Add(this.nud_k);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nud_MaxValue);
            this.groupBox1.Controls.Add(this.lab_MaxValue);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.btn_Calck);
            this.groupBox1.Location = new System.Drawing.Point(8, 280);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 148);
            this.groupBox1.TabIndex = 80;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据管控";
            // 
            // lab_MinValue
            // 
            this.lab_MinValue.AutoSize = true;
            this.lab_MinValue.Location = new System.Drawing.Point(173, 35);
            this.lab_MinValue.Name = "lab_MinValue";
            this.lab_MinValue.Size = new System.Drawing.Size(92, 17);
            this.lab_MinValue.TabIndex = 88;
            this.lab_MinValue.Text = "最小值（mm）";
            // 
            // nud_RealValue
            // 
            this.nud_RealValue.DecimalPlaces = 3;
            this.nud_RealValue.Location = new System.Drawing.Point(322, 94);
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
            this.nud_RealValue.Size = new System.Drawing.Size(89, 23);
            this.nud_RealValue.TabIndex = 82;
            // 
            // nud_MinValue
            // 
            this.nud_MinValue.DecimalPlaces = 3;
            this.nud_MinValue.Location = new System.Drawing.Point(176, 55);
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
            this.nud_MinValue.TabIndex = 80;
            this.nud_MinValue.ValueChanged += new System.EventHandler(this.nud_MinValue_ValueChanged);
            // 
            // nud_k
            // 
            this.nud_k.DecimalPlaces = 8;
            this.nud_k.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nud_k.Location = new System.Drawing.Point(11, 94);
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
            this.nud_k.TabIndex = 85;
            this.nud_k.ValueChanged += new System.EventHandler(this.nud_k_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 84;
            this.label4.Text = "单位像素长度（k）";
            // 
            // nud_MaxValue
            // 
            this.nud_MaxValue.DecimalPlaces = 3;
            this.nud_MaxValue.Location = new System.Drawing.Point(175, 94);
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
            this.nud_MaxValue.TabIndex = 81;
            this.nud_MaxValue.ValueChanged += new System.EventHandler(this.nud_MaxValue_ValueChanged);
            // 
            // lab_MaxValue
            // 
            this.lab_MaxValue.AutoSize = true;
            this.lab_MaxValue.Location = new System.Drawing.Point(173, 79);
            this.lab_MaxValue.Name = "lab_MaxValue";
            this.lab_MaxValue.Size = new System.Drawing.Size(92, 17);
            this.lab_MaxValue.TabIndex = 83;
            this.lab_MaxValue.Text = "最大值（mm）";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(323, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 17);
            this.label13.TabIndex = 86;
            this.label13.Text = "测量结果（mm）";
            // 
            // btn_Calck
            // 
            this.btn_Calck.Location = new System.Drawing.Point(322, 54);
            this.btn_Calck.Name = "btn_Calck";
            this.btn_Calck.Size = new System.Drawing.Size(89, 23);
            this.btn_Calck.TabIndex = 87;
            this.btn_Calck.Text = "计算k值";
            this.btn_Calck.UseVisualStyleBackColor = true;
            this.btn_Calck.Click += new System.EventHandler(this.btn_Calck_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 73;
            this.label2.Text = "请选择圆：";
            // 
            // cmb_Circles
            // 
            this.cmb_Circles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Circles.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_Circles.FormattingEnabled = true;
            this.cmb_Circles.Location = new System.Drawing.Point(182, 168);
            this.cmb_Circles.Name = "cmb_Circles";
            this.cmb_Circles.Size = new System.Drawing.Size(68, 25);
            this.cmb_Circles.TabIndex = 72;
            this.cmb_Circles.SelectedIndexChanged += new System.EventHandler(this.cmb_Circles_SelectedIndexChanged);
            // 
            // nud_Spacing
            // 
            this.nud_Spacing.Location = new System.Drawing.Point(182, 105);
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
            this.nud_Spacing.Size = new System.Drawing.Size(70, 23);
            this.nud_Spacing.TabIndex = 68;
            this.nud_Spacing.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_Spacing.ValueChanged += new System.EventHandler(this.nud_Spacing_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 69;
            this.label3.Text = "字符间距调整：";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(182, 40);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(172, 23);
            this.txt_Name.TabIndex = 71;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 70;
            this.label1.Text = "请输入名字：";
            // 
            // Ufrm_Radius
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
            this.Name = "Ufrm_Radius";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "半径计算窗体";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ufrm_Radius_FormClosing);
            this.Load += new System.EventHandler(this.Ufrm_Radius_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RealValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_k)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Spacing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Circles;
        private System.Windows.Forms.NumericUpDown nud_Spacing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lab_MinValue;
        private System.Windows.Forms.NumericUpDown nud_RealValue;
        private System.Windows.Forms.NumericUpDown nud_MinValue;
        private System.Windows.Forms.NumericUpDown nud_k;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud_MaxValue;
        private System.Windows.Forms.Label lab_MaxValue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_Calck;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
    }
}