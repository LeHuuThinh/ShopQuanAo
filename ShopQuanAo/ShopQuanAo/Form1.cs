using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopQuanAo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            grbSanPham.Visible = false;

            grbHangHot.Visible = true;
            grbVoucher.Visible = false;
            
            grbAbtUs.Visible = false;

            grbDanhMuc.Visible = false;

            grbCart.Visible = false;

            grbDaThem.Visible = true;
            grbDaMua.Visible = false;



        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Gacha f = new Gacha(this);
            f.Show();
            
        }
        private void btnTrangChu_Click(object sender, EventArgs e)
        {

            grbAbtUs.Visible = false;
            grbDanhMuc.Visible = false;
            grbCart.Visible = false;
            grbSanPham.Visible = false;
            grbTrangChu.Visible = true;

        }
        private void btnHangHot_Click(object sender, EventArgs e)
        {
            grbVoucher.Visible = false;
            grbHangHot.Visible = true;
            

        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            grbHangHot.Visible = false;
            grbVoucher.Visible = true;
            
        }

        private void btnAbtUs_Click(object sender, EventArgs e)
        {
            grbTrangChu.Visible = false;
            grbDanhMuc.Visible = false;
            grbCart.Visible = false;
            grbSanPham.Visible = false;
            grbAbtUs.Visible = true;
        }

        

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            grbAbtUs.Visible = false;
            grbTrangChu.Visible = false;
            grbCart.Visible = false;
            grbDanhMuc.Visible = false;
            grbSanPham.Visible = true;

        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            grbAbtUs.Visible = false;
            grbTrangChu.Visible = false;
            grbCart.Visible = false;
            grbSanPham.Visible = false;
            grbDanhMuc.Visible = true;
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            grbAbtUs.Visible = false;
            grbTrangChu.Visible = false;
            grbSanPham.Visible = false;
            grbDanhMuc.Visible = false;
            grbCart.Visible = true;
        }

        private void btnCartThem_Click(object sender, EventArgs e)
        {
            grbDaMua.Visible = false;
            grbDaThem.Visible = true;
        }

        private void btnCartMua_Click(object sender, EventArgs e)
        {
            grbDaThem.Visible = false;
            grbDaMua.Visible = true;
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private bool isRed = false;

        private void tmAd_Tick(object sender, EventArgs e)
        {
            if (isRed)
            {
                
                lblKhauHieu.ForeColor = Color.Blue;
            }
            else
            {
               
                lblKhauHieu.ForeColor = Color.Red;

            }

            // Đảo trạng thái isRed để tạo hiệu ứng nhấp nháy
            isRed = !isRed;
        }
    }
}
