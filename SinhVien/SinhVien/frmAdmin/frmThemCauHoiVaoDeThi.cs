using QLShop;
using QLShop.TienIch;
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
    public partial class frmThemCauHoiVaoDeThi : Form
    {
        DBConnect conn = new DBConnect();
        int maDeThi;

        public frmThemCauHoiVaoDeThi()
        {
            InitializeComponent();
            LoadDanhSachCauHoi();
            LoadCapDo();
            LoadMonHoc();
            load_dgv_ChiTietDeThi_TheoMaDeThi();
            radioA.Checked = false;
            radioB.Checked = false;
            radioC.Checked = false;
            radioD.Checked = false;
            dgvCauHoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCauHoi.AllowUserToAddRows = false;
            dgvCauHoi.ReadOnly = true;
            dgvCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDeThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeThi.AllowUserToAddRows = false;
            dgvDeThi.ReadOnly = true;
            dgvDeThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public frmThemCauHoiVaoDeThi(int maDeThi)
        {
            InitializeComponent();
            LoadDanhSachCauHoi();
            LoadCapDo();
            LoadMonHoc();
            radioA.Checked = false;
            radioB.Checked = false;
            radioC.Checked = false;
            radioD.Checked = false;
            dgvCauHoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCauHoi.AllowUserToAddRows = false;
            dgvCauHoi.ReadOnly = true;
            dgvCauHoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDeThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeThi.AllowUserToAddRows = false;
            dgvDeThi.ReadOnly = true;
            dgvDeThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.maDeThi = maDeThi;
            load_dgv_ChiTietDeThi_TheoMaDeThi();
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

        //---------------- Load dữ liệu ---------------------
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
            cboMaMonHoc.DisplayMember = "TenMon";
            cboMaMonHoc.ValueMember = "MaMon";
            cboMaMonHoc.SelectedIndex = -1;

            cboMaMonHoc.Format += (s, e) =>
            {
                if (e.DesiredType == typeof(string) && e.ListItem is DataRowView row)
                {
                    e.Value = row["TenMon"] + $" ({row["MaMon"]})";
                }
            };
        }
        private void LoadDanhSachCauHoi()
        {
            string query = "SELECT * FROM CauHoi";
            DataTable dt = conn.ExecuteQuery(query);
            dgvCauHoi.DataSource = dt;
            //dataGridView1.Columns["NoiDung"].Width = 400;
        }
        void load_dgv_ChiTietDeThi_TheoMaDeThi()
        {
            string query = "SP_Select_ChiTietDeThi";
            var parameters = new Dictionary<string, object>
            {
                { "@MaDT", this.maDeThi }
            };
            var dt = conn.ExecuteStoredProcedure(query, parameters);

            dgvDeThi.DataSource = dt;

            // Thực hiện load dữ liệu lên textBox
            if (dt.Rows.Count > 0)
            {
                dgvDeThi.CurrentCell = dgvDeThi.Rows[0].Cells[0]; // Chọn dòng đầu tiên
                                                                            // Tạo sự kiện CellClick
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0); // Cột 0, dòng 0
                dgvDeThi_CellClick(dgvDeThi, args);
            }
            
        }

        //------------------ Form -----------------------
        private void dgvCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCauHoi.Rows[e.RowIndex];
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
                cboMaMonHoc.SelectedValue = row["MaMon"].ToString();
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

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "Tìm kiếm theo mã câu hỏi hoặc nội dung")
            {
                txtTimKiem.Text = "";
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

        private void dgvDeThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int index = e.RowIndex;
                    int maCauHoi = Convert.ToInt32(dgvDeThi.Rows[index].Cells["MaCH"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowMessageError(ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtMaCauHoi.Text))
                {
                    int maCauHoi = Convert.ToInt32(txtMaCauHoi.Text);
                    string ghiChu = "";
                    string query = "SP_Insert_ChiTietDeThi";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@MaDT", this.maDeThi },
                        { "@MaCH", maCauHoi },
                        { "@GhiChu", ghiChu }
                    };
                    conn.ExecuteStoredProcedure(query, parameters);

                    MessageBoxHelper.ShowMessage($"Đã thêm mã câu hỏi '{maCauHoi}' vào đề thi thành công!");
                    load_dgv_ChiTietDeThi_TheoMaDeThi();
                    ClearControls();

                }
                else
                    throw new Exception("Bạn chưa chọn dữ liệu cần thêm");
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowMessageError(ex.Message);
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
                    dgvCauHoi.DataSource = dt;
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
    }
}
