namespace Vision.Forms
{
    partial class Frm_Unit
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
            this.pnl_Top = new System.Windows.Forms.Panel();
            this.pnl_Bottom = new System.Windows.Forms.Panel();
            this.pnl_Fill = new System.Windows.Forms.Panel();
            this.pnl_String = new System.Windows.Forms.Panel();
            this.nud_Spacing = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.pnl_Top.SuspendLayout();
            this.pnl_Bottom.SuspendLayout();
            this.pnl_String.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Spacing)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Top
            // 
            this.pnl_Top.AutoScroll = true;
            this.pnl_Top.Controls.Add(this.pnl_String);
            this.pnl_Top.Controls.Add(this.txt_Name);
            this.pnl_Top.Controls.Add(this.label1);
            this.pnl_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Top.Location = new System.Drawing.Point(0, 0);
            this.pnl_Top.Name = "pnl_Top";
            this.pnl_Top.Size = new System.Drawing.Size(460, 54);
            this.pnl_Top.TabIndex = 0;
            // 
            // pnl_Bottom
            // 
            this.pnl_Bottom.AutoScroll = true;
            this.pnl_Bottom.Controls.Add(this.btn_Cancel);
            this.pnl_Bottom.Controls.Add(this.btn_OK);
            this.pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Bottom.Location = new System.Drawing.Point(0, 614);
            this.pnl_Bottom.Name = "pnl_Bottom";
            this.pnl_Bottom.Size = new System.Drawing.Size(460, 51);
            this.pnl_Bottom.TabIndex = 1;
            // 
            // pnl_Fill
            // 
            this.pnl_Fill.AutoScroll = true;
            this.pnl_Fill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Fill.Location = new System.Drawing.Point(0, 54);
            this.pnl_Fill.Name = "pnl_Fill";
            this.pnl_Fill.Size = new System.Drawing.Size(460, 560);
            this.pnl_Fill.TabIndex = 2;
            // 
            // pnl_String
            // 
            this.pnl_String.Controls.Add(this.nud_Spacing);
            this.pnl_String.Controls.Add(this.label3);
            this.pnl_String.Location = new System.Drawing.Point(191, 11);
            this.pnl_String.Name = "pnl_String";
            this.pnl_String.Size = new System.Drawing.Size(164, 32);
            this.pnl_String.TabIndex = 9;
            // 
            // nud_Spacing
            // 
            this.nud_Spacing.Location = new System.Drawing.Point(89, 3);
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
            this.nud_Spacing.Size = new System.Drawing.Size(62, 23);
            this.nud_Spacing.TabIndex = 2;
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
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "字符间距调整";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(74, 14);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(111, 23);
            this.txt_Name.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "请输入名字";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(277, 12);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 27);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(21, 12);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 27);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // Frm_Unit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(460, 665);
            this.Controls.Add(this.pnl_Fill);
            this.Controls.Add(this.pnl_Bottom);
            this.Controls.Add(this.pnl_Top);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_Unit";
            this.Text = "Frm_Unit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Unit_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Unit_Load);
            this.pnl_Top.ResumeLayout(false);
            this.pnl_Top.PerformLayout();
            this.pnl_Bottom.ResumeLayout(false);
            this.pnl_String.ResumeLayout(false);
            this.pnl_String.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Spacing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Top;
        protected System.Windows.Forms.Panel pnl_String;
        protected System.Windows.Forms.NumericUpDown nud_Spacing;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_Bottom;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        protected System.Windows.Forms.Panel pnl_Fill;
    }
}