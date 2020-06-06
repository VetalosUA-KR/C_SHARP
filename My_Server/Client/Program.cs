using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        private const int port = 8888;
        private const string server = "127.0.0.1";

        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(server, port);
                NetworkStream stream = client.GetStream();

                string msg = "";
                while (msg != "close")
                {
                    Console.WriteLine("enter text: ");
                    msg = Console.ReadLine();
                    byte[] data = Encoding.Default.GetBytes(msg);
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                    Console.WriteLine("sending msg: {0}", data.Length);

                    byte[] dataRead = new byte[256];
                    int length = stream.Read(dataRead, 0, dataRead.Length);
                    string answer = Encoding.Default.GetString(dataRead, 0, length);
                    Console.WriteLine(answer);
                }

                Console.WriteLine("Closed");
                stream.Close();
                client.Close();
                /*byte[] data = new byte[256];
                StringBuilder response = new StringBuilder();
                NetworkStream stream = client.GetStream();

                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable); // пока данные есть в потоке

                Console.WriteLine(response.ToString());

                // Закрываем потоки
                stream.Close();
                client.Close();*/


            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }

            Console.WriteLine("Запрос завершен...");
            Console.Read();
        }
    }
}
