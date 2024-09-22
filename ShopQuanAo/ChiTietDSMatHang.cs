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
    public partial class ChiTietDSMatHang : Form
    {
        public ChiTietDSMatHang(QuanLy form1)
        {
            InitializeComponent();
        }

        private void ChiTietDSMH_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThemMatHang formThemMH = new ThemMatHang(this);
            formThemMH.Show();
        }
    }
}
