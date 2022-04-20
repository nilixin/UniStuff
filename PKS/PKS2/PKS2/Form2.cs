namespace PKS2
{
    public partial class Form2 : Form
    {
        public string EmailAddress = string.Empty;
        public string Password = string.Empty;
        public string Host = string.Empty;
        public int Port = 0;

        public Form2()
        {
            InitializeComponent();
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            EmailAddress = tbEmailAddress.Text;
            if (string.IsNullOrEmpty(EmailAddress))
            {
                MessageBox.Show("Поле почтового адреса пустое");
                return;
            }

            Password = tbPassword.Text;
            if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Поле пароля пустое");
                return;
            }

            Host = tbHost.Text;
            if (string.IsNullOrEmpty(Host))
            {
                MessageBox.Show("Поле хоста пустое");
                return;
            }

            try
            {
                Port = int.Parse(tbPort.Text);
            }
            catch (Exception) { }
            if (Port == 0)
            {
                MessageBox.Show("Поле порта пустое");
                return;
            }

            Close();
        }

        private void tbEmailAddress_Leave(object sender, EventArgs e)
        {
            if (tbEmailAddress.Text.Contains("gmail"))
            {
                tbHost.Text = "smtp.gmail.com";
                tbPort.Text = "587";
                return;
            }
            else if (tbEmailAddress.Text.Contains("yandex"))
            {
                tbHost.Text = "smtp.yandex.com";
                tbPort.Text = "465";
                return;
            }
            else if (tbEmailAddress.Text.Contains("mail.ru"))
            {
                tbHost.Text = "smtp.mail.ru";
                tbPort.Text = "465";
                return;
            }
            else if (string.IsNullOrEmpty(tbEmailAddress.Text)) { }
            else
                MessageBox.Show("Приложение не знает такого провайдера электронной почты\n" +
                    "Информацию о хосте и порте SMTP можно найти на сайте провайдера электронной почты");
        }
    }
}
