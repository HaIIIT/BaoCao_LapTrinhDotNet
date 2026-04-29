using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HETHONGQLCHUNGCU
{
    public partial class Frm_TTBaiXe_CuDan : Form
    {
        public Frm_TTBaiXe_CuDan()
        {
            InitializeComponent();
        }
        void thongke()
        {
            Connection ketnoi = new Connection();
            try
            {
                if (ketnoi.moketnoi())
                {
                    string sel = "SELECT COUNT(*) FROM Xe";
                    SqlCommand cmd = new SqlCommand(sel, ketnoi.conn);
                    lblTongSoXe.Text = cmd.ExecuteScalar().ToString();
                    string sel1 = "SELECT COUNT(*) FROM GuiXe WHERE TrangThai LIKE N'%Đang gửi%'";
                    SqlCommand cmd1 = new SqlCommand(sel1, ketnoi.conn);
                    lblTongSoXeTrongBai.Text = cmd1.ExecuteScalar().ToString();
                    string sel2 = "SELECT COUNT(*) FROM ViTriBaiXe";
                    SqlCommand cmd2 = new SqlCommand(sel2, ketnoi.conn);
                    lblTongSoViTri.Text = cmd2.ExecuteScalar().ToString();
                    string sel3 = "SELECT COUNT(*) FROM ViTriBaiXe WHERE TrangThai LIKE N'%trống%'";
                    SqlCommand cmd3 = new SqlCommand(sel3, ketnoi.conn);
                    lblSoViTriTrong.Text = cmd3.ExecuteScalar().ToString();
                    ketnoi.dongketnoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_TTBaiXe_CuDan_Load(object sender, EventArgs e)
        {
            thongke();
            Connection ketnoi = new Connection();
            if (ketnoi.moketnoi())
            {
                string sel = "SELECT MaXe,  BienSo, TrangThai FROM Xe";
                SqlDataAdapter ad = new SqlDataAdapter(sel, ketnoi.conn);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dgvXe.DataSource = dt;
                dgvXe.Columns["MaXe"].HeaderText = "Mã Xe";
                dgvXe.Columns["BienSo"].HeaderText = "Biển Số";
                dgvXe.Columns["TrangThai"].HeaderText = "Trạng Thái";
                string sqlGird = "SELECT MaViTri, KhuVuc, Tang, SoCho, LoaiCho, TrangThai FROM ViTriBaiXe";
                SqlDataAdapter adGrid = new SqlDataAdapter(sqlGird, ketnoi.conn);
                DataTable dtGrid = new DataTable();
                adGrid.Fill(dtGrid);
                dgvViTri.DataSource = dtGrid;
                dgvViTri.Columns["MaViTri"].HeaderText = "Mã Vị Trí";
                dgvViTri.Columns["KhuVuc"].HeaderText = "Khu Vực";
                dgvViTri.Columns["Tang"].HeaderText = "Tầng";
                dgvViTri.Columns["SoCho"].HeaderText = "Số Chỗ";
                dgvViTri.Columns["LoaiCho"].HeaderText = "Loại Chỗ";
                dgvViTri.Columns["TrangThaivt"].HeaderText = "Trạng Thái";
                ketnoi.dongketnoi();
            }
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            Frm_BaiXe frmCha = this.MdiParent as Frm_BaiXe;
            if (frmCha != null)
            {
                frmCha.QuayVeMenu();
            }
        }
    }
}
