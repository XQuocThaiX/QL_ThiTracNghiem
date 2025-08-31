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
    public partial class frmQLCauHoiVaDapAn : Form
    {
        DBConnect conn = new DBConnect();

        public frmQLCauHoiVaDapAn()
        {
            InitializeComponent();
            LoadDanhSachCauHoi();
            EnableControls(true);
            LoadCapDo();
            LoadMonHoc();
            radioA.Checked = false;
            radioB.Checked = false;
            radioC.Checked = false;
            radioD.Checked = false;
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void EnableControls(bool enable)
        {
            //txtMaCauHoi.Enabled = enable;
            cboCapDo.Enabled = enable;
            cboMaMonHoc.Enabled = enable;
            txtNoiDung.Enabled = enable;
            txtA.Enabled = enable;
            txtB.Enabled = enable;
            txtC.Enabled = enable;
            txtD.Enabled = enable;

        }
        private void frmQLCauHoiVaDapAn_Load(object sender, EventArgs e)
        {

        }
        private void LoadCapDo()
        {
            string query = "SELECT * FROM CapDo";
            DataTable dt = conn.ExecuteQuery(query);
            cboCapDo.DataSource = dt;
            cboCapDo.DisplayMember = "TenCapDo";
            cboCapDo.ValueMember = "MaCapDo";
            cboCapDo.SelectedIndex = -1;
        }
        private void LoadMonHoc()
        {
            string query = "SELECT * FROM MonHoc"; // Lấy dữ liệu từ bảng MonHoc
            DataTable dt = conn.ExecuteQuery(query);
            cboMaMonHoc.DataSource = dt;
            cboMaMonHoc.DisplayMember = "MaMon";
            cboMaMonHoc.ValueMember = "MaMon";
            cboMaMonHoc.SelectedIndex = -1;

        }
        private void LoadDanhSachCauHoi()
        {
            string query = "SELECT * FROM CauHoi";
            DataTable dt = conn.ExecuteQuery(query);
            dataGridView1.DataSource = dt;
            //dataGridView1.Columns["NoiDung"].Width = 400;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int maCH = Convert.ToInt32(row.Cells["MaCH"].Value);
                LoadChiTietCauHoi(maCH);
            }
        }
        private void LoadChiTietCauHoi(int maCH)
        {
            string queryCauHoi = @"
                                SELECT MaCH, CapDo.TenCapDo, MonHoc.MaMon, CauHoi.NoiDung
                                FROM CauHoi
                                JOIN CapDo ON CauHoi.MaCapDo = CapDo.MaCapDo
                                JOIN MonHoc ON CauHoi.MaMon = MonHoc.MaMon
                                WHERE MaCH = @MaCH";

            var parametersCauHoi = new Dictionary<string, object>
            {
                { "@MaCH", maCH }
            };

            DataTable dtCauHoi = conn.ExecuteQuery(queryCauHoi, parametersCauHoi);
            if (dtCauHoi.Rows.Count > 0)
            {
                DataRow row = dtCauHoi.Rows[0];
                txtMaCauHoi.Text = row["MaCH"].ToString();
                cboCapDo.Text = row["TenCapDo"].ToString();
                cboMaMonHoc.Text = row["MaMon"].ToString();
                txtNoiDung.Text = row["NoiDung"].ToString();
            }

            string queryDapAn = "SELECT TenDA, NoiDung, DungSai FROM DapAn WHERE MaCH = @MaCH";
            DataTable dtDapAn = conn.ExecuteQuery(queryDapAn, parametersCauHoi);
            txtA.Clear();
            txtB.Clear();
            txtC.Clear();
            txtD.Clear();
            radioA.Checked = false;
            radioB.Checked = false;
            radioC.Checked = false;
            radioD.Checked = false;

            foreach (DataRow dapAnRow in dtDapAn.Rows)
            {
                string tenDA = dapAnRow["TenDA"].ToString();
                string noiDung = dapAnRow["NoiDung"].ToString();
                bool dungSai = Convert.ToBoolean(dapAnRow["DungSai"]);

                switch (tenDA)
                {
                    case "A":
                        txtA.Text = noiDung;
                        radioA.Checked = dungSai;
                        break;
                    case "B":
                        txtB.Text = noiDung;
                        radioB.Checked = dungSai;
                        break;
                    case "C":
                        txtC.Text = noiDung;
                        radioC.Checked = dungSai;
                        break;
                    case "D":
                        txtD.Text = noiDung;
                        radioD.Checked = dungSai;
                        break;
                }
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    string searchValue = txtTimKiem.Text.Trim();


            //    if (string.IsNullOrEmpty(searchValue) || searchValue == "Tìm kiếm theo mã hoặc tên câu hỏi")
            //    {
            //        LoadDanhSachCauHoi();
            //        return;
            //    }

            //    try
            //    {

            //        string query = @"
            //                        SELECT * 
            //                        FROM CauHoi
            //                        WHERE MaCH LIKE @Search OR NoiDung LIKE @Search";

            //        var parameters = new Dictionary<string, object>
            //        {
            //            { "@Search", $"%{searchValue}%" }
            //        };
            //        DataTable dt = conn.ExecuteQuery(query, parameters);
            //        dataGridView1.DataSource = dt;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //    e.SuppressKeyPress = true;
            //}
        }
        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tìm kiếm theo mã câu hỏi hoặc nội dung")
            {
                txtTimKiem.Text = string.Empty;
                txtTimKiem.ForeColor = SystemColors.MenuHighlight;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
            {
                txtTimKiem.Text = "Tìm kiếm theo mã câu hỏi hoặc nội dung";
                txtTimKiem.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTimKiem.Text.Trim()) && txtTimKiem.Text != "Tìm kiếm theo mã câu hỏi hoặc nội dung")
            {
                string searchValue = txtTimKiem.Text.Trim();

                try
                {
                    string query = @"
                                    SELECT * 
                                    FROM CauHoi
                                    WHERE MaCH LIKE @Search OR NoiDung LIKE @Search";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@Search", $"%{searchValue}%" }
                    };
                    DataTable dt = conn.ExecuteQuery(query, parameters);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                LoadDanhSachCauHoi();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                if (cboCapDo.SelectedIndex == -1 ||
                    cboMaMonHoc.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtNoiDung.Text) ||
                    string.IsNullOrWhiteSpace(txtA.Text) ||
                    string.IsNullOrWhiteSpace(txtB.Text) ||
                    string.IsNullOrWhiteSpace(txtC.Text) ||
                    string.IsNullOrWhiteSpace(txtD.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string queryInsertCauHoi = @"
            INSERT INTO CauHoi (MaCapDo, MaMon, NoiDung)
            VALUES (@MaCapDo, @MaMon, @NoiDung);
            SELECT SCOPE_IDENTITY();";

                var parametersCauHoi = new Dictionary<string, object>
                {
                    { "@MaCapDo", cboCapDo.SelectedValue },
                    { "@MaMon", cboMaMonHoc.SelectedValue },
                    { "@NoiDung", txtNoiDung.Text }
                };

                object result = conn.ExecuteScalar(queryInsertCauHoi, parametersCauHoi);
                int maCH = Convert.ToInt32(result);

                // Thêm đáp án
                AddDapAn(maCH, "A", txtA.Text, radioA.Checked);
                AddDapAn(maCH, "B", txtB.Text, radioB.Checked);
                AddDapAn(maCH, "C", txtC.Text, radioC.Checked);
                AddDapAn(maCH, "D", txtD.Text, radioD.Checked);

                LoadDanhSachCauHoi();
                ClearControls();

                MessageBox.Show("Thêm câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm câu hỏi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddDapAn(int maCH, string tenDA, string noiDung, bool dungSai)
        {
            string queryInsertDapAn = @"
                                        INSERT INTO DapAn (MaCH, TenDA, NoiDung, DungSai)
                                        VALUES (@MaCH, @TenDA, @NoiDung, @DungSai);";

            var parametersDapAn = new Dictionary<string, object>
            {
                { "@MaCH", maCH },
                { "@TenDA", tenDA },
                { "@NoiDung", noiDung },
                { "@DungSai", dungSai ? 1 : 0 }
            };

            conn.ExecuteNonQuery(queryInsertDapAn, parametersDapAn);
        }
        private void ClearControls()
        {
            txtMaCauHoi.Clear();
            cboCapDo.SelectedIndex = -1;
            cboMaMonHoc.SelectedIndex = -1;
            txtNoiDung.Clear();
            txtA.Clear();
            txtB.Clear();
            txtC.Clear();
            txtD.Clear();
            radioA.Checked = false;
            radioB.Checked = false;
            radioC.Checked = false;
            radioD.Checked = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một câu hỏi để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa các câu hỏi đã chọn không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult == DialogResult.No)
                {
                    return;
                }

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.Cells["MaCH"].Value != null)
                    {
                        int maCH = Convert.ToInt32(row.Cells["MaCH"].Value);

                        DeleteCauHoi(maCH);
                    }
                }

                LoadDanhSachCauHoi();

                MessageBox.Show("Xóa câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa câu hỏi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteCauHoi(int maCH)
        {
            try
            {

                string queryDeleteDapAn = "DELETE FROM DapAn WHERE MaCH = @MaCH";
                var parametersDapAn = new Dictionary<string, object>
                {
                    { "@MaCH", maCH }
                };
                conn.ExecuteNonQuery(queryDeleteDapAn, parametersDapAn);


                string queryDeleteCauHoi = "DELETE FROM CauHoi WHERE MaCH = @MaCH";
                var parametersCauHoi = new Dictionary<string, object>
                {
                    { "@MaCH", maCH }
                };
                conn.ExecuteNonQuery(queryDeleteCauHoi, parametersCauHoi);
            }
            catch (Exception ex)
            {
                throw new Exception($"Không thể xóa câu hỏi có MaCH = {maCH}: {ex.Message}");
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một câu hỏi để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maCH = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MaCH"].Value);

                if (cboCapDo.SelectedIndex == -1 ||
                    cboMaMonHoc.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtNoiDung.Text) ||
                    string.IsNullOrWhiteSpace(txtA.Text) ||
                    string.IsNullOrWhiteSpace(txtB.Text) ||
                    string.IsNullOrWhiteSpace(txtC.Text) ||
                    string.IsNullOrWhiteSpace(txtD.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string queryUpdateCauHoi = @"
                                            UPDATE CauHoi
                                            SET MaCapDo = @MaCapDo, MaMon = @MaMon, NoiDung = @NoiDung
                                            WHERE MaCH = @MaCH";

                var parametersCauHoi = new Dictionary<string, object>
                {
                    { "@MaCH", maCH },
                    { "@MaCapDo", cboCapDo.SelectedValue },
                    { "@MaMon", cboMaMonHoc.SelectedValue },
                    { "@NoiDung", txtNoiDung.Text }
                };

                conn.ExecuteNonQuery(queryUpdateCauHoi, parametersCauHoi);
                UpdateDapAn(maCH, "A", txtA.Text, radioA.Checked);
                UpdateDapAn(maCH, "B", txtB.Text, radioB.Checked);
                UpdateDapAn(maCH, "C", txtC.Text, radioC.Checked);
                UpdateDapAn(maCH, "D", txtD.Text, radioD.Checked);

                LoadDanhSachCauHoi();
                ClearControls();

                MessageBox.Show("Sửa câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa câu hỏi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDapAn(int maCH, string tenDA, string noiDung, bool dungSai)
        {
            string queryUpdateDapAn = @"
                                    UPDATE DapAn
                                    SET NoiDung = @NoiDung, DungSai = @DungSai
                                    WHERE MaCH = @MaCH AND TenDA = @TenDA";

            var parametersDapAn = new Dictionary<string, object>
            {
                { "@MaCH", maCH },
                { "@TenDA", tenDA },
                { "@NoiDung", noiDung },
                { "@DungSai", dungSai ? 1 : 0 }
            };

            conn.ExecuteNonQuery(queryUpdateDapAn, parametersDapAn);
        }
    }
}
