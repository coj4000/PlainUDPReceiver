using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

namespace JsonUDPSender
{
    class Client
    {
        private readonly int PORT;

        public Client(int port)
        {
            PORT = port;
        }

        public void Start()
        {
           Car car = new Car("Tesla", "red", "EL23400");

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, PORT);
            UdpClient udp = new UdpClient();

            string sendcar = JsonConvert.SerializeObject(car);

            byte[] data = Encoding.ASCII.GetBytes(sendcar);

            while (true)
            {
                udp.Send(data, data.Length, endPoint);

                Console.WriteLine($"UDP Data send Length: {sendcar.Length}");
                Console.WriteLine();
                Console.WriteLine("object: " + sendcar);
                System.Threading.Thread.Sleep(1500);
            }
        }

    }
}
