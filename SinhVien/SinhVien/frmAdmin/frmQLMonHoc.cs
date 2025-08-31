using QLShop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinhVien.frmAdmin
{
    public partial class frmQLMonHoc : Form
    {
        DBConnect conn = new DBConnect();

        public frmQLMonHoc()
        {
            InitializeComponent();
            dgvMonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonHoc.AllowUserToAddRows = false;
            dgvMonHoc.ReadOnly = true;
            dgvMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Câu lệnh SQL để lấy danh sách môn học từ cơ sở dữ liệu
                string query = "SELECT MaMon, TenMon, SoTinChi FROM MonHoc";

                // Sử dụng phương thức ExecuteQuery của DBConnect để lấy dữ liệu
                DataTable dataTable = conn.ExecuteQuery(query);

                // Kiểm tra nếu dữ liệu không rỗng
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    dgvMonHoc.DataSource = dataTable;
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
            //if (txtTimKiem.Text != "Tìm kiếm theo mã hoặc tên")
            //{
            //    // Thực hiện chức năng tìm kiếm
            //}
            string filterText = txtTimKiem.Text;
            if (!string.IsNullOrEmpty(filterText) && filterText != "Tìm kiếm theo mã hoặc tên")
            {
                string filterExpression = "";

                // Kiểm tra xem có phải là số (để tìm kiếm theo MaMon)
                if (int.TryParse(filterText, out int maMon))
                {
                    filterExpression = $"MaMon = {maMon}";
                }
                else
                {
                    // Nếu không phải số thì tìm kiếm theo TenMon
                    filterExpression = $"TenMon LIKE '%{filterText}%'";
                }

                (dgvMonHoc.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
            }
            else
            {
                (dgvMonHoc.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvMonHoc.Rows[e.RowIndex];
                txtMaMH.Text = selectedRow.Cells["MaMon"].Value.ToString();
                txtTenMH.Text = selectedRow.Cells["TenMon"].Value.ToString();
                SoTinChi.Text = selectedRow.Cells["SoTinChi"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenMH.Text) || string.IsNullOrEmpty(SoTinChi.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            try
            {
                string query = "INSERT INTO MonHoc (TenMon, SoTinChi) VALUES (@TenMon, @SoTinChi)";
                var parameters = new Dictionary<string, object>
                {
                    { "@TenMon", txtTenMH.Text },
                    { "@SoTinChi", int.Parse(SoTinChi.Text) }
                };
                conn.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Thêm môn học thành công!");

                txtMaMH.Clear();
                txtTenMH.Clear();
                SoTinChi.Value = 0;

                LoadData(); // Tải lại dữ liệu sau khi thêm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm môn học: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvMonHoc.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgvMonHoc.SelectedRows)
                        {
                            string maMon = row.Cells["MaMon"].Value.ToString();
                            string query = "DELETE FROM MonHoc WHERE MaMon = @MaMon";
                            var parameters = new Dictionary<string, object>
                            {
                                { "@MaMon", maMon }
                            };
                            conn.ExecuteNonQuery(query, parameters);
                        }
                        MessageBox.Show("Xóa môn học thành công!");

                        txtMaMH.Clear();
                        txtTenMH.Clear();
                        SoTinChi.Value = 0;

                        LoadData(); // Tải lại dữ liệu sau khi xóa
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa môn học: " + ex.Message);
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
            if (dgvMonHoc.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgvMonHoc.SelectedRows[0];
                    string maMon = selectedRow.Cells["MaMon"].Value.ToString();

                    string query = "UPDATE MonHoc SET TenMon = @TenMon, SoTinChi = @SoTinChi WHERE MaMon = @MaMon";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@TenMon", txtTenMH.Text },
                        { "@SoTinChi", int.Parse(SoTinChi.Text) },
                        { "@MaMon", maMon }
                    };
                    conn.ExecuteNonQuery(query, parameters);
                    MessageBox.Show("Sửa môn học thành công!");

                    txtMaMH.Clear();
                    txtTenMH.Clear();
                    SoTinChi.Value = 0;

                    LoadData(); // Tải lại dữ liệu sau khi sửa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa môn học: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng để sửa!");
            }
        }
    }
}
