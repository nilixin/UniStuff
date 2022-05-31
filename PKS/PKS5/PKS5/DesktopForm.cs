using System;
using System.Windows.Forms;

namespace PKS5
{
    public partial class DesktopForm : Form
    {
        public DesktopForm()
        {
            InitializeComponent();
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            // Ввод данных
            string host;

            if (string.IsNullOrEmpty(tbHost.Text))
                host = "localhost";
            else
                host = tbHost.Text;
            
            // Подключение
            try
            {
                rdDesktop.Connect(host);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                rdDesktop.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
