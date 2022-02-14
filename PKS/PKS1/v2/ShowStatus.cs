using System.Drawing;
using System.Windows.Forms;

namespace v2
{
    public static class ShowStatus
    {
        const string DefaultMessageFtp = "Статус FTP подключения: ";

        public static void FtpNone(Label label)
        {
            label.ForeColor = Color.Red;
            label.Text = DefaultMessageFtp + "Нет подключения";
        }

        public static void FtpEstablished(Label label)
        {
            label.ForeColor = Color.Green;
            label.Text = DefaultMessageFtp + "Подключение установлено";
        }
    }
}
