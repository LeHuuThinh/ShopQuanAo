using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopQuanAo
{
    public partial class DanhSachHoaDon : Form
    {
        public DanhSachHoaDon(QuanLy form1)
        {
            InitializeComponent();

            //lvDSHD.Items.Insert(0, new ListViewItem(new[] {"01", "Đỗ Trần Quốc Huy", "22/9/2024", "Ngô Đào Bảo Quân", "0988123456",
            // "350.000", "10%", "15.000", "5.000", "334.000", "Đã thanh toán", "Thằng béo"}));
        }

        private void DanhSachHoaDon_Load(object sender, EventArgs e)
        {

        }

        private void lvDSHD_ItemActivate(object sender, EventArgs e)
        {
            ChiTietDonHang formCTDH = new ChiTietDonHang(this);
            formCTDH.Show();
        }
    }
}
