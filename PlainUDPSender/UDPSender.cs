using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

namespace PlainUDPSender
{
    class UDPSender
    {
        private readonly int PORT;

        public UDPSender(int port)
        {
            PORT = port;
        }

        public void Start()
        {
            Car car = new Car("Tesla", "Red", "EL23400");
            //sender
            string SenderStr = car.ToString();
            byte[] buffer = Encoding.ASCII.GetBytes(SenderStr);

            UdpClient udp = new UdpClient();

            IPEndPoint OtherEP = new IPEndPoint(IPAddress.Broadcast, PORT);
            udp.Send(buffer, buffer.Length, OtherEP);

            IPEndPoint ReceiverEP = new IPEndPoint(IPAddress.Any, 0);
            byte[] receivebuffer = udp.Receive(ref ReceiverEP);
            Console.WriteLine($"UDP datagram received lgt={receivebuffer.Length}");
            string incomingStr = Encoding.ASCII.GetString(receivebuffer);
            Console.WriteLine(incomingStr);
        }

      
    }
}
