namespace PKS2
{
    public partial class Form1 : Form
    {
        SmtpClient? smtpClient = null;

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
            }); // ����� ��������� ����� �����������, ���������� ���������� ������������ � ������� �����������

            void connect()
            {
                try
                {
                    smtpClient = new SmtpClient(emailAddress, password, host, port);
                    lUserEmailAddress.Text = emailAddress;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�� ������� ��������������\n" + ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // �������� ���������
        private void bSend_Click(object sender, EventArgs e)
        {
            EmailMessage message = new(tbRecipientAddress.Text, tbSubject.Text, tbBody.Text);
            smtpClient.Send(message);
        }

        private void bAttach_Click(object sender, EventArgs e)
        {

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