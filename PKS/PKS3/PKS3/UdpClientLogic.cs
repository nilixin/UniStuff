using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PKS3
{
    public class UdpClientLogic
    {
        int LocalPort;
        IPAddress RemoteIp;
        int RemotePort;

        public UdpClientLogic(int localPort, IPAddress remoteIp, int remotePort)
        {
            LocalPort = localPort;
            RemoteIp = remoteIp;
            RemotePort = remotePort;
        }

        public string? Connect()
        {
            UdpClient udpClient = new UdpClient();
            try
            {
                udpClient.Connect(RemoteIp, RemotePort);
                return udpClient.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                udpClient.Close();
            }
        }

        public string Receive()
        {
            UdpClient receiver = new(LocalPort);
            IPEndPoint remoteAddress = null;

            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteAddress);
                    string message = Encoding.UTF8.GetString(data);
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
