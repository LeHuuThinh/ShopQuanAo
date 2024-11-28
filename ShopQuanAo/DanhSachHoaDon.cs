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
    public partial class DanhSachHoaDon : Form
    {
        public DanhSachHoaDon(QuanLy form1)
        {
            InitializeComponent();


        }

        private void DanhSachHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDon();

        }

        private void lvDSHD_ItemActivate(object sender, EventArgs e)
        {
            ChiTietDonHang formCTDH = new ChiTietDonHang(this);
            formCTDH.Show();
        }

        private void LoadHoaDon()
        {
            string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";
            string query = "SELECT Ma_HD, Ma_NV, NgayLap, KH, SDT, DiaChi, TongTien, PhiShip, TongThanhToan FROM HoaDon";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Mở kết nối
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        lvDSHD.Items.Clear(); // Xóa các mục cũ nếu có
                        while (reader.Read())
                        {
                            // Đọc dữ liệu từ từng dòng
                            string maHD = reader["Ma_HD"].ToString();
                            string maNV = reader["Ma_NV"].ToString();
                            string ngayLap = Convert.ToDateTime(reader["NgayLap"]).ToString("dd/MM/yyyy");
                            string KH = reader["KH"].ToString();
                            string SDT = reader["SDT"].ToString();
                            string diaChi = reader["DiaChi"].ToString();
                            string tongTien = reader["TongTien"].ToString();
                            string phiShip = reader["PhiShip"].ToString();
                            string tongThanhToan = reader["TongThanhToan"].ToString();

                            // Tạo một ListViewItem
                            ListViewItem item = new ListViewItem(maHD);
                            item.SubItems.Add(maNV);
                            item.SubItems.Add(ngayLap);
                            item.SubItems.Add(KH);
                            item.SubItems.Add(SDT);
                            item.SubItems.Add(diaChi);
                            item.SubItems.Add(tongTien);
                            item.SubItems.Add(phiShip);
                            item.SubItems.Add(tongThanhToan);

                            // Thêm vào ListView
                            lvDSHD.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddToListView(string maHD, string maNV, DateTime ngayLap, string khachHang, string sdt, string diaChi, string tongTien, string phiShip, string tongThanhToan)
        {
            // Tạo một dòng mới (ListViewItem)
            ListViewItem item = new ListViewItem(maHD);
            item.SubItems.Add(maNV);
            item.SubItems.Add(ngayLap.ToString("dd/MM/yyyy"));
            item.SubItems.Add(khachHang);
            item.SubItems.Add(sdt);
            item.SubItems.Add(tongTien);
            item.SubItems.Add(phiShip);
            item.SubItems.Add(tongThanhToan);

            // Thêm dòng vào ListView
            lvDSHD.Items.Add(item);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có item nào được chọn không
            if (lvDSHD.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy item được chọn
            ListViewItem selectedItem = lvDSHD.SelectedItems[0];
            string maHD = selectedItem.SubItems[0].Text; // Ma_HD nằm ở cột đầu tiên

            // Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn {maHD} không?",
                                                  "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Chuỗi kết nối 
                string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";


                // Câu lệnh SQL DELETE
                string query = "DELETE FROM HoaDon WHERE Ma_HD = @MaHD";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);

                        // Thêm tham số
                        command.Parameters.AddWithValue("@MaHD", maHD);

                        // Thực thi lệnh DELETE
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Xóa item khỏi ListView
                            lvDSHD.Items.Remove(selectedItem);
                            MessageBox.Show($"Hóa đơn {maHD} đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Không tìm thấy hóa đơn {maHD} trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
