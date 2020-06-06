using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpListener serverSocket = new TcpListener(IPAddress.Any, 7000);
                Console.WriteLine("Server started");
                serverSocket.Start();
                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                while(true)
                {
                    NetworkStream stream = clientSocket.GetStream();

                    //Слушаем клиента
                    byte[] bytes = new byte[256];
                    int length = stream.Read(bytes, 0, bytes.Length);
                    string request = Encoding.ASCII.GetString(bytes, 0, length);
                    Console.WriteLine("Got request: "+request);

                    if(request == "close")
                    {
                        Console.WriteLine("user is disconnected !");
                        clientSocket.Close();
                    }

                    //Отправляем ответ клиенту
                    string message = "Length of you request: "+request.Length;
                    bytes = Encoding.ASCII.GetBytes(message);
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                    Console.WriteLine("Sent message: " + message);
                }
                serverSocket.Stop();
                Console.WriteLine("Srever stopped");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Console.ReadKey();

        }
    }
}
