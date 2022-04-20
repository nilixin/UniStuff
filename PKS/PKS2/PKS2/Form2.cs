namespace PKS2
{
    public partial class Form2 : Form
    {
        public string EmailAddress = string.Empty;
        public string Password = string.Empty;
        public string SmtpHost = string.Empty;
        public int SmtpPort = 0;
        public string ImapHost = string.Empty;
        public int ImapPort = 0;

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

            SmtpHost = tbSmtpHost.Text;
            if (string.IsNullOrEmpty(SmtpHost))
            {
                MessageBox.Show("Поле SMTP хоста пустое");
                return;
            }

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

            ImapHost = tbSmtpHost.Text;
            if (string.IsNullOrEmpty(ImapHost))
            {
                MessageBox.Show("Поле IMAP хоста пустое");
                return;
            }

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

            Close();
        }

        private void tbEmailAddress_Leave(object sender, EventArgs e)
        {
            if (tbEmailAddress.Text.Contains("gmail"))
            {
                tbSmtpHost.Text = "smtp.gmail.com";
                //tbPort.Text = "587"; // не SSL
                tbSmtpPort.Text = "465"; // SSL
                tbImapHost.Text = "imap.gmail.com";
                tbImapPort.Text = "993";
                return;
            }
            else if (tbEmailAddress.Text.Contains("yandex"))
            {
                tbSmtpHost.Text = "smtp.yandex.com";
                tbSmtpPort.Text = "465";
                tbImapHost.Text = "imap.yandex.ru";
                tbImapPort.Text = "993";
                return;
            }
            else if (tbEmailAddress.Text.Contains("mail.ru"))
            {
                tbSmtpHost.Text = "smtp.mail.ru";
                tbSmtpPort.Text = "465";
                tbImapHost.Text = "imap.mail.ru";
                tbImapPort.Text = "993";
                return;
            }
            else if (string.IsNullOrEmpty(tbEmailAddress.Text)) { }
            else
                MessageBox.Show("Приложение не знает такого провайдера электронной почты\n" +
                    "Информацию о хостах и портах можно найти на сайте провайдера электронной почты");
        }
    }
}
