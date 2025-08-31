using QLShop;
using QLShop.TienIch;
using Sunny.UI;
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
    public partial class frmQLDeThi : Form
    {
        DBConnect conn = new DBConnect();

        public frmQLDeThi()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //------------------ Load dữ liệu ---------------------
        void load_cbo_MaDeThi()
        {
            string query = "SP_Select_DeThi";
            var dt = conn.ExecuteStoredProcedure(query, null);

            cboMaDeThi.DataSource = dt;
            cboMaDeThi.DisplayMember = "MaDT";
            cboMaDeThi.ValueMember = "MaDT";

            cboMaDeThi.SelectedIndex = 0;
            cboMaDeThi_SelectionChangeCommitted(cboMaDeThi, EventArgs.Empty);
        }
        void load_dgv_ChiTietDeThi_TheoMaDeThi()
        {
            string query = "SP_Select_ChiTietDeThi";
            var parameters = new Dictionary<string, object>
            {
                { "@MaDT", cboMaDeThi.SelectedValue }
            };
            var dt = conn.ExecuteStoredProcedure(query, parameters);

            dataGridView1.DataSource = dt;

            // Thực hiện load dữ liệu lên textBox
            if(dt.Rows.Count > 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0]; // Chọn dòng đầu tiên
                                                                            // Tạo sự kiện CellClick
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0); // Cột 0, dòng 0
                dataGridView1_CellClick(dataGridView1, args);
            }
            else
            {
                txtGhiChu.Clear();
                txtNoiDung.Clear();
            }
        }
        void load_textBox_DeThi(int maDeThi)
        {
            string query = "SP_Select_DeThi_TheoMaDT";
            var parameters = new Dictionary<string, object>
            {
                { "@MaDT", maDeThi }
            };
            var dt = conn.ExecuteStoredProcedure(query, parameters);

            if(dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtMaDeThi.Text = row["MaDT"].ToString();
                numberSoLuongCauHoi.Value = Convert.ToInt32(row["SoLuongCau"].ToString());
                numberThoiGianLam.Value = Convert.ToInt32(row["ThoiGianLam"].ToString());
                dtpNgayTao.Value = Convert.ToDateTime(row["NgayTao"].ToString());
            }
        }
        void load_textBox_ChiTietDeThi_NoiDung(int maCauHoi)
        {
            string query = "SP_Select_CauHoi_TheoMaCauHoi";
            var parameters = new Dictionary<string, object>
            {
                { "@MaCauHoi", maCauHoi }
            };
            var dt = conn.ExecuteStoredProcedure(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtNoiDung.Text = row["NoiDung"].ToString();
            }
        }

        //------------------- Form --------------------------
        private void frmQLDeThi_Load(object sender, EventArgs e)
        {
            load_cbo_MaDeThi();
            load_dgv_ChiTietDeThi_TheoMaDeThi();
        }
        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim() == "Tìm kiếm theo mã câu hỏi hoặc tên ghi chú")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = SystemColors.MenuHighlight;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiem.Text.Trim()))
            {
                txtTimKiem.Text = "Tìm kiếm theo mã câu hỏi hoặc tên ghi chú";
                txtTimKiem.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "Tìm kiếm theo mã câu hỏi hoặc tên ghi chú")
            {
                // Thực hiện chức năng tìm kiếm
                int maDT = Convert.ToInt16(cboMaDeThi.SelectedValue);
                string timKiem = txtTimKiem.Text;

                string query = "SP_Select_ChiTietDeThi_TimKiem";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaDT", maDT },
                    { "@TimKiem", timKiem }
                };
                var dt = conn.ExecuteStoredProcedure(query, parameters);

                dataGridView1.DataSource = dt;
            }
        }

        private void cboMaDeThi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            load_dgv_ChiTietDeThi_TheoMaDeThi();
            load_textBox_DeThi(Convert.ToInt32(cboMaDeThi.SelectedValue));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex >= 0)
                {
                    int index = e.RowIndex;
                    int maCauHoi = Convert.ToInt32(dataGridView1.Rows[index].Cells["MaCH"].Value.ToString());
                    load_textBox_ChiTietDeThi_NoiDung(maCauHoi);
                    txtGhiChu.Text = dataGridView1.Rows[index].Cells["GhiChu"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowMessageError(ex.Message);
            }
        }

        private void btnThemDeThi_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SP_Insert_DeThi";
                var parameters = new Dictionary<string, object>
                {
                    { "@Ngaytao", dtpNgayTao.Value },
                    { "@SoLuongCauHoi", numberSoLuongCauHoi.Value },
                    { "@ThoiGianLam", numberThoiGianLam.Value }
                };
                conn.ExecuteStoredProcedure(query, parameters);
                load_dgv_ChiTietDeThi_TheoMaDeThi();
                load_cbo_MaDeThi();

                MessageBoxHelper.ShowMessage("Đã thêm thành công");
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowMessageError (ex.Message);
            }
        }

        private void btnXoaDeThi_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "Bạn có chắc chắn muốn xoá đề thi này không? (Điều này sẽ xoá tất cả câu hỏi liên quan được sắp xếp trong đề thi và xoá đi kết quả của sinh viên khi đã làm đề thi đó)";
                if (MessageBoxHelper.ShowMessageQuestion(message) == DialogResult.Yes)
                {
                    // Kiểm tra sự tồn tại của đề thi trong bảng KetQua
                    string query = "SP_Select_KetQua_TheoMaDT";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@MaDT", txtMaDeThi.Text }
                    };
                    var dt = conn.ExecuteStoredProcedure(query, parameters);
                    // Nếu trường hợp không có dữ liệu KetQua thì thực hiện xoá bình thường
                    if (dt.Rows.Count == 0)
                    {
                        query = "SP_Delete_DeThiVaChiTietDeThi";

                        MessageBox.Show($"Đã xoá mã đề thi '{txtMaDeThi.Text}' thành công");
                        conn.ExecuteStoredProcedure(query, parameters);
                        load_dgv_ChiTietDeThi_TheoMaDeThi();
                        load_cbo_MaDeThi();
                    }
                    else
                    {
                        throw new Exception("Không thể xoá đề thi được vì đề thi này đã được thực hiện bởi sinh viên và có kết quả");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowMessageError(ex.Message);
            }
        }

        private void btnSuaDeThi_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SP_Update_DeThi_TheoMaDT";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaDT", txtMaDeThi.Text },
                    { "@Ngaytao", dtpNgayTao.Value },
                    { "@SoLuongCauHoi", numberSoLuongCauHoi.Value },
                    { "@ThoiGianLam", numberThoiGianLam.Value }
                };
                conn.ExecuteStoredProcedure(query, parameters);
                load_dgv_ChiTietDeThi_TheoMaDeThi();
                load_cbo_MaDeThi();

                MessageBoxHelper.ShowMessage("Đã sửa thành công");
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowMessageError(ex.Message);
            }
        }

        private void btnThemCauHoi_Click(object sender, EventArgs e)
        {
            using (var form = new frmThemCauHoiVaoDeThi(Convert.ToInt32(cboMaDeThi.SelectedValue)))
            {
                form.ShowDialog();
            }
            load_dgv_ChiTietDeThi_TheoMaDeThi();
        }

        private void btnXoaCH_Click(object sender, EventArgs e)
        {
            try
            {
                string message = $"Bạn có chắc là muốn xoá các câu hỏi này không?";
                if (MessageBoxHelper.ShowMessageQuestion(message) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int maDT = Convert.ToInt16(cboMaDeThi.SelectedValue);
                        int maCH = Convert.ToInt16(row.Cells["MaCH"].Value);

                        string query = "SP_Delete_ChiTietDeThi";
                        var parameters = new Dictionary<string, object>
                        {
                            { "@MaDT", maDT },
                            { "@MaCH", maCH }
                        };
                        conn.ExecuteStoredProcedure(query, parameters);
                    }
                    load_dgv_ChiTietDeThi_TheoMaDeThi();
                    MessageBoxHelper.ShowMessage("Đã xoá dữ liệu thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowMessageError(ex.Message);
            }
        }

        private void btnSuaGhiChu_Click(object sender, EventArgs e)
        {
            try
            {
                string ghiChu = txtGhiChu.Text;

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int maDT = Convert.ToInt16(cboMaDeThi.SelectedValue);
                    int maCH = Convert.ToInt16(row.Cells["MaCH"].Value);

                    string query = "SP_Update_ChiTietDeThi_GhiChu";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@MaDT", maDT },
                        { "@MaCH", maCH },
                        { "@GhiChu", ghiChu }
                    };
                    conn.ExecuteStoredProcedure(query, parameters);
                }
                load_dgv_ChiTietDeThi_TheoMaDeThi();
                MessageBoxHelper.ShowMessage("Đã sửa dữ liệu thành công");
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowMessageError(ex.Message);
            }
        }

        
    }
}
