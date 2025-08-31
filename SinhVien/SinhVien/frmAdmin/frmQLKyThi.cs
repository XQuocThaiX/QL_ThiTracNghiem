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
    public partial class frmQLKyThi : Form
    {
        DBConnect conn = new DBConnect();

        public frmQLKyThi()
        {
            InitializeComponent();
            dgvKyThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKyThi.AllowUserToAddRows = false;
            dgvKyThi.ReadOnly = true;
            dgvKyThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadData();
        }

        private void LoadData()
        {
            
            try
            {
                // Câu lệnh SQL để lấy danh sách môn học từ cơ sở dữ liệu
                string query = "SELECT * FROM KyThi";

                // Sử dụng phương thức ExecuteQuery của DBConnect để lấy dữ liệu
                DataTable dataTable = conn.ExecuteQuery(query);

                // Kiểm tra nếu dữ liệu không rỗng
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    dgvKyThi.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu kỳ thi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "Tìm kiếm theo mã hoặc tên")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = SystemColors.MenuHighlight;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
            {
                txtTimKiem.Text = "Tìm kiếm theo mã hoặc tên";
                txtTimKiem.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtTimKiem.Text;
            if (!string.IsNullOrEmpty(filterText) && filterText != "Tìm kiếm theo mã hoặc tên")
            {
                string filterExpression = "";

                filterExpression = $"TenHocKy LIKE '%{filterText}%' OR MaKyThi LIKE '%{filterText}%'";

                (dgvKyThi.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
            }
            else
            {
                (dgvKyThi.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenHocKy.Text) || string.IsNullOrEmpty(HocKy.Text) || string.IsNullOrEmpty(txtNamHoc.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            try
            {
                string query = "INSERT INTO KyThi (HocKy, NamHoc, TenHocKy) VALUES (@HocKy, @NamHoc, @TenHocKy)";
                var parameters = new Dictionary<string, object>
                {
                    { "@HocKy", int.Parse(HocKy.Text) },
                    { "@NamHoc", txtNamHoc.Text },
                    { "@TenHocKy", txtTenHocKy.Text }
                };
                conn.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Thêm kỳ thi thành công!");

                txtTenHocKy.Clear();
                txtNamHoc.Clear();
                HocKy.Value = 0;

                LoadData(); // Tải lại dữ liệu sau khi thêm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm kỳ thi: " + ex.Message);
            }
        }

        private void dgvKyThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvKyThi.Rows[e.RowIndex];
                txtMaKyThi.Text = selectedRow.Cells["MaKyThi"].Value.ToString();
                HocKy.Text = selectedRow.Cells["HocKy"].Value.ToString();
                txtNamHoc.Text = selectedRow.Cells["NamHoc"].Value.ToString();
                txtTenHocKy.Text = selectedRow.Cells["TenHocKy"].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKyThi.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgvKyThi.SelectedRows)
                        {
                            string maKyThi = row.Cells["MaKyThi"].Value.ToString();
                            string query = "DELETE FROM KyThi WHERE MaKyThi = @MaKyThi";
                            var parameters = new Dictionary<string, object>
                            {
                                { "@MaKyThi", maKyThi }
                            };
                            conn.ExecuteNonQuery(query, parameters);
                        }
                        MessageBox.Show("Xóa kỳ thi thành công!");

                        txtMaKyThi.Clear();
                        txtTenHocKy.Clear();
                        txtNamHoc.Clear();
                        HocKy.Value = 0;

                        LoadData(); // Tải lại dữ liệu sau khi xóa
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa kỳ thi: " + ex.Message);
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
            if (dgvKyThi.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgvKyThi.SelectedRows[0];
                    string maKyThi = selectedRow.Cells["MaKyThi"].Value.ToString();

                    // Kiểm tra nếu khóa chính (MaKyThi) không được thay đổi
                    if (maKyThi == txtMaKyThi.Text)
                    {
                        string query = "UPDATE KyThi SET HocKy = @HocKy, NamHoc = @NamHoc, TenHocKy = @TenHocKy WHERE MaKyThi = @MaKyThi";
                        var parameters = new Dictionary<string, object>
                        {
                            { "@HocKy", int.Parse(HocKy.Text) },
                            { "@NamHoc", txtNamHoc.Text },
                            { "@TenHocKy", txtTenHocKy.Text },
                            { "@MaKyThi", maKyThi }
                        };
                        conn.ExecuteNonQuery(query, parameters);
                        MessageBox.Show("Sửa kỳ thi thành công!");

                        txtMaKyThi.Clear();
                        txtTenHocKy.Clear();
                        txtNamHoc.Clear();
                        HocKy.Value = 0;

                        LoadData(); // Tải lại dữ liệu sau khi sửa
                    }
                    else
                    {
                        MessageBox.Show("Không thể thay đổi mã kỳ thi!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa kỳ thi: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng để sửa!");
            }
        }
    }
}
