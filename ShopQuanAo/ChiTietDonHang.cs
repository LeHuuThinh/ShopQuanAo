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

namespace ShopQuanAo
{
    public partial class ChiTietDonHang : Form
    {
        private string maHD;
        public ChiTietDonHang(string maHD)
        {
            InitializeComponent();
            this.maHD = maHD;
        }

        private void ChiTietDonHang_Load(object sender, EventArgs e)
        {
            // Kết nối cơ sở dữ liệu
            string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Lấy thông tin hóa đơn từ bảng HoaDon
                string queryHoaDon = "SELECT * FROM HoaDon WHERE Ma_HD = @MaHD";
                using (SqlCommand cmd = new SqlCommand(queryHoaDon, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtHD_MaHD.Text = reader["Ma_HD"].ToString();
                            txtHD_MaNV.Text = reader["Ma_NV"].ToString();
                            dtpHD_NgayLap.Value = Convert.ToDateTime(reader["NgayLap"]);
                            txtHD_HoTen.Text = reader["KH"].ToString();
                            txtHD_SDT.Text = reader["SDT"].ToString();
                            txtHD_DiaChi.Text = reader["DiaChi"].ToString();
                            txtHD_TongTien.Text = reader["TongTien"].ToString();
                            txtHD_Ship.Text = reader["PhiShip"].ToString();
                            txtHD_Total.Text = reader["TongThanhToan"].ToString();
                        }
                    }
                }

                // Lấy danh sách mặt hàng từ bảng ChiTietHoaDon
                string queryChiTiet = "SELECT Ma_SP, Ten_SP, SoLuong, ThanhTien FROM ChiTietHoaDon WHERE Ma_HD = @MaHD";
                using (SqlCommand cmd = new SqlCommand(queryChiTiet, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["Ma_SP"].ToString());
                            item.SubItems.Add(reader["Ten_SP"].ToString());
                            item.SubItems.Add(reader["SoLuong"].ToString());
                            item.SubItems.Add(reader["ThanhTien"].ToString());
                            lvDetailHD.Items.Add(item);
                        }
                    }
                }
            }
        }
    }
}
