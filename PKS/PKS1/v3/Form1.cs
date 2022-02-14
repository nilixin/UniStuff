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

            // TODO here be download
            IPAddress ip = new IPAddress(ipArr);
            var client = new TftpClient(ip);
            var transfer = client.Download(tbFileName.Text);

            transfer.OnFinished += new TftpEventHandler(transfer_OnFinshed);
            transfer.OnError += new TftpErrorHandler(transfer_OnError);

            Stream ms = new MemoryStream();
            transfer.Start(ms);
            TransferFinishedEvent.WaitOne();

            string filePath = tbLocalFolder.Text + "\\" + tbFileName.Text;
            var fs = new FileStream(filePath, FileMode.Create);
            byte[] bytes = new byte[ms.Length];
            ms.Read(bytes, 0, bytes.Length);
            fs.Write(bytes, 0, bytes.Length);
            ms.Close();
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

            // TODO here be upload
        }

        private void transfer_OnFinshed(ITftpTransfer transfer)
        {
            MessageBox.Show("OK");
            TransferFinishedEvent.Set();
        }

        private void transfer_OnError(ITftpTransfer transfer, TftpTransferError error)
        {
            MessageBox.Show("D'oh!\n" + error.ToString());
            TransferFinishedEvent.Set();
        }
    }
}
