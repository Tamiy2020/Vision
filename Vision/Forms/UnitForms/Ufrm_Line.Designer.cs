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
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_Threshold = new System.Windows.Forms.TabPage();
            this.cmb_VerticalTracking_L = new System.Windows.Forms.ComboBox();
            this.nud_slg_b_pex = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_HorizontalTracking = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.tp_Metrology = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_Select = new System.Windows.Forms.ComboBox();
            this.cmb_Transition = new System.Windows.Forms.ComboBox();
            this.nud_Threshold = new System.Windows.Forms.NumericUpDown();
            this.nud_Distance = new System.Windows.Forms.NumericUpDown();
            this.nud_Length2 = new System.Windows.Forms.NumericUpDown();
            this.nud_Length1 = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_Angle = new System.Windows.Forms.CheckBox();
            this.btn_Draw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.tp_Metrology.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Threshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Distance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Length2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Length1)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.txt_Name);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Cancel);
            this.splitContainer1.Panel2.Controls.Add(this.btn_OK);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.chk_Angle);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Draw);
            this.splitContainer1.Size = new System.Drawing.Size(1292, 796);
            this.splitContainer1.SplitterDistance = 863;
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
            this.hWindow_Final1.Size = new System.Drawing.Size(863, 796);
            this.hWindow_Final1.TabIndex = 0;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(243, 65);
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
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(6, 757);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 27);
            this.btn_Cancel.TabIndex = 52;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(340, 757);
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
            this.tabControl1.Controls.Add(this.tp_Metrology);
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
            this.tp_Threshold.Controls.Add(this.cmb_VerticalTracking_L);
            this.tp_Threshold.Controls.Add(this.nud_slg_b_pex);
            this.tp_Threshold.Controls.Add(this.label2);
            this.tp_Threshold.Controls.Add(this.cmb_HorizontalTracking);
            this.tp_Threshold.Controls.Add(this.label9);
            this.tp_Threshold.Controls.Add(this.label3);
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
            // cmb_VerticalTracking_L
            // 
            this.cmb_VerticalTracking_L.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_VerticalTracking_L.FormattingEnabled = true;
            this.cmb_VerticalTracking_L.Location = new System.Drawing.Point(224, 386);
            this.cmb_VerticalTracking_L.Name = "cmb_VerticalTracking_L";
            this.cmb_VerticalTracking_L.Size = new System.Drawing.Size(121, 25);
            this.cmb_VerticalTracking_L.TabIndex = 65;
            this.cmb_VerticalTracking_L.SelectedIndexChanged += new System.EventHandler(this.cmb_VerticalTracking_L_SelectedIndexChanged);
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
            this.nud_slg_b_pex.ValueChanged += new System.EventHandler(this.nud_slg_b_pex_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(6, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 62;
            this.label2.Text = "水平跟踪：";
            // 
            // cmb_HorizontalTracking
            // 
            this.cmb_HorizontalTracking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_HorizontalTracking.FormattingEnabled = true;
            this.cmb_HorizontalTracking.Location = new System.Drawing.Point(224, 339);
            this.cmb_HorizontalTracking.Name = "cmb_HorizontalTracking";
            this.cmb_HorizontalTracking.Size = new System.Drawing.Size(121, 25);
            this.cmb_HorizontalTracking.TabIndex = 64;
            this.cmb_HorizontalTracking.SelectedIndexChanged += new System.EventHandler(this.cmb_HorizontalTracking_SelectedIndexChanged);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(6, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 63;
            this.label3.Text = "垂直跟踪：";
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
            // tp_Metrology
            // 
            this.tp_Metrology.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tp_Metrology.Controls.Add(this.groupBox1);
            this.tp_Metrology.Location = new System.Drawing.Point(4, 26);
            this.tp_Metrology.Name = "tp_Metrology";
            this.tp_Metrology.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Metrology.Size = new System.Drawing.Size(398, 429);
            this.tp_Metrology.TabIndex = 4;
            this.tp_Metrology.Text = "直线拟合";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_Select);
            this.groupBox1.Controls.Add(this.cmb_Transition);
            this.groupBox1.Controls.Add(this.nud_Threshold);
            this.groupBox1.Controls.Add(this.nud_Distance);
            this.groupBox1.Controls.Add(this.nud_Length2);
            this.groupBox1.Controls.Add(this.nud_Length1);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 423);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "拟合参数调整";
            // 
            // cmb_Select
            // 
            this.cmb_Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Select.FormattingEnabled = true;
            this.cmb_Select.Items.AddRange(new object[] {
            "第一点",
            "最后一点",
            "所有"});
            this.cmb_Select.Location = new System.Drawing.Point(130, 330);
            this.cmb_Select.Name = "cmb_Select";
            this.cmb_Select.Size = new System.Drawing.Size(121, 25);
            this.cmb_Select.TabIndex = 11;
            this.cmb_Select.SelectedIndexChanged += new System.EventHandler(this.cmb_Select_SelectedIndexChanged);
            // 
            // cmb_Transition
            // 
            this.cmb_Transition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Transition.FormattingEnabled = true;
            this.cmb_Transition.Items.AddRange(new object[] {
            "由白到黑",
            "由黑到白",
            "所有"});
            this.cmb_Transition.Location = new System.Drawing.Point(130, 269);
            this.cmb_Transition.Name = "cmb_Transition";
            this.cmb_Transition.Size = new System.Drawing.Size(121, 25);
            this.cmb_Transition.TabIndex = 10;
            this.cmb_Transition.SelectedIndexChanged += new System.EventHandler(this.cmb_Transition_SelectedIndexChanged);
            // 
            // nud_Threshold
            // 
            this.nud_Threshold.Location = new System.Drawing.Point(130, 210);
            this.nud_Threshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_Threshold.Name = "nud_Threshold";
            this.nud_Threshold.Size = new System.Drawing.Size(120, 23);
            this.nud_Threshold.TabIndex = 9;
            this.nud_Threshold.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nud_Threshold.ValueChanged += new System.EventHandler(this.nud_Threshold_ValueChanged);
            // 
            // nud_Distance
            // 
            this.nud_Distance.Location = new System.Drawing.Point(130, 149);
            this.nud_Distance.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_Distance.Name = "nud_Distance";
            this.nud_Distance.Size = new System.Drawing.Size(120, 23);
            this.nud_Distance.TabIndex = 8;
            this.nud_Distance.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_Distance.ValueChanged += new System.EventHandler(this.nud_Distance_ValueChanged);
            // 
            // nud_Length2
            // 
            this.nud_Length2.Location = new System.Drawing.Point(130, 88);
            this.nud_Length2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_Length2.Name = "nud_Length2";
            this.nud_Length2.Size = new System.Drawing.Size(120, 23);
            this.nud_Length2.TabIndex = 7;
            this.nud_Length2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_Length2.ValueChanged += new System.EventHandler(this.nud_Length2_ValueChanged);
            // 
            // nud_Length1
            // 
            this.nud_Length1.Location = new System.Drawing.Point(130, 27);
            this.nud_Length1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_Length1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Length1.Name = "nud_Length1";
            this.nud_Length1.Size = new System.Drawing.Size(120, 23);
            this.nud_Length1.TabIndex = 6;
            this.nud_Length1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_Length1.ValueChanged += new System.EventHandler(this.nud_Length1_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 338);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 17);
            this.label18.TabIndex = 5;
            this.label18.Text = "点筛选：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 277);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 17);
            this.label17.TabIndex = 4;
            this.label17.Text = "颜色模式：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 216);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 17);
            this.label16.TabIndex = 3;
            this.label16.Text = "灰度阈值：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "卡尺间隔：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "卡尺高度：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "卡尺宽度：";
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
            this.tp_Metrology.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Threshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Distance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Length2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Length1)).EndInit();
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
        private System.Windows.Forms.TabPage tp_Metrology;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_Select;
        private System.Windows.Forms.ComboBox cmb_Transition;
        private System.Windows.Forms.NumericUpDown nud_Threshold;
        private System.Windows.Forms.NumericUpDown nud_Distance;
        private System.Windows.Forms.NumericUpDown nud_Length2;
        private System.Windows.Forms.NumericUpDown nud_Length1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}