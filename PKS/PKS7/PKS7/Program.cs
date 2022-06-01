using System;
using System.Text;
using NativeWifi;

namespace PKS7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WlanClient client = new WlanClient();

            foreach (WlanClient.WlanInterface iface in client.Interfaces)
            {
                Wlan.WlanAvailableNetwork[] networks = iface.GetAvailableNetworkList(0);
                int index = 0;
                foreach (Wlan.WlanAvailableNetwork network in networks)
                {
                    Wlan.Dot11Ssid ssid = network.dot11Ssid;
                    Console.Write(index.ToString() + " ");
                    Console.Write(Encoding.ASCII.GetString(ssid.SSID, 0, (int)ssid.SSIDLength) + " ");
                    Console.Write(network.dot11DefaultCipherAlgorithm.ToString() + " ");
                    Console.WriteLine(network.dot11DefaultAuthAlgorithm.ToString() + " ");
                    Console.Write(network.wlanSignalQuality + "%" + "\n");
                    index++;
                }
            }

            Console.ReadKey();
        }
    }
}
