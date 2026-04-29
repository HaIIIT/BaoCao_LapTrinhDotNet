namespace HETHONGQLCHUNGCU
{
    partial class Frm_thongtincongno
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_mhd = new System.Windows.Forms.ComboBox();
            this.cbx_mch = new System.Windows.Forms.ComboBox();
            this.dtp_hanno = new System.Windows.Forms.DateTimePicker();
            this.txt_ghichu = new System.Windows.Forms.TextBox();
            this.dtp_ngayps = new System.Windows.Forms.DateTimePicker();
            this.rdb_quahan = new System.Windows.Forms.RadioButton();
            this.rdb_ctt = new System.Windows.Forms.RadioButton();
            this.rdb_dtt = new System.Windows.Forms.RadioButton();
            this.txt_sotien = new System.Windows.Forms.TextBox();
            this.txt_mcn = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btn_lammoi = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgv_ttcongno = new System.Windows.Forms.DataGridView();
            this.MaCongNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCanHo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ttcongno)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(282, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông Tin Công Nợ";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cbx_mhd);
            this.groupBox1.Controls.Add(this.cbx_mch);
            this.groupBox1.Controls.Add(this.dtp_hanno);
            this.groupBox1.Controls.Add(this.txt_ghichu);
            this.groupBox1.Controls.Add(this.dtp_ngayps);
            this.groupBox1.Controls.Add(this.rdb_quahan);
            this.groupBox1.Controls.Add(this.rdb_ctt);
            this.groupBox1.Controls.Add(this.rdb_dtt);
            this.groupBox1.Controls.Add(this.txt_sotien);
            this.groupBox1.Controls.Add(this.txt_mcn);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(822, 451);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Công Nợ";
            // 
            // cbx_mhd
            // 
            this.cbx_mhd.FormattingEnabled = true;
            this.cbx_mhd.Location = new System.Drawing.Point(228, 137);
            this.cbx_mhd.Name = "cbx_mhd";
            this.cbx_mhd.Size = new System.Drawing.Size(265, 36);
            this.cbx_mhd.TabIndex = 21;
            this.cbx_mhd.SelectedIndexChanged += new System.EventHandler(this.cbx_mhd_SelectedIndexChanged);
            // 
            // cbx_mch
            // 
            this.cbx_mch.Enabled = false;
            this.cbx_mch.FormattingEnabled = true;
            this.cbx_mch.Location = new System.Drawing.Point(228, 88);
            this.cbx_mch.Name = "cbx_mch";
            this.cbx_mch.Size = new System.Drawing.Size(265, 36);
            this.cbx_mch.TabIndex = 20;
            // 
            // dtp_hanno
            // 
            this.dtp_hanno.Enabled = false;
            this.dtp_hanno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtp_hanno.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_hanno.Location = new System.Drawing.Point(227, 269);
            this.dtp_hanno.Name = "dtp_hanno";
            this.dtp_hanno.Size = new System.Drawing.Size(266, 34);
            this.dtp_hanno.TabIndex = 19;
            this.dtp_hanno.Value = new System.DateTime(2026, 4, 22, 0, 0, 0, 0);
            // 
            // txt_ghichu
            // 
            this.txt_ghichu.Location = new System.Drawing.Point(228, 346);
            this.txt_ghichu.Multiline = true;
            this.txt_ghichu.Name = "txt_ghichu";
            this.txt_ghichu.Size = new System.Drawing.Size(274, 74);
            this.txt_ghichu.TabIndex = 18;
            // 
            // dtp_ngayps
            // 
            this.dtp_ngayps.Enabled = false;
            this.dtp_ngayps.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtp_ngayps.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngayps.Location = new System.Drawing.Point(227, 225);
            this.dtp_ngayps.Name = "dtp_ngayps";
            this.dtp_ngayps.Size = new System.Drawing.Size(266, 34);
            this.dtp_ngayps.TabIndex = 17;
            this.dtp_ngayps.Value = new System.DateTime(2026, 4, 22, 0, 0, 0, 0);
            // 
            // rdb_quahan
            // 
            this.rdb_quahan.AutoSize = true;
            this.rdb_quahan.ForeColor = System.Drawing.Color.Teal;
            this.rdb_quahan.Location = new System.Drawing.Point(557, 307);
            this.rdb_quahan.Name = "rdb_quahan";
            this.rdb_quahan.Size = new System.Drawing.Size(115, 32);
            this.rdb_quahan.TabIndex = 16;
            this.rdb_quahan.TabStop = true;
            this.rdb_quahan.Text = "Quá Hạn";
            this.rdb_quahan.UseVisualStyleBackColor = true;
            // 
            // rdb_ctt
            // 
            this.rdb_ctt.AutoSize = true;
            this.rdb_ctt.ForeColor = System.Drawing.Color.Teal;
            this.rdb_ctt.Location = new System.Drawing.Point(381, 307);
            this.rdb_ctt.Name = "rdb_ctt";
            this.rdb_ctt.Size = new System.Drawing.Size(169, 32);
            this.rdb_ctt.TabIndex = 15;
            this.rdb_ctt.TabStop = true;
            this.rdb_ctt.Text = "Chưa Tất Toán";
            this.rdb_ctt.UseVisualStyleBackColor = true;
            // 
            // rdb_dtt
            // 
            this.rdb_dtt.AutoSize = true;
            this.rdb_dtt.ForeColor = System.Drawing.Color.Teal;
            this.rdb_dtt.Location = new System.Drawing.Point(228, 307);
            this.rdb_dtt.Name = "rdb_dtt";
            this.rdb_dtt.Size = new System.Drawing.Size(147, 32);
            this.rdb_dtt.TabIndex = 14;
            this.rdb_dtt.TabStop = true;
            this.rdb_dtt.Text = "Đã Tất Toán";
            this.rdb_dtt.UseVisualStyleBackColor = true;
            // 
            // txt_sotien
            // 
            this.txt_sotien.Enabled = false;
            this.txt_sotien.Location = new System.Drawing.Point(227, 179);
            this.txt_sotien.Name = "txt_sotien";
            this.txt_sotien.Size = new System.Drawing.Size(266, 34);
            this.txt_sotien.TabIndex = 11;
            // 
            // txt_mcn
            // 
            this.txt_mcn.Location = new System.Drawing.Point(227, 40);
            this.txt_mcn.Name = "txt_mcn";
            this.txt_mcn.Size = new System.Drawing.Size(266, 34);
            this.txt_mcn.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label9.Location = new System.Drawing.Point(143, 354);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 23);
            this.label9.TabIndex = 7;
            this.label9.Text = "Ghi Chú:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Location = new System.Drawing.Point(125, 314);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "Trạng Thái:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(146, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "Hạn Nợ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(89, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Ngày Phát Sinh:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(121, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Số Tiền Nợ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(110, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mã Hóa Đơn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(121, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã Căn Hộ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(109, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Công Nợ:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.btn_lammoi);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.btn_delete);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.btn_update);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(12, 510);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(822, 115);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tác Vụ Thực Hiện";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::HETHONGQLCHUNGCU.Properties.Resources.change;
            this.pictureBox4.Location = new System.Drawing.Point(622, 44);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(43, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // btn_lammoi
            // 
            this.btn_lammoi.Location = new System.Drawing.Point(666, 44);
            this.btn_lammoi.Name = "btn_lammoi";
            this.btn_lammoi.Size = new System.Drawing.Size(128, 40);
            this.btn_lammoi.TabIndex = 6;
            this.btn_lammoi.Text = "Làm Mới";
            this.btn_lammoi.UseVisualStyleBackColor = true;
            this.btn_lammoi.Click += new System.EventHandler(this.btn_lammoi_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::HETHONGQLCHUNGCU.Properties.Resources.delete;
            this.pictureBox3.Location = new System.Drawing.Point(425, 44);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(468, 44);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(128, 40);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HETHONGQLCHUNGCU.Properties.Resources.pencil;
            this.pictureBox2.Location = new System.Drawing.Point(221, 44);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(264, 44);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(128, 40);
            this.btn_update.TabIndex = 2;
            this.btn_update.Text = "Cập Nhật";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HETHONGQLCHUNGCU.Properties.Resources.add;
            this.pictureBox1.Location = new System.Drawing.Point(22, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(65, 44);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(128, 40);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dgv_ttcongno
            // 
            this.dgv_ttcongno.AllowUserToAddRows = false;
            this.dgv_ttcongno.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ttcongno.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ttcongno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ttcongno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCongNo,
            this.MaCanHo,
            this.MaHoaDon,
            this.TrangThai});
            this.dgv_ttcongno.Location = new System.Drawing.Point(838, 53);
            this.dgv_ttcongno.Name = "dgv_ttcongno";
            this.dgv_ttcongno.ReadOnly = true;
            this.dgv_ttcongno.RowHeadersVisible = false;
            this.dgv_ttcongno.RowHeadersWidth = 51;
            this.dgv_ttcongno.RowTemplate.Height = 24;
            this.dgv_ttcongno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ttcongno.Size = new System.Drawing.Size(471, 572);
            this.dgv_ttcongno.TabIndex = 3;
            this.dgv_ttcongno.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ttcongno_CellClick);
            // 
            // MaCongNo
            // 
            this.MaCongNo.DataPropertyName = "MaCongNo";
            this.MaCongNo.HeaderText = "Mã Công Nợ";
            this.MaCongNo.MinimumWidth = 6;
            this.MaCongNo.Name = "MaCongNo";
            this.MaCongNo.ReadOnly = true;
            this.MaCongNo.Width = 125;
            // 
            // MaCanHo
            // 
            this.MaCanHo.DataPropertyName = "MaCanHo";
            this.MaCanHo.HeaderText = "Mã Căn Hộ";
            this.MaCanHo.MinimumWidth = 6;
            this.MaCanHo.Name = "MaCanHo";
            this.MaCanHo.ReadOnly = true;
            this.MaCanHo.Width = 125;
            // 
            // MaHoaDon
            // 
            this.MaHoaDon.DataPropertyName = "MaHoaDon";
            this.MaHoaDon.HeaderText = "Mã Hóa Đơn";
            this.MaHoaDon.MinimumWidth = 6;
            this.MaHoaDon.Name = "MaHoaDon";
            this.MaHoaDon.ReadOnly = true;
            this.MaHoaDon.Width = 125;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Width = 125;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(1282, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 31);
            this.label10.TabIndex = 4;
            this.label10.Text = "X";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // Frm_thongtincongno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 635);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgv_ttcongno);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_thongtincongno";
            this.Text = "Frm_thongtincongno";
            this.Load += new System.EventHandler(this.Frm_thongtincongno_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ttcongno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdb_ctt;
        private System.Windows.Forms.RadioButton rdb_dtt;
        private System.Windows.Forms.TextBox txt_sotien;
        private System.Windows.Forms.TextBox txt_mcn;
        private System.Windows.Forms.RadioButton rdb_quahan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtp_ngayps;
        private System.Windows.Forms.TextBox txt_ghichu;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btn_lammoi;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgv_ttcongno;
        private System.Windows.Forms.DateTimePicker dtp_hanno;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCongNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCanHo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbx_mhd;
        private System.Windows.Forms.ComboBox cbx_mch;
    }
}