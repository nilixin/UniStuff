using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Tftp.Net;

namespace v3
{
    public partial class Form1 : Form
    {
        private static AutoResetEvent TransferFinishedEvent = new AutoResetEvent(false);

        public Form1()
        {
            InitializeComponent();
        }

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

        private void bDownload_Click(object sender, EventArgs e)
        {
            byte[] ipArr = new byte[4];
            try
            {
                string[] ipStrArr = tbServerIp.Text.Split('.');
                for (int i = 0; i < ipArr.Length; i++)
                {
                    ipArr[i] = byte.Parse(ipStrArr[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IPAddress ip = new IPAddress(ipArr);
            TftpClient client = new TftpClient(ip);

            var transfer = client.Download(tbFileName.Text);

            transfer.OnFinished += new TftpEventHandler(transfer_OnFinshed);
            transfer.OnError += new TftpErrorHandler(transfer_OnError);

            Stream stream = new MemoryStream();
            transfer.Start(stream);

            TransferFinishedEvent.WaitOne();
        }

        private void bUpload_Click(object sender, EventArgs e)
        {
            byte[] ipArr = new byte[4];
            try
            {
                string[] ipStrArr = tbServerIp.Text.Split('.');
                for (int i = 0; i < ipArr.Length; i++)
                {
                    ipArr[i] = byte.Parse(ipStrArr[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IPAddress ip = new IPAddress(ipArr);
            TftpClient client = new TftpClient(ip);

            string finalPath = tbLocalFolder.Text + "\\" + tbFileName.Text;
            var transfer = client.Upload(finalPath);

            transfer.OnFinished += new TftpEventHandler(transfer_OnFinshed);
            transfer.OnError += new TftpErrorHandler(transfer_OnError);

            Stream stream = new MemoryStream();
            transfer.Start(stream);

            TransferFinishedEvent.WaitOne();

        }

        private void transfer_OnFinshed(ITftpTransfer transfer)
        {
            MessageBox.Show("Операция успешна!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TransferFinishedEvent.Set();
        }

        private void transfer_OnError(ITftpTransfer transfer, TftpTransferError error)
        {
            MessageBox.Show("Операция неудачна", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TransferFinishedEvent.Set();
        }
    }
}
