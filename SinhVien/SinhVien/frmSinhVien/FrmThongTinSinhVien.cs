using QLShop.TienIch;
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

namespace SinhVien
{
    public partial class FrmThongTinSinhVien : Form
    {

        
        public FrmThongTinSinhVien()
        {
            InitializeComponent();
        }

        private void SetFieldsEditable(bool isEditable)
        {
            txtHoTen.ReadOnly = !isEditable;
            dateTimePicker1.Enabled = isEditable;
            txtEmail.ReadOnly = !isEditable;
            txtSDT.ReadOnly = !isEditable;

            btnSave.Enabled = isEditable;  // Nút Lưu chỉ hoạt động khi ở chế độ chỉnh sửa
        }

        private void ThongTinSV_Load(object sender, EventArgs e)
        {
            // Kiểm tra xem thông tin sinh viên đã được lưu chưa
            if (SinhVien.CurrentSinhVien != null)
            {
                // Lấy thông tin từ SinhVien.CurrentSinhVien
                textBox1.Text = SinhVien.CurrentSinhVien.MaSV;
                txtHoTen.Text = SinhVien.CurrentSinhVien.HoTen;

                dateTimePicker1.Value = SinhVien.CurrentSinhVien.NgaySinh;
                txtEmail.Text = SinhVien.CurrentSinhVien.Email;
                txtSDT.Text = SinhVien.CurrentSinhVien.SDT;

                SetFieldsEditable(false);
            }
            else
            {
                MessageBoxHelper.ShowMessage("Không có thông tin sinh viên để hiển thị.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }

        private void UpdateStudentInfoInDatabase()
        {
            string connectionString = @"Data source = .; Initial Catalog = QL_THITRACNGHIEM; INTEGRATED SECURITY= TRUE; Connection Timeout=5";
            string query = @"
            UPDATE SinhVien
            SET TenSV = @TenSV, NgaySinh = @NgaySinh, Email = @Email, SDT = @SDT
            WHERE MaSV = @MaSV
        ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenSV", SinhVien.CurrentSinhVien.HoTen);
                cmd.Parameters.AddWithValue("@NgaySinh", SinhVien.CurrentSinhVien.NgaySinh);
                cmd.Parameters.AddWithValue("@Email", SinhVien.CurrentSinhVien.Email);
                cmd.Parameters.AddWithValue("@SDT", SinhVien.CurrentSinhVien.SDT);
                cmd.Parameters.AddWithValue("@MaSV", SinhVien.CurrentSinhVien.MaSV);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBoxHelper.ShowMessage("Vui lòng nhập họ tên.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBoxHelper.ShowMessage("Vui lòng nhập email hợp lệ.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBoxHelper.ShowMessage("Vui lòng nhập số điện thoại.");
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra thông tin nhập vào
                if (ValidateForm())
                {
                    // Lưu lại thông tin vào đối tượng SinhVien.CurrentSinhVien
                    SinhVien.CurrentSinhVien.HoTen = txtHoTen.Text;
                    SinhVien.CurrentSinhVien.NgaySinh = dateTimePicker1.Value;
                    SinhVien.CurrentSinhVien.Email = txtEmail.Text;
                    SinhVien.CurrentSinhVien.SDT = txtSDT.Text;

                    // Cập nhật cơ sở dữ liệu
                    UpdateStudentInfoInDatabase();

                    MessageBoxHelper.ShowMessage("Thông tin đã được lưu thành công.");

                    // Chuyển trường về chế độ không chỉnh sửa
                    SetFieldsEditable(false);
                }
                else
                {
                    MessageBoxHelper.ShowMessage("Vui lòng kiểm tra lại thông tin đã nhập.");
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowMessageError(ex.Message);
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            SetFieldsEditable(true);
        }
    }
}
