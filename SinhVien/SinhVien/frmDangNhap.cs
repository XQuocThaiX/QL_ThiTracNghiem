using QLShop;
using QLShop.TienIch;
using SinhVien.frmAdmin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinhVien
{
    public partial class frmDangNhap : Form
    {
        DBConnect conn = new DBConnect();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm;
                string tenDangNhap = txtTenDangNhap.Text;
                string matKhau = txtMatKhau.Text;
                if(tenDangNhap != "" && matKhau != "")
                {
                    if(tenDangNhap == "sa")
                    {
                        DBConnect.stringConnection = $"Data Source=.;Initial Catalog=QL_THITRACNGHIEM;User ID={tenDangNhap};Password={matKhau};TrustServerCertificate=True;Connection Timeout=5";
                        conn = new DBConnect(); // Khởi tạo lại chuỗi kết nối

                        // Xét trường hợp đăng nhập tài khoản hợp lệ
                        try
                        {
                            conn.Open(); // Catch lỗi trường hợp đăng nhập thất bại
                        }
                        catch
                        {
                            throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng!");
                        }
                        finally { conn.Close(); }

                        // Vào form admin
                        frm = new frmMain();
                    }
                    else
                    {
                        DBConnect.stringConnection = @"Data source = .; Initial Catalog = QL_THITRACNGHIEM; INTEGRATED SECURITY= TRUE; Connection Timeout=5";
                        conn = new DBConnect(); // Khởi tạo lại chuỗi kết nối
                        LuuTenDangNhap.tenDangNhap = tenDangNhap;

                        var parameters = new Dictionary<string, object>
                        {
                            { "@MaSV", tenDangNhap },
                            { "@MatKhau", matKhau }
                        };

                        // Gọi thủ tục kiểm tra tài khoản đăng nhập
                        try
                        {
                            var dt = conn.ExecuteStoredProcedure("SP_Select_DangNhap", parameters);
                            if (dt.Rows.Count == 0)
                            {
                                throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng!");
                            }
                            else
                            {
                                SinhVien.CurrentSinhVien = new SinhVien
                                {
                                    MaSV = dt.Rows[0]["MaSV"].ToString(),
                                    HoTen = dt.Rows[0]["TenSV"].ToString(),
                                    NgaySinh = Convert.ToDateTime(dt.Rows[0]["NgaySinh"]),
                                    Email = dt.Rows[0]["Email"].ToString(),
                                    SDT = dt.Rows[0]["SDT"].ToString()
                                };
                            }
                        }
                        catch
                        {
                            throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng!");
                        }

                        // Vào form sinh viên
                        frm = new TrangSinhVien();
                    }

                    this.Hide();
                    frm.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBoxHelper.ShowMessage("Vui lòng điền thông tin đăng nhập và mật khẩu đầy đủ!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowMessageError(ex.Message);
            }
            finally
            {
                txtTenDangNhap.Clear();
                txtMatKhau.Clear();
            }
        }

        private void linkLabel_DangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangky frm = new frmDangky();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void checkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHienMatKhau.Checked)
                txtMatKhau.UseSystemPasswordChar = true;
            else
                txtMatKhau.UseSystemPasswordChar = false;
        }
    }
}
