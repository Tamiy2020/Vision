namespace Vision.Forms
{
    partial class Frm_TwoWin
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.hWindow_Final1 = new ChoiceTech.Halcon.Control.HWindow_Final();
            this.hWindow_Final2 = new ChoiceTech.Halcon.Control.HWindow_Final();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lbl_Yield1 = new System.Windows.Forms.Label();
            this.lbl_Num1 = new System.Windows.Forms.Label();
            this.lbl_Sum1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_OK1 = new System.Windows.Forms.Label();
            this.lbl_Yield2 = new System.Windows.Forms.Label();
            this.lbl_Num2 = new System.Windows.Forms.Label();
            this.lbl_Sum2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_OK2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1238, 721);
            this.splitContainer1.SplitterDistance = 947;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.hWindow_Final1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.hWindow_Final2);
            this.splitContainer2.Size = new System.Drawing.Size(947, 721);
            this.splitContainer2.SplitterDistance = 360;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
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
            this.hWindow_Final1.Size = new System.Drawing.Size(947, 360);
            this.hWindow_Final1.TabIndex = 0;
            // 
            // hWindow_Final2
            // 
            this.hWindow_Final2.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hWindow_Final2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindow_Final2.DrawModel = true;
            this.hWindow_Final2.EditModel = true;
            this.hWindow_Final2.Image = null;
            this.hWindow_Final2.Location = new System.Drawing.Point(0, 0);
            this.hWindow_Final2.Name = "hWindow_Final2";
            this.hWindow_Final2.Size = new System.Drawing.Size(947, 360);
            this.hWindow_Final2.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer3.Panel1.Controls.Add(this.lbl_Yield1);
            this.splitContainer3.Panel1.Controls.Add(this.lbl_Num1);
            this.splitContainer3.Panel1.Controls.Add(this.lbl_Sum1);
            this.splitContainer3.Panel1.Controls.Add(this.label7);
            this.splitContainer3.Panel1.Controls.Add(this.label5);
            this.splitContainer3.Panel1.Controls.Add(this.label4);
            this.splitContainer3.Panel1.Controls.Add(this.lbl_OK1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer3.Panel2.Controls.Add(this.lbl_Yield2);
            this.splitContainer3.Panel2.Controls.Add(this.lbl_Num2);
            this.splitContainer3.Panel2.Controls.Add(this.lbl_Sum2);
            this.splitContainer3.Panel2.Controls.Add(this.label12);
            this.splitContainer3.Panel2.Controls.Add(this.label13);
            this.splitContainer3.Panel2.Controls.Add(this.label14);
            this.splitContainer3.Panel2.Controls.Add(this.lbl_OK2);
            this.splitContainer3.Size = new System.Drawing.Size(290, 721);
            this.splitContainer3.SplitterDistance = 360;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 0;
            // 
            // lbl_Yield1
            // 
            this.lbl_Yield1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Yield1.AutoSize = true;
            this.lbl_Yield1.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lbl_Yield1.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_Yield1.Location = new System.Drawing.Point(197, 292);
            this.lbl_Yield1.Name = "lbl_Yield1";
            this.lbl_Yield1.Size = new System.Drawing.Size(24, 28);
            this.lbl_Yield1.TabIndex = 23;
            this.lbl_Yield1.Text = "0";
            // 
            // lbl_Num1
            // 
            this.lbl_Num1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_Num1.AutoSize = true;
            this.lbl_Num1.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lbl_Num1.ForeColor = System.Drawing.Color.Green;
            this.lbl_Num1.Location = new System.Drawing.Point(197, 222);
            this.lbl_Num1.Name = "lbl_Num1";
            this.lbl_Num1.Size = new System.Drawing.Size(24, 28);
            this.lbl_Num1.TabIndex = 22;
            this.lbl_Num1.Text = "0";
            // 
            // lbl_Sum1
            // 
            this.lbl_Sum1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Sum1.AutoSize = true;
            this.lbl_Sum1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Sum1.Location = new System.Drawing.Point(197, 150);
            this.lbl_Sum1.Name = "lbl_Sum1";
            this.lbl_Sum1.Size = new System.Drawing.Size(24, 28);
            this.lbl_Sum1.TabIndex = 21;
            this.lbl_Sum1.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(38, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 28);
            this.label7.TabIndex = 20;
            this.label7.Text = "良率";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(38, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 28);
            this.label5.TabIndex = 19;
            this.label5.Text = "良品";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(38, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 28);
            this.label4.TabIndex = 18;
            this.label4.Text = "产量";
            // 
            // lbl_OK1
            // 
            this.lbl_OK1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_OK1.BackColor = System.Drawing.Color.Green;
            this.lbl_OK1.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_OK1.Location = new System.Drawing.Point(59, 21);
            this.lbl_OK1.Name = "lbl_OK1";
            this.lbl_OK1.Size = new System.Drawing.Size(162, 97);
            this.lbl_OK1.TabIndex = 12;
            this.lbl_OK1.Text = "OK";
            this.lbl_OK1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Yield2
            // 
            this.lbl_Yield2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Yield2.AutoSize = true;
            this.lbl_Yield2.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lbl_Yield2.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_Yield2.Location = new System.Drawing.Point(197, 295);
            this.lbl_Yield2.Name = "lbl_Yield2";
            this.lbl_Yield2.Size = new System.Drawing.Size(24, 28);
            this.lbl_Yield2.TabIndex = 29;
            this.lbl_Yield2.Text = "0";
            // 
            // lbl_Num2
            // 
            this.lbl_Num2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_Num2.AutoSize = true;
            this.lbl_Num2.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lbl_Num2.ForeColor = System.Drawing.Color.Green;
            this.lbl_Num2.Location = new System.Drawing.Point(197, 224);
            this.lbl_Num2.Name = "lbl_Num2";
            this.lbl_Num2.Size = new System.Drawing.Size(24, 28);
            this.lbl_Num2.TabIndex = 28;
            this.lbl_Num2.Text = "0";
            // 
            // lbl_Sum2
            // 
            this.lbl_Sum2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Sum2.AutoSize = true;
            this.lbl_Sum2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Sum2.Location = new System.Drawing.Point(197, 156);
            this.lbl_Sum2.Name = "lbl_Sum2";
            this.lbl_Sum2.Size = new System.Drawing.Size(24, 28);
            this.lbl_Sum2.TabIndex = 27;
            this.lbl_Sum2.Text = "0";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.label12.ForeColor = System.Drawing.Color.Maroon;
            this.label12.Location = new System.Drawing.Point(38, 295);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 28);
            this.label12.TabIndex = 26;
            this.label12.Text = "良率";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.label13.ForeColor = System.Drawing.Color.Green;
            this.label13.Location = new System.Drawing.Point(38, 224);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 28);
            this.label13.TabIndex = 25;
            this.label13.Text = "良品";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(38, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 28);
            this.label14.TabIndex = 24;
            this.label14.Text = "产量";
            // 
            // lbl_OK2
            // 
            this.lbl_OK2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_OK2.BackColor = System.Drawing.Color.Green;
            this.lbl_OK2.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_OK2.Location = new System.Drawing.Point(59, 20);
            this.lbl_OK2.Name = "lbl_OK2";
            this.lbl_OK2.Size = new System.Drawing.Size(162, 97);
            this.lbl_OK2.TabIndex = 18;
            this.lbl_OK2.Text = "OK";
            this.lbl_OK2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_TwoWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 721);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_TwoWin";
            this.Text = "Frm_TwoWin";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final1;
        private ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lbl_Yield1;
        private System.Windows.Forms.Label lbl_Num1;
        private System.Windows.Forms.Label lbl_Sum1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_OK1;
        private System.Windows.Forms.Label lbl_Yield2;
        private System.Windows.Forms.Label lbl_Num2;
        private System.Windows.Forms.Label lbl_Sum2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_OK2;
    }
}