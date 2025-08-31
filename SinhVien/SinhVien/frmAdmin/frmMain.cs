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
    public partial class frmMain : Form
    {
        private bool isMenuCollapsed = false;        // Trạng thái menu: false = mở rộng, true = thu nhỏ
        private int panelMenuOriginalWidth = 213;   // Chiều rộng ban đầu của panelMenu
        private int panelMenuCollapsedWidth = 50;   // Chiều rộng khi thu nhỏ (bằng kích thước pictureBox6)
        private int animationStep = 10;             // Bước thay đổi chiều rộng
        private Timer menuAnimationTimer;           // Timer cho hiệu ứng
        public frmMain()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (menuAnimationTimer != null && menuAnimationTimer.Enabled)
                return; // Đang chạy hiệu ứng, bỏ qua thao tác mới

            menuAnimationTimer = new Timer { Interval = 10 }; // Tốc độ khung hình (10ms)
            menuAnimationTimer.Tick += MenuAnimationTimer_Tick;
            menuAnimationTimer.Start();
        }
        private void MenuAnimationTimer_Tick(object sender, EventArgs e)
        {
            if (isMenuCollapsed)
            {
                // Mở rộng pnlMenu
                if (panelMenu.Width < panelMenuOriginalWidth)
                {
                    panelMenu.Width += animationStep; // Tăng chiều rộng từng bước
                }
                else
                {
                    panelMenu.Width = panelMenuOriginalWidth; // Đảm bảo đúng kích thước khi kết thúc
                    foreach (Control ctrl in panelMenu.Controls)
                    {
                        // Hiển thị toàn bộ các thành phần và text của button
                        if (ctrl is Button btn)
                        {
                            btn.Text = btn.Tag?.ToString(); // Hiển thị lại text từ thuộc tính Tag
                            btn.TextAlign = ContentAlignment.MiddleCenter;
                        }
                    }
                    isMenuCollapsed = false; // Cập nhật trạng thái
                    menuAnimationTimer.Stop(); // Dừng Timer
                }
            }
            else
            {
                // Thu nhỏ pnlMenu
                if (panelMenu.Width > panelMenuCollapsedWidth)
                {
                    panelMenu.Width -= animationStep; // Giảm chiều rộng từng bước
                }
                else
                {
                    panelMenu.Width = panelMenuCollapsedWidth; // Đảm bảo đúng kích thước khi kết thúc
                    foreach (Control ctrl in panelMenu.Controls)
                    {
                        // Chỉ hiển thị icon, ẩn text của button
                        if (ctrl is Button btn)
                        {
                            btn.Tag = btn.Text; // Lưu text vào Tag
                            btn.Text = "";      // Xóa text
                            btn.TextAlign = ContentAlignment.MiddleCenter;
                        }
                    }
                    isMenuCollapsed = true; // Cập nhật trạng thái
                    menuAnimationTimer.Stop(); // Dừng Timer
                }
            }
        }

        private void btnTranChu_Click(object sender, EventArgs e)
        {
            var Trangchu = new frmTrangChu
            {
                TopLevel = false,       // Không hiển thị khung Form
                FormBorderStyle = FormBorderStyle.None, // Loại bỏ tiêu đề
                Dock = DockStyle.Fill   // Chiếm toàn bộ PanelContent
            };

            panelDesktop.Controls.Clear(); // Xóa nội dung cũ
            panelDesktop.Controls.Add(Trangchu);
            Trangchu.Show();
        }

        private void btnQLCH_Click(object sender, EventArgs e)
        {
            var CauHoi = new frmQLCauHoiVaDapAn
            {
                TopLevel = false,       // Không hiển thị khung Form
                FormBorderStyle = FormBorderStyle.None, // Loại bỏ tiêu đề
                Dock = DockStyle.Fill   // Chiếm toàn bộ PanelContent
            };

            panelDesktop.Controls.Clear(); // Xóa nội dung cũ
            panelDesktop.Controls.Add(CauHoi);
            CauHoi.Show();
        }

        private void btnQLDeThi_Click(object sender, EventArgs e)
        {
            var dethi = new frmQLDeThi
            {
                TopLevel = false,       // Không hiển thị khung Form
                FormBorderStyle = FormBorderStyle.None, // Loại bỏ tiêu đề
                Dock = DockStyle.Fill   // Chiếm toàn bộ PanelContent
            };

            panelDesktop.Controls.Clear(); // Xóa nội dung cũ
            panelDesktop.Controls.Add(dethi);
            dethi.Show();
        }

        private void btnQLKetQua_Click(object sender, EventArgs e)
        {
            var ketqua = new frmQLKetQua
            {
                TopLevel = false,       // Không hiển thị khung Form
                FormBorderStyle = FormBorderStyle.None, // Loại bỏ tiêu đề
                Dock = DockStyle.Fill   // Chiếm toàn bộ PanelContent
            };

            panelDesktop.Controls.Clear(); // Xóa nội dung cũ
            panelDesktop.Controls.Add(ketqua);
            ketqua.Show();
        }

        private void btnQLMH_Click(object sender, EventArgs e)
        {
            var monhoc = new frmQLMonHoc
            {
                TopLevel = false,       // Không hiển thị khung Form
                FormBorderStyle = FormBorderStyle.None, // Loại bỏ tiêu đề
                Dock = DockStyle.Fill   // Chiếm toàn bộ PanelContent
            };

            panelDesktop.Controls.Clear(); // Xóa nội dung cũ
            panelDesktop.Controls.Add(monhoc);
            monhoc.Show();
        }

        private void btnQLKyThi_Click(object sender, EventArgs e)
        {
            var kythi = new frmQLKyThi
            {
                TopLevel = false,       // Không hiển thị khung Form
                FormBorderStyle = FormBorderStyle.None, // Loại bỏ tiêu đề
                Dock = DockStyle.Fill   // Chiếm toàn bộ PanelContent
            };

            panelDesktop.Controls.Clear(); // Xóa nội dung cũ
            panelDesktop.Controls.Add(kythi);
            kythi.Show();
        }

        private void btnQLSV_Click(object sender, EventArgs e)
        {
            var sv = new frmQLSinhVien
            {
                TopLevel = false,       // Không hiển thị khung Form
                FormBorderStyle = FormBorderStyle.None, // Loại bỏ tiêu đề
                Dock = DockStyle.Fill   // Chiếm toàn bộ PanelContent
            };

            panelDesktop.Controls.Clear(); // Xóa nội dung cũ
            panelDesktop.Controls.Add(sv);
            sv.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
