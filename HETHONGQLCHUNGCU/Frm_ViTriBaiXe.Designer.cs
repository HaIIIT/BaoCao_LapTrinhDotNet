namespace HETHONGQLCHUNGCU
{
    partial class Frm_ViTriBaiXe
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
            this.grp = new System.Windows.Forms.GroupBox();
            this.rdbBaoTri = new System.Windows.Forms.RadioButton();
            this.rdbDangSuDung = new System.Windows.Forms.RadioButton();
            this.rdbTrong = new System.Windows.Forms.RadioButton();
            this.cbx_LoaiCho = new System.Windows.Forms.ComboBox();
            this.txt_SoCho = new System.Windows.Forms.TextBox();
            this.txt_Tang = new System.Windows.Forms.TextBox();
            this.txt_KhuVuc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MaViTri = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Lammoi = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgvViTriBaiXe = new System.Windows.Forms.DataGridView();
            this.lbl_exit = new System.Windows.Forms.Label();
            this.grp.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViTriBaiXe)).BeginInit();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.BackColor = System.Drawing.Color.White;
            this.grp.Controls.Add(this.rdbBaoTri);
            this.grp.Controls.Add(this.rdbDangSuDung);
            this.grp.Controls.Add(this.rdbTrong);
            this.grp.Controls.Add(this.cbx_LoaiCho);
            this.grp.Controls.Add(this.txt_SoCho);
            this.grp.Controls.Add(this.txt_Tang);
            this.grp.Controls.Add(this.txt_KhuVuc);
            this.grp.Controls.Add(this.label1);
            this.grp.Controls.Add(this.txt_MaViTri);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.label6);
            this.grp.Controls.Add(this.label3);
            this.grp.Controls.Add(this.label5);
            this.grp.Controls.Add(this.label4);
            this.grp.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp.ForeColor = System.Drawing.Color.Teal;
            this.grp.Location = new System.Drawing.Point(12, 41);
            this.grp.Margin = new System.Windows.Forms.Padding(4);
            this.grp.Name = "grp";
            this.grp.Padding = new System.Windows.Forms.Padding(4);
            this.grp.Size = new System.Drawing.Size(750, 332);
            this.grp.TabIndex = 26;
            this.grp.TabStop = false;
            this.grp.Text = "Vị Trí Bãi Xe";
            // 
            // rdbBaoTri
            // 
            this.rdbBaoTri.AutoSize = true;
            this.rdbBaoTri.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbBaoTri.Location = new System.Drawing.Point(524, 262);
            this.rdbBaoTri.Margin = new System.Windows.Forms.Padding(4);
            this.rdbBaoTri.Name = "rdbBaoTri";
            this.rdbBaoTri.Size = new System.Drawing.Size(87, 27);
            this.rdbBaoTri.TabIndex = 40;
            this.rdbBaoTri.TabStop = true;
            this.rdbBaoTri.Text = "Bảo Trì";
            this.rdbBaoTri.UseVisualStyleBackColor = true;
            // 
            // rdbDangSuDung
            // 
            this.rdbDangSuDung.AutoSize = true;
            this.rdbDangSuDung.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDangSuDung.Location = new System.Drawing.Point(346, 262);
            this.rdbDangSuDung.Margin = new System.Windows.Forms.Padding(4);
            this.rdbDangSuDung.Name = "rdbDangSuDung";
            this.rdbDangSuDung.Size = new System.Drawing.Size(144, 27);
            this.rdbDangSuDung.TabIndex = 39;
            this.rdbDangSuDung.TabStop = true;
            this.rdbDangSuDung.Text = "Đang sử dụng";
            this.rdbDangSuDung.UseVisualStyleBackColor = true;
            // 
            // rdbTrong
            // 
            this.rdbTrong.AutoSize = true;
            this.rdbTrong.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTrong.Location = new System.Drawing.Point(242, 262);
            this.rdbTrong.Margin = new System.Windows.Forms.Padding(4);
            this.rdbTrong.Name = "rdbTrong";
            this.rdbTrong.Size = new System.Drawing.Size(78, 27);
            this.rdbTrong.TabIndex = 38;
            this.rdbTrong.TabStop = true;
            this.rdbTrong.Text = "Trống";
            this.rdbTrong.UseVisualStyleBackColor = true;
            // 
            // cbx_LoaiCho
            // 
            this.cbx_LoaiCho.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_LoaiCho.FormattingEnabled = true;
            this.cbx_LoaiCho.Location = new System.Drawing.Point(242, 210);
            this.cbx_LoaiCho.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_LoaiCho.Name = "cbx_LoaiCho";
            this.cbx_LoaiCho.Size = new System.Drawing.Size(359, 36);
            this.cbx_LoaiCho.TabIndex = 37;
            // 
            // txt_SoCho
            // 
            this.txt_SoCho.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SoCho.Location = new System.Drawing.Point(242, 168);
            this.txt_SoCho.Margin = new System.Windows.Forms.Padding(4);
            this.txt_SoCho.Name = "txt_SoCho";
            this.txt_SoCho.Size = new System.Drawing.Size(359, 34);
            this.txt_SoCho.TabIndex = 36;
            // 
            // txt_Tang
            // 
            this.txt_Tang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Tang.Location = new System.Drawing.Point(242, 125);
            this.txt_Tang.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Tang.Name = "txt_Tang";
            this.txt_Tang.Size = new System.Drawing.Size(359, 34);
            this.txt_Tang.TabIndex = 35;
            // 
            // txt_KhuVuc
            // 
            this.txt_KhuVuc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_KhuVuc.Location = new System.Drawing.Point(242, 83);
            this.txt_KhuVuc.Margin = new System.Windows.Forms.Padding(4);
            this.txt_KhuVuc.Name = "txt_KhuVuc";
            this.txt_KhuVuc.Size = new System.Drawing.Size(359, 34);
            this.txt_KhuVuc.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(156, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Mã Vị trí:";
            // 
            // txt_MaViTri
            // 
            this.txt_MaViTri.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MaViTri.Location = new System.Drawing.Point(242, 44);
            this.txt_MaViTri.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MaViTri.Name = "txt_MaViTri";
            this.txt_MaViTri.Size = new System.Drawing.Size(359, 34);
            this.txt_MaViTri.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(158, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 28;
            this.label2.Text = "Khu vực:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(140, 262);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 23);
            this.label6.TabIndex = 32;
            this.label6.Text = "Trạng Thái:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(182, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 23);
            this.label3.TabIndex = 29;
            this.label3.Text = "Tầng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(153, 219);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 23);
            this.label5.TabIndex = 31;
            this.label5.Text = "Loại Chỗ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(165, 174);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 23);
            this.label4.TabIndex = 30;
            this.label4.Text = "Số Chỗ:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Teal;
            this.label9.Location = new System.Drawing.Point(227, -1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(417, 38);
            this.label9.TabIndex = 28;
            this.label9.Text = "PHIẾU THÔNG TIN BÃI GỬI XE";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.btn_Lammoi);
            this.groupBox2.Controls.Add(this.btn_delete);
            this.groupBox2.Controls.Add(this.btn_update);
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(12, 380);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(750, 90);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tác Vụ Thực Hiện";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::HETHONGQLCHUNGCU.Properties.Resources.add;
            this.pictureBox3.Location = new System.Drawing.Point(6, 33);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 32;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::HETHONGQLCHUNGCU.Properties.Resources.change;
            this.pictureBox4.Location = new System.Drawing.Point(568, 33);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(43, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 37;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HETHONGQLCHUNGCU.Properties.Resources.pencil;
            this.pictureBox2.Location = new System.Drawing.Point(192, 33);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HETHONGQLCHUNGCU.Properties.Resources.delete;
            this.pictureBox1.Location = new System.Drawing.Point(378, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Lammoi
            // 
            this.btn_Lammoi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Lammoi.Location = new System.Drawing.Point(612, 33);
            this.btn_Lammoi.Name = "btn_Lammoi";
            this.btn_Lammoi.Size = new System.Drawing.Size(128, 40);
            this.btn_Lammoi.TabIndex = 36;
            this.btn_Lammoi.Text = "Làm Mới";
            this.btn_Lammoi.UseVisualStyleBackColor = true;
            this.btn_Lammoi.Click += new System.EventHandler(this.btn_Lammoi_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(422, 33);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(128, 40);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.Location = new System.Drawing.Point(235, 33);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(128, 40);
            this.btn_update.TabIndex = 1;
            this.btn_update.Text = "Cập Nhật";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.Teal;
            this.btn_add.Location = new System.Drawing.Point(49, 33);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(128, 40);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dgvViTriBaiXe
            // 
            this.dgvViTriBaiXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViTriBaiXe.Location = new System.Drawing.Point(769, 42);
            this.dgvViTriBaiXe.Name = "dgvViTriBaiXe";
            this.dgvViTriBaiXe.RowHeadersWidth = 51;
            this.dgvViTriBaiXe.RowTemplate.Height = 24;
            this.dgvViTriBaiXe.Size = new System.Drawing.Size(510, 428);
            this.dgvViTriBaiXe.TabIndex = 30;
            this.dgvViTriBaiXe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViTriBaiXe_CellClick);
            // 
            // lbl_exit
            // 
            this.lbl_exit.AutoSize = true;
            this.lbl_exit.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_exit.ForeColor = System.Drawing.Color.Red;
            this.lbl_exit.Location = new System.Drawing.Point(1259, 1);
            this.lbl_exit.Name = "lbl_exit";
            this.lbl_exit.Size = new System.Drawing.Size(29, 31);
            this.lbl_exit.TabIndex = 35;
            this.lbl_exit.Text = "X";
            this.lbl_exit.Click += new System.EventHandler(this.lbl_exit_Click);
            // 
            // Frm_ViTriBaiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 475);
            this.Controls.Add(this.lbl_exit);
            this.Controls.Add(this.dgvViTriBaiXe);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.grp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_ViTriBaiXe";
            this.Text = "Frm_ViTriBaiXe";
            this.Load += new System.EventHandler(this.Frm_ViTriBaiXe_Load);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViTriBaiXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgvViTriBaiXe;
        private System.Windows.Forms.RadioButton rdbBaoTri;
        private System.Windows.Forms.RadioButton rdbDangSuDung;
        private System.Windows.Forms.RadioButton rdbTrong;
        private System.Windows.Forms.ComboBox cbx_LoaiCho;
        private System.Windows.Forms.TextBox txt_SoCho;
        private System.Windows.Forms.TextBox txt_Tang;
        private System.Windows.Forms.TextBox txt_KhuVuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MaViTri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btn_Lammoi;
        private System.Windows.Forms.Label lbl_exit;
    }
}