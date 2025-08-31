using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLShop.TienIch
{
    internal static class MessageBoxHelper
    {
        // Phương thức chung
        private static DialogResult Show(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, title, buttons, icon);
        }

        // Thông báo thông tin
        public static void ShowMessage(string message)
        {
            Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Thông báo lỗi
        public static void ShowMessageError(string message)
        {
            Show(message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Câu hỏi (Yes/No)
        public static DialogResult ShowMessageQuestion(string message)
        {
            return Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
