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
    public partial class NhapHang : Form
    {
        public NhapHang(QuanLy form1)
        {
            InitializeComponent();
        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            LoadNhapHang();
        }

        private void LoadNhapHang()
        {
            string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";
            string query = "SELECT ID_Phieu, Ma_SP, Gia, SoLuong, ThanhTien FROM ChiTietPhieuNhap";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Mở kết nối
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        lvNhapHang.Items.Clear(); // Xóa các mục cũ nếu có
                        while (reader.Read())
                        {
                            // Đọc dữ liệu từ từng dòng
                            string idPhieu = reader["ID_Phieu"].ToString();
                            string maSP = reader["Ma_SP"].ToString();
                            string gia = reader["Gia"].ToString();
                            string soLuong = reader["SoLuong"].ToString();
                            string thanhTien = reader["ThanhTien"].ToString();

                            // Tạo một ListViewItem
                            ListViewItem item = new ListViewItem(idPhieu);
                            item.SubItems.Add(maSP);
                            item.SubItems.Add(gia);
                            item.SubItems.Add(soLuong);
                            item.SubItems.Add(thanhTien);

                            // Thêm vào ListView
                            lvNhapHang.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchNH_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchNH.Text.Trim(); // Lấy giá trị từ txtSearchPN
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";
            string query = "SELECT ID_Phieu, Ma_SP, Gia, SoLuong, ThanhTien FROM ChiTietPhieuNhap WHERE Ma_SP LIKE @searchText";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số tìm kiếm
                        command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lvNhapHang.Items.Clear(); // Xóa dữ liệu cũ trong ListView
                            while (reader.Read())
                            {
                                // Đọc dữ liệu từ từng dòng
                                string maSP = reader["ID_Phieu"].ToString();
                                string tenSP = reader["Ma_SP"].ToString();
                                string giaSi = reader["Gia"].ToString();
                                string giaLe = reader["SoLuong"].ToString();
                                string slSP = reader["ThanhTien"].ToString();

                                // Tạo một ListViewItem
                                ListViewItem item = new ListViewItem(maSP);
                                item.SubItems.Add(tenSP);
                                item.SubItems.Add(giaSi);
                                item.SubItems.Add(giaLe);
                                item.SubItems.Add(slSP);

                                // Thêm vào ListView
                                lvNhapHang.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSearchNH.ResetText();
        }

        private void thêmMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvNhapHang.FocusedItem != null) // Kiểm tra xem có item nào được chọn không
            {
                ListViewItem selectedItem = lvNhapHang.FocusedItem; // Item được chọn từ lvMatHang
                string maSP = selectedItem.Text; // Ma_SP
                string tenSP = selectedItem.SubItems[1].Text; // Ten_SP
                decimal giaLe = decimal.Parse(selectedItem.SubItems[2].Text); // Giá lẻ
                decimal giaSi = decimal.Parse(selectedItem.SubItems[3].Text); // Giá sỉ
                decimal thanhTien = decimal.Parse(selectedItem.SubItems[4].Text); // Giá sỉ

                // Kiểm tra xem item đã tồn tại trong lvMatHang2 chưa
                ListViewItem existingItem = null;
                foreach (ListViewItem item in lvChiTietPN.Items)
                {
                    if (item.Text == maSP) // So sánh Ma_SP
                    {
                        existingItem = item;
                        break;
                    }

                }
                if (existingItem != null) // Nếu item đã tồn tại
                {
                    
                }
                else // Nếu item chưa tồn tại
                {
                    // Thêm item mới vào lvMatHang2
                    ListViewItem newItem = new ListViewItem(maSP);
                    newItem.SubItems.Add(tenSP); // Tên sản phẩm
                    newItem.SubItems.Add(giaLe.ToString()); // Giá tiền mặc định là giá lẻ
                    newItem.SubItems.Add("1"); // Số lượng mặc định là 1
                    newItem.SubItems.Add(thanhTien.ToString());
                    lvChiTietPN.Items.Add(newItem);
                }
                
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
