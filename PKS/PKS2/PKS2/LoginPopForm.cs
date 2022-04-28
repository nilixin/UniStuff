namespace PKS2
{
    public partial class LoginPopForm : Form
    {
        public string EmailAddress = string.Empty;
        public string Password = string.Empty;
        public string SmtpHost = string.Empty;
        public int SmtpPort = 0;
        public string Pop3Host = string.Empty;
        public int Pop3Port = 0;

        public LoginPopForm()
        {
            InitializeComponent();
            DefineTabOrder();
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

            Pop3Host = tbPop3Host.Text;
            if (string.IsNullOrEmpty(Pop3Host))
            {
                MessageBox.Show("Поле POP3 хоста пустое");
                return;
            }

            try
            {
                Pop3Port = int.Parse(tbPop3Port.Text);
            }
            catch (Exception) { }
            if (Pop3Port == 0)
            {
                MessageBox.Show("Поле POP3 порта пустое");
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
                tbPop3Host.Text = "pop.gmail.com";
                tbPop3Port.Text = "995";
                return;
            }
            else if (tbEmailAddress.Text.Contains("yandex"))
            {
                tbSmtpHost.Text = "smtp.yandex.com";
                tbSmtpPort.Text = "465";
                tbPop3Host.Text = "pop.yandex.ru";
                tbPop3Port.Text = "995";
                return;
            }
            else if (tbEmailAddress.Text.Contains("mail.ru"))
            {
                tbSmtpHost.Text = "smtp.mail.ru";
                tbSmtpPort.Text = "465";
                tbPop3Host.Text = "pop.mail.ru";
                tbPop3Port.Text = "995";
                return;
            }
            else if (string.IsNullOrEmpty(tbEmailAddress.Text)) { }
            else
                MessageBox.Show("Приложение не знает такого провайдера электронной почты\n" +
                    "Информацию о хостах и портах можно найти на сайте провайдера электронной почты");
        }

        private void DefineTabOrder()
        {
            tbEmailAddress.TabIndex = 0;
            tbPassword.TabIndex = 1;
            tbSmtpHost.TabIndex = 2;
            tbSmtpPort.TabIndex = 3;
            tbPop3Host.TabIndex = 4;
            tbPop3Port.TabIndex = 5;
            bConfirm.TabIndex = 6;
        }
    }
}
