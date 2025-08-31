using QLShop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinhVien.frmAdmin
{
    public partial class frmQLSinhVien : Form
    {
        DBConnect conn = new DBConnect();

        public frmQLSinhVien()
        {
            InitializeComponent();
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadData();
            txtTraCuuThongTin.TextChanged += txtTraCuuThongTin_TextChanged;
        }

        private void LoadData()
        {
            try
            {
                // Câu lệnh SQL để lấy danh sách môn học từ cơ sở dữ liệu
                string query = "SELECT * FROM SinhVien";

                // Sử dụng phương thức ExecuteQuery của DBConnect để lấy dữ liệu
                DataTable dataTable = conn.ExecuteQuery(query);

                // Kiểm tra nếu dữ liệu không rỗng
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    dgvSinhVien.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu môn học.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }


        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "Tìm kiếm theo mã hoặc tên sinh viên")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = SystemColors.MenuHighlight;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
            {
                txtTimKiem.Text = "Tìm kiếm theo mã hoặc tên sinh viên";
                txtTimKiem.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtTraCuuThongTin_Enter(object sender, EventArgs e)
        {
            if (txtTraCuuThongTin.Text.Trim() == "Nhập mã sinh viên")
            {
                txtTraCuuThongTin.Text = "";
                txtTraCuuThongTin.ForeColor = SystemColors.MenuHighlight;
            }
        }

        private void txtTraCuuThongTin_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTraCuuThongTin.Text.Trim()))
            {
                txtTraCuuThongTin.Text = "Nhập mã sinh viên";
                txtTraCuuThongTin.ForeColor = SystemColors.GrayText;
            }
        }

        

        private void chkHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMK.Checked)
                txtMatKhau.UseSystemPasswordChar = false;
            else
                txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSV.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            try
            {
                string query = "INSERT INTO SinhVien (TenSV, NgaySinh, Email, SDT, MatKhau) VALUES (@TenSV, @NgaySinh, @Email, @SDT, @MatKhau)";
                var parameters = new Dictionary<string, object>
                {
                    { "@TenSV", txtTenSV.Text },
                    { "@NgaySinh", NgaySinh.Value },
                    { "@Email", txtEmail.Text },
                    { "@SDT", txtSDT.Text },
                    { "@MatKhau", txtMatKhau.Text }
                };
                conn.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Thêm sinh viên thành công!");

                // Xóa thông tin trong các TextBox
                txtTenSV.Clear();
                txtEmail.Clear();
                txtSDT.Clear();
                txtMatKhau.Clear();
                txtMaSV.Clear();

                // Đặt lại giá trị DateTimePicker về ngày hiện tại
                NgaySinh.Value = DateTime.Now;

                LoadData(); // Tải lại dữ liệu sau khi thêm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgvSinhVien.SelectedRows)
                        {
                            int maSV = int.Parse(row.Cells["MaSV"].Value.ToString());
                            string query = "DELETE FROM SinhVien WHERE MaSV = @MaSV";
                            var parameters = new Dictionary<string, object>
                            {
                                { "@MaSV", maSV }
                            };
                            conn.ExecuteNonQuery(query, parameters);
                        }
                        MessageBox.Show("Xóa sinh viên thành công!");

                        // Xóa thông tin trong các TextBox
                        txtTenSV.Clear();
                        txtEmail.Clear();
                        txtSDT.Clear();
                        txtMatKhau.Clear();
                        txtMaSV.Clear();

                        // Đặt lại giá trị DateTimePicker về ngày hiện tại
                        NgaySinh.Value = DateTime.Now;

                        LoadData(); // Tải lại dữ liệu sau khi xóa
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgvSinhVien.SelectedRows[0];
                    int maSV = int.Parse(selectedRow.Cells["MaSV"].Value.ToString());

                    // Kiểm tra nếu mã sinh viên không thể sửa
                    if (maSV <= 0)
                    {
                        MessageBox.Show("Không thể sửa mã sinh viên!");
                        return;
                    }

                    string query = "UPDATE SinhVien SET TenSV = @TenSV, NgaySinh = @NgaySinh, Email = @Email, SDT = @SDT, MatKhau = @MatKhau WHERE MaSV = @MaSV";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@TenSV", txtTenSV.Text },
                        { "@NgaySinh", NgaySinh.Value },
                        { "@Email", txtEmail.Text },
                        { "@SDT", txtSDT.Text },
                        { "@MatKhau", txtMatKhau.Text },
                        { "@MaSV", maSV }
                    };
                    conn.ExecuteNonQuery(query, parameters);
                    MessageBox.Show("Sửa thông tin sinh viên thành công!");

                    // Xóa thông tin trong các TextBox
                    txtTenSV.Clear();
                    txtEmail.Clear();
                    txtSDT.Clear();
                    txtMatKhau.Clear();
                    txtMaSV.Clear();

                    // Đặt lại giá trị DateTimePicker về ngày hiện tại
                    NgaySinh.Value = DateTime.Now;

                    LoadData(); // Tải lại dữ liệu sau khi sửa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa sinh viên: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng để sửa!");
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvSinhVien.Rows[e.RowIndex];

                // Lấy giá trị từ các ô và kiểm tra nếu có giá trị null hoặc kiểu không đúng
                txtMaSV.Text = selectedRow.Cells["MaSV"].Value.ToString();
                txtTenSV.Text = selectedRow.Cells["TenSV"].Value.ToString();

                // Kiểm tra kiểu dữ liệu của NgaySinh trước khi gán
                if (selectedRow.Cells["NgaySinh"].Value != DBNull.Value)
                {
                    NgaySinh.Value = Convert.ToDateTime(selectedRow.Cells["NgaySinh"].Value);
                }
                else
                {
                    NgaySinh.Value = DateTime.Now; // Hoặc giá trị mặc định nào đó
                }

                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtSDT.Text = selectedRow.Cells["SDT"].Value.ToString();
                txtMatKhau.Text = selectedRow.Cells["MatKhau"].Value.ToString();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            //if (txtTimKiem.Text != "Tìm kiếm theo mã hoặc tên sinh viên")
            //{
            //    // Thực hiện chức năng tìm kiếm
            //}
            string filterText = txtTimKiem.Text.Trim();

            // Kiểm tra nếu ô tìm kiếm không rỗng và không phải là văn bản mặc định
            if (!string.IsNullOrEmpty(filterText) && filterText != "Tìm kiếm theo mã hoặc tên sinh viên")
            {
                string filterExpression = "";

                // Kiểm tra nếu là số (tìm kiếm theo MaSV)
                if (int.TryParse(filterText, out int maSV))
                {
                    filterExpression = $"MaSV = {maSV}";
                }
                else
                {
                    // Nếu không phải số thì tìm kiếm theo TenSV
                    filterExpression = $"TenSV LIKE '%{filterText}%'";
                }

                // Áp dụng bộ lọc trên DataGridView
                (dgvSinhVien.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
            }
            else
            {
                // Nếu ô tìm kiếm rỗng hoặc chứa văn bản mặc định, xóa bộ lọc và hiển thị lại toàn bộ dữ liệu
                (dgvSinhVien.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTraCuuThongTin.Text.Trim();

            // Nếu ô tìm kiếm rỗng, hiển thị toàn bộ dữ liệu
            if (string.IsNullOrEmpty(keyword))
            {
                HienThiToanBoSinhVien();
                return;
            }

            // Truy vấn dữ liệu dựa trên mã sinh viên
            string query = "SELECT * FROM SinhVien WHERE MaSV = @MaSV";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@MaSV", keyword } };
            DataTable dt = conn.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                // Hiển thị thông tin sinh viên lên các label
                DataRow row = dt.Rows[0];
                lblMaSV.Text = "Mã Sinh Viên:            " + row["MaSV"].ToString();
                lblTenSV.Text = "Tên Sinh Viên:            " + row["TenSV"].ToString();
                lblNgaySinh.Text = "Ngày sinh:            " + Convert.ToDateTime(row["NgaySinh"]).ToString("dd/MM/yyyy");
                lblEmail.Text = "Email:            " + row["Email"].ToString();
                lblSDT.Text = "SĐT:            " + row["SDT"].ToString();
                lblMatKhau.Text = "Mật khẩu:            " + row["MatKhau"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearLabels();
            }
        }

        private void HienThiToanBoSinhVien()
        {
            string query = "SELECT * FROM SinhVien";
            DataTable dt = conn.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                ClearLabels();
                string allData = "";

                foreach (DataRow row in dt.Rows)
                {
                    allData += $"Mã SV: {row["MaSV"]}, Tên SV: {row["TenSV"]}, Ngày sinh: {Convert.ToDateTime(row["NgaySinh"]).ToString("dd/MM/yyyy")}, Email: {row["Email"]}, SĐT: {row["SDT"]}\n";
                }

                lblMaSV.Text = allData; // Gộp toàn bộ thông tin và hiển thị trong một label
            }
            else
            {
                ClearLabels();
            }
        }

        private void ClearLabels()
        {
            lblMaSV.Text = "Mã Sinh Viên:            ";
            lblTenSV.Text = "Tên Sinh Viên:            ";
            lblNgaySinh.Text = "Ngày sinh:            ";
            lblEmail.Text = "Email:            ";
            lblSDT.Text = "SĐT:            ";
            lblMatKhau.Text = "Mật khẩu:            ";
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTraCuuThongTin_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtTraCuuThongTin.Text.Trim();
            // Nếu ô tìm kiếm rỗng, trả về trạng thái ban đầu cho các label
            if (!string.IsNullOrEmpty(filterText) && filterText != "Nhập mã sinh viên")
            {
                ClearLabels();
            }
        }
    }
}
