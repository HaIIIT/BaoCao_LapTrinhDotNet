namespace HETHONGQLCHUNGCU
{
    partial class Frm_NhanSu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvdsns = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmns = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpngsinh = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcccd = new System.Windows.Forms.TextBox();
            this.txtht = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rdb_nam = new System.Windows.Forms.RadioButton();
            this.rdb_nu = new System.Windows.Forms.RadioButton();
            this.txtsdt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtdc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtns = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtqq = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxchucvu = new System.Windows.Forms.ComboBox();
            this.cbxmpb = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpngayvaolam = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.txtlcb = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.rdb_nvc = new System.Windows.Forms.RadioButton();
            this.rdb_danglvc = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btn_lamlai = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MaNhanSu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdsns)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(315, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN NHÂN SỰ";
            // 
            // dgvdsns
            // 
            this.dgvdsns.AllowUserToAddRows = false;
            this.dgvdsns.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdsns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvdsns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdsns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhanSu,
            this.HoTen,
            this.CCCD,
            this.Email,
            this.DiaChi,
            this.ChucVu,
            this.MaPhongBan,
            this.TrangThai});
            this.dgvdsns.Location = new System.Drawing.Point(0, 397);
            this.dgvdsns.Name = "dgvdsns";
            this.dgvdsns.ReadOnly = true;
            this.dgvdsns.RowHeadersVisible = false;
            this.dgvdsns.RowHeadersWidth = 51;
            this.dgvdsns.RowTemplate.Height = 24;
            this.dgvdsns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvdsns.Size = new System.Drawing.Size(1130, 285);
            this.dgvdsns.TabIndex = 1;
            this.dgvdsns.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdsns_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Nhân Sự";
            // 
            // txtmns
            // 
            this.txtmns.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmns.Location = new System.Drawing.Point(36, 47);
            this.txtmns.Name = "txtmns";
            this.txtmns.Size = new System.Drawing.Size(191, 30);
            this.txtmns.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Họ Tên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(705, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ngày Sinh";
            // 
            // dtpngsinh
            // 
            this.dtpngsinh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpngsinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpngsinh.Location = new System.Drawing.Point(708, 44);
            this.dtpngsinh.Name = "dtpngsinh";
            this.dtpngsinh.Size = new System.Drawing.Size(153, 30);
            this.dtpngsinh.TabIndex = 9;
            this.dtpngsinh.Value = new System.DateTime(2026, 4, 24, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "CCCD";
            // 
            // txtcccd
            // 
            this.txtcccd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcccd.Location = new System.Drawing.Point(467, 46);
            this.txtcccd.Name = "txtcccd";
            this.txtcccd.Size = new System.Drawing.Size(221, 30);
            this.txtcccd.TabIndex = 7;
            // 
            // txtht
            // 
            this.txtht.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtht.Location = new System.Drawing.Point(246, 46);
            this.txtht.Name = "txtht";
            this.txtht.Size = new System.Drawing.Size(202, 30);
            this.txtht.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(888, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Giới Tính";
            // 
            // rdb_nam
            // 
            this.rdb_nam.AutoSize = true;
            this.rdb_nam.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_nam.Location = new System.Drawing.Point(3, 3);
            this.rdb_nam.Name = "rdb_nam";
            this.rdb_nam.Size = new System.Drawing.Size(68, 27);
            this.rdb_nam.TabIndex = 11;
            this.rdb_nam.TabStop = true;
            this.rdb_nam.Text = "Nam";
            this.rdb_nam.UseVisualStyleBackColor = true;
            // 
            // rdb_nu
            // 
            this.rdb_nu.AutoSize = true;
            this.rdb_nu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_nu.Location = new System.Drawing.Point(77, 3);
            this.rdb_nu.Name = "rdb_nu";
            this.rdb_nu.Size = new System.Drawing.Size(54, 27);
            this.rdb_nu.TabIndex = 12;
            this.rdb_nu.TabStop = true;
            this.rdb_nu.Text = "Nữ";
            this.rdb_nu.UseVisualStyleBackColor = true;
            // 
            // txtsdt
            // 
            this.txtsdt.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsdt.Location = new System.Drawing.Point(34, 104);
            this.txtsdt.Name = "txtsdt";
            this.txtsdt.Size = new System.Drawing.Size(193, 30);
            this.txtsdt.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Số Điện Thoại";
            // 
            // txtemail
            // 
            this.txtemail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemail.Location = new System.Drawing.Point(246, 104);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(276, 30);
            this.txtemail.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(243, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "Email";
            // 
            // txtdc
            // 
            this.txtdc.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdc.Location = new System.Drawing.Point(542, 104);
            this.txtdc.Name = "txtdc";
            this.txtdc.Size = new System.Drawing.Size(158, 30);
            this.txtdc.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(539, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 23);
            this.label9.TabIndex = 17;
            this.label9.Text = "Địa Chỉ";
            // 
            // txtns
            // 
            this.txtns.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtns.Location = new System.Drawing.Point(708, 104);
            this.txtns.Name = "txtns";
            this.txtns.Size = new System.Drawing.Size(164, 30);
            this.txtns.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(705, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 23);
            this.label10.TabIndex = 19;
            this.label10.Text = "Nơi Sinh";
            // 
            // txtqq
            // 
            this.txtqq.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtqq.Location = new System.Drawing.Point(891, 104);
            this.txtqq.Name = "txtqq";
            this.txtqq.Size = new System.Drawing.Size(154, 30);
            this.txtqq.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(888, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 23);
            this.label11.TabIndex = 21;
            this.label11.Text = "Quê Quán";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(33, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 23);
            this.label12.TabIndex = 23;
            this.label12.Text = "Chức Vụ";
            // 
            // cbxchucvu
            // 
            this.cbxchucvu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxchucvu.FormattingEnabled = true;
            this.cbxchucvu.Location = new System.Drawing.Point(36, 164);
            this.cbxchucvu.Name = "cbxchucvu";
            this.cbxchucvu.Size = new System.Drawing.Size(186, 31);
            this.cbxchucvu.TabIndex = 24;
            // 
            // cbxmpb
            // 
            this.cbxmpb.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxmpb.FormattingEnabled = true;
            this.cbxmpb.Location = new System.Drawing.Point(246, 164);
            this.cbxmpb.Name = "cbxmpb";
            this.cbxmpb.Size = new System.Drawing.Size(186, 31);
            this.cbxmpb.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(243, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 23);
            this.label13.TabIndex = 25;
            this.label13.Text = "Mã Phòng Ban";
            // 
            // dtpngayvaolam
            // 
            this.dtpngayvaolam.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpngayvaolam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpngayvaolam.Location = new System.Drawing.Point(452, 164);
            this.dtpngayvaolam.Name = "dtpngayvaolam";
            this.dtpngayvaolam.Size = new System.Drawing.Size(161, 30);
            this.dtpngayvaolam.TabIndex = 28;
            this.dtpngayvaolam.Value = new System.DateTime(2026, 4, 24, 0, 0, 0, 0);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(449, 140);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 23);
            this.label14.TabIndex = 27;
            this.label14.Text = "Ngày Vào Làm";
            // 
            // txtlcb
            // 
            this.txtlcb.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlcb.Location = new System.Drawing.Point(638, 164);
            this.txtlcb.Name = "txtlcb";
            this.txtlcb.Size = new System.Drawing.Size(207, 30);
            this.txtlcb.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(635, 140);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(124, 23);
            this.label15.TabIndex = 29;
            this.label15.Text = "Lương Cơ Bản";
            // 
            // rdb_nvc
            // 
            this.rdb_nvc.AutoSize = true;
            this.rdb_nvc.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_nvc.Location = new System.Drawing.Point(864, 195);
            this.rdb_nvc.Name = "rdb_nvc";
            this.rdb_nvc.Size = new System.Drawing.Size(105, 27);
            this.rdb_nvc.TabIndex = 33;
            this.rdb_nvc.TabStop = true;
            this.rdb_nvc.Text = "Nghỉ Việc";
            this.rdb_nvc.UseVisualStyleBackColor = true;
            // 
            // rdb_danglvc
            // 
            this.rdb_danglvc.AutoSize = true;
            this.rdb_danglvc.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_danglvc.Location = new System.Drawing.Point(864, 164);
            this.rdb_danglvc.Name = "rdb_danglvc";
            this.rdb_danglvc.Size = new System.Drawing.Size(146, 27);
            this.rdb_danglvc.TabIndex = 32;
            this.rdb_danglvc.TabStop = true;
            this.rdb_danglvc.Text = "Dang Làm Việc";
            this.rdb_danglvc.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(861, 142);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 23);
            this.label16.TabIndex = 31;
            this.label16.Text = "Trạng Thái";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.btn_lamlai);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.btn_delete);
            this.groupBox2.Controls.Add(this.btn_update);
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(12, 301);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1118, 90);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tác Vụ Thực Hiện";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::HETHONGQLCHUNGCU.Properties.Resources.change;
            this.pictureBox4.Location = new System.Drawing.Point(807, 35);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(43, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 34;
            this.pictureBox4.TabStop = false;
            // 
            // btn_lamlai
            // 
            this.btn_lamlai.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lamlai.Location = new System.Drawing.Point(851, 35);
            this.btn_lamlai.Name = "btn_lamlai";
            this.btn_lamlai.Size = new System.Drawing.Size(128, 40);
            this.btn_lamlai.TabIndex = 33;
            this.btn_lamlai.Text = "Làm Lại";
            this.btn_lamlai.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::HETHONGQLCHUNGCU.Properties.Resources.add;
            this.pictureBox3.Location = new System.Drawing.Point(81, 34);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 32;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HETHONGQLCHUNGCU.Properties.Resources.pencil;
            this.pictureBox2.Location = new System.Drawing.Point(321, 35);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HETHONGQLCHUNGCU.Properties.Resources.delete;
            this.pictureBox1.Location = new System.Drawing.Point(559, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(602, 35);
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
            this.btn_update.Location = new System.Drawing.Point(364, 35);
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
            this.btn_add.Location = new System.Drawing.Point(125, 35);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(128, 40);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.txtmns);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rdb_nvc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rdb_danglvc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtht);
            this.groupBox1.Controls.Add(this.txtlcb);
            this.groupBox1.Controls.Add(this.txtcccd);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpngayvaolam);
            this.groupBox1.Controls.Add(this.dtpngsinh);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbxmpb);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cbxchucvu);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtsdt);
            this.groupBox1.Controls.Add(this.txtqq);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtemail);
            this.groupBox1.Controls.Add(this.txtns);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtdc);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1118, 237);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phiếu Thông Tin Nhân Sự";
            // 
            // MaNhanSu
            // 
            this.MaNhanSu.DataPropertyName = "MaNhanSu";
            this.MaNhanSu.HeaderText = "Mã Nhân Sự";
            this.MaNhanSu.MinimumWidth = 6;
            this.MaNhanSu.Name = "MaNhanSu";
            this.MaNhanSu.ReadOnly = true;
            this.MaNhanSu.Width = 125;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ tên";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 125;
            // 
            // CCCD
            // 
            this.CCCD.DataPropertyName = "CCCD";
            this.CCCD.HeaderText = "CCCD";
            this.CCCD.MinimumWidth = 6;
            this.CCCD.Name = "CCCD";
            this.CCCD.ReadOnly = true;
            this.CCCD.Width = 125;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 125;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.MinimumWidth = 6;
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 125;
            // 
            // ChucVu
            // 
            this.ChucVu.DataPropertyName = "ChucVu";
            this.ChucVu.HeaderText = "Chức Vụ";
            this.ChucVu.MinimumWidth = 6;
            this.ChucVu.Name = "ChucVu";
            this.ChucVu.ReadOnly = true;
            this.ChucVu.Width = 125;
            // 
            // MaPhongBan
            // 
            this.MaPhongBan.DataPropertyName = "MaPhongBan";
            this.MaPhongBan.HeaderText = "Mã Phòng Ban";
            this.MaPhongBan.MinimumWidth = 6;
            this.MaPhongBan.Name = "MaPhongBan";
            this.MaPhongBan.ReadOnly = true;
            this.MaPhongBan.Width = 150;
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.rdb_nam);
            this.flowLayoutPanel1.Controls.Add(this.rdb_nu);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(892, 43);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 31);
            this.flowLayoutPanel1.TabIndex = 34;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(1105, 5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 31);
            this.label17.TabIndex = 36;
            this.label17.Text = "X";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // Frm_NhanSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 691);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvdsns);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_NhanSu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_NhanSu";
            this.Load += new System.EventHandler(this.Frm_NhanSu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdsns)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvdsns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpngsinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtcccd;
        private System.Windows.Forms.TextBox txtht;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdb_nam;
        private System.Windows.Forms.RadioButton rdb_nu;
        private System.Windows.Forms.TextBox txtsdt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtdc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtns;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtqq;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbxchucvu;
        private System.Windows.Forms.ComboBox cbxmpb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpngayvaolam;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtlcb;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton rdb_nvc;
        private System.Windows.Forms.RadioButton rdb_danglvc;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btn_lamlai;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanSu;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label17;
    }
}