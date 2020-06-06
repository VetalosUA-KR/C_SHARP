using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApp1
{
    class Program
    {
        const int port = 8888;
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);

                server.Start();

                while(true)
                {
                    Console.WriteLine("waitinf for connection...");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Client is connected. Query execution");

                    NetworkStream stream = client.GetStream();

                    string response = "Hello world";

                    byte[] data = Encoding.Default.GetBytes(response);

                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Send message: {0}", response);

                    stream.Close();
                    client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(server != null)
                {
                    server.Stop();
                }
            }
        }
    }
}
