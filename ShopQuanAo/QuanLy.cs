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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShopQuanAo
{
    public partial class QuanLy : Form
    {
        public QuanLy(TrangChu form1)
        {
            InitializeComponent();
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            LoadMatHang();
        }

        

        private void menuDSHD_Click(object sender, EventArgs e)  // Nút Danh sách hóa đơn
        {
            DanhSachHoaDon formDshd = new DanhSachHoaDon(this);
            formDshd.Show();
        }

        private void menuNhomMatHang_Click(object sender, EventArgs e)  // Nút Nhóm mặt hàng
        {
            NhomMatHang formNhomMH = new NhomMatHang(this);
            formNhomMH.Show();
        }

        private void menuChiTietDSMH_Click(object sender, EventArgs e) // Nút chi tiết danh sách mặt hàng
        {
            ChiTietDSMatHang formChiTietDSMH = new ChiTietDSMatHang(this);
            formChiTietDSMH.Show();
        }

        private void menuInMaVach_Click(object sender, EventArgs e)
        {
            InMaVach formInMaVach = new InMaVach(this);
            formInMaVach.Show();
        }

        private void menuNewNH_Click(object sender, EventArgs e)
        {
            NhapHang formNhapHang = new NhapHang(this);
            formNhapHang.Show();
        }

        private void menuDSNH_Click(object sender, EventArgs e)
        {
            DSNhapHang formDSNhapHang = new DSNhapHang(this);
            formDSNhapHang.Show();
        }

        private void menuBaoCaoDT_Click(object sender, EventArgs e)
        {
            BaoCaoDoanhThu formBaoCaoDoanhThu = new BaoCaoDoanhThu(this);
            formBaoCaoDoanhThu.Show();
        }

        private void menuMHSapHet_Click(object sender, EventArgs e)
        {
            MatHangSapHet formMatHangSapHet = new MatHangSapHet(this);
            formMatHangSapHet.Show();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan formQuanLyTaiKhoan = new QuanLyTaiKhoan(this);
            formQuanLyTaiKhoan.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau formDoiMatKhau = new DoiMatKhau(this);
            formDoiMatKhau.Show();
        }

        private void LoadMatHang()
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
                        lvMatHang.Items.Clear(); // Xóa các mục cũ nếu có
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
                            lvMatHang.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            lvMatHang.Items.Clear(); // Xóa dữ liệu cũ trong ListView
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
                                lvMatHang.Items.Add(item);
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

        

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtHD_HoTen.Text = "";
            txtHD_SDT.Text = "";
            lvHD_Hang.Items.Clear();
            txtHD_MaNV.Text = "";
            txtHD_DiaChi.Text = "";
            txtHD_TongTien.Text = "";
            txtHD_Note.Text = "";
            txtHD_Ship.Text = "";
            txtHD_Total.Text = "";
        }

        private void lvMatHang_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void thêmVàoĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvMatHang.FocusedItem != null) // Kiểm tra xem có item nào được chọn không
            {
                ListViewItem selectedItem = lvMatHang.FocusedItem; // Item được chọn từ lvMatHang
                string maSP = selectedItem.Text; // Ma_SP
                string tenSP = selectedItem.SubItems[1].Text; // Ten_SP
                decimal giaLe = decimal.Parse(selectedItem.SubItems[3].Text); // Giá lẻ
                decimal giaSi = decimal.Parse(selectedItem.SubItems[2].Text); // Giá sỉ

                // Kiểm tra xem item đã tồn tại trong lvMatHang2 chưa
                ListViewItem existingItem = null;
                foreach (ListViewItem item in lvHD_Hang.Items)
                {
                    if (item.Text == maSP) // So sánh Ma_SP
                    {
                        existingItem = item;
                        break;
                    }
                    
                }

                if (existingItem != null) // Nếu item đã tồn tại
                {
                    // Tăng số lượng
                    int soLuong = int.Parse(existingItem.SubItems[2].Text) + 1;
                    existingItem.SubItems[2].Text = soLuong.ToString();

                    // Cập nhật giá tiền (số lượng từ 2 trở lên sử dụng giá sỉ)
                    decimal giaTien = soLuong >= 2 ? giaSi * soLuong : giaLe;
                    existingItem.SubItems[3].Text = giaTien.ToString();
                }
                else // Nếu item chưa tồn tại
                {
                    // Thêm item mới vào lvMatHang2
                    ListViewItem newItem = new ListViewItem(maSP);
                    newItem.SubItems.Add(tenSP); // Tên sản phẩm
                    newItem.SubItems.Add("1"); // Số lượng mặc định là 1
                    newItem.SubItems.Add(giaLe.ToString()); // Giá tiền mặc định là giá lẻ
                    lvHD_Hang.Items.Add(newItem);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mặt hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            UpdateTongTien();
        }

        private void UpdateTongTien()
        {
            decimal tongTien = 0;

            foreach (ListViewItem item in lvHD_Hang.Items)
            {
                // Lấy giá trị cột "Thành tiền" (cột thứ 4, index = 3)
                if (decimal.TryParse(item.SubItems[3].Text, out decimal thanhTien))
                {
                    tongTien += thanhTien;
                }
            }

            // Hiển thị tổng tiền vào txtHD_TongTien
            txtHD_TongTien.Text = tongTien.ToString();
        }

        private void UpdateTotal()
        {
            if (decimal.TryParse(txtHD_TongTien.Text, out decimal tongTien) &&
                decimal.TryParse(txtHD_Ship.Text, out decimal phiShip))
            {
                // Tổng tiền thanh toán = Tổng tiền + Phí ship
                decimal total = tongTien + phiShip;
                txtHD_Total.Text = total.ToString();
            }
            else
            {
                txtHD_Total.Text = "0"; // Nếu nhập sai dữ liệu, hiển thị 0
            }
        }

        private void txtHD_Ship_TextChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kết nối CSDL
            string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // 1. Lưu hóa đơn vào bảng HoaDon
                    string maHD = txtHD_MaHD.Text.Trim();
                    string maNV = txtHD_MaNV.Text.Trim();
                    DateTime ngayLap = dtpHD_NgayLap.Value;
                    string hoTen = txtHD_HoTen.Text.Trim();
                    string sdt = txtHD_SDT.Text.Trim();
                    string diaChi = txtHD_DiaChi.Text.Trim();
                    string tongTien = txtHD_TongTien.Text.Trim();
                    string phiShip = txtHD_Ship.Text.Trim();
                    string tongThanhToan = txtHD_Total.Text.Trim();

                    string queryHoaDon = @"INSERT INTO HoaDon (Ma_HD, Ma_NV, NgayLap, KH, SDT, DiaChi, TongTien, PhiShip, TongThanhToan)
                                   VALUES (@MaHD, @MaNV, @NgayLap, @KH, @SDT, @DiaChi, @TongTien, @PhiShip, @TongThanhToan)";

                    using (SqlCommand cmdHoaDon = new SqlCommand(queryHoaDon, connection))
                    {
                        cmdHoaDon.Parameters.AddWithValue("@MaHD", maHD);
                        cmdHoaDon.Parameters.AddWithValue("@MaNV", maNV);
                        cmdHoaDon.Parameters.AddWithValue("@NgayLap", ngayLap);
                        cmdHoaDon.Parameters.AddWithValue("@KH", hoTen);
                        cmdHoaDon.Parameters.AddWithValue("@SDT", sdt);
                        cmdHoaDon.Parameters.AddWithValue("@DiaChi", sdt);
                        cmdHoaDon.Parameters.AddWithValue("@TongTien", tongTien);
                        cmdHoaDon.Parameters.AddWithValue("@PhiShip", phiShip);
                        cmdHoaDon.Parameters.AddWithValue("@TongThanhToan", tongThanhToan);

                        cmdHoaDon.ExecuteNonQuery();
                    }

                    // 2. Lưu các item từ lvMatHang2 vào bảng ChiTietHoaDon
                    foreach (ListViewItem item in lvHD_Hang.Items)
                    {
                        string maSP = item.SubItems[0].Text; // Ma_SP
                        string tenSP = item.SubItems[1].Text; // Ten_SP
                        int soLuong = int.Parse(item.SubItems[2].Text); // SoLuong
                        string thanhTien = item.SubItems[3].Text; // ThanhTien

                        string queryChiTiet = @"INSERT INTO ChiTietHoaDon (Ma_HD, Ma_SP, Ten_SP, SoLuong, ThanhTien)
                                        VALUES (@MaHD, @MaSP, @TenSP, @SoLuong, @ThanhTien)";

                        using (SqlCommand cmdChiTiet = new SqlCommand(queryChiTiet, connection))
                        {
                            cmdChiTiet.Parameters.AddWithValue("@MaHD", maHD);
                            cmdChiTiet.Parameters.AddWithValue("@MaSP", maSP);
                            cmdChiTiet.Parameters.AddWithValue("@TenSP", tenSP);
                            cmdChiTiet.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmdChiTiet.Parameters.AddWithValue("@ThanhTien", thanhTien);

                            cmdChiTiet.ExecuteNonQuery();
                        }
                    }

                    // Thông báo thành công
                    MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
