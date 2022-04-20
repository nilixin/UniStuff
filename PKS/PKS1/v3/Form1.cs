using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Tftp.Net;

namespace v3
{
    public partial class Form1 : Form
    {
        private TftpClient Client;
        private static AutoResetEvent TransferFinishedEvent = new AutoResetEvent(false);

        public Form1()
        {
            InitializeComponent();

            Client = new TftpClient(tbServerIp.Text);
        }

        // Сохранение пути к файлу
        private void bChoose_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    tbLocalFolder.Text = fbd.SelectedPath;
                }
            }
        }
        
        // Скачивание файла с сервера на локальный компьютер
        private void bDownload_Click(object sender, EventArgs e)
        {
            var transfer = Client.Download(tbFileName.Text);
            string filePath = tbLocalFolder.Text + "\\" + tbFileName.Text;
            var fileStream = File.Create(filePath);

            transfer.OnFinished += new TftpEventHandler(transfer_OnFinshed);
            transfer.OnError += new TftpErrorHandler(transfer_OnError);

            Stream memoryStream = new MemoryStream();
            transfer.Start(memoryStream);

            TransferFinishedEvent.WaitOne();

            memoryStream.Seek(0, SeekOrigin.Begin);
            memoryStream.CopyTo(fileStream);

            memoryStream.Close();
            fileStream.Close();
        }

        // Загрузка файла с локального компьютера на сервер
        private void bUpload_Click(object sender, EventArgs e)
        {
            try
            {
                var transfer = Client.Upload(tbFileName.Text);
                string filePath = tbLocalFolder.Text + "\\" + tbFileName.Text;

                transfer.OnFinished += new TftpEventHandler(transfer_OnFinshed);
                transfer.OnError += new TftpErrorHandler(transfer_OnError);

                var byteArray = File.ReadAllBytes(filePath);

                Stream memoryStream = new MemoryStream(byteArray);
                transfer.Start(memoryStream);

                TransferFinishedEvent.WaitOne();

                memoryStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка передачи:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void transfer_OnError(ITftpTransfer transfer, TftpTransferError error)
        {
            MessageBox.Show("Ошибка передачи:\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            TransferFinishedEvent.Set();
        }

        static void transfer_OnFinshed(ITftpTransfer transfer)
        {
            MessageBox.Show("Передача успешна!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TransferFinishedEvent.Set();
        }
    }
}
