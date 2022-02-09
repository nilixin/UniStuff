using System.Drawing;
using System.Windows.Forms;

namespace v2
{
    public static class ConnectionStatus
    {
        const string lConnectionStatusDefaultMessage = "Статус: ";

        public static void None(Label label)
        {
            label.ForeColor = Color.Red;
            label.Text = lConnectionStatusDefaultMessage + "Нет подключения";
        }

        public static void Established(Label label)
        {
            label.ForeColor = Color.Green;
            label.Text = lConnectionStatusDefaultMessage + "Подключение установлено";
        }
    }
}
