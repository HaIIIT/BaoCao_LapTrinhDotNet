namespace HETHONGQLCHUNGCU
{
    partial class Frm_TTThanhToan_CuDan
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_macn_tracuu = new System.Windows.Forms.ComboBox();
            this.cbx_mahd_tracuu = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_tracuu = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_thangtt = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_thanhtoan = new System.Windows.Forms.Button();
            this.txt_nd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_sotien = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_tt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_mtt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_dstt = new System.Windows.Forms.DataGridView();
            this.MaThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCongNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_exit = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dstt)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(438, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 38);
            this.label1.TabIndex = 8;
            this.label1.Text = "Thông Tin Thanh Toán";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cbx_macn_tracuu);
            this.groupBox1.Controls.Add(this.cbx_mahd_tracuu);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btn_tracuu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbx_thangtt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(11, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1177, 129);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tra Cưu Thanh Toán";
            // 
            // cbx_macn_tracuu
            // 
            this.cbx_macn_tracuu.FormattingEnabled = true;
            this.cbx_macn_tracuu.Location = new System.Drawing.Point(700, 68);
            this.cbx_macn_tracuu.Name = "cbx_macn_tracuu";
            this.cbx_macn_tracuu.Size = new System.Drawing.Size(245, 31);
            this.cbx_macn_tracuu.TabIndex = 7;
            // 
            // cbx_mahd_tracuu
            // 
            this.cbx_mahd_tracuu.FormattingEnabled = true;
            this.cbx_mahd_tracuu.Location = new System.Drawing.Point(378, 68);
            this.cbx_mahd_tracuu.Name = "cbx_mahd_tracuu";
            this.cbx_mahd_tracuu.Size = new System.Drawing.Size(245, 31);
            this.cbx_mahd_tracuu.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(696, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mã Công Nợ :";
            // 
            // btn_tracuu
            // 
            this.btn_tracuu.Location = new System.Drawing.Point(984, 66);
            this.btn_tracuu.Name = "btn_tracuu";
            this.btn_tracuu.Size = new System.Drawing.Size(141, 32);
            this.btn_tracuu.TabIndex = 4;
            this.btn_tracuu.Text = "Tra Cứu";
            this.btn_tracuu.UseVisualStyleBackColor = true;
            this.btn_tracuu.Click += new System.EventHandler(this.btn_tracuu_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(374, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã Hóa Đơn :";
            // 
            // cbx_thangtt
            // 
            this.cbx_thangtt.FormattingEnabled = true;
            this.cbx_thangtt.Location = new System.Drawing.Point(41, 68);
            this.cbx_thangtt.Name = "cbx_thangtt";
            this.cbx_thangtt.Size = new System.Drawing.Size(245, 31);
            this.cbx_thangtt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(37, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tháng Thanh Toán :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btn_thanhtoan);
            this.groupBox2.Controls.Add(this.txt_nd);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txt_sotien);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_tt);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_mtt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(11, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1177, 206);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi Tiết Thanh Toán ";
            // 
            // btn_thanhtoan
            // 
            this.btn_thanhtoan.Location = new System.Drawing.Point(771, 62);
            this.btn_thanhtoan.Name = "btn_thanhtoan";
            this.btn_thanhtoan.Size = new System.Drawing.Size(141, 30);
            this.btn_thanhtoan.TabIndex = 7;
            this.btn_thanhtoan.Text = "Thanh Toán";
            this.btn_thanhtoan.UseVisualStyleBackColor = true;
            this.btn_thanhtoan.Click += new System.EventHandler(this.btn_thanhtoan_Click);
            // 
            // txt_nd
            // 
            this.txt_nd.Enabled = false;
            this.txt_nd.Location = new System.Drawing.Point(369, 137);
            this.txt_nd.Multiline = true;
            this.txt_nd.Name = "txt_nd";
            this.txt_nd.Size = new System.Drawing.Size(329, 63);
            this.txt_nd.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Location = new System.Drawing.Point(365, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Nội Dung :";
            // 
            // txt_sotien
            // 
            this.txt_sotien.Enabled = false;
            this.txt_sotien.Location = new System.Drawing.Point(369, 62);
            this.txt_sotien.Name = "txt_sotien";
            this.txt_sotien.Size = new System.Drawing.Size(329, 30);
            this.txt_sotien.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(365, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "Số Tiền :";
            // 
            // txt_tt
            // 
            this.txt_tt.Enabled = false;
            this.txt_tt.Location = new System.Drawing.Point(29, 137);
            this.txt_tt.Name = "txt_tt";
            this.txt_tt.Size = new System.Drawing.Size(247, 30);
            this.txt_tt.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(25, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Trạng Thái :";
            // 
            // txt_mtt
            // 
            this.txt_mtt.Enabled = false;
            this.txt_mtt.Location = new System.Drawing.Point(29, 62);
            this.txt_mtt.Name = "txt_mtt";
            this.txt_mtt.Size = new System.Drawing.Size(247, 30);
            this.txt_mtt.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(25, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mã Thanh Toán :";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.dgv_dstt);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Teal;
            this.groupBox3.Location = new System.Drawing.Point(7, 411);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1177, 313);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh Sách Các Khoản Thanh Toán ";
            // 
            // dgv_dstt
            // 
            this.dgv_dstt.AllowUserToAddRows = false;
            this.dgv_dstt.AllowUserToDeleteRows = false;
            this.dgv_dstt.BackgroundColor = System.Drawing.Color.White;
            this.dgv_dstt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dstt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaThanhToan,
            this.MaHoaDon,
            this.MaCongNo,
            this.SoTien,
            this.NoiDung,
            this.TrangThai});
            this.dgv_dstt.Location = new System.Drawing.Point(16, 33);
            this.dgv_dstt.Name = "dgv_dstt";
            this.dgv_dstt.ReadOnly = true;
            this.dgv_dstt.RowHeadersVisible = false;
            this.dgv_dstt.RowHeadersWidth = 51;
            this.dgv_dstt.RowTemplate.Height = 24;
            this.dgv_dstt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_dstt.Size = new System.Drawing.Size(1142, 274);
            this.dgv_dstt.TabIndex = 0;
            this.dgv_dstt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_dstt_CellClick);
            // 
            // MaThanhToan
            // 
            this.MaThanhToan.DataPropertyName = "MaThanhToan";
            this.MaThanhToan.HeaderText = "Mã Thanh Toán";
            this.MaThanhToan.MinimumWidth = 6;
            this.MaThanhToan.Name = "MaThanhToan";
            this.MaThanhToan.ReadOnly = true;
            this.MaThanhToan.Width = 150;
            // 
            // MaHoaDon
            // 
            this.MaHoaDon.DataPropertyName = "MaHoaDon";
            this.MaHoaDon.HeaderText = "Mã Hóa Đơn";
            this.MaHoaDon.MinimumWidth = 6;
            this.MaHoaDon.Name = "MaHoaDon";
            this.MaHoaDon.ReadOnly = true;
            this.MaHoaDon.Width = 150;
            // 
            // MaCongNo
            // 
            this.MaCongNo.DataPropertyName = "MaCongNo";
            this.MaCongNo.HeaderText = "Mã Công Nợ";
            this.MaCongNo.MinimumWidth = 6;
            this.MaCongNo.Name = "MaCongNo";
            this.MaCongNo.ReadOnly = true;
            this.MaCongNo.Width = 150;
            // 
            // SoTien
            // 
            this.SoTien.DataPropertyName = "SoTien";
            this.SoTien.HeaderText = "Số Tiền";
            this.SoTien.MinimumWidth = 6;
            this.SoTien.Name = "SoTien";
            this.SoTien.ReadOnly = true;
            this.SoTien.Width = 170;
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
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Width = 200;
            // 
            // lbl_exit
            // 
            this.lbl_exit.AutoSize = true;
            this.lbl_exit.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_exit.ForeColor = System.Drawing.Color.Red;
            this.lbl_exit.Location = new System.Drawing.Point(1162, 5);
            this.lbl_exit.Name = "lbl_exit";
            this.lbl_exit.Size = new System.Drawing.Size(29, 31);
            this.lbl_exit.TabIndex = 31;
            this.lbl_exit.Text = "X";
            this.lbl_exit.Click += new System.EventHandler(this.lbl_exit_Click);
            // 
            // Frm_TTThanhToan_CuDan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 736);
            this.Controls.Add(this.lbl_exit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_TTThanhToan_CuDan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_TTThanhToan_CuDan";
            this.Load += new System.EventHandler(this.Frm_TTThanhToan_CuDan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dstt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_tracuu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_thangtt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_dstt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_sotien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_tt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_mtt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_thanhtoan;
        private System.Windows.Forms.TextBox txt_nd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_exit;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCongNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.ComboBox cbx_macn_tracuu;
        private System.Windows.Forms.ComboBox cbx_mahd_tracuu;
    }
}