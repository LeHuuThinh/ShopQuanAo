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
    public partial class DSNhapHang : Form
    {
        public DSNhapHang(QuanLy form1)
        {
            InitializeComponent();
        }

        private void DSNhapHang_Load(object sender, EventArgs e)
        {
            LoadPhieuNhap();
        }

        private void listView2_ItemActivate(object sender, EventArgs e)
        {
            ChiTietPhieuNhap formChiTietPN = new ChiTietPhieuNhap(this);
            formChiTietPN.Show();
        }

        private void LoadPhieuNhap()
        {
            string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";
            string query = "SELECT ID_Phieu, Ma_NV, Ma_NCC, NgayNhap, ThanhTien FROM PhieuNhap";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Mở kết nối
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        lvPhieuNhap.Items.Clear(); // Xóa các mục cũ nếu có
                        while (reader.Read())
                        {
                            // Đọc dữ liệu từ từng dòng
                            string idPhieu = reader["ID_Phieu"].ToString();
                            string maNV = reader["Ma_NV"].ToString();
                            string maNCC = reader["Ma_NCC"].ToString();
                            string ngayNhap = reader["NgayNhap"].ToString();
                            string thanhTien = reader["ThanhTien"].ToString();

                            // Tạo một ListViewItem
                            ListViewItem item = new ListViewItem(idPhieu);
                            item.SubItems.Add(maNV);
                            item.SubItems.Add(maNCC);
                            item.SubItems.Add(ngayNhap);
                            item.SubItems.Add(thanhTien);

                            // Thêm vào ListView
                            lvPhieuNhap.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
