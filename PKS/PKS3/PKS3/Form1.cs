using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PKS3
{
    public partial class Form1 : Form
    {
        int LocalPort;
        string RemoteAddress;
        int RemotePort;

        public Form1()
        {
            InitializeComponent();

            tbLocalPort.Text = "8001";
            tbRemoteAddress.Text = "127.0.0.1";
            tbRemotePort.Text = "8002";

            bSend.Enabled = false;

            Thread receiveThread = new(new ThreadStart(ReceiveMessage));
            receiveThread.Start();
        }

        private void bCheckConnection_Click(object sender, EventArgs e)
        {
            try
            {
                LocalPort = int.Parse(tbLocalPort.Text);
                RemoteAddress = tbRemoteAddress.Text;
                RemotePort = int.Parse(tbRemotePort.Text);

                bSend.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось внести данные\n\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Send
        private void bSend_Click(object sender, EventArgs e)
        {
            UdpClient udpSender = new UdpClient();
            try
            {
                string message = tbMessage.Text;
                byte[] data = Encoding.UTF8.GetBytes(message);
                udpSender.Send(data, data.Length, RemoteAddress, RemotePort);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось отправить\n\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                udpSender.Close();
            }
        }

        // Receive
        private void ReceiveMessage()
        {
            UdpClient udpReceiver = new(LocalPort);
            IPEndPoint? remoteIp = null;

            try
            {
                while (true)
                {
                    byte[] data = udpReceiver.Receive(ref remoteIp);
                    string message = Encoding.UTF8.GetString(data);
                    tbChat.Text += message + "\r\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось получить\n\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                udpReceiver.Close();
            }
        }
    }
}