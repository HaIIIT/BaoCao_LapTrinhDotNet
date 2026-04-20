namespace HETHONGQLCHUNGCU
{
    partial class Frm_Hejthongkhoiphuctaikhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Hejthongkhoiphuctaikhoan));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txt_tk = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_xacthuc = new System.Windows.Forms.Button();
            this.grb_xacthuc = new System.Windows.Forms.GroupBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grb_changePwd = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_otp = new System.Windows.Forms.Button();
            this.txt_comform = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.txt_newmk = new System.Windows.Forms.TextBox();
            this.txt_otp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grb_xacthuc.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grb_changePwd.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(608, 390);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(269, 28);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "<< Trở về trang đăng nhập";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // txt_tk
            // 
            this.txt_tk.Location = new System.Drawing.Point(174, 36);
            this.txt_tk.Name = "txt_tk";
            this.txt_tk.Size = new System.Drawing.Size(184, 30);
            this.txt_tk.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(113, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(49, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Tài Khoản:";
            // 
            // btn_xacthuc
            // 
            this.btn_xacthuc.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xacthuc.Location = new System.Drawing.Point(376, 79);
            this.btn_xacthuc.Name = "btn_xacthuc";
            this.btn_xacthuc.Size = new System.Drawing.Size(100, 31);
            this.btn_xacthuc.TabIndex = 4;
            this.btn_xacthuc.Text = "Xác Thực";
            this.btn_xacthuc.UseVisualStyleBackColor = true;
            this.btn_xacthuc.Click += new System.EventHandler(this.btn_xacthuc_Click);
            // 
            // grb_xacthuc
            // 
            this.grb_xacthuc.BackColor = System.Drawing.Color.White;
            this.grb_xacthuc.Controls.Add(this.btn_xacthuc);
            this.grb_xacthuc.Controls.Add(this.txt_email);
            this.grb_xacthuc.Controls.Add(this.txt_tk);
            this.grb_xacthuc.Controls.Add(this.label3);
            this.grb_xacthuc.Controls.Add(this.label2);
            this.grb_xacthuc.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_xacthuc.ForeColor = System.Drawing.Color.Teal;
            this.grb_xacthuc.Location = new System.Drawing.Point(361, 14);
            this.grb_xacthuc.Name = "grb_xacthuc";
            this.grb_xacthuc.Size = new System.Drawing.Size(503, 129);
            this.grb_xacthuc.TabIndex = 8;
            this.grb_xacthuc.TabStop = false;
            this.grb_xacthuc.Text = "Xác thực người dùng";
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(174, 79);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(184, 30);
            this.txt_email.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 76);
            this.label1.TabIndex = 3;
            this.label1.Text = "HỆ THỐNG KHÔI PHỤC \r\n           TÀI KHOẢN";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 417);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(30, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(276, 265);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // grb_changePwd
            // 
            this.grb_changePwd.BackColor = System.Drawing.Color.White;
            this.grb_changePwd.Controls.Add(this.label7);
            this.grb_changePwd.Controls.Add(this.btn_otp);
            this.grb_changePwd.Controls.Add(this.txt_comform);
            this.grb_changePwd.Controls.Add(this.label6);
            this.grb_changePwd.Controls.Add(this.btn_update);
            this.grb_changePwd.Controls.Add(this.txt_newmk);
            this.grb_changePwd.Controls.Add(this.txt_otp);
            this.grb_changePwd.Controls.Add(this.label4);
            this.grb_changePwd.Controls.Add(this.label5);
            this.grb_changePwd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_changePwd.ForeColor = System.Drawing.Color.Teal;
            this.grb_changePwd.Location = new System.Drawing.Point(361, 156);
            this.grb_changePwd.Name = "grb_changePwd";
            this.grb_changePwd.Size = new System.Drawing.Size(503, 219);
            this.grb_changePwd.TabIndex = 12;
            this.grb_changePwd.TabStop = false;
            this.grb_changePwd.Text = "Đặt lại mật khẩu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(171, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "*nhấm enter khi nhập xong dữ liệu";
            // 
            // btn_otp
            // 
            this.btn_otp.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_otp.Location = new System.Drawing.Point(364, 35);
            this.btn_otp.Name = "btn_otp";
            this.btn_otp.Size = new System.Drawing.Size(125, 31);
            this.btn_otp.TabIndex = 7;
            this.btn_otp.Text = "Gửi  mã OTP";
            this.btn_otp.UseVisualStyleBackColor = true;
            this.btn_otp.Click += new System.EventHandler(this.btn_otp_Click);
            // 
            // txt_comform
            // 
            this.txt_comform.Location = new System.Drawing.Point(174, 134);
            this.txt_comform.Name = "txt_comform";
            this.txt_comform.Size = new System.Drawing.Size(184, 30);
            this.txt_comform.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(13, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nhập lại mật khẩu:";
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Location = new System.Drawing.Point(214, 179);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(100, 31);
            this.btn_update.TabIndex = 4;
            this.btn_update.Text = "Cập nhật";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // txt_newmk
            // 
            this.txt_newmk.Location = new System.Drawing.Point(174, 89);
            this.txt_newmk.Name = "txt_newmk";
            this.txt_newmk.Size = new System.Drawing.Size(184, 30);
            this.txt_newmk.TabIndex = 3;
            // 
            // txt_otp
            // 
            this.txt_otp.Location = new System.Drawing.Point(174, 36);
            this.txt_otp.Name = "txt_otp";
            this.txt_otp.Size = new System.Drawing.Size(184, 30);
            this.txt_otp.TabIndex = 2;
            this.txt_otp.TextChanged += new System.EventHandler(this.txt_otp_TextChanged_1);
            this.txt_otp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_otp_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(48, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mật khẩu mới:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(49, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nhập mã OTP:";
            // 
            // Frm_Hejthongkhoiphuctaikhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(882, 420);
            this.Controls.Add(this.grb_changePwd);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.grb_xacthuc);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Hejthongkhoiphuctaikhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Hejthongkhoiphuctaikhoan";
            this.Load += new System.EventHandler(this.Frm_Hejthongkhoiphuctaikhoan_Load);
            this.grb_xacthuc.ResumeLayout(false);
            this.grb_xacthuc.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grb_changePwd.ResumeLayout(false);
            this.grb_changePwd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txt_tk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_xacthuc;
        private System.Windows.Forms.GroupBox grb_xacthuc;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grb_changePwd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_otp;
        private System.Windows.Forms.TextBox txt_comform;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.TextBox txt_newmk;
        private System.Windows.Forms.TextBox txt_otp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}