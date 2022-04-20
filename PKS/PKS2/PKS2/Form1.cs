using MimeKit;

namespace PKS2
{
    public partial class Form1 : Form
    {
        ProtocolLogic? SmtpClient = null;
        string AttachedFilePath = string.Empty;

        public Form1()
        {
            InitializeComponent();

            lUserEmailAddress.Text = "������� ������������� ->";
        }

        // ����������� � ������� ������������ �� �������� �� ����������
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

                connect();
                retrieveInbox();
            }); // ����� ��������� ����� �����������, ���������� ���������� ������������ � ������� �����������

            void connect()
            {
                try
                {
                    SmtpClient = new ProtocolLogic(emailAddress, password, smtpHost, smtpPort, imapHost, imapPort);
                    lUserEmailAddress.Text = emailAddress;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�� ������� ��������������\n" + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            void retrieveInbox()
            {
                try
                {
                    var messages = SmtpClient.RetrieveInbox(imapHost, imapPort);
                    
                    foreach (var message in messages)
                    {
                        string line = string.Empty;
                        line += message.Subject + " | ";
                        line += message.Sender + " | ";
                        line += message.Date;

                        lbInboxMessages.Items.Add(line);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�� ������� ������� �������� ����\n" + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // �������� ���������
        private void bSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AttachedFilePath)) // ���� ������������ ������� ��������
            {
                EmailMessage message = new(tbRecipientAddress.Text, tbSubject.Text, tbBody.Text);
                SmtpClient.Send(message, AttachedFilePath);
                AttachedFilePath = string.Empty;
                lAttachmentStatus.Text = "";
            }
            else // ���� ������������ �� �������� ��������
            {
                EmailMessage message = new(tbRecipientAddress.Text, tbSubject.Text, tbBody.Text);
                SmtpClient.Send(message);
            }
        }

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

        #region ������ ����
        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("���������, ��������������� ������ ���������� ��� ������ � ����������� ������\n\n�����������, ��-19�");
        }
        #endregion
    }
}