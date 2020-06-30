namespace Vision.Forms
{
    partial class Frm_FourWin
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
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.hWindow_Final1 = new ChoiceTech.Halcon.Control.HWindow_Final();
            this.hWindow_Final2 = new ChoiceTech.Halcon.Control.HWindow_Final();
            this.hWindow_Final3 = new ChoiceTech.Halcon.Control.HWindow_Final();
            this.hWindow_Final4 = new ChoiceTech.Halcon.Control.HWindow_Final();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1280, 712);
            this.splitContainer1.SplitterDistance = 1018;
            this.splitContainer1.TabIndex = 0;
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
            this.splitContainer2.Panel1.Controls.Add(this.hWindow_Final1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1018, 712);
            this.splitContainer2.SplitterDistance = 175;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.hWindow_Final2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(1018, 536);
            this.splitContainer3.SplitterDistance = 190;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.hWindow_Final3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.hWindow_Final4);
            this.splitContainer4.Size = new System.Drawing.Size(1018, 345);
            this.splitContainer4.SplitterDistance = 181;
            this.splitContainer4.SplitterWidth = 1;
            this.splitContainer4.TabIndex = 0;
            // 
            // hWindow_Final1
            // 
            this.hWindow_Final1.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hWindow_Final1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindow_Final1.DrawModel = false;
            this.hWindow_Final1.EditModel = true;
            this.hWindow_Final1.Image = null;
            this.hWindow_Final1.Location = new System.Drawing.Point(0, 0);
            this.hWindow_Final1.Name = "hWindow_Final1";
            this.hWindow_Final1.Size = new System.Drawing.Size(1018, 175);
            this.hWindow_Final1.TabIndex = 0;
            // 
            // hWindow_Final2
            // 
            this.hWindow_Final2.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hWindow_Final2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindow_Final2.DrawModel = false;
            this.hWindow_Final2.EditModel = true;
            this.hWindow_Final2.Image = null;
            this.hWindow_Final2.Location = new System.Drawing.Point(0, 0);
            this.hWindow_Final2.Name = "hWindow_Final2";
            this.hWindow_Final2.Size = new System.Drawing.Size(1018, 190);
            this.hWindow_Final2.TabIndex = 1;
            // 
            // hWindow_Final3
            // 
            this.hWindow_Final3.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hWindow_Final3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindow_Final3.DrawModel = false;
            this.hWindow_Final3.EditModel = true;
            this.hWindow_Final3.Image = null;
            this.hWindow_Final3.Location = new System.Drawing.Point(0, 0);
            this.hWindow_Final3.Name = "hWindow_Final3";
            this.hWindow_Final3.Size = new System.Drawing.Size(1018, 181);
            this.hWindow_Final3.TabIndex = 1;
            // 
            // hWindow_Final4
            // 
            this.hWindow_Final4.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hWindow_Final4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindow_Final4.DrawModel = false;
            this.hWindow_Final4.EditModel = true;
            this.hWindow_Final4.Image = null;
            this.hWindow_Final4.Location = new System.Drawing.Point(0, 0);
            this.hWindow_Final4.Name = "hWindow_Final4";
            this.hWindow_Final4.Size = new System.Drawing.Size(1018, 163);
            this.hWindow_Final4.TabIndex = 1;
            // 
            // Frm_FourWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 712);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_FourWin";
            this.Text = "Frm_FourWin";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final3;
        private ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final4;
    }
}