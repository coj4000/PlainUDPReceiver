using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainUDPSender
{
    class Program
    {
        private const int PORT = 11001;
        static void Main(string[] args)
        {
            UDPSender service = new UDPSender(PORT);
            service.Start();

            Console.ReadLine();
        }
    }
}
