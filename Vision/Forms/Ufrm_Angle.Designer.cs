namespace Vision.Forms
{
    partial class Ufrm_Angle
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
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_Item1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_Item2 = new System.Windows.Forms.ComboBox();
            this.txt_RealValue = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lab_MinValue = new System.Windows.Forms.Label();
            this.nud_MinValue = new System.Windows.Forms.NumericUpDown();
            this.nud_MaxValue = new System.Windows.Forms.NumericUpDown();
            this.lab_MaxValue = new System.Windows.Forms.Label();
            this.cbx_AlwaysMinAngel = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Spacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxValue)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.btn_Cancel);
            this.splitContainer1.Panel2.Controls.Add(this.btn_OK);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.cbx_AlwaysMinAngel);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.cmb_Item2);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.cmb_Item1);
            this.splitContainer1.Panel2.Controls.Add(this.nud_Spacing);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Name);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1292, 796);
            this.splitContainer1.SplitterDistance = 848;
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
            this.hWindow_Final1.Size = new System.Drawing.Size(848, 796);
            this.hWindow_Final1.TabIndex = 0;
            // 
            // nud_Spacing
            // 
            this.nud_Spacing.Location = new System.Drawing.Point(173, 88);
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
            this.nud_Spacing.TabIndex = 64;
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
            this.label3.Location = new System.Drawing.Point(26, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 65;
            this.label3.Text = "字符间距调整：";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(173, 26);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(172, 23);
            this.txt_Name.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 66;
            this.label1.Text = "请输入名字：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 17);
            this.label4.TabIndex = 69;
            this.label4.Text = "线1";
            // 
            // cmb_Item1
            // 
            this.cmb_Item1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Item1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_Item1.FormattingEnabled = true;
            this.cmb_Item1.Location = new System.Drawing.Point(29, 176);
            this.cmb_Item1.Name = "cmb_Item1";
            this.cmb_Item1.Size = new System.Drawing.Size(121, 25);
            this.cmb_Item1.TabIndex = 68;
            this.cmb_Item1.SelectedIndexChanged += new System.EventHandler(this.cmb_Item1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(282, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 17);
            this.label5.TabIndex = 71;
            this.label5.Text = "线2";
            // 
            // cmb_Item2
            // 
            this.cmb_Item2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Item2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_Item2.FormattingEnabled = true;
            this.cmb_Item2.Location = new System.Drawing.Point(282, 176);
            this.cmb_Item2.Name = "cmb_Item2";
            this.cmb_Item2.Size = new System.Drawing.Size(121, 25);
            this.cmb_Item2.TabIndex = 70;
            this.cmb_Item2.SelectedIndexChanged += new System.EventHandler(this.cmb_Item2_SelectedIndexChanged);
            // 
            // txt_RealValue
            // 
            this.txt_RealValue.Location = new System.Drawing.Point(261, 58);
            this.txt_RealValue.MaxLength = 4;
            this.txt_RealValue.Name = "txt_RealValue";
            this.txt_RealValue.ReadOnly = true;
            this.txt_RealValue.Size = new System.Drawing.Size(100, 23);
            this.txt_RealValue.TabIndex = 74;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(258, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 17);
            this.label13.TabIndex = 77;
            this.label13.Text = "测量结果（°）";
            // 
            // lab_MinValue
            // 
            this.lab_MinValue.AutoSize = true;
            this.lab_MinValue.Location = new System.Drawing.Point(6, 42);
            this.lab_MinValue.Name = "lab_MinValue";
            this.lab_MinValue.Size = new System.Drawing.Size(73, 17);
            this.lab_MinValue.TabIndex = 76;
            this.lab_MinValue.Text = "最小值（°）";
            // 
            // nud_MinValue
            // 
            this.nud_MinValue.DecimalPlaces = 1;
            this.nud_MinValue.Location = new System.Drawing.Point(7, 59);
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
            this.nud_MinValue.TabIndex = 72;
            this.nud_MinValue.ValueChanged += new System.EventHandler(this.nud_MinValue_ValueChanged);
            // 
            // nud_MaxValue
            // 
            this.nud_MaxValue.DecimalPlaces = 1;
            this.nud_MaxValue.Location = new System.Drawing.Point(133, 60);
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
            this.nud_MaxValue.TabIndex = 73;
            this.nud_MaxValue.ValueChanged += new System.EventHandler(this.nud_MaxValue_ValueChanged);
            // 
            // lab_MaxValue
            // 
            this.lab_MaxValue.AutoSize = true;
            this.lab_MaxValue.Location = new System.Drawing.Point(132, 42);
            this.lab_MaxValue.Name = "lab_MaxValue";
            this.lab_MaxValue.Size = new System.Drawing.Size(73, 17);
            this.lab_MaxValue.TabIndex = 75;
            this.lab_MaxValue.Text = "最大值（°）";
            // 
            // cbx_AlwaysMinAngel
            // 
            this.cbx_AlwaysMinAngel.AutoSize = true;
            this.cbx_AlwaysMinAngel.Checked = true;
            this.cbx_AlwaysMinAngel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_AlwaysMinAngel.Location = new System.Drawing.Point(332, 90);
            this.cbx_AlwaysMinAngel.Name = "cbx_AlwaysMinAngel";
            this.cbx_AlwaysMinAngel.Size = new System.Drawing.Size(99, 21);
            this.cbx_AlwaysMinAngel.TabIndex = 78;
            this.cbx_AlwaysMinAngel.Text = "总是选择锐角";
            this.cbx_AlwaysMinAngel.UseVisualStyleBackColor = true;
            this.cbx_AlwaysMinAngel.CheckedChanged += new System.EventHandler(this.cbx_AlwaysMinAngel_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.lab_MinValue);
            this.groupBox1.Controls.Add(this.lab_MaxValue);
            this.groupBox1.Controls.Add(this.txt_RealValue);
            this.groupBox1.Controls.Add(this.nud_MaxValue);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.nud_MinValue);
            this.groupBox1.Location = new System.Drawing.Point(5, 263);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 127);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据管控";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(29, 680);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 27);
            this.btn_Cancel.TabIndex = 81;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(343, 680);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 27);
            this.btn_OK.TabIndex = 80;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // Ufrm_Angle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 796);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ufrm_Angle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角度计算窗体";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ufrm_Angle_FormClosing);
            this.Load += new System.EventHandler(this.Ufrm_Angle_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Spacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxValue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_Spacing;
        private System.Windows.Forms.CheckBox cbx_AlwaysMinAngel;
        private System.Windows.Forms.TextBox txt_RealValue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lab_MinValue;
        private System.Windows.Forms.NumericUpDown nud_MinValue;
        private System.Windows.Forms.NumericUpDown nud_MaxValue;
        private System.Windows.Forms.Label lab_MaxValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_Item2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_Item1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
    }
}