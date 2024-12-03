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
    public partial class ThemMatHang : Form
    {
        public delegate void MatHangAddedHandler(string maSP, string tenSP, string giaSi, string giaLe, int slSP);
        public event MatHangAddedHandler MatHangAdded;

        

        public ThemMatHang(ChiTietDSMatHang form1)
        {
            InitializeComponent();
        }

        private void ThemMatHang_Load(object sender, EventArgs e)
        {

        }

        

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveNExit_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các textbox
            string maSP = txtMaSP.Text.Trim();
            string tenSP = txtTenSP.Text.Trim();
            string giaSi = txtGiaSi.Text.Trim();
            string giaLe = txtGiaLe.Text.Trim();
            string slSPText = txtSLSP.Text.Trim();

            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrEmpty(maSP) || string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(giaSi) ||
                string.IsNullOrEmpty(giaLe) || string.IsNullOrEmpty(slSPText) || !int.TryParse(slSPText, out int slSP))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuỗi kết nối 
            string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";


            // Lưu vào cơ sở dữ liệu
            string query = "INSERT INTO MatHang (Ma_SP, Ten_SP, GiaSi, GiaLe, SL_SP) VALUES (@MaSP, @TenSP, @GiaSi, @GiaLe, @SLSP)";

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
                        MatHangAdded?.Invoke(maSP, tenSP, giaSi, giaLe, slSP);

                        // Hiển thị thông báo và đóng form
                        MessageBox.Show("Thêm mặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm mặt hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
