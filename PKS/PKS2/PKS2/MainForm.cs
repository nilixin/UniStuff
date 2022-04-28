using MimeKit;

namespace PKS2
{
    public partial class MainForm : Form
    {
        string[] PinnedFiles = new string[0];
        List<MimeMessage> InboxMessages = new();
        SmtpLogic SmtpLogic = null;

        public MainForm()
        {
            InitializeComponent();

            Status.NeedsAuthorization(lConnection);
            lPinnedStatus.Text = "";
            bSend.Enabled = false;
            bPin.Enabled = false;
        }
        
        // Нажатие на кнопку "Авторизация"
        private void bAuthorize_Click(object sender, EventArgs e)
        {
            string emailAddress = string.Empty;
            string password = string.Empty;
            string smtpHost = string.Empty;
            int smtpPort = 0;
            string imapHost = string.Empty;
            int imapPort = 0;
            string popHost = string.Empty;
            int popPort = 0;

            ClearAll();

            var chosenProtocols = cbChosenProtocols.SelectedIndex;

            if (chosenProtocols < 0) // если не выбраны протоколы
                MessageBox.Show("Сначала выберите подходящие протоколы в поле слева.");
            else if (chosenProtocols == 0) // выбраны SMTP и IMAP
            {
                var authorizeImapForm = new AuthorizeImapForm();
                authorizeImapForm.Show();
                authorizeImapForm.FormClosing += new FormClosingEventHandler((object? sender, FormClosingEventArgs e) =>
                {
                    emailAddress = authorizeImapForm.EmailAddress;
                    password = authorizeImapForm.Password;
                    smtpHost = authorizeImapForm.SmtpHost;
                    smtpPort = authorizeImapForm.SmtpPort;
                    imapHost = authorizeImapForm.ImapHost;
                    imapPort = authorizeImapForm.ImapPort;

                    connect();
                });

                void connect()
                {
                    try
                    {
                        SmtpLogic = new SmtpLogic(emailAddress, password, smtpHost, smtpPort);
                        var imapLogic = new ImapLogic(emailAddress, password, imapHost, imapPort);

                        Status.Authorized(lConnection, emailAddress); // обновление статуса
                        InboxMessages = imapLogic.Retrieve(); // подгрузка писем
                        for (int i = 0; i < InboxMessages?.Count; i++)
                        {
                            dgvInbox.Rows.Add(InboxMessages[i].From, InboxMessages[i].Date, InboxMessages[i].Subject);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось авторизоваться\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                bSend.Enabled = true;
                bPin.Enabled = true;
            }
            else if (chosenProtocols == 1) // выбраны SMTP и POP3
            {
                var authorizePopForm = new AuthorizePopForm();
                authorizePopForm.Show();
                authorizePopForm.FormClosing += new FormClosingEventHandler((object? sender, FormClosingEventArgs e) =>
                {
                    emailAddress = authorizePopForm.EmailAddress;
                    password = authorizePopForm.Password;
                    smtpHost = authorizePopForm.SmtpHost;
                    smtpPort = authorizePopForm.SmtpPort;
                    popHost = authorizePopForm.PopHost;
                    popPort = authorizePopForm.PopPort;

                    connect();
                });

                void connect()
                {
                    try
                    {
                        SmtpLogic = new SmtpLogic(emailAddress, password, smtpHost, smtpPort);
                        var popLogic = new PopLogic(emailAddress, password, popHost, popPort);

                        Status.Authorized(lConnection, emailAddress); // обновление статуса

                        popLogic.Download();
                        
                        var messages = new List<MimeMessage>();
                        
                        var files = Directory.GetFiles(Constants.PopInboxFolder);

                        if (files.Length <= 0) // если файлов не найдено
                            return;

                        foreach (var file in files)
                        {
                            var stream = File.OpenRead(file);
                            var parser = new MimeParser(stream, MimeFormat.Entity);
                            var message = parser.ParseMessage();

                            dgvInbox.Rows.Add(message.From, message.Date, message.Subject); // добавление сообщения в dgvInbox
                            InboxMessages.Add(message);  // добавление сообщения в InboxMessages для последующей ссылки на него по индексу в методе dgvInbox_CellClick
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось авторизоваться\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                bSend.Enabled = true;
                bPin.Enabled = true;
            }
            else { }
        }

        // Нажатие на кнопку "Вложить"
        private void bPin_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.InitialDirectory = "C:\\Users";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    PinnedFiles = ofd.FileNames;
                    for (int i = 0; i < PinnedFiles.Length; i++)
                        lPinnedStatus.Text += "\u2713";
                }
            }
        }

        // Выбор сообщение пользователем, последующее открытие формы сообщения
        private void dgvInbox_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dgvInbox.ClearSelection();
                    dgvInbox.Rows[e.RowIndex].Selected = true;

                    var messageForm = new MessageForm(InboxMessages[e.RowIndex]);
                    messageForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть письмо\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            if (PinnedFiles.Length == 0) // пользователь не добавлял вложения
            {
                Message message = new(tbTo.Text, tbSubject.Text, tbBody.Text);
                SmtpLogic.Send(message);

            }
            else // пользователь добавил вложения
            {
                Message message = new(tbTo.Text, tbSubject.Text, tbBody.Text);
                SmtpLogic.Send(message, PinnedFiles);

                PinnedFiles = new string[0];
                lPinnedStatus.Text = "";
            }
        }

        void ClearAll()
        {
            tbTo.Text = string.Empty;
            tbSubject.Text = string.Empty;
            tbBody.Text = string.Empty;

            dgvInbox.Rows.Clear();
            InboxMessages.Clear();
        }
    }
}