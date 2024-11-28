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
    public partial class ChiTietDSMatHang : Form
    {
        public ChiTietDSMatHang(QuanLy form1)
        {
            InitializeComponent();
        }

        private void ChiTietDSMH_Load(object sender, EventArgs e)
        {
            LoadMatHang();
        }

        public void LoadMatHang()
        {
            string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";
            string query = "SELECT Ma_SP, Ten_SP, GiaSi, GiaLe, SL_SP FROM MatHang";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Mở kết nối
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        lvDSMH_CT.Items.Clear(); // Xóa các mục cũ nếu có
                        while (reader.Read())
                        {
                            // Đọc dữ liệu từ từng dòng
                            string maSP = reader["Ma_SP"].ToString();
                            string tenSP = reader["Ten_SP"].ToString();
                            string giaSi = reader["GiaSi"].ToString();
                            string giaLe = reader["GiaLe"].ToString();
                            string slSP = reader["SL_SP"].ToString();

                            // Tạo một ListViewItem
                            ListViewItem item = new ListViewItem(maSP);
                            item.SubItems.Add(tenSP);
                            item.SubItems.Add(giaSi);
                            item.SubItems.Add(giaLe);
                            item.SubItems.Add(slSP);

                            // Thêm vào ListView
                            lvDSMH_CT.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateSL();

        }

        public void UpdateSL()
        {
            lblSLMH.Text = lvDSMH_CT.Items.Count.ToString();

            int tongSL = 0;

            foreach (ListViewItem item in lvDSMH_CT.Items)
            {
                if (int.TryParse(item.SubItems[4].Text, out int quantity))
                {
                    tongSL += quantity;
                }
            }

            lblTongSL.Text = tongSL.ToString();
        }

        private void btnAddMH_Click(object sender, EventArgs e)
        {
            ThemMatHang formThemMH = new ThemMatHang(this);
            formThemMH.MatHangAdded += OnMatHangAdded;
            formThemMH.Show();
        }

        private void btnUpdateMH_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn item chưa
            if (lvDSMH_CT.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ item được chọn
            ListViewItem selectedItem = lvDSMH_CT.SelectedItems[0];
            string maSP = selectedItem.SubItems[0].Text;
            string tenSP = selectedItem.SubItems[1].Text;
            string giaSi = selectedItem.SubItems[2].Text;
            string giaLe = selectedItem.SubItems[3].Text;
            string slSP = selectedItem.SubItems[4].Text;

            // Mở form cập nhật
            CapNhatMatHang capNhatForm = new CapNhatMatHang(maSP, tenSP, giaSi, giaLe, slSP);
            capNhatForm.UpdateMatHangCompleted += OnUpdateMatHangCompleted; // Đăng ký event
            capNhatForm.Show();
        }

        private void OnMatHangAdded(string maSP, string tenSP, string giaSi, string giaLe, int slSP)
        {
            // Thêm vào ListView
            ListViewItem item = new ListViewItem(maSP);
            item.SubItems.Add(tenSP);
            item.SubItems.Add(giaSi);
            item.SubItems.Add(giaLe);
            item.SubItems.Add(slSP.ToString());
            lvDSMH_CT.Items.Add(item);

            // Cập nhật tổng số lượng và tổng số item
            UpdateSL();
        }
        // Hàm xử lý khi nhận dữ liệu cập nhật từ form CapNhatMatHang
        private void OnUpdateMatHangCompleted(string maSP, string tenSP, string giaSi, string giaLe, int slSP)
        {
            // Cập nhật item trong lvMatHang
            foreach (ListViewItem item in lvDSMH_CT.Items)
            {
                if (item.SubItems[0].Text == maSP)
                {
                    item.SubItems[1].Text = tenSP;
                    item.SubItems[2].Text = giaSi;
                    item.SubItems[3].Text = giaLe;
                    item.SubItems[4].Text = slSP.ToString();
                    break;
                }
            }

            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim(); // Lấy giá trị từ txtSearch
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";
            string query = "SELECT Ma_SP, Ten_SP, GiaSi, GiaLe, SL_SP FROM MatHang WHERE Ten_SP LIKE @searchText";

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
                            lvDSMH_CT.Items.Clear(); // Xóa dữ liệu cũ trong ListView
                            while (reader.Read())
                            {
                                // Đọc dữ liệu từ từng dòng
                                string maSP = reader["Ma_SP"].ToString();
                                string tenSP = reader["Ten_SP"].ToString();
                                string giaSi = reader["GiaSi"].ToString();
                                string giaLe = reader["GiaLe"].ToString();
                                string slSP = reader["SL_SP"].ToString();

                                // Tạo một ListViewItem
                                ListViewItem item = new ListViewItem(maSP);
                                item.SubItems.Add(tenSP);
                                item.SubItems.Add(giaSi);
                                item.SubItems.Add(giaLe);
                                item.SubItems.Add(slSP);

                                // Thêm vào ListView
                                lvDSMH_CT.Items.Add(item);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn hay không
            if (lvDSMH_CT.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy Mã SP của mục được chọn
            string maSP = lvDSMH_CT.SelectedItems[0].Text; // Lấy giá trị từ cột đầu tiên (Ma_SP)

            // Xác nhận xóa
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa sản phẩm có mã '{maSP}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";

                string query = "DELETE FROM MatHang WHERE Ma_SP = @maSP";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Thêm tham số
                            command.Parameters.AddWithValue("@maSP", maSP);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Xóa mục khỏi ListView
                                lvDSMH_CT.Items.Remove(lvDSMH_CT.SelectedItems[0]);
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy sản phẩm để xóa trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
