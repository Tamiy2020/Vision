namespace Vision.Forms
{
    partial class Frm_OneWin
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
            this.lbl_Yield1 = new System.Windows.Forms.Label();
            this.lbl_Num1 = new System.Windows.Forms.Label();
            this.lbl_Sum1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_OK1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel2.Controls.Add(this.lbl_Yield1);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_Num1);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_Sum1);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_OK1);
            this.splitContainer1.Size = new System.Drawing.Size(1210, 692);
            this.splitContainer1.SplitterDistance = 912;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // hWindow_Final1
            // 
            this.hWindow_Final1.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hWindow_Final1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindow_Final1.DrawModel = true;
            this.hWindow_Final1.EditModel = true;
            this.hWindow_Final1.Image = null;
            this.hWindow_Final1.Location = new System.Drawing.Point(0, 0);
            this.hWindow_Final1.Name = "hWindow_Final1";
            this.hWindow_Final1.Size = new System.Drawing.Size(912, 692);
            this.hWindow_Final1.TabIndex = 0;
            // 
            // lbl_Yield1
            // 
            this.lbl_Yield1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_Yield1.AutoSize = true;
            this.lbl_Yield1.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lbl_Yield1.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_Yield1.Location = new System.Drawing.Point(192, 560);
            this.lbl_Yield1.Name = "lbl_Yield1";
            this.lbl_Yield1.Size = new System.Drawing.Size(24, 28);
            this.lbl_Yield1.TabIndex = 37;
            this.lbl_Yield1.Text = "0";
            // 
            // lbl_Num1
            // 
            this.lbl_Num1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_Num1.AutoSize = true;
            this.lbl_Num1.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lbl_Num1.ForeColor = System.Drawing.Color.Green;
            this.lbl_Num1.Location = new System.Drawing.Point(192, 484);
            this.lbl_Num1.Name = "lbl_Num1";
            this.lbl_Num1.Size = new System.Drawing.Size(24, 28);
            this.lbl_Num1.TabIndex = 36;
            this.lbl_Num1.Text = "0";
            // 
            // lbl_Sum1
            // 
            this.lbl_Sum1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_Sum1.AutoSize = true;
            this.lbl_Sum1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Sum1.Location = new System.Drawing.Point(192, 408);
            this.lbl_Sum1.Name = "lbl_Sum1";
            this.lbl_Sum1.Size = new System.Drawing.Size(24, 28);
            this.lbl_Sum1.TabIndex = 35;
            this.lbl_Sum1.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(26, 560);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 28);
            this.label7.TabIndex = 34;
            this.label7.Text = "良率";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(26, 484);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 28);
            this.label5.TabIndex = 33;
            this.label5.Text = "良品";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(26, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 28);
            this.label4.TabIndex = 32;
            this.label4.Text = "产量";
            // 
            // lbl_OK1
            // 
            this.lbl_OK1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_OK1.BackColor = System.Drawing.Color.Green;
            this.lbl_OK1.Font = new System.Drawing.Font("微软雅黑", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_OK1.Location = new System.Drawing.Point(26, 102);
            this.lbl_OK1.Name = "lbl_OK1";
            this.lbl_OK1.Size = new System.Drawing.Size(250, 182);
            this.lbl_OK1.TabIndex = 26;
            this.lbl_OK1.Text = "OK";
            this.lbl_OK1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_OneWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 692);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_OneWin";
            this.Text = "Frm_OneWin";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final1;
        private System.Windows.Forms.Label lbl_Yield1;
        private System.Windows.Forms.Label lbl_Num1;
        private System.Windows.Forms.Label lbl_Sum1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_OK1;
    }
}