namespace HETHONGQLCHUNGCU
{
    partial class Frm_TTDGNS_CUDAN
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_dsdg = new System.Windows.Forms.DataGridView();
            this.Madg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kydg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaydg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemTacPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemHieuSuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemThaiDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongDIEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XepLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhanXet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_mns = new System.Windows.Forms.TextBox();
            this.txt_kdg = new System.Windows.Forms.TextBox();
            this.txt_mdg = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_nx = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_td = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_dtd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_dhs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_dtp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_ndg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsdg)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dgv_dsdg);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(12, 271);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1334, 362);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Thông Tin Đánh Giá";
            // 
            // dgv_dsdg
            // 
            this.dgv_dsdg.AllowUserToAddRows = false;
            this.dgv_dsdg.AllowUserToDeleteRows = false;
            this.dgv_dsdg.BackgroundColor = System.Drawing.Color.White;
            this.dgv_dsdg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsdg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Madg,
            this.Kydg,
            this.Ngaydg,
            this.DiemTacPhong,
            this.DiemHieuSuat,
            this.DiemThaiDo,
            this.TongDIEM,
            this.XepLoai,
            this.NhanXet});
            this.dgv_dsdg.Location = new System.Drawing.Point(12, 31);
            this.dgv_dsdg.Name = "dgv_dsdg";
            this.dgv_dsdg.ReadOnly = true;
            this.dgv_dsdg.RowHeadersVisible = false;
            this.dgv_dsdg.RowHeadersWidth = 51;
            this.dgv_dsdg.RowTemplate.Height = 24;
            this.dgv_dsdg.Size = new System.Drawing.Size(1307, 301);
            this.dgv_dsdg.TabIndex = 0;
            this.dgv_dsdg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_dsdg_CellClick);
            // 
            // Madg
            // 
            this.Madg.HeaderText = "Mã Đánh Giá";
            this.Madg.MinimumWidth = 6;
            this.Madg.Name = "Madg";
            this.Madg.ReadOnly = true;
            this.Madg.Width = 125;
            // 
            // Kydg
            // 
            this.Kydg.HeaderText = "Kỳ Đánh Giá";
            this.Kydg.MinimumWidth = 6;
            this.Kydg.Name = "Kydg";
            this.Kydg.ReadOnly = true;
            this.Kydg.Width = 125;
            // 
            // Ngaydg
            // 
            this.Ngaydg.HeaderText = "Ngày Đánh Giá";
            this.Ngaydg.MinimumWidth = 6;
            this.Ngaydg.Name = "Ngaydg";
            this.Ngaydg.ReadOnly = true;
            this.Ngaydg.Width = 125;
            // 
            // DiemTacPhong
            // 
            this.DiemTacPhong.HeaderText = "Điểm Tác Phong";
            this.DiemTacPhong.MinimumWidth = 6;
            this.DiemTacPhong.Name = "DiemTacPhong";
            this.DiemTacPhong.ReadOnly = true;
            this.DiemTacPhong.Width = 125;
            // 
            // DiemHieuSuat
            // 
            this.DiemHieuSuat.HeaderText = "ĐIểm Hệu Suất";
            this.DiemHieuSuat.MinimumWidth = 6;
            this.DiemHieuSuat.Name = "DiemHieuSuat";
            this.DiemHieuSuat.ReadOnly = true;
            this.DiemHieuSuat.Width = 125;
            // 
            // DiemThaiDo
            // 
            this.DiemThaiDo.HeaderText = "Điểm Thái Độ";
            this.DiemThaiDo.MinimumWidth = 6;
            this.DiemThaiDo.Name = "DiemThaiDo";
            this.DiemThaiDo.ReadOnly = true;
            this.DiemThaiDo.Width = 125;
            // 
            // TongDIEM
            // 
            this.TongDIEM.HeaderText = "Tổng Điểm";
            this.TongDIEM.MinimumWidth = 6;
            this.TongDIEM.Name = "TongDIEM";
            this.TongDIEM.ReadOnly = true;
            this.TongDIEM.Width = 125;
            // 
            // XepLoai
            // 
            this.XepLoai.HeaderText = "Xếp Loại";
            this.XepLoai.MinimumWidth = 6;
            this.XepLoai.Name = "XepLoai";
            this.XepLoai.ReadOnly = true;
            this.XepLoai.Width = 125;
            // 
            // NhanXet
            // 
            this.NhanXet.HeaderText = "Nhận Xét";
            this.NhanXet.MinimumWidth = 6;
            this.NhanXet.Name = "NhanXet";
            this.NhanXet.ReadOnly = true;
            this.NhanXet.Width = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(45, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Mã đánh giá :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(52, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Kỳ đánh giá :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(50, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mã nhân sự :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(436, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 38);
            this.label1.TabIndex = 9;
            this.label1.Text = "THÔNG TIN ĐÁNH GIÁ NHÂN SỰ";
            // 
            // txt_mns
            // 
            this.txt_mns.Location = new System.Drawing.Point(166, 45);
            this.txt_mns.Name = "txt_mns";
            this.txt_mns.Size = new System.Drawing.Size(214, 30);
            this.txt_mns.TabIndex = 16;
            // 
            // txt_kdg
            // 
            this.txt_kdg.Location = new System.Drawing.Point(166, 145);
            this.txt_kdg.Name = "txt_kdg";
            this.txt_kdg.Size = new System.Drawing.Size(214, 30);
            this.txt_kdg.TabIndex = 15;
            // 
            // txt_mdg
            // 
            this.txt_mdg.Location = new System.Drawing.Point(166, 94);
            this.txt_mdg.Name = "txt_mdg";
            this.txt_mdg.Size = new System.Drawing.Size(214, 30);
            this.txt_mdg.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txt_nx);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txt_td);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txt_dtd);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txt_dhs);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_dtp);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_ndg);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_mns);
            this.groupBox2.Controls.Add(this.txt_mdg);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_kdg);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(12, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1334, 198);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Đánh Giá Chi Tiết";
            // 
            // txt_nx
            // 
            this.txt_nx.Location = new System.Drawing.Point(996, 147);
            this.txt_nx.Name = "txt_nx";
            this.txt_nx.Size = new System.Drawing.Size(214, 30);
            this.txt_nx.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label10.Location = new System.Drawing.Point(899, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 23);
            this.label10.TabIndex = 27;
            this.label10.Text = "Nhận Xét :";
            // 
            // txt_td
            // 
            this.txt_td.Location = new System.Drawing.Point(996, 94);
            this.txt_td.Name = "txt_td";
            this.txt_td.Size = new System.Drawing.Size(214, 30);
            this.txt_td.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label9.Location = new System.Drawing.Point(886, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 23);
            this.label9.TabIndex = 25;
            this.label9.Text = "Tổng Điểm :";
            // 
            // txt_dtd
            // 
            this.txt_dtd.Location = new System.Drawing.Point(996, 44);
            this.txt_dtd.Name = "txt_dtd";
            this.txt_dtd.Size = new System.Drawing.Size(214, 30);
            this.txt_dtd.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Location = new System.Drawing.Point(867, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 23);
            this.label8.TabIndex = 23;
            this.label8.Text = "Điểm Thái Độ :";
            // 
            // txt_dhs
            // 
            this.txt_dhs.Location = new System.Drawing.Point(591, 146);
            this.txt_dhs.Name = "txt_dhs";
            this.txt_dhs.Size = new System.Drawing.Size(214, 30);
            this.txt_dhs.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(447, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 23);
            this.label7.TabIndex = 21;
            this.label7.Text = "Điểm Hiệu Suất :";
            // 
            // txt_dtp
            // 
            this.txt_dtp.Location = new System.Drawing.Point(591, 94);
            this.txt_dtp.Name = "txt_dtp";
            this.txt_dtp.Size = new System.Drawing.Size(214, 30);
            this.txt_dtp.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(442, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "Điểm Tác Phong :";
            // 
            // txt_ndg
            // 
            this.txt_ndg.Location = new System.Drawing.Point(591, 45);
            this.txt_ndg.Name = "txt_ndg";
            this.txt_ndg.Size = new System.Drawing.Size(214, 30);
            this.txt_ndg.TabIndex = 18;
            this.txt_ndg.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(450, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 23);
            this.label5.TabIndex = 17;
            this.label5.Text = "Ngày Đánh Giá :";
            // 
            // Frm_TTDGNS_CUDAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 645);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_TTDGNS_CUDAN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_TTDGNS_CUDAN";
            this.Load += new System.EventHandler(this.Frm_TTDGNS_CUDAN_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsdg)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_dsdg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_mns;
        private System.Windows.Forms.TextBox txt_kdg;
        private System.Windows.Forms.TextBox txt_mdg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Madg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kydg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaydg;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemTacPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemHieuSuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemThaiDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongDIEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn XepLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhanXet;
        private System.Windows.Forms.TextBox txt_dhs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_dtp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_ndg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_nx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_td;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_dtd;
        private System.Windows.Forms.Label label8;
    }
}