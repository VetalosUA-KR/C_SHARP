using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //Socket listener, connecter, acc;
            //listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //connecter = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ////Если напишем в аргумент IP 0 то можно будет подключится по любому IP(далее)
            //listener.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1994));
            //listener.Listen(0);
            //new Thread(() =>
            //    {
            //        acc = listener.Accept();
            //        Console.WriteLine("Connected");
            //    }).Start();
            //connecter.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1994));
            //Process.GetCurrentProcess().WaitForExit();

            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            sck.Bind(new IPEndPoint(0, 1994));
            sck.Listen(0);

            Socket acc = sck.Accept();

            byte[] buffer = Encoding.Default.GetBytes("Hello client");
            acc.Send(buffer, 0, buffer.Length, 0);

            buffer = new byte[255];
            int rec = acc.Receive(buffer, 0, buffer.Length, 0);

            Array.Resize(ref buffer, rec);
            Console.WriteLine("Recived: {0}", Encoding.Default.GetString(buffer));

            sck.Close();
            acc.Close();

            Console.Read();

        }
    }
}
