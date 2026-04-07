using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class frm_DanhGiaNhanSu : Form
    {
        private frm_dgns frmDanhGiaNhanSu = null;
        public Frm_Menu Menu = null;
        public frm_DanhGiaNhanSu()
        {
            InitializeComponent();
        }
        public frm_DanhGiaNhanSu(Frm_Menu menu)
        {
            InitializeComponent();
            Menu = menu;
        }
        private void frm_DanhGiaNhanSu_Load(object sender, EventArgs e)
        {
            
        }
        

        private void thêmNhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDanhGiaNhanSu == null || frmDanhGiaNhanSu.IsDisposed)
            {
                frmDanhGiaNhanSu = new frm_dgns();
                frmDanhGiaNhanSu.MdiParent = this;
                frmDanhGiaNhanSu.StartPosition = FormStartPosition.Manual;
                frmDanhGiaNhanSu.Location = new Point(170,100);
                frmDanhGiaNhanSu.FormBorderStyle = FormBorderStyle.None;
                frmDanhGiaNhanSu.FormClosed += frmDanhGiaNhanSu_FormClosed;
                frmDanhGiaNhanSu.Show();
                grp_ThongTinNhanSu.Visible = false;
                grp_TraCuNhanVien.Visible = false;
                dgv_ThongTinNs.Visible = false;
            }
            else
            {
                frmDanhGiaNhanSu.Activate();
            }    
        }
        private void frmDanhGiaNhanSu_FormClosed(object sender,FormClosedEventArgs e)
        {
            grp_ThongTinNhanSu.Visible = true;
            grp_TraCuNhanVien.Visible = true;
            dgv_ThongTinNs.Visible = true;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Menu!= null)
            {
                Menu.Show();
            }this.Close();
        }

        private void đăngXuâToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Menu != null)
            {
                Menu.DangXuat();
                Menu.Show();
            }this.Close();
        }

        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            if (Menu != null)
            {
                Menu.Show();
            }
            this.Close();
        }

        private void btn_cudan_Click(object sender, EventArgs e)
        {
            Frm_CuDan cudan = new Frm_CuDan(Menu);
            cudan.Show();
            this.Close();
        }

        private void btn_canho_Click(object sender, EventArgs e)
        {
            Frm_CanHo canho = new Frm_CanHo(Menu);
            canho.Show();
            this.Close();
        }

        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            Frm_HoaDon hoaDon = new Frm_HoaDon(Menu);
            hoaDon.Show();
            this.Close();
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            Frm_TT thanhtoan = new Frm_TT(Menu);
            thanhtoan.Show();
            this.Close();
        }

        private void btn_congnno_Click(object sender, EventArgs e)
        {
            Frm_CongNo congNo = new Frm_CongNo(Menu);
            congNo.Show();
            this.Close();
        }

        private void btn_thongketc_Click(object sender, EventArgs e)
        {
            Frm_ThongKeTaiChinh thongKeTaiChinh = new Frm_ThongKeTaiChinh(Menu);
            thongKeTaiChinh.Show();
            this.Close();
        }

        private void btn_cskh_Click(object sender, EventArgs e)
        {
            Frm_CSKH cskh = new Frm_CSKH(Menu);
            cskh.Show();
            this.Close();
        }

        private void btn_dkdv_Click(object sender, EventArgs e)
        {
            frm_Dangkydichvu dkdv = new frm_Dangkydichvu(Menu);
            dkdv.Show();
            this.Close();
        }

        private void btn_btsc_Click(object sender, EventArgs e)
        {
            Frm_BaotruSuachua baotri = new Frm_BaotruSuachua(Menu);
            baotri.Show();
            this.Close();
        }

        private void btn_baixe_Click(object sender, EventArgs e)
        {
            Frm_BaiXe baiXe = new Frm_BaiXe(Menu);
            baiXe.Show();
            this.Close();
        }

        private void btn_chamcong_Click(object sender, EventArgs e)
        {
            Frm_ChamCong chamCong = new Frm_ChamCong(Menu);
            chamCong.Show();
            this.Close();
        }

        private void btn_bpc_Click(object sender, EventArgs e)
        {
            Frm_BPCNV bpc = new Frm_BPCNV(Menu);
            bpc.Show();
            this.Close();
        }

        private void btn_danhgia_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đang ở trang đánh giá nhân sự!", "Hệ Thống Quản Lý Chung Cư - Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
