using ModelLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlUDPReceiver
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
            //Receive
            byte[] buffer = new byte[2048];

            try
            {
                UdpClient udp = new UdpClient(PORT);
                IPEndPoint senderEP = new IPEndPoint(IPAddress.Any, 0);

                buffer = udp.Receive(ref senderEP);
                Console.WriteLine($"UDP datagram received lgt={buffer.Length}");
                Console.WriteLine($"Afsender er {senderEP.Address}, port {senderEP.Port}");

                // convert bytes to string
                string incommingStr = Encoding.ASCII.GetString(buffer);
                Console.WriteLine();
                Console.WriteLine("Before decerialise");
                Console.WriteLine(incommingStr);
                using (StringReader reader = new StringReader(incommingStr))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Car));
                    Console.WriteLine(reader.ReadLine());
                    Car car = (Car)serializer.Deserialize(reader);
                    Console.WriteLine();
                    Console.WriteLine("Deserialised Car:");
                    Console.WriteLine(car.ToString());
                }
                //Send Back
                string outgoingStr = incommingStr.ToUpper();
                byte[] outBuffer = Encoding.ASCII.GetBytes(outgoingStr);

                udp.Send(outBuffer, outBuffer.Length, senderEP);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

          
        }
    }
}
