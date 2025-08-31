using QLShop;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SinhVien
{
    public partial class FrmXemKetQua : Form
    {

        private SqlConnection conn;
        public FrmXemKetQua()
        {
            InitializeComponent();
        }

        private void LoadComboBoxData()
        {
            try
            {
                // Kết nối cơ sở dữ liệu
                DBConnect.stringConnection = @"Data source = .; Initial Catalog = QL_THITRACNGHIEM; INTEGRATED SECURITY= TRUE; Connection Timeout=5";
                conn = new SqlConnection(DBConnect.stringConnection);  // Khởi tạo conn
                conn.Open();

                // Lấy danh sách Mã Đề Thi
                string queryMaDT = "SELECT MaDT FROM DeThi";
                SqlDataAdapter daMaDT = new SqlDataAdapter(queryMaDT, conn);
                DataTable dtMaDT = new DataTable();
                daMaDT.Fill(dtMaDT);
                comboBox2.DataSource = dtMaDT;
                comboBox2.DisplayMember = "MaDT";  // Hiển thị MaDT
                comboBox2.ValueMember = "MaDT";    // Giá trị của MaDT

                // Lấy danh sách Mã Kỳ Thi
                string queryMaKyThi = "SELECT MaKyThi FROM KyThi";
                SqlDataAdapter daMaKyThi = new SqlDataAdapter(queryMaKyThi, conn);
                DataTable dtMaKyThi = new DataTable();
                daMaKyThi.Fill(dtMaKyThi);
                comboBox3.DataSource = dtMaKyThi;
                comboBox3.DisplayMember = "MaKyThi";  // Hiển thị MaKyThi
                comboBox3.ValueMember = "MaKyThi";    // Giá trị của MaKyThi
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                conn?.Close();  // Đảm bảo đóng kết nối
            }
        }

        private void FrmXemKetQua_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void GetStudentResult(string maDT, string maKyThi)
        {
            try
            {
                // Kết nối cơ sở dữ liệu
                DBConnect.stringConnection = @"Data source = .; Initial Catalog = QL_THITRACNGHIEM; INTEGRATED SECURITY= TRUE; Connection Timeout=5";
                using (SqlConnection conn = new SqlConnection(DBConnect.stringConnection))
                {
                    conn.Open();

                    // Câu truy vấn SQL để lấy kết quả thi của sinh viên
                    string query = @"
                SELECT 
                    SinhVien.MaSV, 
                    SinhVien.TenSV, 
                    KetQua.SoCauDung, 
                    KetQua.SoCauSai, 
                    KetQua.Diem, 
                    KetQua.NgayHoanThanh
                FROM KetQua
                INNER JOIN SinhVien ON KetQua.MaSV = SinhVien.MaSV
                WHERE KetQua.MaDT = @MaDT 
                    AND KetQua.MaKyThi = @MaKyThi 
                    AND KetQua.MaSV = @MaSV";  // Lọc kết quả của sinh viên đăng nhập

                    // Tạo câu lệnh SQL
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDT", maDT);  // Thêm tham số MaDT vào câu lệnh
                    cmd.Parameters.AddWithValue("@MaKyThi", maKyThi);  // Thêm tham số MaKyThi vào câu lệnh
                    cmd.Parameters.AddWithValue("@MaSV", SinhVien.CurrentSinhVien.MaSV);  // Lọc theo sinh viên đang đăng nhập

                    // Thực hiện truy vấn và lưu kết quả vào DataTable
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Gán dữ liệu vào DataGridView
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có
                MessageBox.Show("Lỗi khi lấy kết quả: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy mã đề thi và mã kỳ thi từ ComboBox
            string maDT = comboBox2.SelectedValue.ToString();  // Lấy giá trị của MaDT
            string maKyThi = comboBox3.SelectedValue.ToString();  // Lấy giá trị của MaKyThi

            // Gọi hàm lấy kết quả thi của sinh viên
            GetStudentResult(maDT, maKyThi);
        }
    }
}
