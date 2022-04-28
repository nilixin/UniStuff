using MailKit;
using MailKit.Net.Imap;
using MimeKit;
using MailKit.Security;

namespace PKS2
{
    public class ImapLogic
    {
        string EmailAddress = string.Empty;
        string Password = string.Empty;
        string ImapHost = string.Empty;
        int ImapPort = 0;
        SecureSocketOptions Options;

        public ImapLogic(string emailAddress, string password, string imapHost, int imapPort, SecureSocketOptions options = SecureSocketOptions.SslOnConnect)
        {
            EmailAddress = emailAddress;
            Password = password;
            ImapHost = imapHost;
            ImapPort = imapPort;
            Options = options;

            using (var client = new ImapClient())
            {
                client.Connect(ImapHost, ImapPort, Options);
                client.Authenticate(EmailAddress, Password);
                client.Disconnect(true);
            }
        }

        public List<MimeMessage> Retrieve()
        {
            var messages = new List<MimeMessage>();
            
            using (var client = new ImapClient())
            {
                client.Connect(ImapHost, ImapPort, Options);
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
    }
}
