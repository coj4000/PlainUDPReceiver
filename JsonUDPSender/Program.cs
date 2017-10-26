using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUDPSender
{
    class Program
    {
        private const int PORT = 11003;
        static void Main(string[] args)
        {
            Client client = new Client(PORT);
            client.Start();

            Console.ReadLine();
        }
    }
}
