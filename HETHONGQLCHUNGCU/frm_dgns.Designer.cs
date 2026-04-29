namespace HETHONGQLCHUNGCU
{
    partial class frm_dgns
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_xl = new System.Windows.Forms.ComboBox();
            this.txt_tongd = new System.Windows.Forms.TextBox();
            this.txt_dtd = new System.Windows.Forms.TextBox();
            this.txt_dhx = new System.Windows.Forms.TextBox();
            this.txt_dtp = new System.Windows.Forms.TextBox();
            this.txt_nx = new System.Windows.Forms.TextBox();
            this.dtp_ngdg = new System.Windows.Forms.DateTimePicker();
            this.txt_kydg = new System.Windows.Forms.TextBox();
            this.txt_mdg = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btn_lammoi = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgvdsdg = new System.Windows.Forms.DataGridView();
            this.cbx_ns = new System.Windows.Forms.ComboBox();
            this.MaDanhGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhanSu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyDanhGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_exit = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdsdg)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cbx_ns);
            this.groupBox1.Controls.Add(this.cbx_xl);
            this.groupBox1.Controls.Add(this.txt_tongd);
            this.groupBox1.Controls.Add(this.txt_dtd);
            this.groupBox1.Controls.Add(this.txt_dhx);
            this.groupBox1.Controls.Add(this.txt_dtp);
            this.groupBox1.Controls.Add(this.txt_nx);
            this.groupBox1.Controls.Add(this.dtp_ngdg);
            this.groupBox1.Controls.Add(this.txt_kydg);
            this.groupBox1.Controls.Add(this.txt_mdg);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(840, 351);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bảng Đánh Giá Nhân Sự";
            // 
            // cbx_xl
            // 
            this.cbx_xl.Enabled = false;
            this.cbx_xl.FormattingEnabled = true;
            this.cbx_xl.Location = new System.Drawing.Point(612, 242);
            this.cbx_xl.Name = "cbx_xl";
            this.cbx_xl.Size = new System.Drawing.Size(170, 31);
            this.cbx_xl.TabIndex = 19;
            // 
            // txt_tongd
            // 
            this.txt_tongd.Enabled = false;
            this.txt_tongd.Location = new System.Drawing.Point(612, 185);
            this.txt_tongd.Name = "txt_tongd";
            this.txt_tongd.Size = new System.Drawing.Size(170, 30);
            this.txt_tongd.TabIndex = 18;
            // 
            // txt_dtd
            // 
            this.txt_dtd.Location = new System.Drawing.Point(612, 134);
            this.txt_dtd.Name = "txt_dtd";
            this.txt_dtd.Size = new System.Drawing.Size(170, 30);
            this.txt_dtd.TabIndex = 17;
            this.txt_dtd.TextChanged += new System.EventHandler(this.txt_dtd_TextChanged);
            // 
            // txt_dhx
            // 
            this.txt_dhx.Location = new System.Drawing.Point(612, 87);
            this.txt_dhx.Name = "txt_dhx";
            this.txt_dhx.Size = new System.Drawing.Size(170, 30);
            this.txt_dhx.TabIndex = 16;
            this.txt_dhx.TextChanged += new System.EventHandler(this.txt_dhx_TextChanged);
            // 
            // txt_dtp
            // 
            this.txt_dtp.Location = new System.Drawing.Point(612, 41);
            this.txt_dtp.Name = "txt_dtp";
            this.txt_dtp.Size = new System.Drawing.Size(170, 30);
            this.txt_dtp.TabIndex = 15;
            this.txt_dtp.TextChanged += new System.EventHandler(this.txt_dtp_TextChanged);
            // 
            // txt_nx
            // 
            this.txt_nx.Location = new System.Drawing.Point(175, 233);
            this.txt_nx.Multiline = true;
            this.txt_nx.Name = "txt_nx";
            this.txt_nx.Size = new System.Drawing.Size(254, 79);
            this.txt_nx.TabIndex = 14;
            // 
            // dtp_ngdg
            // 
            this.dtp_ngdg.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_ngdg.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngdg.Location = new System.Drawing.Point(175, 184);
            this.dtp_ngdg.Name = "dtp_ngdg";
            this.dtp_ngdg.Size = new System.Drawing.Size(254, 24);
            this.dtp_ngdg.TabIndex = 13;
            // 
            // txt_kydg
            // 
            this.txt_kydg.Location = new System.Drawing.Point(175, 133);
            this.txt_kydg.Name = "txt_kydg";
            this.txt_kydg.Size = new System.Drawing.Size(254, 30);
            this.txt_kydg.TabIndex = 12;
            // 
            // txt_mdg
            // 
            this.txt_mdg.Location = new System.Drawing.Point(175, 41);
            this.txt_mdg.Name = "txt_mdg";
            this.txt_mdg.Size = new System.Drawing.Size(254, 30);
            this.txt_mdg.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label10.Location = new System.Drawing.Point(516, 242);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "Xếp Loại : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label9.Location = new System.Drawing.Point(480, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Điểm Thái Độ : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Location = new System.Drawing.Point(458, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Điểm Tác Phong : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(464, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Điểm Hiệu Xuất : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(501, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tổng Điểm : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(69, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nhận Xét :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(24, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày Đánh Giá : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(44, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kỳ Đánh Giá :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(44, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Nhân Sự :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(43, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Đánh Giá:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Teal;
            this.label11.Location = new System.Drawing.Point(240, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(385, 38);
            this.label11.TabIndex = 27;
            this.label11.Text = "BẢNG ĐÁNH GIÁ NHÂN SỰ";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.btn_lammoi);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.btn_delete);
            this.groupBox2.Controls.Add(this.btn_update);
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(12, 407);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(840, 90);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tác Vụ Thực Hiện";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::HETHONGQLCHUNGCU.Properties.Resources.change;
            this.pictureBox4.Location = new System.Drawing.Point(629, 33);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(43, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 34;
            this.pictureBox4.TabStop = false;
            // 
            // btn_lammoi
            // 
            this.btn_lammoi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lammoi.Location = new System.Drawing.Point(672, 33);
            this.btn_lammoi.Name = "btn_lammoi";
            this.btn_lammoi.Size = new System.Drawing.Size(128, 40);
            this.btn_lammoi.TabIndex = 33;
            this.btn_lammoi.Text = "Làm Mới";
            this.btn_lammoi.UseVisualStyleBackColor = true;
            this.btn_lammoi.Click += new System.EventHandler(this.btn_lammoi_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::HETHONGQLCHUNGCU.Properties.Resources.add;
            this.pictureBox3.Location = new System.Drawing.Point(29, 33);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 32;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HETHONGQLCHUNGCU.Properties.Resources.pencil;
            this.pictureBox2.Location = new System.Drawing.Point(227, 33);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HETHONGQLCHUNGCU.Properties.Resources.delete;
            this.pictureBox1.Location = new System.Drawing.Point(426, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(470, 33);
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
            this.btn_update.Location = new System.Drawing.Point(270, 33);
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
            this.btn_add.Location = new System.Drawing.Point(72, 33);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(128, 40);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dgvdsdg
            // 
            this.dgvdsdg.AllowUserToAddRows = false;
            this.dgvdsdg.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdsdg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvdsdg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdsdg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDanhGia,
            this.MaNhanSu,
            this.KyDanhGia});
            this.dgvdsdg.Location = new System.Drawing.Point(858, 50);
            this.dgvdsdg.Name = "dgvdsdg";
            this.dgvdsdg.ReadOnly = true;
            this.dgvdsdg.RowHeadersVisible = false;
            this.dgvdsdg.RowHeadersWidth = 51;
            this.dgvdsdg.RowTemplate.Height = 24;
            this.dgvdsdg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdsdg.Size = new System.Drawing.Size(447, 449);
            this.dgvdsdg.TabIndex = 31;
            this.dgvdsdg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdsdg_CellClick);
            // 
            // cbx_ns
            // 
            this.cbx_ns.FormattingEnabled = true;
            this.cbx_ns.Location = new System.Drawing.Point(175, 87);
            this.cbx_ns.Name = "cbx_ns";
            this.cbx_ns.Size = new System.Drawing.Size(254, 31);
            this.cbx_ns.TabIndex = 20;
            // 
            // MaDanhGia
            // 
            this.MaDanhGia.DataPropertyName = "MaDanhGia";
            this.MaDanhGia.HeaderText = "Mã Đánh Giá";
            this.MaDanhGia.MinimumWidth = 6;
            this.MaDanhGia.Name = "MaDanhGia";
            this.MaDanhGia.ReadOnly = true;
            this.MaDanhGia.Width = 150;
            // 
            // MaNhanSu
            // 
            this.MaNhanSu.DataPropertyName = "MaNhanSu";
            this.MaNhanSu.HeaderText = "Mã Nhân Sự";
            this.MaNhanSu.MinimumWidth = 6;
            this.MaNhanSu.Name = "MaNhanSu";
            this.MaNhanSu.ReadOnly = true;
            this.MaNhanSu.Width = 150;
            // 
            // KyDanhGia
            // 
            this.KyDanhGia.DataPropertyName = "KyDanhGia";
            this.KyDanhGia.HeaderText = "Kỳ Đánh Giá";
            this.KyDanhGia.MinimumWidth = 6;
            this.KyDanhGia.Name = "KyDanhGia";
            this.KyDanhGia.ReadOnly = true;
            this.KyDanhGia.Width = 150;
            // 
            // lbl_exit
            // 
            this.lbl_exit.AutoSize = true;
            this.lbl_exit.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_exit.ForeColor = System.Drawing.Color.Red;
            this.lbl_exit.Location = new System.Drawing.Point(1276, 4);
            this.lbl_exit.Name = "lbl_exit";
            this.lbl_exit.Size = new System.Drawing.Size(35, 38);
            this.lbl_exit.TabIndex = 32;
            this.lbl_exit.Text = "X";
            this.lbl_exit.Click += new System.EventHandler(this.lbl_exit_Click);
            // 
            // frm_dgns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1315, 511);
            this.Controls.Add(this.lbl_exit);
            this.Controls.Add(this.dgvdsdg);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_dgns";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "quanlynhansu";
            this.Load += new System.EventHandler(this.frm_dgns_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdsdg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_nx;
        private System.Windows.Forms.DateTimePicker dtp_ngdg;
        private System.Windows.Forms.TextBox txt_kydg;
        private System.Windows.Forms.TextBox txt_mdg;
        private System.Windows.Forms.TextBox txt_tongd;
        private System.Windows.Forms.TextBox txt_dtd;
        private System.Windows.Forms.TextBox txt_dhx;
        private System.Windows.Forms.TextBox txt_dtp;
        private System.Windows.Forms.ComboBox cbx_xl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btn_lammoi;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgvdsdg;
        private System.Windows.Forms.ComboBox cbx_ns;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDanhGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanSu;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyDanhGia;
        private System.Windows.Forms.Label lbl_exit;
    }
}