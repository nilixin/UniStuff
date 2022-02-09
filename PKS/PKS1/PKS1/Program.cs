using System;
using System.Net;
using System.Threading.Tasks;

namespace v1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://127.0.0.1/file.txt");
            request.Credentials = new NetworkCredential("User2", "1231");

            Console.ReadKey();
        }
    }
}
