using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SinhVien
{
    public partial class TrangSinhVien : Form
    {
        private bool isMenuCollapsed = false;        // Trạng thái menu: false = mở rộng, true = thu nhỏ
        private int panelMenuOriginalWidth = 213;   // Chiều rộng ban đầu của panelMenu
        private int panelMenuCollapsedWidth = 35;   // Chiều rộng khi thu nhỏ (bằng kích thước pictureBox6)
        private int animationStep = 10;             // Bước thay đổi chiều rộng
        private Timer menuAnimationTimer;           // Timer cho hiệu ứng
        public TrangSinhVien()
        {
            InitializeComponent();
        }
        
        private void btnTTSV_Click(object sender, EventArgs e)
        {
            var frmSinhVien = new FrmThongTinSinhVien
            {
                TopLevel = false,       // Không hiển thị khung Form
                FormBorderStyle = FormBorderStyle.None, // Loại bỏ tiêu đề
                Dock = DockStyle.Fill   // Chiếm toàn bộ PanelContent
            };

            panelContent.Controls.Clear(); // Xóa nội dung cũ
            panelContent.Controls.Add(frmSinhVien);
            frmSinhVien.Show();

        }

        private void btnThiTN_Click(object sender, EventArgs e)
        {
            
            // Mở FrmThiTracNghiem
            FrmThiTracNghiem frmThiTracNghiem = new FrmThiTracNghiem();
            frmThiTracNghiem.ShowDialog();

        }

        private void btnXemKQ_Click(object sender, EventArgs e)
        {
            var frmKetQua = new FrmXemKetQua
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelContent.Controls.Clear();
            panelContent.Controls.Add(frmKetQua);
            frmKetQua.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
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
                // Mở rộng panelMenu
                if (panelMenu.Width < panelMenuOriginalWidth)
                {
                    panelMenu.Width += animationStep; // Tăng chiều rộng từng bước
                }
                else
                {
                    panelMenu.Width = panelMenuOriginalWidth; // Đảm bảo đúng kích thước khi kết thúc
                    foreach (Control ctrl in panelMenu.Controls)
                    {
                        if (ctrl != pictureBox6) ctrl.Visible = true; // Hiển thị lại các thành phần
                    }
                    isMenuCollapsed = false; // Cập nhật trạng thái
                    menuAnimationTimer.Stop(); // Dừng Timer
                }
            }
            else
            {
                // Thu nhỏ panelMenu
                if (panelMenu.Width > panelMenuCollapsedWidth)
                {
                    panelMenu.Width -= animationStep; // Giảm chiều rộng từng bước
                }
                else
                {
                    panelMenu.Width = panelMenuCollapsedWidth; // Đảm bảo đúng kích thước khi kết thúc
                    foreach (Control ctrl in panelMenu.Controls)
                    {
                        if (ctrl != pictureBox6) ctrl.Visible = false; // Ẩn các thành phần (trừ pictureBox6)
                    }
                    isMenuCollapsed = true; // Cập nhật trạng thái
                    menuAnimationTimer.Stop(); // Dừng Timer
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Xóa tất cả các điều khiển trong panelContent
            panelContent.Controls.Clear();

            
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
