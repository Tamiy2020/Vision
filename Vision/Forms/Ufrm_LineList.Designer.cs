namespace Vision.Forms
{
    partial class Ufrm_LineList
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.hWindow_Final1 = new ChoiceTech.Halcon.Control.HWindow_Final();
            this.btn_DrawROIs = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nud_slg_b_pex = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.trb_slg_MaxGray = new System.Windows.Forms.TrackBar();
            this.nud_slg_MaxGray = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.trb_slg_MinGray = new System.Windows.Forms.TrackBar();
            this.nud_slg_MinGray = new System.Windows.Forms.NumericUpDown();
            this.btn_slg_ReDrowROI = new System.Windows.Forms.Button();
            this.cmb_slg_SelectItem = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_Next = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Done = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_Cancel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trb_MaxGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_MinGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinGray)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_slg_b_pex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_slg_MaxGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_slg_MaxGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_slg_MinGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_slg_MinGray)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.txt_Name);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btn_DrawROIs);
            this.splitContainer1.Size = new System.Drawing.Size(1292, 796);
            this.splitContainer1.SplitterDistance = 845;
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
            this.hWindow_Final1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hWindow_Final1.Name = "hWindow_Final1";
            this.hWindow_Final1.Size = new System.Drawing.Size(845, 796);
            this.hWindow_Final1.TabIndex = 0;
            // 
            // btn_DrawROIs
            // 
            this.btn_DrawROIs.Location = new System.Drawing.Point(15, 12);
            this.btn_DrawROIs.Name = "btn_DrawROIs";
            this.btn_DrawROIs.Size = new System.Drawing.Size(130, 34);
            this.btn_DrawROIs.TabIndex = 1;
            this.btn_DrawROIs.Text = "框选区域";
            this.btn_DrawROIs.UseVisualStyleBackColor = true;
            this.btn_DrawROIs.Click += new System.EventHandler(this.btn_DrawROIs_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.trb_MaxGray);
            this.groupBox1.Controls.Add(this.nud_MaxGray);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.trb_MinGray);
            this.groupBox1.Controls.Add(this.nud_MinGray);
            this.groupBox1.Location = new System.Drawing.Point(6, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 265);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "整体参数设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdo_RightEdge);
            this.groupBox2.Controls.Add(this.rdo_LeftEdge);
            this.groupBox2.Controls.Add(this.rdo_DownEdge);
            this.groupBox2.Controls.Add(this.rdo_UpEdge);
            this.groupBox2.Location = new System.Drawing.Point(6, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(415, 114);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "边缘选择";
            // 
            // rdo_RightEdge
            // 
            this.rdo_RightEdge.AutoSize = true;
            this.rdo_RightEdge.Location = new System.Drawing.Point(198, 73);
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
            this.rdo_LeftEdge.Location = new System.Drawing.Point(198, 32);
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
            this.label8.Location = new System.Drawing.Point(9, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "上限灰度值";
            // 
            // trb_MaxGray
            // 
            this.trb_MaxGray.AutoSize = false;
            this.trb_MaxGray.BackColor = System.Drawing.Color.LightGreen;
            this.trb_MaxGray.LargeChange = 1;
            this.trb_MaxGray.Location = new System.Drawing.Point(83, 89);
            this.trb_MaxGray.Maximum = 255;
            this.trb_MaxGray.Name = "trb_MaxGray";
            this.trb_MaxGray.Size = new System.Drawing.Size(345, 43);
            this.trb_MaxGray.TabIndex = 9;
            this.trb_MaxGray.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trb_MaxGray.Value = 255;
            this.trb_MaxGray.Scroll += new System.EventHandler(this.trb_MaxGray_Scroll);
            // 
            // nud_MaxGray
            // 
            this.nud_MaxGray.Location = new System.Drawing.Point(12, 109);
            this.nud_MaxGray.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_MaxGray.Name = "nud_MaxGray";
            this.nud_MaxGray.Size = new System.Drawing.Size(48, 23);
            this.nud_MaxGray.TabIndex = 10;
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
            this.label7.Location = new System.Drawing.Point(9, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "下限灰度值";
            // 
            // trb_MinGray
            // 
            this.trb_MinGray.AutoSize = false;
            this.trb_MinGray.BackColor = System.Drawing.Color.Wheat;
            this.trb_MinGray.LargeChange = 1;
            this.trb_MinGray.Location = new System.Drawing.Point(83, 25);
            this.trb_MinGray.Maximum = 255;
            this.trb_MinGray.Name = "trb_MinGray";
            this.trb_MinGray.Size = new System.Drawing.Size(345, 43);
            this.trb_MinGray.TabIndex = 6;
            this.trb_MinGray.Scroll += new System.EventHandler(this.trb_MinGray_Scroll);
            // 
            // nud_MinGray
            // 
            this.nud_MinGray.Location = new System.Drawing.Point(12, 45);
            this.nud_MinGray.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_MinGray.Name = "nud_MinGray";
            this.nud_MinGray.Size = new System.Drawing.Size(48, 23);
            this.nud_MinGray.TabIndex = 7;
            this.nud_MinGray.ValueChanged += new System.EventHandler(this.nud_MinGray_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.nud_slg_b_pex);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.trb_slg_MaxGray);
            this.groupBox3.Controls.Add(this.nud_slg_MaxGray);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.trb_slg_MinGray);
            this.groupBox3.Controls.Add(this.btn_slg_ReDrowROI);
            this.groupBox3.Controls.Add(this.nud_slg_MinGray);
            this.groupBox3.Controls.Add(this.cmb_slg_SelectItem);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(6, 382);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(440, 256);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "单项参数设置";
            // 
            // nud_slg_b_pex
            // 
            this.nud_slg_b_pex.Location = new System.Drawing.Point(9, 218);
            this.nud_slg_b_pex.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_slg_b_pex.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nud_slg_b_pex.Name = "nud_slg_b_pex";
            this.nud_slg_b_pex.Size = new System.Drawing.Size(51, 23);
            this.nud_slg_b_pex.TabIndex = 64;
            this.nud_slg_b_pex.ValueChanged += new System.EventHandler(this.nud_slg_b_pex_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 203);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 17);
            this.label15.TabIndex = 63;
            this.label15.Text = "上下微调";
            // 
            // trb_slg_MaxGray
            // 
            this.trb_slg_MaxGray.AutoSize = false;
            this.trb_slg_MaxGray.BackColor = System.Drawing.Color.LightGreen;
            this.trb_slg_MaxGray.LargeChange = 1;
            this.trb_slg_MaxGray.Location = new System.Drawing.Point(83, 144);
            this.trb_slg_MaxGray.Maximum = 255;
            this.trb_slg_MaxGray.Name = "trb_slg_MaxGray";
            this.trb_slg_MaxGray.Size = new System.Drawing.Size(345, 43);
            this.trb_slg_MaxGray.TabIndex = 60;
            this.trb_slg_MaxGray.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trb_slg_MaxGray.Value = 255;
            this.trb_slg_MaxGray.Scroll += new System.EventHandler(this.trb_slg_MaxGray_Scroll);
            // 
            // nud_slg_MaxGray
            // 
            this.nud_slg_MaxGray.Location = new System.Drawing.Point(12, 164);
            this.nud_slg_MaxGray.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_slg_MaxGray.Name = "nud_slg_MaxGray";
            this.nud_slg_MaxGray.Size = new System.Drawing.Size(48, 23);
            this.nud_slg_MaxGray.TabIndex = 61;
            this.nud_slg_MaxGray.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_slg_MaxGray.ValueChanged += new System.EventHandler(this.nud_slg_MaxGray_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 59;
            this.label4.Text = "下限灰度值";
            // 
            // trb_slg_MinGray
            // 
            this.trb_slg_MinGray.AutoSize = false;
            this.trb_slg_MinGray.BackColor = System.Drawing.Color.Wheat;
            this.trb_slg_MinGray.LargeChange = 1;
            this.trb_slg_MinGray.Location = new System.Drawing.Point(83, 80);
            this.trb_slg_MinGray.Maximum = 255;
            this.trb_slg_MinGray.Name = "trb_slg_MinGray";
            this.trb_slg_MinGray.Size = new System.Drawing.Size(345, 43);
            this.trb_slg_MinGray.TabIndex = 57;
            this.trb_slg_MinGray.Scroll += new System.EventHandler(this.trb_slg_MinGray_Scroll);
            // 
            // nud_slg_MinGray
            // 
            this.nud_slg_MinGray.Location = new System.Drawing.Point(12, 100);
            this.nud_slg_MinGray.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_slg_MinGray.Name = "nud_slg_MinGray";
            this.nud_slg_MinGray.Size = new System.Drawing.Size(48, 23);
            this.nud_slg_MinGray.TabIndex = 58;
            this.nud_slg_MinGray.ValueChanged += new System.EventHandler(this.nud_slg_MinGray_ValueChanged);
            // 
            // btn_slg_ReDrowROI
            // 
            this.btn_slg_ReDrowROI.Enabled = false;
            this.btn_slg_ReDrowROI.Location = new System.Drawing.Point(83, 37);
            this.btn_slg_ReDrowROI.Name = "btn_slg_ReDrowROI";
            this.btn_slg_ReDrowROI.Size = new System.Drawing.Size(84, 29);
            this.btn_slg_ReDrowROI.TabIndex = 56;
            this.btn_slg_ReDrowROI.Text = "重画选区";
            this.btn_slg_ReDrowROI.UseVisualStyleBackColor = true;
            this.btn_slg_ReDrowROI.Click += new System.EventHandler(this.btn_slg_ReDrowROI_Click);
            // 
            // cmb_slg_SelectItem
            // 
            this.cmb_slg_SelectItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_slg_SelectItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_slg_SelectItem.FormattingEnabled = true;
            this.cmb_slg_SelectItem.Location = new System.Drawing.Point(12, 41);
            this.cmb_slg_SelectItem.Name = "cmb_slg_SelectItem";
            this.cmb_slg_SelectItem.Size = new System.Drawing.Size(48, 25);
            this.cmb_slg_SelectItem.TabIndex = 55;
            this.cmb_slg_SelectItem.SelectedIndexChanged += new System.EventHandler(this.cmb_slg_SelectItem_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 17);
            this.label11.TabIndex = 54;
            this.label11.Text = "抓边选择";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 65;
            this.label1.Text = "上限灰度值";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(178, 70);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(151, 23);
            this.txt_Name.TabIndex = 50;
            this.txt_Name.Text = "多边";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 49;
            this.label2.Text = "请输入名字：";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(12, 748);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 27);
            this.btn_Cancel.TabIndex = 52;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(356, 748);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 27);
            this.btn_OK.TabIndex = 51;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Next,
            this.tsmi_Done,
            this.toolStripSeparator1,
            this.tsmi_Cancel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 76);
            // 
            // tsmi_Next
            // 
            this.tsmi_Next.Name = "tsmi_Next";
            this.tsmi_Next.Size = new System.Drawing.Size(180, 22);
            this.tsmi_Next.Text = "下一个";
            this.tsmi_Next.Click += new System.EventHandler(this.tsmi_Next_Click);
            // 
            // tsmi_Done
            // 
            this.tsmi_Done.Name = "tsmi_Done";
            this.tsmi_Done.Size = new System.Drawing.Size(180, 22);
            this.tsmi_Done.Text = "完成";
            this.tsmi_Done.Click += new System.EventHandler(this.tsmi_Done_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // tsmi_Cancel
            // 
            this.tsmi_Cancel.Name = "tsmi_Cancel";
            this.tsmi_Cancel.Size = new System.Drawing.Size(180, 22);
            this.tsmi_Cancel.Text = "取消";
            this.tsmi_Cancel.Click += new System.EventHandler(this.tsmi_Cancel_Click);
            // 
            // Ufrm_LineList
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
            this.Name = "Ufrm_LineList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "多边抓取窗体";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ufrm_LineList_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trb_MaxGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_MinGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MinGray)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_slg_b_pex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_slg_MaxGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_slg_MaxGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_slg_MinGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_slg_MinGray)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_slg_b_pex;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar trb_slg_MaxGray;
        private System.Windows.Forms.NumericUpDown nud_slg_MaxGray;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trb_slg_MinGray;
        private System.Windows.Forms.NumericUpDown nud_slg_MinGray;
        private System.Windows.Forms.Button btn_slg_ReDrowROI;
        private System.Windows.Forms.ComboBox cmb_slg_SelectItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.Button btn_DrawROIs;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Next;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Done;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Cancel;
    }
}