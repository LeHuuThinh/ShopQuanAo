using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShopQuanAo
{
    public partial class QuanLy : Form
    {
        public QuanLy(TrangChu form1)
        {
            InitializeComponent();
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {

        }

        

        private void menuDSHD_Click(object sender, EventArgs e)  // Nút Danh sách hóa đơn
        {
            DanhSachHoaDon formDshd = new DanhSachHoaDon(this);
            formDshd.Show();
        }

        private void menuNhomMatHang_Click(object sender, EventArgs e)  // Nút Nhóm mặt hàng
        {
            NhomMatHang formNhomMH = new NhomMatHang(this);
            formNhomMH.Show();
        }

        private void menuChiTietDSMH_Click(object sender, EventArgs e) // Nút chi tiết danh sách mặt hàng
        {
            ChiTietDSMatHang formChiTietDSMH = new ChiTietDSMatHang(this);
            formChiTietDSMH.Show();
        }

        private void menuInMaVach_Click(object sender, EventArgs e)
        {
            InMaVach formInMaVach = new InMaVach(this);
            formInMaVach.Show();
        }

        private void menuNewNH_Click(object sender, EventArgs e)
        {
            NhapHang formNhapHang = new NhapHang(this);
            formNhapHang.Show();
        }

        private void menuDSNH_Click(object sender, EventArgs e)
        {
            DSNhapHang formDSNhapHang = new DSNhapHang(this);
            formDSNhapHang.Show();
        }

        private void menuBaoCaoDT_Click(object sender, EventArgs e)
        {
            BaoCaoDoanhThu formBaoCaoDoanhThu = new BaoCaoDoanhThu(this);
            formBaoCaoDoanhThu.Show();
        }

        private void menuMHSapHet_Click(object sender, EventArgs e)
        {
            MatHangSapHet formMatHangSapHet = new MatHangSapHet(this);
            formMatHangSapHet.Show();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan formQuanLyTaiKhoan = new QuanLyTaiKhoan(this);
            formQuanLyTaiKhoan.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau formDoiMatKhau = new DoiMatKhau(this);
            formDoiMatKhau.Show();
        }
    }
}
