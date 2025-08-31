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
using System.Windows.Forms.DataVisualization.Charting;

namespace SinhVien.frmAdmin
{
    public partial class frmTrangChu : Form
    {
        DBConnect conn = new DBConnect();

        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            LoadCounts();
            Load5HDGN();
            DisplayChart();
            //XinChaoUserName();
        }

        private void LoadCounts()
        {
            try
            {
                // Tính tổng số đề thi
                string queryDeThi = "SELECT COUNT(*) FROM DeThi";
                int totalDeThi = (int)conn.ExecuteScalar(queryDeThi);
                lblTongDeThi.Text = totalDeThi.ToString();

                // Tính tổng số học sinh
                string queryHocSinh = "SELECT COUNT(*) FROM SinhVien";
                int totalHocSinh = (int)conn.ExecuteScalar(queryHocSinh);
                lblTongHocSinh.Text = totalHocSinh.ToString();

                // Tính tổng số câu hỏi
                string queryCauHoi = "SELECT COUNT(*) FROM CauHoi";
                int totalCauHoi = (int)conn.ExecuteScalar(queryCauHoi);
                lblTongCauHoi.Text = totalCauHoi.ToString();

                // Tính tổng số kỳ thi
                string queryKyThi = "SELECT COUNT(*) FROM KyThi";
                int totalKyThi = (int)conn.ExecuteScalar(queryKyThi);
                lblTongKyThi.Text = totalKyThi.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu tổng quan: " + ex.Message);
            }
        }
        private void Load5HDGN()
        {
            try
            {
                // Câu lệnh SQL để lấy 5 kỳ thi gần nhất
                string query = @"
        SELECT sv.TenSV, dt.MaDT, kq.Diem, kq.NgayHoanThanh
        FROM KetQua kq
        JOIN SinhVien sv ON kq.MaSV = sv.MaSV
        JOIN DeThi dt ON kq.MaDT = dt.MaDT
        ORDER BY kq.NgayHoanThanh DESC
        OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";

                DataTable dataTable = conn.ExecuteQuery(query);

                // Xóa dữ liệu cũ trong ListBox
                lstHDGD.Items.Clear();

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string item = $" {row["TenSV"]}, Đề: {row["MaDT"]}, Điểm: {row["Diem"]}, Ngày hoàn thành: {((DateTime)row["NgayHoanThanh"]).ToString("yyyy-MM-dd")}";
                        lstHDGD.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("Không có hoạt động nào gần đây.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hoạt động: " + ex.Message);
            }
        }


        private void DisplayChart()
        {
            try
            {
                // Lấy dữ liệu điểm từ CSDL
                string query = @"
            WITH ScoreStats AS (
                SELECT 
                    kt.MaKyThi,
                    COUNT(CASE WHEN kq.Diem > 5 THEN 1 END) as TrenNam,
                    COUNT(CASE WHEN kq.Diem <= 5 THEN 1 END) as DuoiNam
                FROM KetQua kq
                JOIN KyThi kt ON kq.MaKyThi = kt.MaKyThi
                GROUP BY kt.MaKyThi
            )
            SELECT * FROM ScoreStats
            ORDER BY MaKyThi";

                DataTable dt = conn.ExecuteQuery(query);

                // Xóa dữ liệu cũ trong chart
                chartThongKe.Series.Clear();
                chartThongKe.ChartAreas.Clear();

                // Tạo ChartArea mới
                ChartArea chartArea = new ChartArea();
                chartThongKe.ChartAreas.Add(chartArea);

                // Tạo hai Series cho điểm trên 5 và dưới 5
                Series seriesTren5 = new Series("Trên 5");
                Series seriesDuoi5 = new Series("Dưới 5");

                // Thiết lập kiểu đồ thị
                seriesTren5.ChartType = SeriesChartType.Column;
                seriesDuoi5.ChartType = SeriesChartType.Column;

                // Màu sắc cho các cột
                seriesTren5.Color = Color.FromArgb(65, 140, 240); // Màu xanh
                seriesDuoi5.Color = Color.FromArgb(252, 180, 65); // Màu cam

                // Thêm dữ liệu vào series
                foreach (DataRow row in dt.Rows)
                {
                    seriesTren5.Points.AddY(row["TrenNam"]);
                    seriesDuoi5.Points.AddY(row["DuoiNam"]);
                }

                // Thêm series vào chart
                chartThongKe.Series.Add(seriesTren5);
                chartThongKe.Series.Add(seriesDuoi5);

                //// Cấu hình chart
                //chartThongKe.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                //chartThongKe.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                //chartThongKe.ChartAreas[0].AxisX.Interval = 1;
                //chartThongKe.ChartAreas[0].AxisY.Interval = 10;

                chartThongKe.ChartAreas[0].AxisX.Title = "Kỳ Thi";
                chartThongKe.ChartAreas[0].AxisY.Title = "Số Lượng";
                chartThongKe.ChartAreas[0].RecalculateAxesScale();



                // Tắt gạch lưới trên cả hai trục
                chartThongKe.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chartThongKe.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                chartThongKe.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                chartThongKe.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

                // Thiết lập tiêu đề
                chartThongKe.Titles.Clear();
                Title title = new Title("Thống Kê Điểm Số");
                title.Font = new Font("Arial", 12, FontStyle.Bold);
                chartThongKe.Titles.Add(title);

                // Legend
                chartThongKe.Legends[0].Docking = Docking.Right;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị biểu đồ: " + ex.Message);
            }
        }



        //private void XinChaoUserName(int userId)
        //{
        //    try
        //    {
        //        // Câu lệnh SQL để lấy họ tên người dùng từ cơ sở dữ liệu
        //        string query = "SELECT TenSV FROM TaiKhoan WHERE MaTK = @MaTK";

        //        // Sử dụng tham số để tránh SQL Injection
        //        SqlCommand cmd = new SqlCommand(query);
        //        cmd.Parameters.AddWithValue("@MaTK", userId);

        //        // Thực hiện truy vấn và lấy kết quả
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        if (reader.Read()) // Nếu có kết quả
        //        {
        //            // Lấy họ và tên người dùng
        //            string fullName = reader["TenSV"].ToString();

        //            // Hiển thị họ tên lên lblUserName
        //            lblUserName.Text = "Xin chào, " + fullName + "!";
        //        }
        //        else
        //        {
        //            // Nếu không tìm thấy người dùng, hiển thị thông báo
        //            lblUserName.Text = "Không tìm thấy người dùng!";
        //        }

        //        reader.Close(); // Đóng kết nối sau khi thực hiện xong
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi tải thông tin người dùng: " + ex.Message);
        //    }
        //}
    }
}