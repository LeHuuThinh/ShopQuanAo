﻿using System;
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
    public partial class DSNhapHang : Form
    {
        public DSNhapHang(QuanLy form1)
        {
            InitializeComponent();
        }

        private void DSNhapHang_Load(object sender, EventArgs e)
        {

        }

        private void listView2_ItemActivate(object sender, EventArgs e)
        {
            ChiTietPhieuNhap formChiTietPN = new ChiTietPhieuNhap(this);
            formChiTietPN.Show();
        }
    }
}