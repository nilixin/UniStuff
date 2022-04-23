using MimeKit;
using Syroot.Windows.IO;

namespace PKS2
{
    public partial class Form3 : Form
    {
        string DownloadedAttachmentsDirectory = KnownFolders.Downloads.Path + "\\PKS2 Attachments";

        public Form3(MimeMessage message)
        {
            InitializeComponent();

            try
            {
                Text = message.From.ToString() + " " + message.Subject;

                lInfo.Text = "Subject: " + message.Subject + "\n";
                lInfo.Text += "Cc: " + message.Cc.ToString() + "\n";
                lInfo.Text += "Bcc: " + message.Bcc.ToString() + "\n";
                lInfo.Text += "BodyParts: " + message.BodyParts.ToString() + "\n";
                lInfo.Text += "Headers: " + message.Headers.ToString() + "\n";

                tbSourceAddress.Text = message.From.ToString();
                tbSubject.Text = message.Subject;

                // Если письмо содержит html-текст, то для его отображения в wvBody скрывается tbBody
                if (!string.IsNullOrEmpty(message.HtmlBody))
                {
                    tbBody.Hide();
                    InitBrowserAsync(message.HtmlBody);
                }
                else
                {
                    tbBody.Text = message.TextBody;
                }

                // Если в письме содержатся вложенные файлы и если не существует папки для их загрузки, она создаётся в папке Загрузки
                if (message.Attachments != null)
                    if (!Directory.Exists(DownloadedAttachmentsDirectory))
                        Directory.CreateDirectory(DownloadedAttachmentsDirectory);

                // Отображение вложений в lvAttachments и их скачивание в DownloadedAttachmentsDirectory
                foreach (var attachment in message.Attachments)
                {
                    if (attachment is MessagePart)
                    {
                        var fileName = attachment.ContentDisposition?.FileName;

                        lvAttachments.Items.Add(new ListViewItem(fileName));

                        var filePath = DownloadedAttachmentsDirectory + "\\" + fileName;
                        var rfc822 = (MessagePart)attachment;

                        using (var stream = File.Create(filePath))
                            rfc822.Message.WriteTo(stream);
                    }
                    else
                    {
                        var part = (MimePart)attachment;
                        var fileName = attachment.ContentDisposition?.FileName;

                        lvAttachments.Items.Add(new ListViewItem(fileName));

                        var filePath = DownloadedAttachmentsDirectory + "\\" + fileName;

                        using (var stream = File.Create(filePath))
                            part.Content.DecodeTo(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось отобразить содержание письма\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        public async void InitBrowserAsync(string htmlContent)
        {
            await EnsureCoreWebView2Async();
            wvBody.NavigateToString(htmlContent);
        }

        private async Task EnsureCoreWebView2Async()
        {
            await wvBody.EnsureCoreWebView2Async(null);
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            wvBody.Dispose();
        }

        private void lvAttachments_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вложения хранятся в папке " + DownloadedAttachmentsDirectory);
        }
    }
}
