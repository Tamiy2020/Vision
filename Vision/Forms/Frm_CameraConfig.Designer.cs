namespace Vision.Forms
{
    partial class Frm_CameraConfig
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
            this.lbl_C1 = new System.Windows.Forms.Label();
            this.lbl_C2 = new System.Windows.Forms.Label();
            this.lbl_C3 = new System.Windows.Forms.Label();
            this.lbl_C4 = new System.Windows.Forms.Label();
            this.lbl_C5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_OK1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_OK2 = new System.Windows.Forms.Button();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fbd_Image = new Ookii.Dialogs.WinForms.VistaFolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_C1
            // 
            this.lbl_C1.AutoSize = true;
            this.lbl_C1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_C1.Location = new System.Drawing.Point(137, 38);
            this.lbl_C1.Name = "lbl_C1";
            this.lbl_C1.Size = new System.Drawing.Size(0, 19);
            this.lbl_C1.TabIndex = 0;
            // 
            // lbl_C2
            // 
            this.lbl_C2.AutoSize = true;
            this.lbl_C2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_C2.Location = new System.Drawing.Point(137, 79);
            this.lbl_C2.Name = "lbl_C2";
            this.lbl_C2.Size = new System.Drawing.Size(0, 19);
            this.lbl_C2.TabIndex = 1;
            // 
            // lbl_C3
            // 
            this.lbl_C3.AutoSize = true;
            this.lbl_C3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_C3.Location = new System.Drawing.Point(137, 120);
            this.lbl_C3.Name = "lbl_C3";
            this.lbl_C3.Size = new System.Drawing.Size(0, 19);
            this.lbl_C3.TabIndex = 2;
            // 
            // lbl_C4
            // 
            this.lbl_C4.AutoSize = true;
            this.lbl_C4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_C4.Location = new System.Drawing.Point(137, 161);
            this.lbl_C4.Name = "lbl_C4";
            this.lbl_C4.Size = new System.Drawing.Size(0, 19);
            this.lbl_C4.TabIndex = 3;
            // 
            // lbl_C5
            // 
            this.lbl_C5.AutoSize = true;
            this.lbl_C5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_C5.Location = new System.Drawing.Point(137, 202);
            this.lbl_C5.Name = "lbl_C5";
            this.lbl_C5.Size = new System.Drawing.Size(0, 19);
            this.lbl_C5.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_OK1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(116, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 133);
            this.panel1.TabIndex = 5;
            // 
            // btn_OK1
            // 
            this.btn_OK1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OK1.Location = new System.Drawing.Point(222, 73);
            this.btn_OK1.Name = "btn_OK1";
            this.btn_OK1.Size = new System.Drawing.Size(95, 31);
            this.btn_OK1.TabIndex = 2;
            this.btn_OK1.Text = "配置完成";
            this.btn_OK1.UseVisualStyleBackColor = true;
            this.btn_OK1.Click += new System.EventHandler(this.btn_OK1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(241, 25);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(9, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "选择相机：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Add);
            this.panel2.Controls.Add(this.btn_OK2);
            this.panel2.Controls.Add(this.txt_Path);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(116, 224);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 186);
            this.panel2.TabIndex = 6;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(113, 70);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(80, 37);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "添加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_OK2
            // 
            this.btn_OK2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OK2.Location = new System.Drawing.Point(300, 70);
            this.btn_OK2.Name = "btn_OK2";
            this.btn_OK2.Size = new System.Drawing.Size(80, 37);
            this.btn_OK2.TabIndex = 3;
            this.btn_OK2.Text = "配置完成";
            this.btn_OK2.UseVisualStyleBackColor = true;
            this.btn_OK2.Click += new System.EventHandler(this.btn_OK2_Click);
            // 
            // txt_Path
            // 
            this.txt_Path.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Path.Location = new System.Drawing.Point(113, 35);
            this.txt_Path.Multiline = true;
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(267, 27);
            this.txt_Path.TabIndex = 2;
            this.txt_Path.DoubleClick += new System.EventHandler(this.txt_Path_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(9, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "选择路径：";
            // 
            // Frm_CameraConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 432);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_C5);
            this.Controls.Add(this.lbl_C4);
            this.Controls.Add(this.lbl_C3);
            this.Controls.Add(this.lbl_C2);
            this.Controls.Add(this.lbl_C1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_CameraConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "相机配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_CameraConfig_FormClosing);
            this.Load += new System.EventHandler(this.Frm_CameraConfig_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_C1;
        private System.Windows.Forms.Label lbl_C2;
        private System.Windows.Forms.Label lbl_C3;
        private System.Windows.Forms.Label lbl_C4;
        private System.Windows.Forms.Label lbl_C5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_OK1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_OK2;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Add;
        private Ookii.Dialogs.WinForms.VistaFolderBrowserDialog fbd_Image;
    }
}