using MimeKit;

namespace PKS2
{
    public partial class Form1 : Form
    {
        ProtocolLogic? ProtocolLogic = null;
        string AttachedFilePath = string.Empty;
        List<MimeKit.MimeMessage> ReceivedMessages = new List<MimeKit.MimeMessage>();

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
            });

            void connect()
            {
                try
                {
                    ProtocolLogic = new ProtocolLogic(emailAddress, password, smtpHost, smtpPort, imapHost, imapPort);
                    lUserEmailAddress.Text = emailAddress;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�� ������� ��������������\n" + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // ������������ �����������
            void retrieveInbox()
            {
                try
                {
                    ReceivedMessages = ProtocolLogic.RetrieveInbox();

                    for (int i = 0; i < ReceivedMessages.Count; i++)
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
            if (e.RowIndex >= 0)
            {
                dgvInboxMessages.ClearSelection();
                dgvInboxMessages.Rows[e.RowIndex].Selected = true;

                var form3 = new Form3(ReceivedMessages[e.RowIndex]);
                form3.Show();
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