using QLShop;
using QLShop.TienIch;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinhVien
{
    public partial class FrmThiTracNghiem : Form
    {
        DBConnect conn = new DBConnect();
        int maSV = Convert.ToInt16(LuuTenDangNhap.tenDangNhap); // Lấy mã sinh viên
        int cauHoi = 1; // lấy số thứ tự câu hỏi
        int maDeThi; // lấy mã đề thi
        int soLuongCau; // Lấy số lượng câu hỏi

        public FrmThiTracNghiem()
        {
            InitializeComponent();
            btnCauTruoc.Enabled = false;
            btnCauSau.Enabled = false;
            btnNopBai.Enabled = false;
            radioA.Visible = false;
            radioB.Visible = false;
            radioC.Visible = false;
            radioD.Visible = false;
            labelCauHoi.Visible = false;
        }
        //----------------- load dữ liệu ---------------------
        void Load_cbo_Dethi()
        {
            string query = $"select * from KetQua where MaSV = {this.maSV} and Diem is null";
            var dt = conn.ExecuteQuery(query, null);

            cboDeThi.DataSource = dt;
            cboDeThi.DisplayMember = "MaDT";
            cboDeThi.ValueMember = "MaDT";
        }
        void ClearCheckedRadio()
        {
            radioA.Checked = false;
            radioB.Checked = false;
            radioC.Checked = false;
            radioD.Checked = false;
        }
        void Load_label_textBox_CauHoiVaDapAn(int maDT, int maCH, int cauHoi)
        {
            // Load dữ liệu câu hỏi và đáp án
            string query = $"select ch.NoiDung AS NoiDungCauHoi, da.NoiDung AS NoiDungDapAn " +
                           $"from CauHoi ch, DapAn da, ChiTietDeThi ctdt " +
                           $"where ch.MaCH = da.MaCH and ctdt.MaCH = ch.MaCH " +
                           $"AND ctdt.MaDT = {maDT} and ctdt.MaCH = {maCH}";
            var dt = conn.ExecuteQuery( query, null );

            if(dt.Rows.Count > 0)
            {
                string NoiDungCauHoi = dt.Rows[0]["NoiDungCauHoi"].ToString();
                string dapAnA = dt.Rows[0]["NoiDungDapAn"].ToString();
                string dapAnB = dt.Rows[1]["NoiDungDapAn"].ToString();
                string dapAnC = dt.Rows[2]["NoiDungDapAn"].ToString();
                string dapAnD = dt.Rows[3]["NoiDungDapAn"].ToString();

                labelCauHoi.Text = $"Câu hỏi {cauHoi}: {NoiDungCauHoi}";
                radioA.Text = $"A. {dapAnA}";
                radioB.Text = $"B. {dapAnB}";
                radioC.Text = $"C. {dapAnC}";
                radioD.Text = $"D. {dapAnD}";
            }

            // Chọn đáp án
            query = $"select * from ThiTracNghiem where CauHoi = {cauHoi} and MaSV = {this.maSV} and MaDT = {maDT}";
            dt.Clear();
            dt = conn.ExecuteQuery(query, null);
            if(dt.Rows.Count > 0)
            {
                string dapAn = dt.Rows[0]["DapAn"].ToString();
                if (string.Compare(dapAn, "A", true) == 0)
                    radioA.Checked = true;
                else if (string.Compare(dapAn, "B", true) == 0)
                    radioB.Checked = true;
                else if (string.Compare(dapAn, "C", true) == 0)
                    radioC.Checked = true;
                else if (string.Compare(dapAn, "D", true) == 0)
                    radioD.Checked = true;
                else
                    ClearCheckedRadio();
            }

        }
        int LayMaCauHoi()
        {
            string query = $"select * from ChiTietDeThi where MaDT = {this.maDeThi}";
            var dt = conn.ExecuteQuery(query, null);
            int maCH = Convert.ToInt16(dt.Rows[this.cauHoi - 1]["MaCH"]);
            return maCH;
        }
        int LaySoCauDung()
        {
            string query = $"SP_Select_ThiTracNghiem_CauDung";
            var parameters = new Dictionary<string, object>
            {
                { "@MaSV", this.maSV },
                { "@MaDT", this.maDeThi }
            };

            var dt = conn.ExecuteStoredProcedure(query, parameters);
            int soCauDung = Convert.ToInt16(dt.Rows[0][0]);
            return soCauDung;
        }
        void StartCountdown()
        {
            string query = $"select ThoiGianLam from DeThi where MaDT = {this.maDeThi}";
            var dt = conn.ExecuteQuery(query);
            int countdown = Convert.ToInt16(dt.Rows[0]["ThoiGianLam"]);
            timerTestTime.Tag = countdown * 60; // Gán 50 phút vào Tag dưới dạng giây
            timerTestTime.Interval = 1000; // Thiết lập thời gian Tick là 1 giây
        }

        //--------------------- Form -----------------------
        private void FrmThiTracNghiem_Load(object sender, EventArgs e)
        {
            Load_cbo_Dethi();
        }

        private void btnBatDauLamBai_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cboDeThi.Text))
                    throw new Exception("Xin vui lòng chọn đề thi để thi trắc nghiệm");
                string query = null;
                this.maDeThi = Convert.ToInt16(cboDeThi.SelectedValue);

                // Lấy số lượng câu hỏi trong đề thi
                query = $"select * from ChiTietDeThi where MaDT = {this.maDeThi}";
                var dt = conn.ExecuteQuery(query, null);
                this.soLuongCau = dt.Rows.Count;
                int n = this.soLuongCau;

                // Thêm dữ liệu vào bảng ThiTracNghiem
                for (int i = 1; i<=n; i++)
                {
                    query = $"INSERT INTO ThiTracNghiem (MaSV, MaDT, CauHoi) VALUES({this.maSV},{this.maDeThi},{i})";
                    conn.ExecuteQuery(query, null);
                }

                // Load dữ liệu textBox và radio với câu hỏi đầu tiên
                int maCH = LayMaCauHoi();
                Load_label_textBox_CauHoiVaDapAn(this.maDeThi, maCH, 1);

                // Hiện và ẩn các nút liên quan
                btnBatDauLamBai.Enabled = false;
                btnCauSau.Enabled = true;
                btnNopBai.Enabled = true;
                radioA.Visible = true;
                radioB.Visible = true;
                radioC.Visible = true;
                radioD.Visible = true;
                labelCauHoi.Visible = true;
                cboDeThi.Enabled = false;

                // Bắt đầu thời gian làm
                StartCountdown();
                timerTestTime.Start();

            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowMessageError(ex.Message);
            }
            
        }

        private void btnCauTruoc_Click(object sender, EventArgs e)
        {
            try
            {
                // false tất cả radio lại
                ClearCheckedRadio();

                this.cauHoi -= 1;
                btnCauSau.Enabled = true;
                if (this.cauHoi == 1)
                {
                    btnCauTruoc.Enabled = false;
                }

                // Thực hiện chức năng chuyển câu hỏi
                int maCH = LayMaCauHoi();
                Load_label_textBox_CauHoiVaDapAn(this.maDeThi, maCH, this.cauHoi);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowMessageError(ex.Message);
            }
        }

        private void btnCauSau_Click(object sender, EventArgs e)
        {
            try
            {
                // false tất cả radio lại
                ClearCheckedRadio();

                this.cauHoi += 1;
                btnCauTruoc.Enabled = true;
                if (this.cauHoi == this.soLuongCau)
                {
                    btnCauSau.Enabled = false;
                }

                // Thực hiện chức năng chuyển câu hỏi
                int maCH = LayMaCauHoi();
                Load_label_textBox_CauHoiVaDapAn(this.maDeThi, maCH, this.cauHoi);
            }
            catch(Exception ex)
            {
                MessageBoxHelper.ShowMessageError(ex.Message);
            }
        }

        private void radioA_CheckedChanged(object sender, EventArgs e)
        {
            if(radioA.Checked)
            {
                string query = $"SP_Update_ThiTracNghiem_DapAnVaDungSai";
                int maCH = LayMaCauHoi();
                string dapAn = "A";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaSV", this.maSV },
                    { "@MaDT", this.maDeThi },
                    { "@MaCH", maCH },
                    { "@CauHoi", this.cauHoi },
                    { "@DapAn", dapAn },
                };
                conn.ExecuteStoredProcedure(query, parameters);
            }
        }

        private void radioB_CheckedChanged(object sender, EventArgs e)
        {
            if(radioB.Checked)
            {
                string query = $"SP_Update_ThiTracNghiem_DapAnVaDungSai";
                int maCH = LayMaCauHoi();
                string dapAn = "B";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaSV", this.maSV },
                    { "@MaDT", this.maDeThi },
                    { "@MaCH", maCH },
                    { "@CauHoi", this.cauHoi },
                    { "@DapAn", dapAn },
                };
                conn.ExecuteStoredProcedure(query, parameters);
            }
        }

        private void radioC_CheckedChanged(object sender, EventArgs e)
        {
            if (radioC.Checked)
            {
                string query = $"SP_Update_ThiTracNghiem_DapAnVaDungSai";
                int maCH = LayMaCauHoi();
                string dapAn = "C";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaSV", this.maSV },
                    { "@MaDT", this.maDeThi },
                    { "@MaCH", maCH },
                    { "@CauHoi", this.cauHoi },
                    { "@DapAn", dapAn },
                };
                conn.ExecuteStoredProcedure(query, parameters);
            }
        }

        private void radioD_CheckedChanged(object sender, EventArgs e)
        {
            if (radioD.Checked)
            {
                string query = $"SP_Update_ThiTracNghiem_DapAnVaDungSai";
                int maCH = LayMaCauHoi();
                string dapAn = "D";
                var parameters = new Dictionary<string, object>
                {
                    { "@MaSV", this.maSV },
                    { "@MaDT", this.maDeThi },
                    { "@MaCH", maCH },
                    { "@CauHoi", this.cauHoi },
                    { "@DapAn", dapAn },
                };
                conn.ExecuteStoredProcedure(query, parameters);
            }
        }

        private void btnNopBai_Click(object sender, EventArgs e)
        {
            // Dừng timer lại
            timerTestTime.Stop();

            // Cập nhật kết quả bài thi
            int soCauDung = LaySoCauDung();
            int soCauSai = this.soLuongCau - soCauDung;
            int tongSoCau = this.soLuongCau;
            decimal diem = (decimal)soCauDung*10 / tongSoCau;

            string query = "SP_Update_KetQuaThiCuaSinhVien";
            var parameters = new Dictionary<string, object>
            {
                { "@MaSV", this.maSV },
                { "@MaDT", this.maDeThi },
                { "@SoCauDung", soCauDung },
                { "@SoCauSai", soCauSai },
                { "@Diem", diem },
            };
            conn.ExecuteStoredProcedure(query, parameters);

            // Xoá dữ liệu ThiTracNghiem sau khi cập nhật kết quả
            query = $"delete from ThiTracNghiem where MaSV = {this.maSV} and MaDT = {this.maDeThi}";
            conn.ExecuteQuery(query, null);

            // Xuất thông tin kết quả bằng MessageBox
            string thongTinKetQua = $"Số câu đúng: {soCauDung}\n" +
                                    $"Số câu sai: {soCauSai}\n" +
                                    $"Tổng điểm thi: {diem}";
            MessageBoxHelper.ShowMessage(thongTinKetQua);

            // Thoát chương trình
            btnNopBai.Enabled = false;
            this.Close();
        }

        

        private void timerTestTime_Tick(object sender, EventArgs e)
        {
            // Lấy thời gian còn lại từ Tag
            int remainingTime = (int)timerTestTime.Tag;

            if (remainingTime > 0)
            {
                remainingTime--; // Giảm 1 giây
                timerTestTime.Tag = remainingTime; // Cập nhật lại thời gian trong Tag

                // Chuyển đổi thời gian còn lại sang định dạng MM:SS
                int minutes = remainingTime / 60;
                int seconds = remainingTime % 60;
                labelTimer.Text = $"Thời gian còn lại: {minutes:D2}:{seconds:D2}";
            }
            else
            {
                btnNopBai.PerformClick();
            }
        }

        private void FrmThiTracNghiem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnNopBai.Enabled == true)
                btnNopBai.PerformClick();
            this.Dispose();
        }
    }
}
