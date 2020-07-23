namespace Vision.Forms
{
    partial class Ufrm_DatumLine
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.nud_yEnd = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nud_yStart = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nud_xEnd = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_xStart = new System.Windows.Forms.NumericUpDown();
            this.btn_Draw = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_VerticalTracking_L = new System.Windows.Forms.ComboBox();
            this.cmb_VerticalTracking_R = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_yEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_yStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_xEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_xStart)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.cmb_VerticalTracking_R);
            this.splitContainer1.Panel2.Controls.Add(this.cmb_VerticalTracking_L);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Name);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Cancel);
            this.splitContainer1.Panel2.Controls.Add(this.btn_OK);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Draw);
            this.splitContainer1.Size = new System.Drawing.Size(1292, 796);
            this.splitContainer1.SplitterDistance = 948;
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
            this.hWindow_Final1.Margin = new System.Windows.Forms.Padding(4);
            this.hWindow_Final1.Name = "hWindow_Final1";
            this.hWindow_Final1.Size = new System.Drawing.Size(948, 796);
            this.hWindow_Final1.TabIndex = 0;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(132, 99);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(151, 23);
            this.txt_Name.TabIndex = 50;
            this.txt_Name.Text = "基准线";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 49;
            this.label1.Text = "请输入名字：";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(12, 592);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 27);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(262, 592);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 27);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.nud_yEnd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nud_yStart);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nud_xEnd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nud_xStart);
            this.groupBox1.Location = new System.Drawing.Point(3, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 203);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "微调";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 44);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 17);
            this.label16.TabIndex = 8;
            this.label16.Text = "起点x";
            // 
            // nud_yEnd
            // 
            this.nud_yEnd.Location = new System.Drawing.Point(194, 161);
            this.nud_yEnd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_yEnd.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nud_yEnd.Name = "nud_yEnd";
            this.nud_yEnd.Size = new System.Drawing.Size(86, 23);
            this.nud_yEnd.TabIndex = 4;
            this.nud_yEnd.ValueChanged += new System.EventHandler(this.nud_yEnd_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "终点y";
            // 
            // nud_yStart
            // 
            this.nud_yStart.Location = new System.Drawing.Point(9, 161);
            this.nud_yStart.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_yStart.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nud_yStart.Name = "nud_yStart";
            this.nud_yStart.Size = new System.Drawing.Size(86, 23);
            this.nud_yStart.TabIndex = 3;
            this.nud_yStart.ValueChanged += new System.EventHandler(this.nud_yStart_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "起点y";
            // 
            // nud_xEnd
            // 
            this.nud_xEnd.Location = new System.Drawing.Point(194, 64);
            this.nud_xEnd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_xEnd.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nud_xEnd.Name = "nud_xEnd";
            this.nud_xEnd.Size = new System.Drawing.Size(86, 23);
            this.nud_xEnd.TabIndex = 2;
            this.nud_xEnd.ValueChanged += new System.EventHandler(this.nud_xEnd_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "终点x";
            // 
            // nud_xStart
            // 
            this.nud_xStart.Location = new System.Drawing.Point(9, 64);
            this.nud_xStart.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_xStart.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nud_xStart.Name = "nud_xStart";
            this.nud_xStart.Size = new System.Drawing.Size(86, 23);
            this.nud_xStart.TabIndex = 1;
            this.nud_xStart.ValueChanged += new System.EventHandler(this.nud_xStart_ValueChanged);
            // 
            // btn_Draw
            // 
            this.btn_Draw.Location = new System.Drawing.Point(6, 22);
            this.btn_Draw.Name = "btn_Draw";
            this.btn_Draw.Size = new System.Drawing.Size(117, 40);
            this.btn_Draw.TabIndex = 1;
            this.btn_Draw.Text = "画基准线";
            this.btn_Draw.UseVisualStyleBackColor = true;
            this.btn_Draw.Click += new System.EventHandler(this.btn_Draw_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(9, 430);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 51;
            this.label2.Text = "垂直跟踪左：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(9, 486);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 52;
            this.label3.Text = "垂直跟踪右：";
            // 
            // cmb_VerticalTracking_L
            // 
            this.cmb_VerticalTracking_L.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_VerticalTracking_L.FormattingEnabled = true;
            this.cmb_VerticalTracking_L.Location = new System.Drawing.Point(132, 422);
            this.cmb_VerticalTracking_L.Name = "cmb_VerticalTracking_L";
            this.cmb_VerticalTracking_L.Size = new System.Drawing.Size(121, 25);
            this.cmb_VerticalTracking_L.TabIndex = 53;
            this.cmb_VerticalTracking_L.SelectedIndexChanged += new System.EventHandler(this.cmb_VerticalTracking_L_SelectedIndexChanged);
            // 
            // cmb_VerticalTracking_R
            // 
            this.cmb_VerticalTracking_R.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_VerticalTracking_R.FormattingEnabled = true;
            this.cmb_VerticalTracking_R.Location = new System.Drawing.Point(132, 478);
            this.cmb_VerticalTracking_R.Name = "cmb_VerticalTracking_R";
            this.cmb_VerticalTracking_R.Size = new System.Drawing.Size(121, 25);
            this.cmb_VerticalTracking_R.TabIndex = 54;
            this.cmb_VerticalTracking_R.SelectedIndexChanged += new System.EventHandler(this.cmb_VerticalTracking_R_SelectedIndexChanged);
            // 
            // Ufrm_DatumLine
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
            this.Name = "Ufrm_DatumLine";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基准线窗体";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ufrm_DatumLine_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_yEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_yStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_xEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_xStart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nud_yEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nud_yStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nud_xEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud_xStart;
        private System.Windows.Forms.Button btn_Draw;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.ComboBox cmb_VerticalTracking_R;
        private System.Windows.Forms.ComboBox cmb_VerticalTracking_L;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}