﻿namespace Vision.Forms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.hWindow_Final1 = new ChoiceTech.Halcon.Control.HWindow_Final();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtn_Exist = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgv_File = new System.Windows.Forms.DataGridView();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditItem = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeleteItem = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_File)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.hWindow_Final1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1268, 662);
            this.splitContainer1.SplitterDistance = 460;
            this.splitContainer1.SplitterWidth = 1;
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
            this.hWindow_Final1.Location = new System.Drawing.Point(0, 50);
            this.hWindow_Final1.Name = "hWindow_Final1";
            this.hWindow_Final1.Size = new System.Drawing.Size(1268, 410);
            this.hWindow_Final1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_Exist});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1268, 50);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtn_Exist
            // 
            this.tsbtn_Exist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_Exist.Image = global::Vision.Properties.Resources.缺陷检测;
            this.tsbtn_Exist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_Exist.Name = "tsbtn_Exist";
            this.tsbtn_Exist.Size = new System.Drawing.Size(54, 47);
            this.tsbtn_Exist.Text = "有无识别";
            this.tsbtn_Exist.Click += new System.EventHandler(this.tsbtn_Exist_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1268, 201);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_Data);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1260, 171);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "测量数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgv_File);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1260, 171);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "文件控制";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgv_File
            // 
            this.dgv_File.AllowUserToAddRows = false;
            this.dgv_File.AllowUserToResizeColumns = false;
            this.dgv_File.AllowUserToResizeRows = false;
            this.dgv_File.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_File.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_File.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_File.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_File.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_File.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.ItemName,
            this.EditItem,
            this.DeleteItem});
            this.dgv_File.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_File.Location = new System.Drawing.Point(3, 3);
            this.dgv_File.Name = "dgv_File";
            this.dgv_File.RowTemplate.Height = 23;
            this.dgv_File.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_File.Size = new System.Drawing.Size(1254, 165);
            this.dgv_File.TabIndex = 0;
            this.dgv_File.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_File_CellClick);
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "ID";
            this.ItemID.Name = "ItemID";
            this.ItemID.Visible = false;
            this.ItemID.Width = 47;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "名称                 ";
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 125;
            // 
            // EditItem
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.NullValue = "编辑";
            this.EditItem.DefaultCellStyle = dataGridViewCellStyle2;
            this.EditItem.HeaderText = "编辑     ";
            this.EditItem.Name = "EditItem";
            this.EditItem.Width = 58;
            // 
            // DeleteItem
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.NullValue = "删除";
            this.DeleteItem.DefaultCellStyle = dataGridViewCellStyle3;
            this.DeleteItem.HeaderText = "删除     ";
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Width = 58;
            // 
            // dgv_Data
            // 
            this.dgv_Data.AllowUserToAddRows = false;
            this.dgv_Data.AllowUserToResizeColumns = false;
            this.dgv_Data.AllowUserToResizeRows = false;
            this.dgv_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Data.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_Data.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Data.ColumnHeadersHeight = 25;
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dgv_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Data.Enabled = false;
            this.dgv_Data.Location = new System.Drawing.Point(3, 3);
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.RowTemplate.Height = 23;
            this.dgv_Data.Size = new System.Drawing.Size(1254, 165);
            this.dgv_Data.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "名称                            ";
            this.Column1.Name = "Column1";
            this.Column1.Width = 169;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "功能             ";
            this.Column2.Name = "Column2";
            this.Column2.Width = 109;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "下限        ";
            this.Column3.Name = "Column3";
            this.Column3.Width = 89;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "上限          ";
            this.Column4.Name = "Column4";
            this.Column4.Width = 97;
            // 
            // Column5
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Green;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column5.HeaderText = "1     ";
            this.Column5.Name = "Column5";
            this.Column5.Width = 56;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "2        ";
            this.Column6.Name = "Column6";
            this.Column6.Width = 72;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "3     ";
            this.Column7.Name = "Column7";
            this.Column7.Width = 56;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "4       ";
            this.Column8.Name = "Column8";
            this.Column8.Width = 68;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "5         ";
            this.Column9.Name = "Column9";
            this.Column9.Width = 76;
            // 
            // Frm_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 662);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_File)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtn_Exist;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgv_File;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewButtonColumn EditItem;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteItem;
        private System.Windows.Forms.DataGridView dgv_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}