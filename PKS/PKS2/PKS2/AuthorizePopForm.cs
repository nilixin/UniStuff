namespace PKS2
{
    public partial class AuthorizePopForm : Form
    {
        public string EmailAddress = string.Empty;
        public string Password = string.Empty;
        public string SmtpHost = string.Empty;
        public int SmtpPort = 0;
        public string PopHost = string.Empty;
        public int PopPort = 0;

        public AuthorizePopForm()
        {
            InitializeComponent();

            DefineTabOrder();
        }

        // Переход от tbEmailAddress, автоподстановка необходимых параметров конфигурации
        private void tbEmailAddress_Leave(object sender, EventArgs e)
        {
            if (tbEmailAddress.Text.Contains("gmail")) // Gmail
            {
                tbSmtpHost.Text = "smtp.gmail.com";
                tbSmtpPort.Text = "465";
                tbPopHost.Text = "pop.gmail.com";
                tbPopPort.Text = "995";
                return;
            }
            else if (tbEmailAddress.Text.Contains("yandex")) // Yandex
            {
                tbSmtpHost.Text = "smtp.yandex.com";
                tbSmtpPort.Text = "465";
                tbPopHost.Text = "pop.yandex.ru";
                tbPopPort.Text = "995";
                return;
            }
            else if (tbEmailAddress.Text.Contains("mail.ru")) // Mail.ru
            {
                tbSmtpHost.Text = "smtp.mail.ru";
                tbSmtpPort.Text = "465";
                tbPopHost.Text = "pop.mail.ru";
                tbPopPort.Text = "995";
                return;
            }
            else if (string.IsNullOrEmpty(tbEmailAddress.Text)) { } // Пустая строка
            else // Неизвестный домен
                MessageBox.Show("Приложение не знает такого провайдера электронной почты\n" +
                    "Информацию о хостах и портах можно найти на сайте провайдера электронной почты");
        }

        // Нажатие на кнопку "Подтвердить"
        private void bConfirm_Click(object sender, EventArgs e)
        {
            // EmailAddress
            EmailAddress = tbEmailAddress.Text;
            if (string.IsNullOrEmpty(EmailAddress))
            {
                MessageBox.Show("Поле почтового адреса пустое");
                return;
            }

            // Password
            Password = tbPassword.Text;
            if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Поле пароля пустое");
                return;
            }

            // SmtpHost
            SmtpHost = tbSmtpHost.Text;
            if (string.IsNullOrEmpty(SmtpHost))
            {
                MessageBox.Show("Поле SMTP хоста пустое");
                return;
            }

            // SmtpPort
            try
            {
                SmtpPort = int.Parse(tbSmtpPort.Text);
            }
            catch (Exception) { }
            if (SmtpPort == 0)
            {
                MessageBox.Show("Поле SMTP порта пустое");
                return;
            }

            // PopHost
            PopHost = tbPopHost.Text;
            if (string.IsNullOrEmpty(PopHost))
            {
                MessageBox.Show("Поле POP3 хоста пустое");
                return;
            }

            // PopPort
            try
            {
                PopPort = int.Parse(tbPopPort.Text);
            }
            catch (Exception) { }
            if (PopPort == 0)
            {
                MessageBox.Show("Поле POP3 порта пустое");
                return;
            }

            // Закрыть форму
            Close();
        }

        private void DefineTabOrder()
        {
            tbEmailAddress.TabIndex = 0;
            tbPassword.TabIndex = 1;
            tbSmtpHost.TabIndex = 2;
            tbSmtpPort.TabIndex = 3;
            tbPopHost.TabIndex = 4;
            tbPopPort.TabIndex = 5;
            bConfirm.TabIndex = 6;
        }
    }
}
