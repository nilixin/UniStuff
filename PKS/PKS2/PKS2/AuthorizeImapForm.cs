namespace PKS2
{
    public partial class AuthorizeImapForm : Form
    {
        public string EmailAddress = string.Empty;
        public string Password = string.Empty;
        public string SmtpHost = string.Empty;
        public int SmtpPort = 0;
        public string ImapHost = string.Empty;
        public int ImapPort = 0;

        public AuthorizeImapForm()
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
                tbImapHost.Text = "imap.gmail.com";
                tbImapPort.Text = "993";
                return;
            }
            else if (tbEmailAddress.Text.Contains("yandex")) // Yandex
            {
                tbSmtpHost.Text = "smtp.yandex.com";
                tbSmtpPort.Text = "465";
                tbImapHost.Text = "imap.yandex.ru";
                tbImapPort.Text = "993";
                return;
            }
            else if (tbEmailAddress.Text.Contains("mail.ru")) // Mail.ru
            {
                tbSmtpHost.Text = "smtp.mail.ru";
                tbSmtpPort.Text = "465";
                tbImapHost.Text = "imap.mail.ru";
                tbImapPort.Text = "993";
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

            // ImapHost
            ImapHost = tbImapHost.Text;
            if (string.IsNullOrEmpty(ImapHost))
            {
                MessageBox.Show("Поле IMAP хоста пустое");
                return;
            }

            // ImapPort
            try
            {
                ImapPort = int.Parse(tbImapPort.Text);
            }
            catch (Exception) { }
            if (ImapPort == 0)
            {
                MessageBox.Show("Поле IMAP порта пустое");
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
            tbImapHost.TabIndex = 4;
            tbImapPort.TabIndex = 5;
            bConfirm.TabIndex = 6;
        }
    }
}
