using MimeKit;
using MailKit;
using MailKit.Net.Pop3;
using MailKit.Security;

namespace PKS2
{
    public class PopLogic
    {
        string EmailAddress = string.Empty;
        string Password = string.Empty;
        string PopHost = string.Empty;
        int PopPort = 0;
        SecureSocketOptions Options;

        public PopLogic(string emailAddress, string password, string popHost, int popPort, SecureSocketOptions options = SecureSocketOptions.SslOnConnect)
        {
            EmailAddress = emailAddress;
            Password = password;
            PopHost = popHost;
            PopPort = popPort;
            Options = options;

            using (var client = new Pop3Client())
            {
                client.Connect(PopHost, PopPort, Options);
                client.Authenticate(EmailAddress, Password);
                client.Disconnect(true);
            }
        }

        public void Download()
        {
            using (var client = new Pop3Client())
            {
                client.Connect(PopHost, PopPort, Options);
                client.Authenticate(EmailAddress, Password);
                var count = client.GetMessageCount();

                if (count <= 0) // на сервере не было ни одного сообщения
                {
                    MessageBox.Show("На сервере нет ни одного сообщения.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    client.Disconnect(true);
                    return;
                }

                if (!Directory.Exists(Constants.PopInboxFolder)) // если не существует папки для загрузки сообщений, то создать её
                    Directory.CreateDirectory(Constants.PopInboxFolder);

                for (int i = 0; i < client.Count; i++)
                {
                    var message = client.GetMessage(i);
                    message.WriteTo($"{Constants.PopInboxFolder}{i}.msg");
                    client.DeleteMessage(i);
                }

                client.Disconnect(true);
            }
        }
    }
}
