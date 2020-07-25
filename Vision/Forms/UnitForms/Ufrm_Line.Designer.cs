namespace Vision.Forms
{
    partial class Ufrm_Line
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_VerticalTracking_L = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_HorizontalTracking = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_Threshold = new System.Windows.Forms.TabPage();
            this.nud_slg_b_pex = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.rdo_RightEdge = new System.Windows.Forms.RadioButton();
            this.rdo_LeftEdge = new System.Windows.Forms.RadioButton();
            this.rdo_DownEdge = new System.Windows.Forms.RadioButton();
            this.rdo_UpEdge = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.trb_MaxGray = new System.Windows.Forms.TrackBar();
            this.nud_MaxGray = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.trb_MinGray = new System.Windows.Forms.TrackBar();
            this.nud_MinGray = new System.Windows.Forms.NumericUpDown();
            this.tp_Measure_Pos = new System.Windows.Forms.TabPage();
            this.rdo_TranslationNegative = new System.Windows.Forms.RadioButton();
            this.rdo_TranslationPositive = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.trb_RoiWidthLen = new System.Windows.Forms.TrackBar();
            this.nud_RoiWidthLen = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.trb_Sigma = new System.Windows.Forms.TrackBar();
            this.nud_Sigma = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.trb_AmplitudeThreshold = new System.Windows.Forms.TrackBar();
            this.nud_AmplitudeThreshold = new System.Windows.Forms.NumericUpDown();
            this.tp_Canny = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.nud_Alpha = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.trb_High = new System.Windows.Forms.TrackBar();
            this.nud_High = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.trb_Low = new System.Windows.Forms.TrackBar();
            this.nud_Low = new System.Windows.Forms.NumericUpDown();
            this.chk_Angle = new System.Windows.Forms.CheckBox();
            this.btn_Draw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tp_Threshold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_slg_b_pex)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trb_MaxGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_MinGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinGray)).BeginInit();
            this.tp_Measure_Pos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trb_RoiWidthLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RoiWidthLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_Sigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Sigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_AmplitudeThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_AmplitudeThreshold)).BeginInit();
            this.tp_Canny.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Alpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_High)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_High)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_Low)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Low)).BeginInit();
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
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Name);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Cancel);
            this.splitContainer1.Panel2.Controls.Add(this.btn_OK);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.chk_Angle);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Draw);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.cmb_VerticalTracking_L);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmb_HorizontalTracking);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(9, 572);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 104);
            this.panel1.TabIndex = 66;
            // 
            // cmb_VerticalTracking_L
            // 
            this.cmb_VerticalTracking_L.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_VerticalTracking_L.FormattingEnabled = true;
            this.cmb_VerticalTracking_L.Location = new System.Drawing.Point(123, 59);
            this.cmb_VerticalTracking_L.Name = "cmb_VerticalTracking_L";
            this.cmb_VerticalTracking_L.Size = new System.Drawing.Size(121, 25);
            this.cmb_VerticalTracking_L.TabIndex = 65;
            this.cmb_VerticalTracking_L.SelectedIndexChanged += new System.EventHandler(this.cmb_VerticalTracking_L_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(16, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 62;
            this.label2.Text = "水平跟踪：";
            // 
            // cmb_HorizontalTracking
            // 
            this.cmb_HorizontalTracking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_HorizontalTracking.FormattingEnabled = true;
            this.cmb_HorizontalTracking.Location = new System.Drawing.Point(123, 12);
            this.cmb_HorizontalTracking.Name = "cmb_HorizontalTracking";
            this.cmb_HorizontalTracking.Size = new System.Drawing.Size(121, 25);
            this.cmb_HorizontalTracking.TabIndex = 64;
            this.cmb_HorizontalTracking.SelectedIndexChanged += new System.EventHandler(this.cmb_HorizontalTracking_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(16, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 63;
            this.label3.Text = "垂直跟踪：";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(247, 65);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(151, 23);
            this.txt_Name.TabIndex = 54;
            this.txt_Name.Text = "线1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "请输入名字：";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(9, 705);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 27);
            this.btn_Cancel.TabIndex = 52;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(332, 705);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 27);
            this.btn_OK.TabIndex = 51;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_Threshold);
            this.tabControl1.Controls.Add(this.tp_Measure_Pos);
            this.tabControl1.Controls.Add(this.tp_Canny);
            this.tabControl1.Location = new System.Drawing.Point(9, 107);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(406, 459);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tp_Threshold
            // 
            this.tp_Threshold.AutoScroll = true;
            this.tp_Threshold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tp_Threshold.Controls.Add(this.nud_slg_b_pex);
            this.tp_Threshold.Controls.Add(this.label9);
            this.tp_Threshold.Controls.Add(this.groupBox2);
            this.tp_Threshold.Controls.Add(this.label8);
            this.tp_Threshold.Controls.Add(this.trb_MaxGray);
            this.tp_Threshold.Controls.Add(this.nud_MaxGray);
            this.tp_Threshold.Controls.Add(this.label7);
            this.tp_Threshold.Controls.Add(this.trb_MinGray);
            this.tp_Threshold.Controls.Add(this.nud_MinGray);
            this.tp_Threshold.Location = new System.Drawing.Point(4, 26);
            this.tp_Threshold.Name = "tp_Threshold";
            this.tp_Threshold.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Threshold.Size = new System.Drawing.Size(398, 429);
            this.tp_Threshold.TabIndex = 1;
            this.tp_Threshold.Text = "灰度抓取";
            // 
            // nud_slg_b_pex
            // 
            this.nud_slg_b_pex.Location = new System.Drawing.Point(9, 301);
            this.nud_slg_b_pex.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nud_slg_b_pex.Name = "nud_slg_b_pex";
            this.nud_slg_b_pex.Size = new System.Drawing.Size(53, 23);
            this.nud_slg_b_pex.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "上下微调";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.rdo_RightEdge);
            this.groupBox2.Controls.Add(this.rdo_LeftEdge);
            this.groupBox2.Controls.Add(this.rdo_DownEdge);
            this.groupBox2.Controls.Add(this.rdo_UpEdge);
            this.groupBox2.Location = new System.Drawing.Point(6, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 114);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "边缘选择";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(304, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 21);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "角点功能";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // rdo_RightEdge
            // 
            this.rdo_RightEdge.AutoSize = true;
            this.rdo_RightEdge.Location = new System.Drawing.Point(162, 73);
            this.rdo_RightEdge.Name = "rdo_RightEdge";
            this.rdo_RightEdge.Size = new System.Drawing.Size(50, 21);
            this.rdo_RightEdge.TabIndex = 3;
            this.rdo_RightEdge.Text = "右→";
            this.rdo_RightEdge.UseVisualStyleBackColor = true;
            this.rdo_RightEdge.CheckedChanged += new System.EventHandler(this.rdo_RightEdge_CheckedChanged);
            // 
            // rdo_LeftEdge
            // 
            this.rdo_LeftEdge.AutoSize = true;
            this.rdo_LeftEdge.Location = new System.Drawing.Point(162, 32);
            this.rdo_LeftEdge.Name = "rdo_LeftEdge";
            this.rdo_LeftEdge.Size = new System.Drawing.Size(50, 21);
            this.rdo_LeftEdge.TabIndex = 2;
            this.rdo_LeftEdge.Text = "左←";
            this.rdo_LeftEdge.UseVisualStyleBackColor = true;
            this.rdo_LeftEdge.CheckedChanged += new System.EventHandler(this.rdo_LeftEdge_CheckedChanged);
            // 
            // rdo_DownEdge
            // 
            this.rdo_DownEdge.AutoSize = true;
            this.rdo_DownEdge.Location = new System.Drawing.Point(18, 73);
            this.rdo_DownEdge.Name = "rdo_DownEdge";
            this.rdo_DownEdge.Size = new System.Drawing.Size(44, 21);
            this.rdo_DownEdge.TabIndex = 1;
            this.rdo_DownEdge.Text = "下↓";
            this.rdo_DownEdge.UseVisualStyleBackColor = true;
            this.rdo_DownEdge.CheckedChanged += new System.EventHandler(this.rdo_DownEdge_CheckedChanged);
            // 
            // rdo_UpEdge
            // 
            this.rdo_UpEdge.AutoSize = true;
            this.rdo_UpEdge.Checked = true;
            this.rdo_UpEdge.Location = new System.Drawing.Point(18, 32);
            this.rdo_UpEdge.Name = "rdo_UpEdge";
            this.rdo_UpEdge.Size = new System.Drawing.Size(44, 21);
            this.rdo_UpEdge.TabIndex = 0;
            this.rdo_UpEdge.TabStop = true;
            this.rdo_UpEdge.Text = "上↑";
            this.rdo_UpEdge.UseVisualStyleBackColor = true;
            this.rdo_UpEdge.CheckedChanged += new System.EventHandler(this.rdo_UpEdge_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "上限灰度值";
            // 
            // trb_MaxGray
            // 
            this.trb_MaxGray.AutoSize = false;
            this.trb_MaxGray.BackColor = System.Drawing.Color.LightGreen;
            this.trb_MaxGray.LargeChange = 1;
            this.trb_MaxGray.Location = new System.Drawing.Point(77, 78);
            this.trb_MaxGray.Maximum = 255;
            this.trb_MaxGray.Name = "trb_MaxGray";
            this.trb_MaxGray.Size = new System.Drawing.Size(317, 43);
            this.trb_MaxGray.TabIndex = 3;
            this.trb_MaxGray.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trb_MaxGray.Value = 255;
            this.trb_MaxGray.Scroll += new System.EventHandler(this.trb_MaxGray_Scroll);
            // 
            // nud_MaxGray
            // 
            this.nud_MaxGray.Location = new System.Drawing.Point(6, 98);
            this.nud_MaxGray.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_MaxGray.Name = "nud_MaxGray";
            this.nud_MaxGray.Size = new System.Drawing.Size(48, 23);
            this.nud_MaxGray.TabIndex = 4;
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
            this.label7.Location = new System.Drawing.Point(3, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "下限灰度值";
            // 
            // trb_MinGray
            // 
            this.trb_MinGray.AutoSize = false;
            this.trb_MinGray.BackColor = System.Drawing.Color.Wheat;
            this.trb_MinGray.LargeChange = 1;
            this.trb_MinGray.Location = new System.Drawing.Point(77, 14);
            this.trb_MinGray.Maximum = 255;
            this.trb_MinGray.Name = "trb_MinGray";
            this.trb_MinGray.Size = new System.Drawing.Size(317, 43);
            this.trb_MinGray.TabIndex = 0;
            this.trb_MinGray.Scroll += new System.EventHandler(this.trb_MinGray_Scroll);
            // 
            // nud_MinGray
            // 
            this.nud_MinGray.Location = new System.Drawing.Point(6, 34);
            this.nud_MinGray.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_MinGray.Name = "nud_MinGray";
            this.nud_MinGray.Size = new System.Drawing.Size(48, 23);
            this.nud_MinGray.TabIndex = 1;
            this.nud_MinGray.ValueChanged += new System.EventHandler(this.nud_MinGray_ValueChanged);
            // 
            // tp_Measure_Pos
            // 
            this.tp_Measure_Pos.AutoScroll = true;
            this.tp_Measure_Pos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tp_Measure_Pos.Controls.Add(this.rdo_TranslationNegative);
            this.tp_Measure_Pos.Controls.Add(this.rdo_TranslationPositive);
            this.tp_Measure_Pos.Controls.Add(this.label12);
            this.tp_Measure_Pos.Controls.Add(this.trb_RoiWidthLen);
            this.tp_Measure_Pos.Controls.Add(this.nud_RoiWidthLen);
            this.tp_Measure_Pos.Controls.Add(this.label11);
            this.tp_Measure_Pos.Controls.Add(this.trb_Sigma);
            this.tp_Measure_Pos.Controls.Add(this.nud_Sigma);
            this.tp_Measure_Pos.Controls.Add(this.label10);
            this.tp_Measure_Pos.Controls.Add(this.trb_AmplitudeThreshold);
            this.tp_Measure_Pos.Controls.Add(this.nud_AmplitudeThreshold);
            this.tp_Measure_Pos.Location = new System.Drawing.Point(4, 26);
            this.tp_Measure_Pos.Name = "tp_Measure_Pos";
            this.tp_Measure_Pos.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Measure_Pos.Size = new System.Drawing.Size(398, 429);
            this.tp_Measure_Pos.TabIndex = 2;
            this.tp_Measure_Pos.Text = "边缘检测";
            // 
            // rdo_TranslationNegative
            // 
            this.rdo_TranslationNegative.AutoSize = true;
            this.rdo_TranslationNegative.Location = new System.Drawing.Point(6, 294);
            this.rdo_TranslationNegative.Name = "rdo_TranslationNegative";
            this.rdo_TranslationNegative.Size = new System.Drawing.Size(74, 21);
            this.rdo_TranslationNegative.TabIndex = 13;
            this.rdo_TranslationNegative.Text = "由白到黑";
            this.rdo_TranslationNegative.UseVisualStyleBackColor = true;
            // 
            // rdo_TranslationPositive
            // 
            this.rdo_TranslationPositive.AutoSize = true;
            this.rdo_TranslationPositive.Checked = true;
            this.rdo_TranslationPositive.Location = new System.Drawing.Point(6, 257);
            this.rdo_TranslationPositive.Name = "rdo_TranslationPositive";
            this.rdo_TranslationPositive.Size = new System.Drawing.Size(74, 21);
            this.rdo_TranslationPositive.TabIndex = 12;
            this.rdo_TranslationPositive.TabStop = true;
            this.rdo_TranslationPositive.Text = "由黑到白";
            this.rdo_TranslationPositive.UseVisualStyleBackColor = true;
            this.rdo_TranslationPositive.CheckedChanged += new System.EventHandler(this.rdo_TranslationPositive_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(0, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 17);
            this.label12.TabIndex = 11;
            this.label12.Text = "ROI宽";
            // 
            // trb_RoiWidthLen
            // 
            this.trb_RoiWidthLen.AutoSize = false;
            this.trb_RoiWidthLen.BackColor = System.Drawing.Color.Wheat;
            this.trb_RoiWidthLen.LargeChange = 1;
            this.trb_RoiWidthLen.Location = new System.Drawing.Point(89, 178);
            this.trb_RoiWidthLen.Maximum = 127;
            this.trb_RoiWidthLen.Name = "trb_RoiWidthLen";
            this.trb_RoiWidthLen.Size = new System.Drawing.Size(305, 43);
            this.trb_RoiWidthLen.TabIndex = 9;
            this.trb_RoiWidthLen.Value = 5;
            this.trb_RoiWidthLen.Scroll += new System.EventHandler(this.trb_RoiWidthLen_Scroll);
            // 
            // nud_RoiWidthLen
            // 
            this.nud_RoiWidthLen.Location = new System.Drawing.Point(6, 198);
            this.nud_RoiWidthLen.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.nud_RoiWidthLen.Name = "nud_RoiWidthLen";
            this.nud_RoiWidthLen.Size = new System.Drawing.Size(48, 23);
            this.nud_RoiWidthLen.TabIndex = 10;
            this.nud_RoiWidthLen.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_RoiWidthLen.ValueChanged += new System.EventHandler(this.nud_RoiWidthLen_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 17);
            this.label11.TabIndex = 8;
            this.label11.Text = "平滑";
            // 
            // trb_Sigma
            // 
            this.trb_Sigma.AutoSize = false;
            this.trb_Sigma.BackColor = System.Drawing.Color.Wheat;
            this.trb_Sigma.LargeChange = 1;
            this.trb_Sigma.Location = new System.Drawing.Point(89, 109);
            this.trb_Sigma.Maximum = 320;
            this.trb_Sigma.Minimum = 4;
            this.trb_Sigma.Name = "trb_Sigma";
            this.trb_Sigma.Size = new System.Drawing.Size(305, 43);
            this.trb_Sigma.TabIndex = 6;
            this.trb_Sigma.Value = 4;
            this.trb_Sigma.Scroll += new System.EventHandler(this.trb_Sigma_Scroll);
            // 
            // nud_Sigma
            // 
            this.nud_Sigma.Location = new System.Drawing.Point(3, 129);
            this.nud_Sigma.Maximum = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.nud_Sigma.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nud_Sigma.Name = "nud_Sigma";
            this.nud_Sigma.Size = new System.Drawing.Size(48, 23);
            this.nud_Sigma.TabIndex = 7;
            this.nud_Sigma.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nud_Sigma.ValueChanged += new System.EventHandler(this.nud_Sigma_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "最小边缘幅度";
            // 
            // trb_AmplitudeThreshold
            // 
            this.trb_AmplitudeThreshold.AutoSize = false;
            this.trb_AmplitudeThreshold.BackColor = System.Drawing.Color.Wheat;
            this.trb_AmplitudeThreshold.LargeChange = 1;
            this.trb_AmplitudeThreshold.Location = new System.Drawing.Point(89, 40);
            this.trb_AmplitudeThreshold.Maximum = 255;
            this.trb_AmplitudeThreshold.Name = "trb_AmplitudeThreshold";
            this.trb_AmplitudeThreshold.Size = new System.Drawing.Size(305, 43);
            this.trb_AmplitudeThreshold.TabIndex = 3;
            this.trb_AmplitudeThreshold.Value = 40;
            this.trb_AmplitudeThreshold.Scroll += new System.EventHandler(this.trb_AmplitudeThreshold_Scroll);
            // 
            // nud_AmplitudeThreshold
            // 
            this.nud_AmplitudeThreshold.Location = new System.Drawing.Point(6, 60);
            this.nud_AmplitudeThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_AmplitudeThreshold.Name = "nud_AmplitudeThreshold";
            this.nud_AmplitudeThreshold.Size = new System.Drawing.Size(48, 23);
            this.nud_AmplitudeThreshold.TabIndex = 4;
            this.nud_AmplitudeThreshold.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nud_AmplitudeThreshold.ValueChanged += new System.EventHandler(this.nud_AmplitudeThreshold_ValueChanged);
            // 
            // tp_Canny
            // 
            this.tp_Canny.AutoScroll = true;
            this.tp_Canny.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tp_Canny.Controls.Add(this.label15);
            this.tp_Canny.Controls.Add(this.nud_Alpha);
            this.tp_Canny.Controls.Add(this.label13);
            this.tp_Canny.Controls.Add(this.trb_High);
            this.tp_Canny.Controls.Add(this.nud_High);
            this.tp_Canny.Controls.Add(this.label14);
            this.tp_Canny.Controls.Add(this.trb_Low);
            this.tp_Canny.Controls.Add(this.nud_Low);
            this.tp_Canny.Location = new System.Drawing.Point(4, 26);
            this.tp_Canny.Name = "tp_Canny";
            this.tp_Canny.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Canny.Size = new System.Drawing.Size(398, 429);
            this.tp_Canny.TabIndex = 3;
            this.tp_Canny.Text = "边缘拟合";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 161);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 17);
            this.label15.TabIndex = 16;
            this.label15.Text = "Alpha";
            // 
            // nud_Alpha
            // 
            this.nud_Alpha.DecimalPlaces = 1;
            this.nud_Alpha.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_Alpha.Location = new System.Drawing.Point(5, 181);
            this.nud_Alpha.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nud_Alpha.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nud_Alpha.Name = "nud_Alpha";
            this.nud_Alpha.Size = new System.Drawing.Size(51, 23);
            this.nud_Alpha.TabIndex = 15;
            this.nud_Alpha.Value = new decimal(new int[] {
            11,
            0,
            0,
            65536});
            this.nud_Alpha.ValueChanged += new System.EventHandler(this.nud_Alpha_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 17);
            this.label13.TabIndex = 14;
            this.label13.Text = "High";
            // 
            // trb_High
            // 
            this.trb_High.AutoSize = false;
            this.trb_High.BackColor = System.Drawing.Color.LightGreen;
            this.trb_High.LargeChange = 1;
            this.trb_High.Location = new System.Drawing.Point(67, 83);
            this.trb_High.Maximum = 255;
            this.trb_High.Minimum = 1;
            this.trb_High.Name = "trb_High";
            this.trb_High.Size = new System.Drawing.Size(327, 43);
            this.trb_High.TabIndex = 12;
            this.trb_High.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trb_High.Value = 70;
            this.trb_High.Scroll += new System.EventHandler(this.trb_High_Scroll);
            // 
            // nud_High
            // 
            this.nud_High.Location = new System.Drawing.Point(5, 103);
            this.nud_High.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_High.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_High.Name = "nud_High";
            this.nud_High.Size = new System.Drawing.Size(48, 23);
            this.nud_High.TabIndex = 13;
            this.nud_High.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.nud_High.ValueChanged += new System.EventHandler(this.nud_High_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 17);
            this.label14.TabIndex = 11;
            this.label14.Text = "Low";
            // 
            // trb_Low
            // 
            this.trb_Low.AutoSize = false;
            this.trb_Low.BackColor = System.Drawing.Color.Wheat;
            this.trb_Low.LargeChange = 1;
            this.trb_Low.Location = new System.Drawing.Point(67, 14);
            this.trb_Low.Maximum = 255;
            this.trb_Low.Minimum = 1;
            this.trb_Low.Name = "trb_Low";
            this.trb_Low.Size = new System.Drawing.Size(327, 43);
            this.trb_Low.TabIndex = 9;
            this.trb_Low.Value = 30;
            this.trb_Low.Scroll += new System.EventHandler(this.trb_Low_Scroll);
            // 
            // nud_Low
            // 
            this.nud_Low.Location = new System.Drawing.Point(8, 34);
            this.nud_Low.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_Low.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Low.Name = "nud_Low";
            this.nud_Low.Size = new System.Drawing.Size(48, 23);
            this.nud_Low.TabIndex = 10;
            this.nud_Low.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nud_Low.ValueChanged += new System.EventHandler(this.nud_Low_ValueChanged);
            // 
            // chk_Angle
            // 
            this.chk_Angle.AutoSize = true;
            this.chk_Angle.Location = new System.Drawing.Point(243, 25);
            this.chk_Angle.Name = "chk_Angle";
            this.chk_Angle.Size = new System.Drawing.Size(51, 21);
            this.chk_Angle.TabIndex = 2;
            this.chk_Angle.Text = "角度";
            this.chk_Angle.UseVisualStyleBackColor = true;
            // 
            // btn_Draw
            // 
            this.btn_Draw.Location = new System.Drawing.Point(18, 12);
            this.btn_Draw.Name = "btn_Draw";
            this.btn_Draw.Size = new System.Drawing.Size(130, 34);
            this.btn_Draw.TabIndex = 1;
            this.btn_Draw.Text = "框选区域";
            this.btn_Draw.UseVisualStyleBackColor = true;
            this.btn_Draw.Click += new System.EventHandler(this.btn_Draw_Click);
            // 
            // Ufrm_Line
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 796);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ufrm_Line";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "边缘提取窗体";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ufrm_Line_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tp_Threshold.ResumeLayout(false);
            this.tp_Threshold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_slg_b_pex)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trb_MaxGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_MinGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinGray)).EndInit();
            this.tp_Measure_Pos.ResumeLayout(false);
            this.tp_Measure_Pos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trb_RoiWidthLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RoiWidthLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_Sigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Sigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_AmplitudeThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_AmplitudeThreshold)).EndInit();
            this.tp_Canny.ResumeLayout(false);
            this.tp_Canny.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Alpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_High)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_High)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_Low)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Low)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_Threshold;
        private System.Windows.Forms.NumericUpDown nud_slg_b_pex;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton rdo_RightEdge;
        private System.Windows.Forms.RadioButton rdo_LeftEdge;
        private System.Windows.Forms.RadioButton rdo_DownEdge;
        private System.Windows.Forms.RadioButton rdo_UpEdge;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trb_MaxGray;
        private System.Windows.Forms.NumericUpDown nud_MaxGray;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trb_MinGray;
        private System.Windows.Forms.NumericUpDown nud_MinGray;
        private System.Windows.Forms.TabPage tp_Measure_Pos;
        private System.Windows.Forms.RadioButton rdo_TranslationNegative;
        private System.Windows.Forms.RadioButton rdo_TranslationPositive;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar trb_RoiWidthLen;
        private System.Windows.Forms.NumericUpDown nud_RoiWidthLen;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar trb_Sigma;
        private System.Windows.Forms.NumericUpDown nud_Sigma;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trb_AmplitudeThreshold;
        private System.Windows.Forms.NumericUpDown nud_AmplitudeThreshold;
        private System.Windows.Forms.TabPage tp_Canny;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nud_Alpha;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar trb_High;
        private System.Windows.Forms.NumericUpDown nud_High;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TrackBar trb_Low;
        private System.Windows.Forms.NumericUpDown nud_Low;
        private System.Windows.Forms.CheckBox chk_Angle;
        private System.Windows.Forms.Button btn_Draw;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_VerticalTracking_L;
        private System.Windows.Forms.ComboBox cmb_HorizontalTracking;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}