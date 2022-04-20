using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace PKS2
{
    internal class SmtpClient
    {
        System.Net.Mail.SmtpClient? client = null;
        string senderAddress = string.Empty;

        static bool messageSent = false;

        public SmtpClient(string emailAddress, string password, string host, int port)
        {
            client = new();

            client.Host = host;
            client.Port = port;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            NetworkCredential nc = new(emailAddress, password);
            client.Credentials = nc;

            senderAddress = emailAddress;
        }

        public void Send(EmailMessage emailMessage)
        {
            messageSent = false;

            MailAddress sender = new(senderAddress, client.TargetName, Encoding.UTF8);
            MailAddress recipient = new(emailMessage.RecipientAddress, null, Encoding.UTF8);
            MailMessage message = new(sender, recipient);
            message.Subject = emailMessage.Subject;
            message.SubjectEncoding = Encoding.UTF8;
            message.Body = emailMessage.Body;
            message.BodyEncoding = Encoding.UTF8;

            try
            {
                client.Send(message);
                MessageBox.Show("Сообщение отправлено", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сообщение НЕ отправлено\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            message.Dispose();
        }
    }
}
