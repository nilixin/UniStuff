using MailKit.Net.Smtp;
using MimeKit;

namespace PKS2
{
    public class SmtpLogic
    {
        string EmailAddress = string.Empty;
        string Password = string.Empty;
        string SmtpHost = string.Empty;
        int SmtpPort = 0;
        bool UseSsl;

        public SmtpLogic (string emailAddress, string password, string smtpHost, int smtpPort, bool useSsl = true)
        {
            EmailAddress = emailAddress;
            Password = password;
            SmtpHost = smtpHost;
            SmtpPort = smtpPort;
            UseSsl = useSsl;

            using (var client = new SmtpClient())
            {
                client.Connect(SmtpHost, SmtpPort, UseSsl);
                client.Authenticate(EmailAddress, Password);
                client.Disconnect(true);
            }
        }

        // Отправка письма без вложения
        public void Send(Message message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(EmailAddress, EmailAddress));
            mimeMessage.To.Add(new MailboxAddress(message.To, message.To));
            mimeMessage.Subject = message.Subject;
            mimeMessage.Body = new TextPart("plain")
            {
                Text = message.Body
            };

            using (var client = new SmtpClient())
            {
                client.Connect(SmtpHost, SmtpPort, UseSsl);
                client.Authenticate(EmailAddress, Password);
                try
                {
                    client.Send(mimeMessage);
                    MessageBox.Show("Сообщение отправлено", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сообщение НЕ отправлено\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }

        // Отправка письма с вложением
        public void Send(Message message, string[] attachments)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(EmailAddress, EmailAddress));
            mimeMessage.To.Add(new MailboxAddress(message.To, message.To));
            mimeMessage.Subject = message.Subject;

            var builder = new BodyBuilder();
            builder.TextBody = message.Body;
            foreach (var attachment in attachments)
                builder.Attachments.Add(attachment);
            mimeMessage.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(SmtpHost, SmtpPort, UseSsl);
                client.Authenticate(EmailAddress, Password);

                try
                {
                    client.Send(mimeMessage);
                    MessageBox.Show("Сообщение отправлено", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сообщение НЕ отправлено\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
