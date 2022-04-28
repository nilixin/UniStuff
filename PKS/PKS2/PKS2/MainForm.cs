using MimeKit;
using System.Diagnostics;

namespace PKS2
{
    public partial class MainForm : Form
    {
        ProtocolLogic? ProtocolLogic = null;
        string AttachedFilePath = string.Empty;
        List<MimeMessage> ReceivedMessages = new List<MimeMessage>();

        public MainForm()
        {
            InitializeComponent();

            lUserEmailAddress.Text = "������� ������������� ->";
        }

        // ����������� � ������� ������������ �� �������� �� ��������������� ������
        // ��������� SMTP, IMAP
        private void bAuthorize_Click(object sender, EventArgs e)
        {
            string emailAddress = string.Empty;
            string password = string.Empty;
            string smtpHost = string.Empty;
            int smtpPort = 0;
            string imapHost = string.Empty;
            int imapPort = 0;

            LoginForm loginForm = new();
            loginForm.Show();
            loginForm.FormClosing += new FormClosingEventHandler((object? sender, FormClosingEventArgs e) => {
                emailAddress = loginForm.EmailAddress;
                password = loginForm.Password;
                smtpHost = loginForm.SmtpHost;
                smtpPort = loginForm.SmtpPort;
                imapHost = loginForm.ImapHost;
                imapPort = loginForm.ImapPort;

                initialize();
                retrieve();
            });

            void initialize()
            {
                try
                {
                    ProtocolLogic = new ProtocolLogic();
                    ProtocolLogic.Initialize(emailAddress, password, smtpHost, smtpPort, imapHost, imapPort);
                    lUserEmailAddress.Text = emailAddress;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�� ������� ��������������\n" + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // ������������ �����������
            void retrieve()
            {
                try
                {
                    ReceivedMessages = ProtocolLogic?.RetrieveInbox();

                    for (int i = 0; i < ReceivedMessages?.Count; i++)
                    {
                        // ���������� dgvInboxMessages
                        dgvInboxMessages.Rows.Add(ReceivedMessages[i].From, ReceivedMessages[i].Date, ReceivedMessages[i].Subject);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�� ������� ������� �������� ����\n" + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // ���������� ����� � �� ����������� � dgvInboxMessages
        }

        // ����������� � ������� ������������ �� �������� �� ��������������� ������
        // �������� POP3
        private void bAuthorizePop_Click(object sender, EventArgs e)
        {
            string emailAddress = string.Empty;
            string password = string.Empty;
            string smtpHost = string.Empty;
            int smtpPort = 0;
            string pop3Host = string.Empty;
            int pop3Port = 0;

            LoginPopForm loginPopForm = new();
            loginPopForm.Show();
            loginPopForm.FormClosing += new FormClosingEventHandler((object? sender, FormClosingEventArgs e) => {
                emailAddress = loginPopForm.EmailAddress;
                password = loginPopForm.Password;
                smtpHost = loginPopForm.SmtpHost;
                smtpPort = loginPopForm.SmtpPort;
                pop3Host = loginPopForm.Pop3Host;
                pop3Port = loginPopForm.Pop3Port;

                initialize();
                downloadInbox();
            });

            void initialize()
            {
                try
                {
                    ProtocolLogic = new ProtocolLogic();
                    ProtocolLogic.InitializePop(emailAddress, password, smtpHost, smtpPort, pop3Host, pop3Port);
                    lUserEmailAddress.Text = emailAddress;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�� ������� ��������������\n" + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            void downloadInbox()
            {
                ProtocolLogic?.DownloadInboxPop();

                var files = new DirectoryInfo(ProtocolLogic.DownloadedMessagesDirectory);

                foreach (var file in files.GetFiles())
                {
                    //dgvInboxMessages.Rows.Add(ReceivedMessages[i].From, ReceivedMessages[i].Date, ReceivedMessages[i].Subject);
                    dgvInboxMessages.Rows.Add(file.FullName, "NaN", "NaN");
                }
            }
        }

        // �������� ���������
        private void bSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AttachedFilePath)) // ���� ������������ ������� ��������
            {
                SentMessage message = new(tbRecipientAddress.Text, tbSubject.Text, tbBody.Text);
                ProtocolLogic.Send(message, AttachedFilePath);
                AttachedFilePath = string.Empty;
                lAttachmentStatus.Text = "";
            }
            else // ���� ������������ �� �������� ��������
            {
                SentMessage message = new(tbRecipientAddress.Text, tbSubject.Text, tbBody.Text);
                ProtocolLogic.Send(message);
            }
        }

        // �������� ����� � ������
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

        // ����� ��������� �������������, ����������� �������� ����� ���������
        private void dgvInboxMessages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dgvInboxMessages.ClearSelection();
                    dgvInboxMessages.Rows[e.RowIndex].Selected = true;

                    var messageForm = new MessageForm(ReceivedMessages[e.RowIndex]);
                    messageForm.Show();
                }
            }
            catch (Exception)
            {
                string filePath = dgvInboxMessages.Rows[e.RowIndex].Cells[0].Value.ToString(); // ���������� ����
                Process.Start("notepad.exe", filePath);
            }
        }
    }
}