namespace HETHONGQLCHUNGCU
{
    partial class Frm_QuanLyHopDong
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
            this.lbl_exit = new System.Windows.Forms.Label();
            this.dgv_dshopdong = new System.Windows.Forms.DataGridView();
            this.MaHopDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCuDan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCanHo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiHopDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rdb_thue = new System.Windows.Forms.RadioButton();
            this.rdb_ban = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rdb_lachuho = new System.Windows.Forms.RadioButton();
            this.dtp_ngban = new System.Windows.Forms.DateTimePicker();
            this.dtp_ngkt = new System.Windows.Forms.DateTimePicker();
            this.dtp_ngbd = new System.Windows.Forms.DateTimePicker();
            this.txt_vaitro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_ngban = new System.Windows.Forms.Label();
            this.lbl_ngkt = new System.Windows.Forms.Label();
            this.lbl_ngbd = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_mahd = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btn_lamlai = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.cbx_cd = new System.Windows.Forms.ComboBox();
            this.cbx_ch = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dshopdong)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_exit
            // 
            this.lbl_exit.AutoSize = true;
            this.lbl_exit.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_exit.ForeColor = System.Drawing.Color.Red;
            this.lbl_exit.Location = new System.Drawing.Point(1279, 3);
            this.lbl_exit.Name = "lbl_exit";
            this.lbl_exit.Size = new System.Drawing.Size(29, 31);
            this.lbl_exit.TabIndex = 35;
            this.lbl_exit.Text = "X";
            this.lbl_exit.Click += new System.EventHandler(this.lbl_exit_Click);
            // 
            // dgv_dshopdong
            // 
            this.dgv_dshopdong.AllowUserToAddRows = false;
            this.dgv_dshopdong.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_dshopdong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_dshopdong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dshopdong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHopDong,
            this.MaCuDan,
            this.MaCanHo,
            this.LoaiHopDong});
            this.dgv_dshopdong.Location = new System.Drawing.Point(804, 54);
            this.dgv_dshopdong.Name = "dgv_dshopdong";
            this.dgv_dshopdong.ReadOnly = true;
            this.dgv_dshopdong.RowHeadersVisible = false;
            this.dgv_dshopdong.RowHeadersWidth = 51;
            this.dgv_dshopdong.RowTemplate.Height = 24;
            this.dgv_dshopdong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_dshopdong.Size = new System.Drawing.Size(498, 560);
            this.dgv_dshopdong.TabIndex = 34;
            this.dgv_dshopdong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_dshopdong_CellClick);
            // 
            // MaHopDong
            // 
            this.MaHopDong.DataPropertyName = "MaHopDong";
            this.MaHopDong.HeaderText = "Mã Căn Hộ";
            this.MaHopDong.MinimumWidth = 6;
            this.MaHopDong.Name = "MaHopDong";
            this.MaHopDong.ReadOnly = true;
            this.MaHopDong.Width = 150;
            // 
            // MaCuDan
            // 
            this.MaCuDan.DataPropertyName = "MaCuDan";
            this.MaCuDan.HeaderText = "Mã Cư Dân";
            this.MaCuDan.MinimumWidth = 6;
            this.MaCuDan.Name = "MaCuDan";
            this.MaCuDan.ReadOnly = true;
            this.MaCuDan.Width = 125;
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
            // LoaiHopDong
            // 
            this.LoaiHopDong.DataPropertyName = "LoaiHopDong";
            this.LoaiHopDong.HeaderText = "Loại Hợp Đồng";
            this.LoaiHopDong.MinimumWidth = 6;
            this.LoaiHopDong.Name = "LoaiHopDong";
            this.LoaiHopDong.ReadOnly = true;
            this.LoaiHopDong.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(175, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 41);
            this.label1.TabIndex = 31;
            this.label1.Text = "THÔNG TIN HỢP ĐỒNG CĂN HỘ";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cbx_ch);
            this.groupBox1.Controls.Add(this.cbx_cd);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rdb_lachuho);
            this.groupBox1.Controls.Add(this.dtp_ngban);
            this.groupBox1.Controls.Add(this.dtp_ngkt);
            this.groupBox1.Controls.Add(this.dtp_ngbd);
            this.groupBox1.Controls.Add(this.txt_vaitro);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lbl_ngban);
            this.groupBox1.Controls.Add(this.lbl_ngkt);
            this.groupBox1.Controls.Add(this.lbl_ngbd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_mahd);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(4, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 464);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi Tiết Hợp Đồng";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.rdb_thue);
            this.flowLayoutPanel1.Controls.Add(this.rdb_ban);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(158, 170);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(305, 33);
            this.flowLayoutPanel1.TabIndex = 58;
            // 
            // rdb_thue
            // 
            this.rdb_thue.AutoSize = true;
            this.rdb_thue.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_thue.Location = new System.Drawing.Point(3, 3);
            this.rdb_thue.Name = "rdb_thue";
            this.rdb_thue.Size = new System.Drawing.Size(70, 27);
            this.rdb_thue.TabIndex = 56;
            this.rdb_thue.TabStop = true;
            this.rdb_thue.Text = "Thuê";
            this.rdb_thue.UseVisualStyleBackColor = true;
            // 
            // rdb_ban
            // 
            this.rdb_ban.AutoSize = true;
            this.rdb_ban.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_ban.Location = new System.Drawing.Point(79, 3);
            this.rdb_ban.Name = "rdb_ban";
            this.rdb_ban.Size = new System.Drawing.Size(61, 27);
            this.rdb_ban.TabIndex = 57;
            this.rdb_ban.TabStop = true;
            this.rdb_ban.Text = "Bán";
            this.rdb_ban.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(16, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 25);
            this.label4.TabIndex = 55;
            this.label4.Text = "Loại Hợp Đồng:";
            // 
            // rdb_lachuho
            // 
            this.rdb_lachuho.AutoSize = true;
            this.rdb_lachuho.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_lachuho.Location = new System.Drawing.Point(156, 399);
            this.rdb_lachuho.Name = "rdb_lachuho";
            this.rdb_lachuho.Size = new System.Drawing.Size(42, 27);
            this.rdb_lachuho.TabIndex = 26;
            this.rdb_lachuho.TabStop = true;
            this.rdb_lachuho.Text = "X";
            this.rdb_lachuho.UseVisualStyleBackColor = true;
            // 
            // dtp_ngban
            // 
            this.dtp_ngban.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_ngban.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngban.Location = new System.Drawing.Point(157, 350);
            this.dtp_ngban.Name = "dtp_ngban";
            this.dtp_ngban.Size = new System.Drawing.Size(309, 31);
            this.dtp_ngban.TabIndex = 54;
            this.dtp_ngban.Value = new System.DateTime(2026, 4, 19, 0, 0, 0, 0);
            // 
            // dtp_ngkt
            // 
            this.dtp_ngkt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_ngkt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngkt.Location = new System.Drawing.Point(157, 303);
            this.dtp_ngkt.Name = "dtp_ngkt";
            this.dtp_ngkt.Size = new System.Drawing.Size(309, 31);
            this.dtp_ngkt.TabIndex = 53;
            this.dtp_ngkt.Value = new System.DateTime(2026, 4, 19, 0, 0, 0, 0);
            // 
            // dtp_ngbd
            // 
            this.dtp_ngbd.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_ngbd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngbd.Location = new System.Drawing.Point(156, 258);
            this.dtp_ngbd.Name = "dtp_ngbd";
            this.dtp_ngbd.Size = new System.Drawing.Size(309, 31);
            this.dtp_ngbd.TabIndex = 52;
            this.dtp_ngbd.Value = new System.DateTime(2026, 4, 19, 0, 0, 0, 0);
            // 
            // txt_vaitro
            // 
            this.txt_vaitro.Location = new System.Drawing.Point(156, 209);
            this.txt_vaitro.Name = "txt_vaitro";
            this.txt_vaitro.Size = new System.Drawing.Size(309, 34);
            this.txt_vaitro.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(46, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 48;
            this.label2.Text = "Mã Căn Hộ:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label13.Location = new System.Drawing.Point(82, 214);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 25);
            this.label13.TabIndex = 46;
            this.label13.Text = "Vai Trò:";
            // 
            // lbl_ngban
            // 
            this.lbl_ngban.AutoSize = true;
            this.lbl_ngban.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ngban.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_ngban.Location = new System.Drawing.Point(58, 353);
            this.lbl_ngban.Name = "lbl_ngban";
            this.lbl_ngban.Size = new System.Drawing.Size(92, 25);
            this.lbl_ngban.TabIndex = 42;
            this.lbl_ngban.Text = "Ngày Bán:";
            // 
            // lbl_ngkt
            // 
            this.lbl_ngkt.AutoSize = true;
            this.lbl_ngkt.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ngkt.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_ngkt.Location = new System.Drawing.Point(25, 309);
            this.lbl_ngkt.Name = "lbl_ngkt";
            this.lbl_ngkt.Size = new System.Drawing.Size(130, 25);
            this.lbl_ngkt.TabIndex = 40;
            this.lbl_ngkt.Text = "Ngày Kết Thúc:";
            // 
            // lbl_ngbd
            // 
            this.lbl_ngbd.AutoSize = true;
            this.lbl_ngbd.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ngbd.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_ngbd.Location = new System.Drawing.Point(26, 263);
            this.lbl_ngbd.Name = "lbl_ngbd";
            this.lbl_ngbd.Size = new System.Drawing.Size(125, 25);
            this.lbl_ngbd.TabIndex = 30;
            this.lbl_ngbd.Text = "Ngày Bắt Đầu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(55, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Là Chủ Hộ:";
            // 
            // txt_mahd
            // 
            this.txt_mahd.Location = new System.Drawing.Point(156, 37);
            this.txt_mahd.Name = "txt_mahd";
            this.txt_mahd.Size = new System.Drawing.Size(309, 34);
            this.txt_mahd.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label17.Location = new System.Drawing.Point(45, 87);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 25);
            this.label17.TabIndex = 7;
            this.label17.Text = "Mã Cư Dân:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label18.Location = new System.Drawing.Point(19, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(131, 25);
            this.label18.TabIndex = 6;
            this.label18.Text = "Mã Hợp Đồng:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::HETHONGQLCHUNGCU.Properties.Resources.add;
            this.pictureBox3.Location = new System.Drawing.Point(21, 33);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 32;
            this.pictureBox3.TabStop = false;
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
            this.groupBox2.Location = new System.Drawing.Point(4, 524);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(794, 90);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tác Vụ Thực Hiện";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::HETHONGQLCHUNGCU.Properties.Resources.change;
            this.pictureBox4.Location = new System.Drawing.Point(611, 33);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(43, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 34;
            this.pictureBox4.TabStop = false;
            // 
            // btn_lamlai
            // 
            this.btn_lamlai.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lamlai.Location = new System.Drawing.Point(655, 33);
            this.btn_lamlai.Name = "btn_lamlai";
            this.btn_lamlai.Size = new System.Drawing.Size(128, 40);
            this.btn_lamlai.TabIndex = 33;
            this.btn_lamlai.Text = "Làm Lại";
            this.btn_lamlai.UseVisualStyleBackColor = true;
            this.btn_lamlai.Click += new System.EventHandler(this.btn_lamlai_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HETHONGQLCHUNGCU.Properties.Resources.pencil;
            this.pictureBox2.Location = new System.Drawing.Point(212, 33);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HETHONGQLCHUNGCU.Properties.Resources.delete;
            this.pictureBox1.Location = new System.Drawing.Point(408, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(451, 33);
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
            this.btn_update.Location = new System.Drawing.Point(255, 33);
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
            this.btn_add.Location = new System.Drawing.Point(65, 34);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(128, 40);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // cbx_cd
            // 
            this.cbx_cd.FormattingEnabled = true;
            this.cbx_cd.Location = new System.Drawing.Point(156, 81);
            this.cbx_cd.Name = "cbx_cd";
            this.cbx_cd.Size = new System.Drawing.Size(310, 36);
            this.cbx_cd.TabIndex = 59;
            // 
            // cbx_ch
            // 
            this.cbx_ch.FormattingEnabled = true;
            this.cbx_ch.Location = new System.Drawing.Point(156, 125);
            this.cbx_ch.Name = "cbx_ch";
            this.cbx_ch.Size = new System.Drawing.Size(310, 36);
            this.cbx_ch.TabIndex = 60;
            // 
            // Frm_QuanLyHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 622);
            this.Controls.Add(this.lbl_exit);
            this.Controls.Add(this.dgv_dshopdong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_QuanLyHopDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_QuanLyHopDong";
            this.Load += new System.EventHandler(this.Frm_QuanLyHopDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dshopdong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_exit;
        private System.Windows.Forms.DataGridView dgv_dshopdong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_vaitro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_ngban;
        private System.Windows.Forms.Label lbl_ngkt;
        private System.Windows.Forms.Label lbl_ngbd;
        private System.Windows.Forms.RadioButton rdb_lachuho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_mahd;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btn_lamlai;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DateTimePicker dtp_ngban;
        private System.Windows.Forms.DateTimePicker dtp_ngkt;
        private System.Windows.Forms.DateTimePicker dtp_ngbd;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton rdb_thue;
        private System.Windows.Forms.RadioButton rdb_ban;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHopDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCuDan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCanHo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiHopDong;
        private System.Windows.Forms.ComboBox cbx_ch;
        private System.Windows.Forms.ComboBox cbx_cd;
    }
}