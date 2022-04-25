using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UdpClientApp
{
    class Program
    {
        static string RemoteAddress; // хост для отправки данных
        static int RemotePort; // порт для отправки данных
        static int LocalPort; // локальный порт для прослушивания входящих подключений

        static void Main(string[] args)
        {
            try
            {
                // Локальный порт
                bool localPortCorrect = false;
                while (!localPortCorrect)
                {
                    Console.Write("Введите порт для прослушивания: ");
                    try
                    {
                        LocalPort = int.Parse(Console.ReadLine());
                        localPortCorrect = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ошибка. Нечисловое значение.");
                    }
                }

                // Удалённый адрес
                bool remoteAddressCorrect = false;
                while (!remoteAddressCorrect)
                {
                    Console.Write("Введите удаленный адрес для подключения: ");
                    try
                    {
                        RemoteAddress = Console.ReadLine();
                        remoteAddressCorrect = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ошибка. Проверьте правильность ввода адреса.");
                    }
                }

                // Удалённый порт
                bool remotePortCorrect = false;
                while (!remotePortCorrect)
                {
                    Console.Write("Введите удаленный порт для подключения: ");
                    try
                    {
                        RemotePort = int.Parse(Console.ReadLine());
                        remotePortCorrect = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ошибка. Нечисловое значение.");
                    }
                }

                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start();
                Console.WriteLine("Данные приняты.");
                SendMessage(); // отправляем сообщение
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void SendMessage()
        {
            UdpClient sender = new UdpClient(); // создаем UdpClient для отправки сообщений
            try
            {
                while (true)
                {
                    string message = Console.ReadLine(); // сообщение для отправки
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    sender.Send(data, data.Length, RemoteAddress, RemotePort); // отправка
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sender.Close();
            }
        }

        private static void ReceiveMessage()
        {
            UdpClient receiver = new UdpClient(LocalPort); // UdpClient для получения данных
            IPEndPoint remoteIp = null; // адрес входящего подключения
            try
            {
                while (true)
                {
                    byte[] data = receiver.Receive(ref remoteIp); // получаем данные
                    string message = Encoding.Unicode.GetString(data);
                    Console.WriteLine("Собеседник: {0}", message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                receiver.Close();
            }
        }
    }
}