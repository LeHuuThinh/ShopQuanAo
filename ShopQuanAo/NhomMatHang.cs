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
    public partial class NhomMatHang : Form
    {
        public NhomMatHang(QuanLy form1)
        {
            InitializeComponent();
        }

        private void NhomMatHang_Load(object sender, EventArgs e)
        {
            LoadNhomMatHang();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaNhom.Text = "";
            txtTenNhom.Text = "";
            txtLuuY.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu hợp lệ
            string maNhom = txtMaNhom.Text.Trim();
            string tenNhom = txtTenNhom.Text.Trim();

            if (string.IsNullOrEmpty(maNhom) || string.IsNullOrEmpty(tenNhom))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mã nhóm và tên nhóm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuỗi kết nối 
            string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";


            // Câu lệnh SQL INSERT
            string query = "INSERT INTO NhomMatHang (MaNhom, TenNhom) VALUES (@MaNhom, @TenNhom)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    // Thêm tham số
                    command.Parameters.AddWithValue("@MaNhom", maNhom);
                    command.Parameters.AddWithValue("@TenNhom", tenNhom);

                    // Thực thi lệnh INSERT
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Thêm item mới vào ListView
                        ListViewItem item = new ListViewItem(maNhom);
                        item.SubItems.Add(tenNhom);
                        lvNhomMH.Items.Add(item);

                        // Thông báo thành công
                        MessageBox.Show("Thêm nhóm mặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Xóa dữ liệu trong textbox sau khi thêm
                        txtMaNhom.Clear();
                        txtTenNhom.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm nhóm mặt hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadNhomMatHang()
        {
            string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";
            string query = "SELECT MaNhom,TenNhom FROM NhomMatHang";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Mở kết nối
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        lvNhomMH.Items.Clear(); // Xóa các mục cũ nếu có
                        while (reader.Read())
                        {
                            // Đọc dữ liệu từ từng dòng
                            string maNhom = reader["MaNhom"].ToString();
                            string tenNhom = reader["TenNhom"].ToString();
                            

                            // Tạo một ListViewItem
                            ListViewItem item = new ListViewItem(maNhom);
                            item.SubItems.Add(tenNhom);
                            

                            // Thêm vào ListView
                            lvNhomMH.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
