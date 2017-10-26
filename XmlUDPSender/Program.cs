using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlUDPSender
{
    class Program
    {
        private const int PORT = 11002;
        static void Main(string[] args)
        {
            UDPSender sender = new UDPSender(PORT);
            sender.Start();

            Console.ReadLine();
        }
    }
}
