namespace HETHONGQLCHUNGCU
{
    partial class Frm_TTDV_DKDV_CUDAN
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_dsdv = new System.Windows.Forms.DataGridView();
            this.MaDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tENDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_mdv = new System.Windows.Forms.TextBox();
            this.txt_tt = new System.Windows.Forms.TextBox();
            this.txt_tdv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_ndk = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsdv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(470, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 23);
            this.label2.TabIndex = 18;
            this.label2.Text = "Trạng Thái :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(235, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 38);
            this.label1.TabIndex = 16;
            this.label1.Text = "THÔNG TIN DỊCH VỤ ĐÃ ĐĂNG KÝ";
            // 
            // dgv_dsdv
            // 
            this.dgv_dsdv.AllowUserToAddRows = false;
            this.dgv_dsdv.AllowUserToDeleteRows = false;
            this.dgv_dsdv.BackgroundColor = System.Drawing.Color.White;
            this.dgv_dsdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDV,
            this.tENDV,
            this.SL,
            this.NgayDk,
            this.TrangThai});
            this.dgv_dsdv.Location = new System.Drawing.Point(6, 29);
            this.dgv_dsdv.Name = "dgv_dsdv";
            this.dgv_dsdv.ReadOnly = true;
            this.dgv_dsdv.RowHeadersVisible = false;
            this.dgv_dsdv.RowHeadersWidth = 51;
            this.dgv_dsdv.RowTemplate.Height = 24;
            this.dgv_dsdv.Size = new System.Drawing.Size(943, 266);
            this.dgv_dsdv.TabIndex = 6;
            this.dgv_dsdv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // MaDV
            // 
            this.MaDV.HeaderText = "Mã DV";
            this.MaDV.MinimumWidth = 6;
            this.MaDV.Name = "MaDV";
            this.MaDV.ReadOnly = true;
            this.MaDV.Width = 125;
            // 
            // tENDV
            // 
            this.tENDV.HeaderText = "Tên DV";
            this.tENDV.MinimumWidth = 6;
            this.tENDV.Name = "tENDV";
            this.tENDV.ReadOnly = true;
            this.tENDV.Width = 250;
            // 
            // SL
            // 
            this.SL.HeaderText = "Số Lượng";
            this.SL.MinimumWidth = 6;
            this.SL.Name = "SL";
            this.SL.ReadOnly = true;
            this.SL.Width = 125;
            // 
            // NgayDk
            // 
            this.NgayDk.HeaderText = "Ngày Đăng Ký";
            this.NgayDk.MinimumWidth = 6;
            this.NgayDk.Name = "NgayDk";
            this.NgayDk.ReadOnly = true;
            this.NgayDk.Width = 200;
            // 
            // TrangThai
            // 
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Width = 250;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(42, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 23);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tên dịch vụ :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(39, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 23);
            this.label3.TabIndex = 20;
            this.label3.Text = "Mã Dịch Vụ :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dgv_dsdv);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(12, 239);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(961, 316);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách dịch vụ";
            // 
            // txt_mdv
            // 
            this.txt_mdv.Location = new System.Drawing.Point(161, 56);
            this.txt_mdv.Multiline = true;
            this.txt_mdv.Name = "txt_mdv";
            this.txt_mdv.Size = new System.Drawing.Size(245, 29);
            this.txt_mdv.TabIndex = 24;
            // 
            // txt_tt
            // 
            this.txt_tt.Location = new System.Drawing.Point(575, 104);
            this.txt_tt.Multiline = true;
            this.txt_tt.Name = "txt_tt";
            this.txt_tt.Size = new System.Drawing.Size(245, 29);
            this.txt_tt.TabIndex = 25;
            // 
            // txt_tdv
            // 
            this.txt_tdv.Location = new System.Drawing.Point(161, 104);
            this.txt_tdv.Multiline = true;
            this.txt_tdv.Name = "txt_tdv";
            this.txt_tdv.Size = new System.Drawing.Size(245, 29);
            this.txt_tdv.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(442, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 23);
            this.label5.TabIndex = 27;
            this.label5.Text = "Ngày Đăng Ký :";
            // 
            // dtp_ndk
            // 
            this.dtp_ndk.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_ndk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_ndk.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ndk.Location = new System.Drawing.Point(575, 56);
            this.dtp_ndk.Name = "dtp_ndk";
            this.dtp_ndk.Size = new System.Drawing.Size(245, 27);
            this.dtp_ndk.TabIndex = 28;
            this.dtp_ndk.Value = new System.DateTime(2026, 4, 15, 0, 0, 0, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txt_tdv);
            this.groupBox2.Controls.Add(this.dtp_ndk);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_tt);
            this.groupBox2.Controls.Add(this.txt_mdv);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Teal;
            this.groupBox2.Location = new System.Drawing.Point(12, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(961, 178);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Dịch Vụ";
            // 
            // Frm_TTDV_DKDV_CUDAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 567);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_TTDV_DKDV_CUDAN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_TTDV_DKDV_CUDAN";
            this.Load += new System.EventHandler(this.Frm_TTDV_DKDV_CUDAN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsdv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_dsdv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_mdv;
        private System.Windows.Forms.TextBox txt_tt;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn tENDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDk;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.TextBox txt_tdv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_ndk;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}