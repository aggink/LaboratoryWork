using System;
using System.Net;
using System.Net.Sockets;
using NewInfoTech.Lab4.SendAndReceive;

namespace NewInfoTech.Lab4.Server
{
    class Program
    {
        private const string IP = "127.0.0.1";
        private const int Port = 1213;

        static void Main(string[] args)
        {
            // Создаем сокет Tcp/Ip
            Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(IP), Port);

            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            try
            {
                socket.Bind(ip);
                socket.Listen(10);

                // Начинаем слушать соединения
                while (true)
                {
                    Console.WriteLine("Ожидаем соединение через порт {0}", ip);

                    // Программа приостанавливается, ожидая входящее соединение
                    Socket handler = socket.Accept();
                    //string data = null;

                    // Дождались клиента, пытающегося с нами соединиться
                    // Принимаем номер команды
                    int typeOfCommand = SocketMethods.ReceiveInt(handler);
                    // Действие сервера
                    ServerAction(handler, typeOfCommand);

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static void ServerAction(Socket socket, int typeOfCommand)
        {
            throw new NotImplementedException();
        }
    }
}
