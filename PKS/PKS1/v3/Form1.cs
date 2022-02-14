using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using GSF.Net.TFtp;

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
            TFtpClient client = new TFtpClient(ip);
            var transfer = client.Download(tbFileName.Text); // подключение и запрос на скачивание

            transfer.OnFinished += new TFtpEventHandler(transfer_OnFinshed);
            transfer.OnError += new TFtpErrorHandler(transfer_OnError);

            MemoryStream ms = new MemoryStream();
            transfer.Start(ms); // перенос в поток

            string filePath = tbLocalFolder.Text + "\\" + tbFileName.Text;
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                byte[] bytes = new byte[ms.Length];
                ms.Read(bytes, 0, bytes.Length);
                fs.Write(bytes, 0, bytes.Length);
                ms.Close();
            }
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
            TFtpClient client = new TFtpClient(ip);
            var transfer = client.Upload(tbFileName.Text);

            transfer.OnFinished += new TFtpEventHandler(transfer_OnFinshed);
            transfer.OnError += new TFtpErrorHandler(transfer_OnError);

            MemoryStream ms = new MemoryStream();

            string filePath = tbLocalFolder.Text + "\\" + tbFileName.Text;
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                ms.Write(bytes, 0, (int)fs.Length);
            }

            transfer.Start(ms);
        }

        private void transfer_OnFinshed(ITFtpTransfer transfer)
        {
            MessageBox.Show("OK");
        }

        private void transfer_OnError(ITFtpTransfer transfer, TFtpTransferError error)
        {
            MessageBox.Show("D'oh!\n" + error.ToString());
        }
    }
}
