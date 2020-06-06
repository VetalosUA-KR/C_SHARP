using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace newClient
{
    class Program
    {
        static Socket sck;
        static void Main(string[] args)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            try
            {
                sck.Connect(localEndPoint);
            }
            catch
            {
                Console.Write("Unable to connect to remote end point! \r\n");
                Main(args);
            }
            Console.Write("enter text: ");
            string txt = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(txt);

            sck.Send(data);
            Console.Write("data send! \r\n");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            sck.Close();

        }
    }
}
