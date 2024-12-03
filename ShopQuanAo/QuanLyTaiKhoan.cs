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
    public partial class QuanLyTaiKhoan : Form
    {
        public QuanLyTaiKhoan(QuanLy form1)
        {
            InitializeComponent();
        }

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            this.Load_TaiKhoan();

        }

        public class TaiKhoanInfo
        {
            public string TenDangNhap { get; set; }
            public string MatKhau { get; set; }
            public string HoVaTenLot_NV { get; set; }
            public string Ten_NV { get; set; }
            public string CCCDNV { get; set; }
            public string SDT_NV { get; set; }
            public DateTime NgaySinh_NV { get; set; }
            public string DiaChi_NV { get; set; }
            public string ChucVu { get; set; }
        }

        private void Load_TaiKhoan()
        {
            string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";

            string query = "SELECT TenDangNhap, MatKhau, HoVaTenLot_NV, Ten_NV, CCCDNV, SDT_NV, NgaySinh_NV, DiaChi_NV, ChucVu FROM TaiKhoan";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        lvDSNV.Items.Clear();
                        while (reader.Read())
                        {
                            // Đọc dữ liệu từ từng dòng
                            string tenDangNhap = reader["TenDangNhap"].ToString();
                            string matKhau = reader["MatKhau"].ToString();
                            string hoVaTenLot_nv = reader["HoVaTenLot_NV"].ToString();
                            string ten_nv = reader["Ten_NV"].ToString();
                            string cccdnv = reader["CCCDNV"].ToString();
                            string sdt_nv = reader["SDT_NV"].ToString();
                            DateTime ngaySinh_nv = Convert.ToDateTime(reader["NgaySinh_NV"]);
                            string diaChi_nv = reader["DiaChi_NV"].ToString();
                            string chucVu = reader["ChucVu"].ToString();


                            TaiKhoanInfo info = new TaiKhoanInfo
                            {
                                TenDangNhap = tenDangNhap,
                                MatKhau = matKhau,
                                HoVaTenLot_NV = hoVaTenLot_nv,
                                Ten_NV = ten_nv,
                                CCCDNV = cccdnv,
                                SDT_NV = sdt_nv,
                                NgaySinh_NV = ngaySinh_nv,
                                DiaChi_NV = diaChi_nv,
                                ChucVu = chucVu
                            };

                            ListViewItem item = new ListViewItem(tenDangNhap);
                            item.SubItems.Add(hoVaTenLot_nv);
                            item.SubItems.Add(ten_nv);
                            item.SubItems.Add(sdt_nv);
                            item.SubItems.Add(cccdnv);
                            item.SubItems.Add(matKhau);
                            item.SubItems.Add(ngaySinh_nv.ToShortDateString());
                            item.SubItems.Add(diaChi_nv);
                            item.SubItems.Add(chucVu);

                            item.Tag = info;

                            lvDSNV.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvDSNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDSNV.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvDSNV.SelectedItems[0];
                TaiKhoanInfo info = (TaiKhoanInfo)selectedItem.Tag;

                if (info != null)
                {
                    DisplayAccountInfo(info);
                }
                else
                {
                    MessageBox.Show("No data available for the selected item.");
                }
            }
        }

        public void DisplayAccountInfo(TaiKhoanInfo info)
        {
            try
            {
                txtTenDangNhap.Text = info.TenDangNhap;
                txtHoTenLot.Text = info.HoVaTenLot_NV;
                txtTen.Text = info.Ten_NV;
                mtxtSDTNV.Text = info.SDT_NV;
                mtxtCCCDNV.Text = info.CCCDNV;
                txtMatKhau.Text = info.MatKhau;
                txtDiaChiNV.Text = info.DiaChi_NV;
                dtpNgaySinhNV.Value = info.NgaySinh_NV;
                if (info.ChucVu == "QuanLy")
                {
                    rdbQuanLy.Checked = true;
                }
                else if (info.ChucVu == "NhanVien")
                {
                    rdbNhanVien.Checked = true;
                }
                else if (info.ChucVu == "QuanTriVien")
                {
                    rdbQuanTriVien.Checked = true;
                }
                else { rdbThuNgan.Checked = true; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Reset thông tin

        private void btnReset_Click(object sender, EventArgs e)
        {
            mtxtCCCDNV.ResetText();
            txtDiaChiNV.ResetText();
            txtHoTenLot.ResetText();
            txtMatKhau.ResetText();
            mtxtSDTNV.ResetText();
            txtTen.ResetText();
            txtTenDangNhap.ResetText();
            dtpNgaySinhNV.ResetText();
            rdbNhanVien.Checked = false;
            rdbQuanLy.Checked = false;
            rdbQuanTriVien.Checked = false;
            rdbThuNgan.Checked = false;
        }
        //Tạo tài khoản

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "EXECUTE InsertAccount @tenDangNhap, @matKhau, @hoVaTenLot_nv, @ten_nv, @sdt_nv, @cccdnv, @ngaySinh_nv, @diaChi_nv, @chucVu";

                cmd.Parameters.Add("@tenDangNhap", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@matKhau", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@hoVaTenLot_nv", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@ten_nv", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@sdt_nv", SqlDbType.Int);
                cmd.Parameters.Add("@cccdnv", SqlDbType.Int);
                cmd.Parameters.Add("@ngaySinh_nv", SqlDbType.Date);
                cmd.Parameters.Add("@diaChi_nv", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@chucVu", SqlDbType.NVarChar, 20);


                cmd.Parameters["@tenDangNhap"].Value = txtTenDangNhap.Text;
                cmd.Parameters["@matKhau"].Value = txtMatKhau.Text;
                cmd.Parameters["@hoVaTenLot_nv"].Value = txtHoTenLot.Text;
                cmd.Parameters["@ten_nv"].Value = txtTen.Text;
                cmd.Parameters["@sdt_nv"].Value = mtxtSDTNV.Text;
                cmd.Parameters["@cccdnv"].Value = mtxtCCCDNV.Text;
                cmd.Parameters["@ngaySinh_nv"].Value = dtpNgaySinhNV.Value.Date;
                cmd.Parameters["@diaChi_nv"].Value = txtDiaChiNV.Text;

                if (rdbQuanLy.Checked)
                {
                    cmd.Parameters["@chucVu"].Value = "QuanLy";
                }
                else if (rdbNhanVien.Checked)
                {
                    cmd.Parameters["@chucVu"].Value = "NhanVien";
                }
                else if (rdbQuanTriVien.Checked)
                {
                    cmd.Parameters["@chucVu"].Value = "QuanTri";
                }
                else
                {
                    cmd.Parameters["@chucVu"].Value = "ThuNgan";
                }
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Đã tạo tài khoản");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //Sửa tài khoản

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "EXECUTE UpdateAccount @tenDangNhap, @matKhau, @hoVaTenLot_nv, @ten_nv, @sdt_nv, @cccdnv, @ngaySinh_nv, @diaChi_nv, @chucVu";

                cmd.Parameters.Add("@tenDangNhap", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@matKhau", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@hoVaTenLot_nv", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@ten_nv", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@sdt_nv", SqlDbType.Int);
                cmd.Parameters.Add("@cccdnv", SqlDbType.Int);
                cmd.Parameters.Add("@ngaySinh_nv", SqlDbType.Date);
                cmd.Parameters.Add("@diaChi_nv", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@chucVu", SqlDbType.NVarChar, 20);


                cmd.Parameters["@tenDangNhap"].Value = txtTenDangNhap.Text;
                cmd.Parameters["@matKhau"].Value = txtMatKhau.Text;
                cmd.Parameters["@hoVaTenLot_nv"].Value = txtHoTenLot.Text;
                cmd.Parameters["@ten_nv"].Value = txtTen.Text;
                cmd.Parameters["@sdt_nv"].Value = mtxtSDTNV.Text;
                cmd.Parameters["@cccdnv"].Value = mtxtCCCDNV.Text;
                cmd.Parameters["@ngaySinh_nv"].Value = dtpNgaySinhNV.Value.Date;
                cmd.Parameters["@diaChi_nv"].Value = txtDiaChiNV.Text;

                if (rdbQuanLy.Checked)
                {
                    cmd.Parameters["@chucVu"].Value = "QuanLy";
                }
                else if (rdbNhanVien.Checked)
                {
                    cmd.Parameters["@chucVu"].Value = "NhanVien";
                }
                else if (rdbQuanTriVien.Checked)
                {
                    cmd.Parameters["@chucVu"].Value = "QuanTri";
                }
                else
                {
                    cmd.Parameters["@chucVu"].Value = "ThuNgan";
                }
                conn.Open();
                int numRowAffected = cmd.ExecuteNonQuery();
                if (numRowAffected > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công", "Thông báo");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công");
                }
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (lvDSNV.SelectedItems.Count > 0)
                    {
                        //lấy thông tin tài khoản
                        ListViewItem selectedItem = lvDSNV.SelectedItems[0];

                        TaiKhoanInfo info = (TaiKhoanInfo)selectedItem.Tag;
                        string tenDangNhap = info.TenDangNhap;

                        DialogResult result = MessageBox.Show("Bạn có muốn xóa tài khoản chứ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            //kết nối database
                            string connectionString = "Server=.\\SQLEXPRESS;Database=ShopQuanAo;Trusted_Connection=True;";


                            using (SqlConnection conn = new SqlConnection(connectionString))
                            {

                                using (SqlCommand cmd = new SqlCommand("DeleteAccount", conn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;


                                    cmd.Parameters.AddWithValue("@tenDangNhap", tenDangNhap);

                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                            }


                            lvDSNV.Items.Remove(selectedItem);

                            MessageBox.Show("Xóa thành công.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.btnReset_Click(sender, e);
                        }
                    }
                    //bắt lỗi
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
