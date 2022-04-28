using MimeKit;
using System.Diagnostics;

namespace PKS2
{
    public partial class MessageForm : Form
    {
        public MessageForm(MimeMessage mimeMessage)
        {
            InitializeComponent();

            try
            {
                Text = $"{mimeMessage.From} {mimeMessage.Subject}";

                tbProperties.Text += $"Headers:\r\n{mimeMessage.Headers}\r\n";

                tbFrom.Text = mimeMessage.From.ToString();
                tbSubject.Text = mimeMessage.Subject;

                // Если письмо содержит html-текст, то для его отображения в wvBody скрывается tbBody
                if (!string.IsNullOrEmpty(mimeMessage.HtmlBody))
                {
                    InitBrowserAsync(mimeMessage.HtmlBody);
                }
                else
                {
                    wvBody.Hide();
                    tbBody.Text = mimeMessage.TextBody;
                }

                // Если в письме содержатся вложенные файлы и если не существует папки для их загрузки, она создаётся в папке Загрузки
                if (mimeMessage.Attachments != null)
                    if (!Directory.Exists(Constants.ReceivedAttachmentsDirectory))
                        Directory.CreateDirectory(Constants.ReceivedAttachmentsDirectory);

                // Отображение вложений в lvPinned и их скачивание в DownloadedAttachmentsDirectory
                foreach (var attachment in mimeMessage.Attachments)
                {
                    if (attachment is MessagePart)
                    {
                        var fileName = attachment.ContentDisposition?.FileName;

                        lvPinned.Items.Add(new ListViewItem(fileName));

                        var filePath = $"{Constants.ReceivedAttachmentsDirectory}{fileName}";
                        var rfc822 = (MessagePart)attachment;

                        using (var stream = File.Create(filePath))
                            rfc822.Message.WriteTo(stream);
                    }
                    else
                    {
                        var part = (MimePart)attachment;
                        var fileName = attachment.ContentDisposition?.FileName;

                        lvPinned.Items.Add(new ListViewItem(fileName));

                        var filePath = $"{Constants.ReceivedAttachmentsDirectory}{fileName}";

                        using (var stream = File.Create(filePath))
                            part.Content.DecodeTo(stream);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void InitBrowserAsync(string htmlContent)
        {
            await EnsureCoreWebView2Async();
            wvBody.NavigateToString(htmlContent);
        }

        private async Task EnsureCoreWebView2Async()
        {
            await wvBody.EnsureCoreWebView2Async(null);
        }

        private void MessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            wvBody.Dispose();
        }

        private void lvPinned_Click(object sender, EventArgs e)
        {
            var selectedItem = lvPinned.SelectedItems[0];
            string filePath = $"{Constants.ReceivedAttachmentsDirectory}{selectedItem.Text}";

            using (var fileOpener = new Process())
            {
                fileOpener.StartInfo.FileName = "explorer";
                fileOpener.StartInfo.Arguments = "\"" + filePath + "\"";
                fileOpener.Start();
            }
        }
    }
}
