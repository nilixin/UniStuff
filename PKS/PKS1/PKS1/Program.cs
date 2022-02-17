using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Tftp.Net;

namespace v1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //// connect
            //FtpWebRequest connectRequest = (FtpWebRequest)WebRequest.Create("ftp://localhost");
            //connectRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            //connectRequest.Credentials = new NetworkCredential("User", "");

            //FtpWebResponse connectResponse = (FtpWebResponse)connectRequest.GetResponse();
            //Console.WriteLine("code " + connectResponse.StatusCode.ToString());
            //connectResponse.Close();


            //// tryout
            //FtpWebRequest commandRequest = (FtpWebRequest)WebRequest.Create("ftp://localhost/folder");
            ////commandRequest.Method = "APPE filez.txt";
            //commandRequest.Method = "LIST";
            //commandRequest.Credentials = new NetworkCredential("User", "");



            //FtpWebResponse commandResponse = (FtpWebResponse)commandRequest.GetResponse();
            //Console.WriteLine("code " + commandResponse.StatusCode.ToString());
            //commandResponse.Close();



            IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
            TftpClient client = new TftpClient(ip);

            //Console.WriteLine(client.ToString());


            Console.ReadKey();
        }
    }
}
