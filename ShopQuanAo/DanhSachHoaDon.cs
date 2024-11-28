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
            if (lvDSHD.SelectedItems.Count > 0)
            {
                // Lấy Mã hóa đơn từ item được chọn
                string maHD = lvDSHD.SelectedItems[0].SubItems[0].Text;
                ChiTietDonHang formCTDH = new ChiTietDonHang(maHD);
                formCTDH.Show();
            }
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
            if (lvDSHD.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã hóa đơn từ item được chọn
            string maHD = lvDSHD.SelectedItems[0].SubItems[0].Text; // Cột 0 là Ma_HD

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn {maHD} và các chi tiết liên quan?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";


                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Bắt đầu transaction để đảm bảo tính nhất quán
                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                // Xóa các chi tiết hóa đơn trong bảng ChiTietHoaDon
                                string deleteChiTietHDQuery = "DELETE FROM ChiTietHoaDon WHERE Ma_HD = @MaHD";
                                using (SqlCommand cmd = new SqlCommand(deleteChiTietHDQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                                    cmd.ExecuteNonQuery();
                                }

                                // Xóa hóa đơn trong bảng HoaDon
                                string deleteHoaDonQuery = "DELETE FROM HoaDon WHERE Ma_HD = @MaHD";
                                using (SqlCommand cmd = new SqlCommand(deleteHoaDonQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                                    cmd.ExecuteNonQuery();
                                }

                                // Commit transaction
                                transaction.Commit();

                                // Xóa item khỏi ListView
                                lvDSHD.Items.Remove(lvDSHD.SelectedItems[0]);

                                MessageBox.Show($"Hóa đơn {maHD} đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch
                            {
                                // Rollback nếu có lỗi xảy ra
                                transaction.Rollback();
                                throw;
                            }
                        }
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
