using QLShop;
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

namespace SinhVien.frmAdmin
{
    public partial class frmQLKetQua : Form
    {
        DBConnect conn = new DBConnect();

        public frmQLKetQua()
        {
            InitializeComponent();
            dgvKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.ReadOnly = true;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "Tìm kiếm theo mã sinh viên")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = SystemColors.MenuHighlight;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
            {
                txtTimKiem.Text = "Tìm kiếm theo mã sinh viên";
                txtTimKiem.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(filterText) && filterText != "Tìm kiếm theo mã sinh viên")
            {
                int filterValue;
                if (int.TryParse(filterText, out filterValue)) // Kiểm tra nếu filterText là số
                {
                    string filterExpression = $"MaSV = {filterValue}";
                    (dgvKetQua.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
                }
                else
                {
                    (dgvKetQua.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                }
            }
            else
            {
                (dgvKetQua.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

        private void frmQLKetQua_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxes();
            txtDiem.ReadOnly = true;
        }

        private void LoadComboBoxes()
        {
            try
            {
                // Load Sinh Viên
                string querySV = "SELECT MaSV FROM SinhVien";
                DataTable dtSV = conn.ExecuteQuery(querySV);
                cboMaSV.DataSource = dtSV;
                cboMaSV.ValueMember = "MaSV";

                // Load Đề Thi
                string queryDT = "SELECT MaDT FROM DeThi";
                DataTable dtDT = conn.ExecuteQuery(queryDT);
                cboMaDeThi.DataSource = dtDT;
                cboMaDeThi.ValueMember = "MaDT";

                // Load Kỳ Thi
                string queryKT = "SELECT MaKyThi FROM KyThi";
                DataTable dtKT = conn.ExecuteQuery(queryKT);
                cboMaKyThi.DataSource = dtKT;
                cboMaKyThi.ValueMember = "MaKyThi";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu combobox: " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                string query = @"SELECT k.MaSV, k.MaDT, k.MaKyThi, k.SoCauDung, k.SoCauSai, 
                               k.Diem, k.NgayHoanThanh 
                               FROM KetQua k 
                               JOIN SinhVien sv ON k.MaSV = sv.MaSV 
                               JOIN DeThi dt ON k.MaDT = dt.MaDT 
                               JOIN KyThi kt ON k.MaKyThi = kt.MaKyThi";

                DataTable dataTable = conn.ExecuteQuery(query);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    dgvKetQua.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu kết quả.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (cboMaSV.SelectedValue == null || cboMaDeThi.SelectedValue == null ||
                cboMaKyThi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin mã sinh viên, đề thi, kỳ thi!");
                return;
            }

            try
            {
                int maSV = Convert.ToInt16(cboMaSV.SelectedValue);
                int maDT = Convert.ToInt16(cboMaDeThi.SelectedValue);
                int maKyThi = Convert.ToInt16(cboMaKyThi.SelectedValue);
                int soCauDung = string.IsNullOrEmpty(SoCauDung.Text) ? 0 : int.Parse(SoCauDung.Text);
                int soCauSai = string.IsNullOrEmpty(SoCauSai.Text) ? 0 : int.Parse(SoCauSai.Text);
                decimal diem = decimal.Parse(txtDiem.Text);
                string query;

                if(soCauDung == 0 && soCauSai == 0)
                    query = @"EXEC sp_ThemKetQua @MaSV, @MaDT, @MaKyThi, @SoCauDung, @SoCauSai, null, @NgayHoanThanh";
                else
                    query = @"EXEC sp_ThemKetQua @MaSV, @MaDT, @MaKyThi, @SoCauDung, @SoCauSai, @Diem, @NgayHoanThanh";

                var parameters = new Dictionary<string, object>
                {
                    { "@MaSV", maSV },
                    { "@MaDT", maDT },
                    { "@MaKyThi", maKyThi },
                    { "@SoCauDung", soCauDung },
                    { "@SoCauSai", soCauSai },
                    { "@Diem", diem },
                    { "@NgayHoanThanh", dtpNgayHoanThanh.Value }
                };


                conn.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Thêm kết quả thành công!");

                ClearFields();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm kết quả: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            cboMaSV.SelectedIndex = -1;
            cboMaDeThi.SelectedIndex = -1;
            cboMaKyThi.SelectedIndex = -1;
            SoCauDung.Text = string.Empty;
            SoCauSai.Text = string.Empty;
            txtDiem.Clear();
            dtpNgayHoanThanh.Value = DateTime.Now;
        }

        private void dgvKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = dgvKetQua.Rows[e.RowIndex];
            //    cboMaSV.SelectedValue = row.Cells["MaSV"].Value;
            //    cboMaDeThi.SelectedValue = row.Cells["MaDT"].Value;
            //    cboMaKyThi.SelectedValue = row.Cells["MaKyThi"].Value;
            //    SoCauDung.Text = row.Cells["SoCauDung"].Value.ToString();
            //    SoCauSai.Text = row.Cells["SoCauSai"].Value.ToString();
            //    txtDiem.Text = row.Cells["Diem"].Value.ToString();
            //    dtpNgayHoanThanh.Value = Convert.ToDateTime(row.Cells["NgayHoanThanh"].Value);
            //}
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKetQua.Rows[e.RowIndex];
                cboMaSV.SelectedValue = row.Cells["MaSV"].Value;
                cboMaDeThi.SelectedValue = row.Cells["MaDT"].Value;
                cboMaKyThi.SelectedValue = row.Cells["MaKyThi"].Value;

                // Xử lý SoCauDung và SoCauSai có thể null, mặc định = 0
                SoCauDung.Text = row.Cells["SoCauDung"].Value != DBNull.Value ? row.Cells["SoCauDung"].Value.ToString() : "0";
                SoCauSai.Text = row.Cells["SoCauSai"].Value != DBNull.Value ? row.Cells["SoCauSai"].Value.ToString() : "0";

                // Xử lý điểm, mặc định = 0
                txtDiem.Text = row.Cells["Diem"].Value != DBNull.Value ? row.Cells["Diem"].Value.ToString() : "0";

                dtpNgayHoanThanh.Value = row.Cells["NgayHoanThanh"].Value != DBNull.Value
                    ? Convert.ToDateTime(row.Cells["NgayHoanThanh"].Value)
                    : DateTime.Now; // Gán giá trị mặc định nếu null
            }



        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKetQua.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?",
                    "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DataGridViewRow row = dgvKetQua.SelectedRows[0];
                        string query = "EXEC sp_XoaKetQua @MaSV, @MaDT";
                        var parameters = new Dictionary<string, object>
                        {
                            { "@MaSV", row.Cells["MaSV"].Value },
                            { "@MaDT", row.Cells["MaDT"].Value }
                        };

                        conn.ExecuteNonQuery(query, parameters);
                        MessageBox.Show("Xóa kết quả thành công!");

                        ClearFields();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa kết quả: " + ex.Message);
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
            if (dgvKetQua.SelectedRows.Count > 0)
            {
                try
                {
                    int maSV = Convert.ToInt16(cboMaSV.SelectedValue);
                    int maDT = Convert.ToInt16(cboMaDeThi.SelectedValue);
                    int maKyThi = Convert.ToInt16(cboMaKyThi.SelectedValue);
                    int soCauDung = string.IsNullOrEmpty(SoCauDung.Text) ? 0 : int.Parse(SoCauDung.Text);
                    int soCauSai = string.IsNullOrEmpty(SoCauSai.Text) ? 0 : int.Parse(SoCauSai.Text);
                    decimal diem = decimal.Parse(txtDiem.Text);
                    string query;

                    if (soCauDung == 0 && soCauSai == 0)
                        query = @"EXEC sp_SuaKetQua @MaSV, @MaDT, @MaKyThi, @SoCauDung, @SoCauSai, null, @NgayHoanThanh";
                    else
                        query = @"EXEC sp_SuaKetQua @MaSV, @MaDT, @MaKyThi, @SoCauDung, @SoCauSai, @Diem, @NgayHoanThanh";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@MaSV", maSV },
                        { "@MaDT", maDT },
                        { "@MaKyThi", maKyThi },
                        { "@SoCauDung", soCauDung },
                        { "@SoCauSai", soCauSai },
                        { "@Diem", diem },
                        { "@NgayHoanThanh", dtpNgayHoanThanh.Value }
                    };

                    conn.ExecuteNonQuery(query, parameters);
                    MessageBox.Show("Sửa kết quả thành công!");

                    ClearFields();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa kết quả: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng để sửa!");
            }
        }

        private void TinhDiem()
        {
            if (int.TryParse(SoCauDung.Text, out int soCauDung) && int.TryParse(SoCauSai.Text, out int soCauSai))
            {
                int tongSoCau = soCauDung + soCauSai;

                if (tongSoCau > 0)
                {
                    decimal diem = (decimal)(soCauDung * 10) / tongSoCau;
                    txtDiem.Text = diem.ToString("0.00");
                }
                else
                {
                    txtDiem.Text = "0";
                }
            }
            else
            {
                txtDiem.Text = "0";
            }
        }

        private void SoCauDung_ValueChanged(object sender, EventArgs e)
        {
            TinhDiem();
        }

        private void SoCauSai_ValueChanged(object sender, EventArgs e)
        {
            TinhDiem();
        }
    }
}
