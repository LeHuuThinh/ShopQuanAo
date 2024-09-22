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
    public partial class InMaVach : Form
    {
        public InMaVach(QuanLy form1)
        {
            InitializeComponent();
        }

        private void InMaVach_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            XemTrangIn formXemTrangIn = new XemTrangIn(this);
            formXemTrangIn.Show();
        }
    }
}
