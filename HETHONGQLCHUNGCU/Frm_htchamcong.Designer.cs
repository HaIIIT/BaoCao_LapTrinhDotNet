namespace HETHONGQLCHUNGCU
{
    partial class Frm_htchamcong
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
            this.lbl_trangthai = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnchamcong = new System.Windows.Forms.Button();
            this.pic_camera = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.llbl_exit = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pic_camera)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_trangthai
            // 
            this.lbl_trangthai.AutoSize = true;
            this.lbl_trangthai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_trangthai.ForeColor = System.Drawing.Color.White;
            this.lbl_trangthai.Location = new System.Drawing.Point(264, 8);
            this.lbl_trangthai.Name = "lbl_trangthai";
            this.lbl_trangthai.Size = new System.Drawing.Size(0, 22);
            this.lbl_trangthai.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 123);
            this.label1.TabIndex = 9;
            this.label1.Text = "  HỆ THỐNG \r\nCHẤM CÔNG \r\n   NHÂN SỰ";
            // 
            // btnchamcong
            // 
            this.btnchamcong.Location = new System.Drawing.Point(473, 365);
            this.btnchamcong.Name = "btnchamcong";
            this.btnchamcong.Size = new System.Drawing.Size(111, 42);
            this.btnchamcong.TabIndex = 8;
            this.btnchamcong.Text = "Chấm công";
            this.btnchamcong.UseVisualStyleBackColor = true;
            this.btnchamcong.Click += new System.EventHandler(this.btnchamcong_Click);
            // 
            // pic_camera
            // 
            this.pic_camera.Location = new System.Drawing.Point(259, 40);
            this.pic_camera.Name = "pic_camera";
            this.pic_camera.Size = new System.Drawing.Size(508, 319);
            this.pic_camera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_camera.TabIndex = 6;
            this.pic_camera.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 413);
            this.panel1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HETHONGQLCHUNGCU.Properties.Resources.canho1;
            this.pictureBox1.Location = new System.Drawing.Point(22, 137);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // llbl_exit
            // 
            this.llbl_exit.AutoSize = true;
            this.llbl_exit.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbl_exit.LinkColor = System.Drawing.Color.Red;
            this.llbl_exit.Location = new System.Drawing.Point(738, 6);
            this.llbl_exit.Name = "llbl_exit";
            this.llbl_exit.Size = new System.Drawing.Size(29, 31);
            this.llbl_exit.TabIndex = 12;
            this.llbl_exit.TabStop = true;
            this.llbl_exit.Text = "X";
            this.llbl_exit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbl_exit_LinkClicked);
            // 
            // Frm_htchamcong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(779, 413);
            this.Controls.Add(this.llbl_exit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_trangthai);
            this.Controls.Add(this.btnchamcong);
            this.Controls.Add(this.pic_camera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_htchamcong";
            this.Text = "Frm_htchamcong";
            this.Load += new System.EventHandler(this.Frm_htchamcong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_camera)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_trangthai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnchamcong;
        private System.Windows.Forms.PictureBox pic_camera;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel llbl_exit;
    }
}