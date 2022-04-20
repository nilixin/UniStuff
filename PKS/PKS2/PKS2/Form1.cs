namespace PKS2
{
    public partial class Form1 : Form
    {
        SmtpClient? smtpClient = null;

        public Form1()
        {
            InitializeComponent();

            lUserEmailAddress.Text = "сначала авторизуйтесь ->";
        }

        // Авторизация в аккаунт пользователя по вводимым им метаданным
        private void bAuthorize_Click(object sender, EventArgs e)
        {
            string emailAddress = string.Empty;
            string password = string.Empty;
            string host = string.Empty;
            int port = 0;

            Form2 form2 = new();
            form2.Show();
            form2.FormClosing += new FormClosingEventHandler((object? sender, FormClosingEventArgs e) => {
                emailAddress = form2.EmailAddress;
                password = form2.Password;
                host = form2.Host;
                port = form2.Port;

                connect();
            }); // перед закрытием формы авторизации, сохранение метаданных пользователя и попытка подключения

            void connect()
            {
                try
                {
                    smtpClient = new SmtpClient(emailAddress, password, host, port);
                    lUserEmailAddress.Text = emailAddress;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось авторизоваться\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Отправка сообщения
        private void bSend_Click(object sender, EventArgs e)
        {
            EmailMessage message = new(tbRecipientAddress.Text, tbSubject.Text, tbBody.Text);
            smtpClient.Send(message);
        }

        private void bAttach_Click(object sender, EventArgs e)
        {

        }

        #region Полоса меню
        private void настроитьИмяToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа, демонстрирующая работу протоколов для работы с электронной почтой\n\nГавриленков, ПИ-19в");
        }
        #endregion
    }
}