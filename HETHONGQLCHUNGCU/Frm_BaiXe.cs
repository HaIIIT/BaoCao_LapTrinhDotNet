using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_BaiXe : Form
    {
        private Frm_Xe Frm_Xe = null;
        private Frm_ViTriBaiXe Frm_ViTriBaiXe = null;
        private Frm_GuiXe Frm_GuiXe = null;
        public Frm_Menu menu;
        public Frm_BaiXe()
        {
            InitializeComponent();
        }
        public Frm_BaiXe(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //xây dựng hàm dùng chung
        private void AnTatCaFormCon()
        {
            if (Frm_Xe != null && !Frm_Xe.IsDisposed)
                Frm_Xe.Hide();
            if (Frm_ViTriBaiXe != null && !Frm_ViTriBaiXe.IsDisposed)
                Frm_ViTriBaiXe.Hide();
            if (Frm_GuiXe != null && !Frm_GuiXe.IsDisposed)
                Frm_GuiXe.Hide();
        }
        private void MDITTBX()
        {
            Frm_Xe = new Frm_Xe();
            Frm_Xe.MdiParent = this;
            Frm_Xe.StartPosition = FormStartPosition.Manual;
            Frm_Xe.Location = new Point(180, 150);
            Frm_Xe.FormBorderStyle = FormBorderStyle.None;
            Frm_Xe.FormClosed += Frm_Xe_FormClosed;
            Frm_Xe.Show();
        }
        private void MDIVTRIBX()
        {
            Frm_ViTriBaiXe = new Frm_ViTriBaiXe();
            Frm_ViTriBaiXe.MdiParent = this;
            Frm_ViTriBaiXe.StartPosition = FormStartPosition.Manual;
            Frm_ViTriBaiXe.Location = new Point(180, 150);
            Frm_ViTriBaiXe.FormBorderStyle = FormBorderStyle.None;
            Frm_ViTriBaiXe.FormClosed += Frm_ViTriBaiXe_FormClosed;
            Frm_ViTriBaiXe.Show();
        }
        private void MDIGUIXE()
        {
            Frm_GuiXe = new Frm_GuiXe();
            Frm_GuiXe.MdiParent = this;
            Frm_GuiXe.StartPosition = FormStartPosition.Manual;
            Frm_GuiXe.Location = new Point(180, 150);
            Frm_GuiXe.FormBorderStyle = FormBorderStyle.None;
            Frm_GuiXe.FormClosed += Frm_GuiXe_FormClosed;
            Frm_GuiXe.Show();
        }
        private void ancontrols()
        {
            pnl_tiltle1.Visible = false;
            pnl_title2.Visible = false;
            pnl_dgv.Visible = false;
            grb_TraCuuThongTinXe.Visible = false;
            grb_TrangThaiBaiXe.Visible = false;
        }
        private void hiencontrols()
        {
            pnl_tiltle1.Visible = true;
            pnl_title2.Visible = true;
            pnl_dgv.Visible = true;
            grb_TraCuuThongTinXe.Visible = true;
            grb_TrangThaiBaiXe.Visible = true;
        }
        //----------------MenuStrip---------------------
        /// <MDIThongTinXe>
        private void thêmThôngTinXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_Xe == null || Frm_Xe.IsDisposed)
            {
                AnTatCaFormCon();
                MDITTBX();
                Frm_Xe.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                Frm_Xe.Activate();
            }
        }
        private void cậpNhậtThôngTinXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_Xe != null && !Frm_Xe.IsDisposed)
            {
                AnTatCaFormCon();
                Frm_Xe.Show();
                Frm_Xe.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
        }
        private void xóaThôngTinXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_Xe != null && !Frm_Xe.IsDisposed)
            {
                AnTatCaFormCon();
                Frm_Xe.Show();
                Frm_Xe.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
        }
        private void Frm_Xe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_Xe = null;
            hiencontrols();
        }
        /// </MDIThongTinXe>

        /// <MDIViTriBaiXe>
        private void thembaidotool_Click(object sender, EventArgs e)
        {
            if (Frm_ViTriBaiXe == null || Frm_ViTriBaiXe.IsDisposed)
            {
                AnTatCaFormCon();
                MDIVTRIBX();
                Frm_ViTriBaiXe.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                Frm_ViTriBaiXe.Activate();
            }
        }
        private void capnhatvtribaidotool_Click(object sender, EventArgs e)
        {
            if (Frm_ViTriBaiXe != null && !Frm_ViTriBaiXe.IsDisposed)
            {
                AnTatCaFormCon();
                Frm_ViTriBaiXe.Show();
                Frm_ViTriBaiXe.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
        }
        private void xoavtribaidotool_Click(object sender, EventArgs e)
        {
            if (Frm_ViTriBaiXe != null && !Frm_ViTriBaiXe.IsDisposed)
            {
                AnTatCaFormCon();
                Frm_ViTriBaiXe.Show();
                Frm_ViTriBaiXe.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
        }
        private void Frm_ViTriBaiXe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_ViTriBaiXe = null;
            hiencontrols();
        }
        ///</MDIViTriBaiXe>

        /// <MDIGuiXe>
        private void thêmThôngTinGửiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_GuiXe == null || Frm_GuiXe.IsDisposed)
            {
                AnTatCaFormCon();
                MDIGUIXE();
                Frm_GuiXe.settrangthaibutton(true, false, false);
                //ẩn controls
                ancontrols();
            }
            else
            {
                Frm_GuiXe.Activate();
            }
        }
        private void cậpNhậtThôngTinGửiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_GuiXe != null && !Frm_GuiXe.IsDisposed)
            {
                AnTatCaFormCon();
                Frm_GuiXe.Show();
                Frm_GuiXe.settrangthaibutton(false, true, false);
                //ẩn controls
                ancontrols();
            }
        }
        private void xóaThôngTinGửiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_GuiXe != null && !Frm_GuiXe.IsDisposed)
            {
                AnTatCaFormCon();
                Frm_GuiXe.Show();
                Frm_GuiXe.settrangthaibutton(false, false, true);
                //ẩn controls
                ancontrols();
            }
        }
        private void Frm_GuiXe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Frm_GuiXe = null;
            hiencontrols();
        }
        /// </MDIGuiXe>
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.DangXuat();
                menu.Show();
            }
            this.Close();
        }
        //-----------------------------------------
        //&&//
        //-----------------Dashboard---------------
        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        private void btn_cudan_Click(object sender, EventArgs e)
        {
            Frm_CuDan cudan = new Frm_CuDan(menu);
            cudan.Show();
            this.Close();
        }
        private void btn_canho_Click(object sender, EventArgs e)
        {
            Frm_CanHo canho = new Frm_CanHo(menu);
            canho.Show();
            this.Close();
        }
        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            Frm_HoaDon hoadon = new Frm_HoaDon(menu);
            hoadon.Show();
            this.Close();
        }
        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            Frm_TT thanhtoan = new Frm_TT(menu);
            thanhtoan.Show();
            this.Close();
        }
        private void btn_congno_Click(object sender, EventArgs e)
        {
            Frm_CongNo congNo = new Frm_CongNo(menu);
            congNo.Show();
            this.Close();
        }
        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongKeTC = new Frm_ThongKeTaiChinh(menu);
            thongKeTC.Show();
            this.Close();
        }
        private void btn_cskh_Click(object sender, EventArgs e)
        {
            Frm_CSKH cskh = new Frm_CSKH(menu);
            cskh.Show();
            this.Close();
        }
        private void btn_dkdv_Click(object sender, EventArgs e)
        {
            frm_Dangkydichvu dkdv = new frm_Dangkydichvu(menu);
            dkdv.Show();
            this.Close();
        }
        private void btn_btsc_Click(object sender, EventArgs e)
        {
            Frm_BaoTriSuaChua baotri = new Frm_BaoTriSuaChua(menu);
            baotri.Show();
            this.Close();
        }
        private void btn_baixe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang ở trang Bãi Xe!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong chamCong = new Frm_ChamCong(menu);
            chamCong.Show();
            this.Close();
        }
        private void btn_bpc_Click(object sender, EventArgs e)
        {
            Frm_BPCNV bpc = new Frm_BPCNV(menu);
            bpc.Show();
            this.Close();
        }
        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhGiaNhanSu = new frm_DanhGiaNhanSu(menu);
            danhGiaNhanSu.Show();
            this.Close();
        }
        
        public void LoadData()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                //  Load dữ liệu dgvTTX (Thông tin xe) 
                string sel = "SELECT MaXe, MaCuDan, BienSo, LoaiXe, HangXe, MauSac, NgayDangKi, TrangThai, MaDichVu FROM Xe";
                SqlDataAdapter ad = new SqlDataAdapter(sel, ketnoi.conn);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dgvTTX.DataSource = dt;


                dgvTTX.Columns["MaXe"].HeaderText = "Mã Xe";
                dgvTTX.Columns["MaCuDan"].HeaderText = "Mã Cư Dân";
                dgvTTX.Columns["BienSo"].HeaderText = "Biển Số";
                dgvTTX.Columns["LoaiXe"].HeaderText = "Loại Xe";
                dgvTTX.Columns["HangXe"].HeaderText = "Hãng Xe";
                dgvTTX.Columns["MauSac"].HeaderText = "Màu Sắc";
                dgvTTX.Columns["NgayDangKi"].HeaderText = "Ngày Đăng Kí";
                dgvTTX.Columns["TrangThai"].HeaderText = "Trạng Thái";
                dgvTTX.Columns["MaDichVu"].HeaderText = "Mã Dịch Vụ";

                // 2. Load dữ liệu dgvViTriXe (Vị trí bãi xe) 
                string sel1 = "SELECT MaViTri, KhuVuc, Tang, SoCho, LoaiCho, TrangThai FROM ViTriBaiXe";
                SqlDataAdapter ad1 = new SqlDataAdapter(sel1, ketnoi.conn);
                DataTable dt1 = new DataTable();
                ad1.Fill(dt1);
                dgvViTriXe.DataSource = dt1;


                dgvViTriXe.Columns["MaViTri"].HeaderText = "Mã Vị Trí";
                dgvViTriXe.Columns["KhuVuc"].HeaderText = "Khu Vực";
                dgvViTriXe.Columns["Tang"].HeaderText = "Tầng";
                dgvViTriXe.Columns["SoCho"].HeaderText = "Số Chỗ";
                dgvViTriXe.Columns["LoaiCho"].HeaderText = "Loại Chỗ";
                dgvViTriXe.Columns["TrangThai"].HeaderText = "Trạng Thái";

                // 3. Load dữ liệu dgvGuiXe (Thông tin gửi xe)
                string sel2 = "SELECT MaGuiXe, MaXe, MaViTri, NgayBatDau, NgayKetThuc,PhiGui, TrangThai FROM GuiXe";
                SqlDataAdapter ad2 = new SqlDataAdapter(sel2, ketnoi.conn);
                DataTable dt2 = new DataTable();
                ad2.Fill(dt2);
                dgvGuiXe.DataSource = dt2;

                dgvGuiXe.Columns["MaGuiXe"].HeaderText = "Mã Gửi Xe";
                dgvGuiXe.Columns["MaXe"].HeaderText = "Mã Xe";
                dgvGuiXe.Columns["MaViTri"].HeaderText = "Mã Vị Trí";
                dgvGuiXe.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
                dgvGuiXe.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
                dgvGuiXe.Columns["PhiGui"].HeaderText = "Phí Gửi";
                dgvGuiXe.Columns["TrangThai"].HeaderText = "Trạng Thái";


                ketnoi.dongketnoi();
            }
        }
        private void Frm_BaiXe_Load(object sender, EventArgs e)
        {
            LoadData();
            thongke(); // Gọi hàm thống kê khi Form load
            
        }

        // Hàm tìm kiếm bãi xe 
        void timkiemBaiXe()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    // --- 1. Tìm kiếm và hiển thị cho dgvTTX (Bảng Xe) ---
                    string sqlXe = "SELECT MaXe, MaCuDan, BienSo, LoaiXe, HangXe, MauSac, NgayDangKi, TrangThai, MaDichVu FROM Xe WHERE 1=1";
                    SqlCommand cmdXe = new SqlCommand();
                    if (!string.IsNullOrEmpty(txtMaxe.Text.Trim()))
                    {
                        sqlXe += " AND MaXe LIKE @MaXe";
                        cmdXe.Parameters.AddWithValue("@MaXe", "%" + txtMaxe.Text.Trim() + "%");
                    }
                    if (!string.IsNullOrEmpty(txtBienso.Text.Trim()))
                    {
                        sqlXe += " AND BienSo LIKE @BienSo";
                        cmdXe.Parameters.AddWithValue("@BienSo", "%" + txtBienso.Text.Trim() + "%");
                    }
                    cmdXe.CommandText = sqlXe;
                    cmdXe.Connection = ketnoi.conn;
                    SqlDataAdapter adXe = new SqlDataAdapter(cmdXe);
                    DataTable dtXe = new DataTable();
                    adXe.Fill(dtXe);
                    dgvTTX.DataSource = dtXe;

                    // --- 2. Tìm kiếm và hiển thị cho dgvGuiXe (Bảng Gửi Xe) ---
                    // Lọc theo MaXe, BienSo (thông qua JOIN) hoặc MaViTri, MaGuiXe
                    string sqlGui = "SELECT gx.MaGuiXe, gx.MaXe, gx.MaViTri, gx.NgayBatDau, gx.NgayKetThuc, gx.PhiGui, gx.TrangThai " +
                                    "FROM GuiXe gx JOIN Xe x ON gx.MaXe = x.MaXe WHERE 1=1";
                    SqlCommand cmdGui = new SqlCommand();
                    if (!string.IsNullOrEmpty(txtMaxe.Text.Trim()))
                    {
                        sqlGui += " AND gx.MaXe LIKE @MaXe";
                        cmdGui.Parameters.AddWithValue("@MaXe", "%" + txtMaxe.Text.Trim() + "%");
                    }
                    if (!string.IsNullOrEmpty(txtMaguixe.Text.Trim()))
                    {
                        sqlGui += " AND gx.MaGuiXe LIKE @MaGui";
                        cmdGui.Parameters.AddWithValue("@MaGui", "%" + txtMaguixe.Text.Trim() + "%");
                    }
                    if (!string.IsNullOrEmpty(txtMavitri.Text.Trim()))
                    {
                        sqlGui += " AND gx.MaViTri LIKE @MaViTri";
                        cmdGui.Parameters.AddWithValue("@MaViTri", "%" + txtMavitri.Text.Trim() + "%");
                    }
                    cmdGui.CommandText = sqlGui;
                    cmdGui.Connection = ketnoi.conn;
                    SqlDataAdapter adGui = new SqlDataAdapter(cmdGui);
                    DataTable dtGui = new DataTable();
                    adGui.Fill(dtGui);
                    dgvGuiXe.DataSource = dtGui;

                    // --- 3. Tìm kiếm vị trí bãi xe dgvViTriXe ---
                    // Nếu tìm theo mã vị trí cụ thể
                    if (!string.IsNullOrEmpty(txtMavitri.Text.Trim()))
                    {
                        string sqlViTri = "SELECT MaViTri, KhuVuc, Tang, SoCho, LoaiCho, TrangThai FROM ViTriBaiXe WHERE MaViTri LIKE @MaViTri";
                        SqlCommand cmdViTri = new SqlCommand(sqlViTri, ketnoi.conn);
                        cmdViTri.Parameters.AddWithValue("@MaViTri", "%" + txtMavitri.Text.Trim() + "%");
                        SqlDataAdapter adViTri = new SqlDataAdapter(cmdViTri);
                        DataTable dtViTri = new DataTable();
                        adViTri.Fill(dtViTri);
                        dgvViTriXe.DataSource = dtViTri;
                    }

                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu tất cả các ô tìm kiếm đều trống
            if (string.IsNullOrWhiteSpace(txtMaxe.Text) &&
                string.IsNullOrWhiteSpace(txtBienso.Text) &&
                string.IsNullOrWhiteSpace(txtMavitri.Text) &&
                string.IsNullOrWhiteSpace(txtMaguixe.Text))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một thông tin để tìm kiếm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            timkiemBaiXe();
           
        }

        // Hàm thống kê các con số trên Dashboard bãi xe
        void thongke()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    // Tổng số xe
                    string sel = "SELECT COUNT(*) FROM Xe";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read()) lblTongSoXe.Text = rdr[0].ToString();
                    rdr.Close();

                    // Tổng số xe đang gửi thực tế
                    string sel1 = "SELECT COUNT(*) FROM GuiXe WHERE TrangThai = N'Đang gửi'";
                    SqlDataReader rdr1 = ketnoi.truyvan(sel1);
                    if (rdr1.Read()) lblTongSoXeTrongBai.Text = rdr1[0].ToString();
                    rdr1.Close();

                    // Tổng số vị trí đỗ
                    string sel2 = "SELECT COUNT(*) FROM ViTriBaiXe";
                    SqlDataReader rdr2 = ketnoi.truyvan(sel2);
                    if (rdr2.Read()) lblTongSoViTri.Text = rdr2[0].ToString();
                    rdr2.Close();

                    // Số vị trí còn trống
                    string sel3 = "SELECT COUNT(*) FROM ViTriBaiXe WHERE TrangThai = N'Trống'";
                    SqlDataReader rdr3 = ketnoi.truyvan(sel3);
                    if (rdr3.Read()) lblSoViTriTrong.Text = rdr3[0].ToString();
                    rdr3.Close();

                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        void LoadChiTietXe(string maXe)
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sql = "SELECT * FROM Xe WHERE MaXe = @MaXe";
                    SqlCommand cmd = new SqlCommand(sql, ketnoi.conn);
                    cmd.Parameters.AddWithValue("@MaXe", maXe);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        txtMaxe.Text = rdr["MaXe"].ToString().Trim();
                        txtBienso.Text = rdr["BienSo"].ToString().Trim();
                        // Điền thêm các ô khác của bạn ở đây
                        // ví dụ: txtLoaiXe.Text = rdr["LoaiXe"].ToString();
                    }
                    rdr.Close();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void dgvTTX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string maXe = dgvTTX.Rows[e.RowIndex].Cells["MaXe"].Value.ToString();
            LoadChiTietXe(maXe);
        }

        private void dgvGuiXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvGuiXe.Rows[e.RowIndex];

            txtMaguixe.Text = row.Cells["MaGuiXe"].Value.ToString();
            txtMavitri.Text = row.Cells["MaViTri"].Value.ToString();
            string maXe = row.Cells["MaXe"].Value.ToString();

            // Gọi hàm bổ trợ để điền nốt thông tin xe lên các ô còn lại
            LoadChiTietXe(maXe);
        }


        private void dgvViTriXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtMavitri.Text = dgvViTriXe.Rows[e.RowIndex].Cells["MaViTri"].Value.ToString();
        }
    }
}