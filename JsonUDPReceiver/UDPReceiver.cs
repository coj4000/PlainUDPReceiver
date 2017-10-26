using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

namespace JsonUDPReceiver
{
    class UDPReceiver
    {
        private readonly int PORT;

        public UDPReceiver(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            using (UdpClient client = new UdpClient(PORT))
            {
                try
                {
                    while (true)
                    {
                        IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, PORT);
                        Console.WriteLine("Modtager: ");
                        byte[] received = client.Receive(ref endpoint);
                        Console.WriteLine("Modtaget fra: " + endpoint.Address + " På port " + endpoint.Port);

                        string str = Encoding.ASCII.GetString(received);
                        Car car = JsonConvert.DeserializeObject<Car>(str);

                        Console.WriteLine("Modtaget: " + car);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }
    }
}
