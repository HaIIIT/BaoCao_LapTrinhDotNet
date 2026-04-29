using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_BPCNV : Form
    {
        private Frm_thongtinBPCNV frmthongtinBPCNV = null;
        public Frm_Menu menu;
        private Frm_TTPCNV_NhanSu frmphancong = null;
        private Frm_HTxacthuctaptrung frmxacthuc = null;
        private Frm_Thongtintaikhoan frmttcanhan = null;
        public Frm_BPCNV()
        {
            InitializeComponent();
        }
        public Frm_BPCNV(Frm_Menu frmmenu)
        {
            InitializeComponent();
            menu = frmmenu;
        }
        //xây dựng hàm dùng chung
        private void MDI()
        {
            frmthongtinBPCNV = new Frm_thongtinBPCNV();
            frmthongtinBPCNV.MdiParent = this;
            frmthongtinBPCNV.StartPosition = FormStartPosition.Manual;
            frmthongtinBPCNV.Location = new Point(150, 130);
            frmthongtinBPCNV.FormClosed += frmthongtinBPCNV_FormClosed;
            frmthongtinBPCNV.Show();
        }   
        private void ancontrols()
        {
            gpb_trangthai.Visible = false;
            gpb_tracuu.Visible = false;
            dgv_dsnhiemvu.Visible = false;
            pnl_tiltelist.Visible = false;
            pnl_tiltethongtin.Visible = false;
        }
        void timkiem()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT MaPhanCong, MaNhanSu, TieuDeCongViec, NoiDung, " +
                                 "FORMAT(NgayGiao,'dd-MM-yyyy') AS NgayGiao, HanHoanThanh, " +
                                 "MucDoUuTien, TrangThai, KetQua " +
                                 "FROM PhanCongNhiemVu WHERE 1=1";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    if (cbx_pc.SelectedIndex > 0 && !cbx_pc.Text.Contains("Chọn"))
                    {
                        sel += " AND MaPhanCong LIKE @mpc";
                        parameters.Add(new SqlParameter("@mpc", "%" + cbx_pc.Text.Trim() + "%"));
                    }
                    if (cbx_ns.SelectedIndex > 0 && !cbx_ns.Text.Contains("Chọn"))
                    {
                        sel += " AND MaNhanSu LIKE @mns";
                        parameters.Add(new SqlParameter("@mns", "%" + cbx_ns.Text.Trim() + "%"));
                    }
                    if (chk_ngay.Checked)
                    {
                        sel += " AND NgayGiao >= @tuNgay AND NgayGiao < @denNgay";
                        DateTime tuNgay = dtp_ng.Value.Date;
                        DateTime denNgay = tuNgay.AddDays(1);
                        parameters.Add(new SqlParameter("@tuNgay", tuNgay));
                        parameters.Add(new SqlParameter("@denNgay", denNgay));
                    }
                    if (rdb_cth.Checked)
                        sel += " AND TrangThai = N'Chưa Thực Hiện'";
                    else if (rdb_dth.Checked)
                        sel += " AND TrangThai = N'Đang Thực Hiện'";
                    else if (rdb_ht.Checked)
                        sel += " AND TrangThai = N'Hoàn Thành'";
                    else if (rdb_td.Checked)
                        sel += " AND TrangThai = N'Tạm Dừng'";
                    SqlCommand cmd = new SqlCommand(sel, ketnoi.conn);
                    if (parameters.Count > 0)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable tb = new DataTable();
                    da.Fill(tb);
                    dgv_dsnhiemvu.DataSource = tb;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chi tiết: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void load_cbx_pc()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sql = "SELECT MaPhanCong FROM PhanCongNhiemVu";
                SqlDataReader rdr = ketnoi.truyvan(sql);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                rdr.Close();
                DataRow row = tb.NewRow();
                row["MaPhanCong"] = "-Chọn-";
                tb.Rows.InsertAt(row, 0);
                cbx_pc.DataSource = tb;
                cbx_pc.DisplayMember = "MaPhanCong";
                cbx_pc.ValueMember = "MaPhanCong";
                ketnoi.dongketnoi();
            }
        }
        void load_cbx_ns()
        {
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sql = "SELECT MaNhanSu FROM NhanSu";
                SqlDataReader rdr = ketnoi.truyvan(sql);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                rdr.Close();
                DataRow row = tb.NewRow();
                row["MaNhanSu"] = "-Chọn-";
                tb.Rows.InsertAt(row, 0);
                cbx_ns.DataSource = tb;
                cbx_ns.DisplayMember = "MaNhanSu";
                cbx_ns.ValueMember = "MaNhanSu";
                ketnoi.dongketnoi();
            }
        }
        void thongke()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT COUNT(*) FROM PhanCongNhiemVu";
                    SqlDataReader rdr = ketnoi.truyvan(sel);
                    if (rdr.Read())
                    {
                        lbl_tong.Text = rdr[0].ToString();
                    }
                    rdr.Close();
                    string sel1 = "SELECT COUNT(*) FROM PhanCongNhiemVu WHERE TrangThai =N'Hoàn Thành'";
                    SqlDataReader rdr1 = ketnoi.truyvan(sel1);
                    if (rdr1.Read())
                    {
                        lbl_hthanh.Text = rdr1[0].ToString();
                    }
                    rdr1.Close();
                    string sel2 = "SELECT COUNT(*) FROM PhanCongNhiemVu WHERE TrangThai =N'Chưa Hoàn Thành'";
                    SqlDataReader rdr2 = ketnoi.truyvan(sel2);
                    if (rdr2.Read())
                    {
                        lbl_choanthanh.Text = rdr2[0].ToString();
                    }
                    rdr2.Close();
                    string sel3 = "SELECT COUNT(*) FROM PhanCongNhiemVu WHERE TrangThai =N'Đang Thực Hiện'";
                    SqlDataReader rdr3 = ketnoi.truyvan(sel3);
                    if (rdr3.Read())
                    {
                        lbl_dangthuchien.Text = rdr3[0].ToString();
                    }
                    rdr3.Close();
                    string sel4 = "SELECT COUNT(*) FROM PhanCongNhiemVu WHERE TrangThai =N'Tạm Dừng'";
                    SqlDataReader rdr4 = ketnoi.truyvan(sel4);
                    if (rdr4.Read())
                    {
                        lbl_tamdung.Text = rdr4[0].ToString();
                    }
                    rdr4.Close();

                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Hệ Thống Quản Lý Chung Cư - Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void QuayVeMenu()
        {
            if (menu != null)
            {
                menu.Show();
            }
            this.Close();
        }
        private void AnTatCaFormCon()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm != null && !frm.IsDisposed)
                {
                    frm.Close();
                }
            }
        }
        //----------------MenuStrip---------------------
        private void mãCănHộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmthongtinBPCNV == null|| frmthongtinBPCNV.IsDisposed)
            {
                MDI();
                frmthongtinBPCNV.settrangthaibutton(true, false, false);
                // ẩn control
                ancontrols();
            }
            else
            {
                frmthongtinBPCNV.Activate();
            }           
        }
        private void CapNhatBPCtool_Click(object sender, EventArgs e)
        {
            if(frmthongtinBPCNV == null || frmthongtinBPCNV.IsDisposed)
            {
                MDI();
                frmthongtinBPCNV.settrangthaibutton(false, true, false);
                // ẩn control
                ancontrols();
            }
            else
            {
                frmthongtinBPCNV.Activate();
            }
        }
        private void xoaBPCtool_Click(object sender, EventArgs e)
        {
            if(frmthongtinBPCNV == null || frmthongtinBPCNV.IsDisposed)
            {
                MDI();
                frmthongtinBPCNV.settrangthaibutton(false, false, true);
                // ẩn control
                ancontrols();
            }
            else
            {
                frmthongtinBPCNV.Activate();
            }
        }
        private void frmthongtinBPCNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            gpb_trangthai.Visible = true;
            gpb_tracuu.Visible = true;
            dgv_dsnhiemvu.Visible = true;
            pnl_tiltelist.Visible = true;
            pnl_tiltethongtin.Visible = true;
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.Show();
            }this.Close();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu != null)
            {
                menu.DangXuat();
                menu.Show();
            }this.Close();
        }
        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmttcanhan == null || frmttcanhan.IsDisposed)
            {
                AnTatCaFormCon();
                frmttcanhan = new Frm_Thongtintaikhoan();
                frmttcanhan.MdiParent = this;
                frmttcanhan.StartPosition = FormStartPosition.Manual;
                frmttcanhan.Location = new Point(180, 95);
                frmttcanhan.FormBorderStyle = FormBorderStyle.None;
                frmttcanhan.FormClosed += Frm_Thongtintaikhoan_FormClosed;
                if (cls_chcecklogin.Quyen == 2)
                {
                    if (frmphancong != null && !frmphancong.IsDisposed)
                    {
                        frmphancong.Hide();
                    }
                }
                else
                {
                    ancontrols();
                }
                frmttcanhan.Show();
            }
            else
            {
                frmttcanhan.Activate();
            }
        }
        private void Frm_Thongtintaikhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmttcanhan = null;
            if (cls_chcecklogin.Quyen == 2)
            {
                if (frmphancong == null || frmphancong.IsDisposed)
                {
                    frmphancong = new Frm_TTPCNV_NhanSu();
                    frmphancong.MdiParent = this;
                    frmphancong.StartPosition = FormStartPosition.Manual;
                    frmphancong.Location = new Point(170, 125);
                    frmphancong.FormBorderStyle = FormBorderStyle.None;
                    frmphancong.Show();
                }
                else
                {
                    frmphancong.Show();
                    frmphancong.BringToFront();
                }
            }
            else
            {
                // hiển thị controls
                gpb_trangthai.Visible = true;
                gpb_tracuu.Visible = true;
                dgv_dsnhiemvu.Visible = true;
                pnl_tiltelist.Visible = true;
                pnl_tiltethongtin.Visible = true;
            }
        }
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmxacthuc == null || frmxacthuc.IsDisposed)
            {
                ancontrols();
                frmxacthuc = new Frm_HTxacthuctaptrung();
                frmxacthuc.MdiParent = this;
                frmxacthuc.StartPosition = FormStartPosition.Manual;
                frmxacthuc.Location = new Point(354, 215);
                frmxacthuc.FormBorderStyle = FormBorderStyle.None;
                frmxacthuc.FormClosed += Frm_HTxacthuctaptrung_FormClosed;
                frmxacthuc.Show();
                if (cls_chcecklogin.Quyen == 2)
                {
                    if (frmphancong != null && !frmphancong.IsDisposed)
                    {
                        frmphancong.Hide();
                    }
                }
                else
                {
                    ancontrols();
                }
                frmxacthuc.Show();
            }
            else
            {
                frmxacthuc.Activate();
            }
        }
        private void Frm_HTxacthuctaptrung_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmxacthuc = null;
            if (cls_chcecklogin.Quyen == 2)
            {
                if (frmphancong == null || frmphancong.IsDisposed)
                {
                    frmphancong = new Frm_TTPCNV_NhanSu();
                    frmphancong.MdiParent = this;
                    frmphancong.StartPosition = FormStartPosition.Manual;
                    frmphancong.Location = new Point(170, 125);
                    frmphancong.FormBorderStyle = FormBorderStyle.None;
                    frmphancong.Show();
                }
                else
                {
                    frmphancong.Show();
                    frmphancong.BringToFront();
                }
            }
            else
            {
                gpb_trangthai.Visible = true;
                gpb_tracuu.Visible = true;
                dgv_dsnhiemvu.Visible = true;
                pnl_tiltelist.Visible = true;
                pnl_tiltethongtin.Visible = true;
            }
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
            Frm_TT thanhtoan = new Frm_TT(menu);
            thanhtoan.Show();
            this.Close();
        }
        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongketc = new Frm_ThongKeTaiChinh(menu);
            thongketc.Show();
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
            frm_Dangkydichvu dk = new frm_Dangkydichvu(menu);
            dk.Show();
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
            Frm_BaiXe baixe = new Frm_BaiXe(menu);
            baixe.Show();
            this.Close();
        }
        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong chamcong = new Frm_ChamCong(menu);
            chamcong.Show();
            this.Close();
        }
        private void btn_bpc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang ở trang bảng phân công!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            frm_DanhGiaNhanSu danhgia = new frm_DanhGiaNhanSu(menu);
            danhgia.Show();
            this.Close();
        }
        //----------------------------------
        private void Frm_BPCNV_Load(object sender, EventArgs e)
        { 
            chk_ngay.Checked = false; 
            btn_load.Visible = false;
            thongke();
            load_cbx_ns();
            load_cbx_pc();
            int quyen = cls_chcecklogin.Quyen;
            if (quyen == 2)
            {
                PhanQuyenDashboard.tat(btn_thongketc, btn_btsc, btn_cudan, btn_canho, btn_hoadon, btn_thanhtoan, btn_congno, btn_thongketc,
                    btn_cskh, btn_dkdv, btn_btsc, btn_baixe);
                quảnLýCôngNợToolStripMenuItem.Visible = false;
                frmphancong = new Frm_TTPCNV_NhanSu();
                frmphancong.MdiParent = this;
                frmphancong.StartPosition = FormStartPosition.Manual;
                frmphancong.Location = new Point(180, 100);
                frmphancong.FormBorderStyle = FormBorderStyle.None;
                frmphancong.Show();
                ancontrols();
            }
            else if (quyen == 3)
            {
                PhanQuyenDashboard.tat(btn_thongketc, btn_btsc, btn_cudan, btn_canho, btn_hoadon, btn_thanhtoan, btn_congno, btn_thongketc,
                btn_cskh, btn_dkdv, btn_btsc, btn_baixe);
            }else if (quyen == 7)
            {
                //null
            }
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT MaPhanCong,MaNhanSu,TieuDeCongViec,NoiDung,FORMAT(NgayGiao,'dd-MM-yyyy') AS NgayGiao,HanHoanThanh,MucDoUuTien,TrangThaI FROM PhanCongNhiemVu ";
                SqlDataReader rdr = ketnoi.truyvan(sel);
                DataTable tb = new DataTable();
                tb.Load(rdr);
                dgv_dsnhiemvu.DataSource = tb;
                rdr.Close();
                ketnoi.dongketnoi();
            }
            else
            {
                MessageBox.Show("khong the ket noi CSDL");
            }
            
        }
        private void btn_tk_Click(object sender, EventArgs e)
        {
            bool coChonTrangThai = rdb_cth.Checked || rdb_dth.Checked || rdb_ht.Checked || rdb_td.Checked;
            bool mpcTrong = cbx_pc.SelectedIndex <= 0 || cbx_pc.Text.Contains("Chọn");
            bool mnsTrong = cbx_ns.SelectedIndex <= 0 || cbx_ns.Text.Contains("Chọn");
            bool ngayKhongChon = !chk_ngay.Checked;
            if (mpcTrong && mnsTrong && !coChonTrangThai && ngayKhongChon)
            {
                MessageBox.Show("Vui lòng nhập ít nhất một thông tin (Mã, ngày hoặc trạng thái) để tìm kiếm!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            timkiem();
            btn_load.Visible = true;
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            cbx_ns.SelectedIndex = 0;
            cbx_pc.SelectedIndex = 0;
            chk_ngay.Checked = false;
            dtp_ng.Value = DateTime.Now;
            dtp_ng.Enabled = false;
            rdb_cth.Checked = false;
            rdb_dth.Checked = false;
            rdb_ht.Checked = false;
            rdb_td.Checked = false;
            Frm_BPCNV_Load(sender, e);
        }
        private void chk_ngay_CheckedChanged(object sender, EventArgs e)
        {
            dtp_ng.Enabled = chk_ngay.Checked;
        }
        
    }
}
