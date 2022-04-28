using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using Syroot.Windows.IO;

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
        string Pop3Host = string.Empty;
        int Pop3Port = 0;
        const bool UseSsl = true;

        public string DownloadedMessagesDirectory = KnownFolders.Downloads.Path + "\\PKS2 Pop3Messages";

        public void Initialize(string emailAddress,
            string password,
            string smtpHost,
            int smtpPort,
            string imapHost,
            int imapPort)
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

        public void InitializePop(string emailAddress,
            string password,
            string smtpHost,
            int smtpPort,
            string pop3Host,
            int pop3Port)
        {
            using (var client = new Pop3Client())
            {
                client.Connect(pop3Host, pop3Port, UseSsl);
                client.Authenticate(emailAddress, password);
                client.Disconnect(true);
            }

            EmailAddress = emailAddress;
            Password = password;
            SmtpHost = smtpHost;
            SmtpPort = smtpPort;
            Pop3Host = pop3Host;
            Pop3Port = pop3Port;
        }

        // Подгрузка писем
        public List<MimeMessage> RetrieveInbox()
        {
            List<MimeMessage> messages = new();


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

        // Загрузка писем с помощью протокола POP3
        public void DownloadInboxPop()
        {
            using (var client = new Pop3Client())
            {
                client.Connect(Pop3Host, Pop3Port, UseSsl);
                client.Authenticate(EmailAddress, Password);
                var count = client.GetMessageCount();

                if (count > 0) // если клиент вернул хотя бы одно сообщение и не существует папки загрузки сообщений, то создать её
                    if (!Directory.Exists(DownloadedMessagesDirectory))
                        Directory.CreateDirectory(DownloadedMessagesDirectory);

                for (int i = 0; i < client.GetMessageCount(); i++)
                {
                    var message = client.GetMessage(i);

                    message.WriteTo(string.Format("{0}\\{1}.msg", DownloadedMessagesDirectory, i));
                }

                client.Disconnect(true);
            }
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
