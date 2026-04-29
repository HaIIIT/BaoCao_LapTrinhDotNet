namespace HETHONGQLCHUNGCU
{
    partial class Frm_TTPCNV_NhanSu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_load1 = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.cbx_tt = new System.Windows.Forms.ComboBox();
            this.btn_check = new System.Windows.Forms.Button();
            this.btn_tracuu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_lichnhiemvu = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_nd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_td = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_hanhoanthanh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nggiao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_dsnhiemvu = new System.Windows.Forms.DataGridView();
            this.MaPhanCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuDeCongViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanHoanThanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MucDoUuTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_exit = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsnhiemvu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(352, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(551, 41);
            this.label1.TabIndex = 13;
            this.label1.Text = "THÔNG TIN NHIỆM VỤ TRONG NGÀY";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btn_load1);
            this.groupBox1.Controls.Add(this.btn_load);
            this.groupBox1.Controls.Add(this.cbx_tt);
            this.groupBox1.Controls.Add(this.btn_check);
            this.groupBox1.Controls.Add(this.btn_tracuu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtp_lichnhiemvu);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(5, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1243, 131);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tra Cứu Nhiệm Vụ";
            // 
            // btn_load1
            // 
            this.btn_load1.Location = new System.Drawing.Point(910, 63);
            this.btn_load1.Name = "btn_load1";
            this.btn_load1.Size = new System.Drawing.Size(123, 40);
            this.btn_load1.TabIndex = 37;
            this.btn_load1.Text = "Load";
            this.btn_load1.UseVisualStyleBackColor = true;
            this.btn_load1.Click += new System.EventHandler(this.btn_load1_Click);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(299, 62);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(123, 40);
            this.btn_load.TabIndex = 36;
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // cbx_tt
            // 
            this.cbx_tt.FormattingEnabled = true;
            this.cbx_tt.Location = new System.Drawing.Point(512, 67);
            this.cbx_tt.Name = "cbx_tt";
            this.cbx_tt.Size = new System.Drawing.Size(221, 31);
            this.cbx_tt.TabIndex = 35;
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(766, 63);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(123, 40);
            this.btn_check.TabIndex = 34;
            this.btn_check.Text = "Checked";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // btn_tracuu
            // 
            this.btn_tracuu.Location = new System.Drawing.Point(296, 64);
            this.btn_tracuu.Name = "btn_tracuu";
            this.btn_tracuu.Size = new System.Drawing.Size(123, 40);
            this.btn_tracuu.TabIndex = 34;
            this.btn_tracuu.Text = "Tra Cứu";
            this.btn_tracuu.UseVisualStyleBackColor = true;
            this.btn_tracuu.Click += new System.EventHandler(this.btn_tracuu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(507, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Trạng Thái :";
            // 
            // dtp_lichnhiemvu
            // 
            this.dtp_lichnhiemvu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtp_lichnhiemvu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_lichnhiemvu.Location = new System.Drawing.Point(42, 68);
            this.dtp_lichnhiemvu.Name = "dtp_lichnhiemvu";
            this.dtp_lichnhiemvu.Size = new System.Drawing.Size(233, 34);
            this.dtp_lichnhiemvu.TabIndex = 33;
            this.dtp_lichnhiemvu.Value = new System.DateTime(2026, 4, 14, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(37, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 28);
            this.label7.TabIndex = 5;
            this.label7.Text = "Lịch Nhiệm Vụ:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txt_nd);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_td);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_hanhoanthanh);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_nggiao);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(5, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1243, 141);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Yêu Cầu Nhiệm Vụ";
            // 
            // txt_nd
            // 
            this.txt_nd.Enabled = false;
            this.txt_nd.Location = new System.Drawing.Point(745, 50);
            this.txt_nd.Multiline = true;
            this.txt_nd.Name = "txt_nd";
            this.txt_nd.Size = new System.Drawing.Size(492, 83);
            this.txt_nd.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(740, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 28);
            this.label6.TabIndex = 42;
            this.label6.Text = "Nội Dung :";
            // 
            // txt_td
            // 
            this.txt_td.Enabled = false;
            this.txt_td.Location = new System.Drawing.Point(492, 75);
            this.txt_td.Name = "txt_td";
            this.txt_td.Size = new System.Drawing.Size(214, 30);
            this.txt_td.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(487, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 28);
            this.label5.TabIndex = 40;
            this.label5.Text = "Tiêu đề :";
            // 
            // txt_hanhoanthanh
            // 
            this.txt_hanhoanthanh.Enabled = false;
            this.txt_hanhoanthanh.Location = new System.Drawing.Point(261, 75);
            this.txt_hanhoanthanh.Name = "txt_hanhoanthanh";
            this.txt_hanhoanthanh.Size = new System.Drawing.Size(214, 30);
            this.txt_hanhoanthanh.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(256, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 28);
            this.label4.TabIndex = 38;
            this.label4.Text = "Hạn Hoàn Thành :";
            // 
            // txt_nggiao
            // 
            this.txt_nggiao.Enabled = false;
            this.txt_nggiao.Location = new System.Drawing.Point(23, 75);
            this.txt_nggiao.Name = "txt_nggiao";
            this.txt_nggiao.Size = new System.Drawing.Size(214, 30);
            this.txt_nggiao.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(18, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 28);
            this.label3.TabIndex = 36;
            this.label3.Text = "Ngày Giao :";
            // 
            // dgv_dsnhiemvu
            // 
            this.dgv_dsnhiemvu.AllowUserToAddRows = false;
            this.dgv_dsnhiemvu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_dsnhiemvu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_dsnhiemvu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsnhiemvu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhanCong,
            this.TieuDeCongViec,
            this.NoiDung,
            this.NgayGiao,
            this.HanHoanThanh,
            this.MucDoUuTien,
            this.TrangThai});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_dsnhiemvu.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_dsnhiemvu.Location = new System.Drawing.Point(5, 357);
            this.dgv_dsnhiemvu.Name = "dgv_dsnhiemvu";
            this.dgv_dsnhiemvu.ReadOnly = true;
            this.dgv_dsnhiemvu.RowHeadersVisible = false;
            this.dgv_dsnhiemvu.RowHeadersWidth = 51;
            this.dgv_dsnhiemvu.RowTemplate.Height = 24;
            this.dgv_dsnhiemvu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_dsnhiemvu.Size = new System.Drawing.Size(1243, 317);
            this.dgv_dsnhiemvu.TabIndex = 0;
            this.dgv_dsnhiemvu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_dsnhiemvu_CellClick);
            // 
            // MaPhanCong
            // 
            this.MaPhanCong.DataPropertyName = "MaPhanCong";
            this.MaPhanCong.HeaderText = "Mã Phân Công";
            this.MaPhanCong.MinimumWidth = 6;
            this.MaPhanCong.Name = "MaPhanCong";
            this.MaPhanCong.ReadOnly = true;
            this.MaPhanCong.Width = 150;
            // 
            // TieuDeCongViec
            // 
            this.TieuDeCongViec.DataPropertyName = "TieuDeCongViec";
            this.TieuDeCongViec.HeaderText = "Tiều đề";
            this.TieuDeCongViec.MinimumWidth = 6;
            this.TieuDeCongViec.Name = "TieuDeCongViec";
            this.TieuDeCongViec.ReadOnly = true;
            this.TieuDeCongViec.Width = 180;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.MinimumWidth = 6;
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            this.NoiDung.Width = 250;
            // 
            // NgayGiao
            // 
            this.NgayGiao.DataPropertyName = "NgayGiao";
            this.NgayGiao.HeaderText = "Ngày Giao";
            this.NgayGiao.MinimumWidth = 6;
            this.NgayGiao.Name = "NgayGiao";
            this.NgayGiao.ReadOnly = true;
            this.NgayGiao.Width = 180;
            // 
            // HanHoanThanh
            // 
            this.HanHoanThanh.DataPropertyName = "HanHoanThanh";
            this.HanHoanThanh.HeaderText = "Hạn Hoàn Thành";
            this.HanHoanThanh.MinimumWidth = 6;
            this.HanHoanThanh.Name = "HanHoanThanh";
            this.HanHoanThanh.ReadOnly = true;
            this.HanHoanThanh.Width = 180;
            // 
            // MucDoUuTien
            // 
            this.MucDoUuTien.DataPropertyName = "MucDoUuTien";
            this.MucDoUuTien.HeaderText = "Mức Độ Ưu Tiên";
            this.MucDoUuTien.MinimumWidth = 6;
            this.MucDoUuTien.Name = "MucDoUuTien";
            this.MucDoUuTien.ReadOnly = true;
            this.MucDoUuTien.Width = 150;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Width = 200;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Teal;
            this.label8.Location = new System.Drawing.Point(5, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 23);
            this.label8.TabIndex = 36;
            this.label8.Text = "Danh Sách Nhiệm Vụ";
            // 
            // lbl_exit
            // 
            this.lbl_exit.AutoSize = true;
            this.lbl_exit.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_exit.ForeColor = System.Drawing.Color.Red;
            this.lbl_exit.Location = new System.Drawing.Point(1227, 3);
            this.lbl_exit.Name = "lbl_exit";
            this.lbl_exit.Size = new System.Drawing.Size(35, 38);
            this.lbl_exit.TabIndex = 37;
            this.lbl_exit.Text = "X";
            this.lbl_exit.Click += new System.EventHandler(this.lbl_exit_Click);
            // 
            // Frm_TTPCNV_NhanSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 693);
            this.Controls.Add(this.lbl_exit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgv_dsnhiemvu);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_TTPCNV_NhanSu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_TTPCNV_NhanSu";
            this.Load += new System.EventHandler(this.Frm_TTPCNV_NhanSu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsnhiemvu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_tracuu;
        private System.Windows.Forms.DateTimePicker dtp_lichnhiemvu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbx_tt;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_dsnhiemvu;
        private System.Windows.Forms.TextBox txt_nd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_td;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_hanhoanthanh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_nggiao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhanCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuDeCongViec;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiao;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanHoanThanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn MucDoUuTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.Button btn_load1;
        private System.Windows.Forms.Label lbl_exit;
    }
}