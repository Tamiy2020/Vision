namespace Vision.Forms
{
    partial class Frm_Edit
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtn_Line = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_LineList = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_Circle = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_Position = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_Exist = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_File = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_File)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.hWindow_Final1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1MinSize = 1000;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 450;
            this.splitContainer1.Size = new System.Drawing.Size(1500, 646);
            this.splitContainer1.SplitterDistance = 1000;
            this.splitContainer1.TabIndex = 0;
            // 
            // hWindow_Final1
            // 
            this.hWindow_Final1.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hWindow_Final1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindow_Final1.DrawModel = false;
            this.hWindow_Final1.EditModel = true;
            this.hWindow_Final1.Image = null;
            this.hWindow_Final1.Location = new System.Drawing.Point(0, 55);
            this.hWindow_Final1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hWindow_Final1.Name = "hWindow_Final1";
            this.hWindow_Final1.Size = new System.Drawing.Size(1000, 591);
            this.hWindow_Final1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_Line,
            this.tsbtn_LineList,
            this.tsbtn_Circle,
            this.tsbtn_Position,
            this.tsbtn_Exist});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1000, 55);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtn_Line
            // 
            this.tsbtn_Line.AutoSize = false;
            this.tsbtn_Line.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Line.Image = global::Vision.Properties.Resources.线;
            this.tsbtn_Line.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Line.Margin = new System.Windows.Forms.Padding(10);
            this.tsbtn_Line.Name = "tsbtn_Line";
            this.tsbtn_Line.Size = new System.Drawing.Size(50, 50);
            this.tsbtn_Line.Text = "线";
            // 
            // tsbtn_LineList
            // 
            this.tsbtn_LineList.AutoSize = false;
            this.tsbtn_LineList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_LineList.Image = global::Vision.Properties.Resources.多边;
            this.tsbtn_LineList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_LineList.Margin = new System.Windows.Forms.Padding(10);
            this.tsbtn_LineList.Name = "tsbtn_LineList";
            this.tsbtn_LineList.Size = new System.Drawing.Size(50, 50);
            this.tsbtn_LineList.Text = "多边";
            // 
            // tsbtn_Circle
            // 
            this.tsbtn_Circle.AutoSize = false;
            this.tsbtn_Circle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Circle.Image = global::Vision.Properties.Resources.圆;
            this.tsbtn_Circle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Circle.Margin = new System.Windows.Forms.Padding(10);
            this.tsbtn_Circle.Name = "tsbtn_Circle";
            this.tsbtn_Circle.Size = new System.Drawing.Size(50, 50);
            this.tsbtn_Circle.Text = "圆";
            // 
            // tsbtn_Position
            // 
            this.tsbtn_Position.AutoSize = false;
            this.tsbtn_Position.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Position.Image = global::Vision.Properties.Resources.跟踪定位;
            this.tsbtn_Position.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Position.Margin = new System.Windows.Forms.Padding(10);
            this.tsbtn_Position.Name = "tsbtn_Position";
            this.tsbtn_Position.Size = new System.Drawing.Size(50, 50);
            this.tsbtn_Position.Text = "定位";
            // 
            // tsbtn_Exist
            // 
            this.tsbtn_Exist.AutoSize = false;
            this.tsbtn_Exist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Exist.Image = global::Vision.Properties.Resources.缺陷检测;
            this.tsbtn_Exist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Exist.Margin = new System.Windows.Forms.Padding(10);
            this.tsbtn_Exist.Name = "tsbtn_Exist";
            this.tsbtn_Exist.Size = new System.Drawing.Size(50, 50);
            this.tsbtn_Exist.Text = "缺陷检测";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(496, 646);
            this.splitContainer2.SplitterDistance = 490;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_Data);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 490);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测量数据";
            // 
            // dgv_Data
            // 
            this.dgv_Data.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Data.Location = new System.Drawing.Point(3, 19);
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.RowTemplate.Height = 23;
            this.dgv_Data.Size = new System.Drawing.Size(490, 468);
            this.dgv_Data.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_File);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件控制";
            // 
            // dgv_File
            // 
            this.dgv_File.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_File.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_File.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_File.Location = new System.Drawing.Point(3, 19);
            this.dgv_File.Name = "dgv_File";
            this.dgv_File.RowTemplate.Height = 23;
            this.dgv_File.Size = new System.Drawing.Size(490, 130);
            this.dgv_File.TabIndex = 0;
            // 
            // Frm_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 646);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_Edit";
            this.Text = "Frm_Edit";
            this.Shown += new System.EventHandler(this.Frm_Edit_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_File)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_File;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtn_Line;
        private System.Windows.Forms.ToolStripButton tsbtn_LineList;
        private System.Windows.Forms.ToolStripButton tsbtn_Circle;
        private System.Windows.Forms.ToolStripButton tsbtn_Position;
        private System.Windows.Forms.ToolStripButton tsbtn_Exist;
        private System.Windows.Forms.DataGridView dgv_Data;
        public ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final1;
    }
}