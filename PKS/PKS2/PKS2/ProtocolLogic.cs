using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit.Net.Imap;

namespace PKS2
{
    internal class ProtocolLogic
    {
        string EmailAddress = string.Empty;
        string Password = string.Empty;
        string SmtpHost = string.Empty;
        int SmtpPort = 0;
        string ImapHost = string.Empty;
        int ImapPort = 0;
        const bool UseSsl = true;

        public ProtocolLogic(string emailAddress, string password, string smtpHost, int smtpPort, string imapHost, int imapPort)
        {
            using (var client = new SmtpClient())
            {
                client.Connect(smtpHost, smtpPort, UseSsl);
                client.Authenticate(emailAddress, password);
                client.Disconnect(true);
            }

            EmailAddress = emailAddress;
            Password = password;
            SmtpHost = smtpHost;
            SmtpPort = smtpPort;
            ImapHost = imapHost;
            ImapPort = imapPort;
        }

        // Подгрузка писем
        public List<MimeMessage> RetrieveInbox()
        {
            List<MimeMessage> messages = new List<MimeMessage>();


            using (var client = new ImapClient())
            {
                client.Connect(ImapHost, ImapPort, UseSsl);
                client.Authenticate(EmailAddress, Password);

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);
                
                for (int i = 0; i < inbox.Count; i++)
                {
                    var message = inbox.GetMessage(i);
                    messages.Add(message);
                }
                
                client.Disconnect(true);
            }

            return messages;
        }

        // Отправка письма БЕЗ ВЛОЖЕНИЯ
        public void Send(SentMessage emailMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(EmailAddress, EmailAddress));
            message.To.Add(new MailboxAddress(emailMessage.DestinationAddress, emailMessage.DestinationAddress));
            message.Subject = emailMessage.Subject;
            message.Body = new TextPart("plain")
            {
                Text = emailMessage.Body
            };

            using (var client = new SmtpClient())
            {
                client.Connect(SmtpHost, SmtpPort, UseSsl);
                client.Authenticate(EmailAddress, Password);
                try
                {
                    client.Send(message);
                    MessageBox.Show("Сообщение отправлено", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сообщение НЕ отправлено\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                client.Disconnect(true);
            }
        }

        // Отправка письма С ВЛОЖЕНИЕМ
        public void Send(SentMessage emailMessage, string attachedFilePath)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(EmailAddress, EmailAddress));
            message.To.Add(new MailboxAddress(emailMessage.DestinationAddress, emailMessage.DestinationAddress));
            message.Subject = emailMessage.Subject;

            var builder = new BodyBuilder();
            builder.TextBody = emailMessage.Body;
            builder.Attachments.Add(attachedFilePath);
            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(SmtpHost, SmtpPort, UseSsl);
                client.Authenticate(EmailAddress, Password);
                try
                {
                    client.Send(message);
                    MessageBox.Show("Сообщение отправлено", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сообщение НЕ отправлено\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                client.Disconnect(true);
            }
        }
    }
}
