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
    public partial class CapNhatMatHang : Form
    {
        // Khai báo delegate và event để truyền dữ liệu cập nhật về Form1
        public delegate void UpdateMatHangHandler(string maSP, string tenSP, string giaSi, string giaLe, int slSP);
        public event UpdateMatHangHandler UpdateMatHangCompleted;

        private string maSP;
        public CapNhatMatHang(string maSP, string tenSP, string giaSi, string giaLe, string slSP)
        {
            InitializeComponent();

            // Gán thông tin mặt hàng vào các textbox
            this.maSP = maSP;
            txtMaSP.Text = maSP;
            txtTenSP.Text = tenSP;
            txtGiaSi.Text = giaSi;
            txtGiaLe.Text = giaLe;
            txtSLSP.Text = slSP;

            // Khóa textbox mã sản phẩm
            txtMaSP.ReadOnly = true;
        }


        private void CapNhatMatHang_Load(object sender, EventArgs e)
        {

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các textbox
            string tenSP = txtTenSP.Text.Trim();
            string giaSi = txtGiaSi.Text.Trim();
            string giaLe = txtGiaLe.Text.Trim();
            string slSPText = txtSLSP.Text.Trim();

            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(giaSi) || string.IsNullOrEmpty(giaLe) ||
                string.IsNullOrEmpty(slSPText) || !int.TryParse(slSPText, out int slSP))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuỗi kết nối (thay đổi theo cấu hình của bạn)
            string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";


            // Cập nhật cơ sở dữ liệu
            string query = "UPDATE MatHang SET Ten_SP = @TenSP, GiaSi = @GiaSi, GiaLe = @GiaLe, SL_SP = @SLSP WHERE Ma_SP = @MaSP";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaSP", maSP);
                    command.Parameters.AddWithValue("@TenSP", tenSP);
                    command.Parameters.AddWithValue("@GiaSi", giaSi);
                    command.Parameters.AddWithValue("@GiaLe", giaLe);
                    command.Parameters.AddWithValue("@SLSP", slSP);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Gửi dữ liệu về Form1 thông qua event
                        UpdateMatHangCompleted?.Invoke(maSP, tenSP, giaSi, giaLe, slSP);

                        // Thông báo thành công và đóng form
                        MessageBox.Show("Cập nhật mặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật mặt hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
