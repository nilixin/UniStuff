using MimeKit;

namespace PKS2
{
    public partial class Form1 : Form
    {
        ProtocolLogic? ProtocolLogic = null;
        string AttachedFilePath = string.Empty;
        List<MimeMessage> ReceivedMessages = new List<MimeMessage>();

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
            string smtpHost = string.Empty;
            int smtpPort = 0;
            string imapHost = string.Empty;
            int imapPort = 0;

            Form2 form2 = new();
            form2.Show();
            form2.FormClosing += new FormClosingEventHandler((object? sender, FormClosingEventArgs e) => {
                emailAddress = form2.EmailAddress;
                password = form2.Password;
                smtpHost = form2.SmtpHost;
                smtpPort = form2.SmtpPort;
                imapHost = form2.ImapHost;
                imapPort = form2.ImapPort;

                initialize();
                retrieve();
            });

            void initialize()
            {
                try
                {
                    ProtocolLogic = new ProtocolLogic(emailAddress, password, smtpHost, smtpPort, imapHost, imapPort);
                    lUserEmailAddress.Text = emailAddress;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось авторизоваться\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // тестирование подключения
            void retrieve()
            {
                try
                {
                    ReceivedMessages = ProtocolLogic.RetrieveInbox();

                    for (int i = 0; i < ReceivedMessages.Count; i++)
                    {
                        // обновление dgvInboxMessages
                        dgvInboxMessages.Rows.Add(ReceivedMessages[i].From, ReceivedMessages[i].Date, ReceivedMessages[i].Subject);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось скачать почтовый ящик\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // сохранение писем и их отображение в dgvInboxMessages
        }

        // Отправка сообщения
        private void bSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AttachedFilePath)) // если пользователь добавил вложение
            {
                SentMessage message = new(tbRecipientAddress.Text, tbSubject.Text, tbBody.Text);
                ProtocolLogic.Send(message, AttachedFilePath);
                AttachedFilePath = string.Empty;
                lAttachmentStatus.Text = "";
            }
            else // если пользователь не добавлял вложение
            {
                SentMessage message = new(tbRecipientAddress.Text, tbSubject.Text, tbBody.Text);
                ProtocolLogic.Send(message);
            }
        }

        // Вложение файла в письмо
        private void bAttach_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "c:\\Users";
                
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    AttachedFilePath = ofd.FileName;
                    lAttachmentStatus.Text = "\u2713";
                }
            }
        }

        // Выбор сообщение пользователем, последующее открытие формы сообщения
        private void dgvInboxMessages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvInboxMessages.ClearSelection();
                dgvInboxMessages.Rows[e.RowIndex].Selected = true;

                var form3 = new Form3(ReceivedMessages[e.RowIndex]);
                form3.Show();
            }
        }
    }
}