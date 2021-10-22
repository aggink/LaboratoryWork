using System;
using System.Net.Sockets;
using System.Text;

namespace NewInfoTech.Lab4.SendAndReceive
{
    public static class SocketMethods
    {
        //Отправка числа int
        public static void SendInt(Socket socket, int value)
        {
            //Представляем число в виде байтов
            byte[] data = BitConverter.GetBytes(value);
            //Отправляем число
            socket.Send(data);
        }

        //Получить число int
        public static int ReceiveInt(Socket socket)
        {
            //Выделяем размер под INT
            byte[] data = new byte[4];
            //Получаем данные
            socket.Receive(data);
            //Конвертируем в INT
            return BitConverter.ToInt32(data, 0);
        }

        //Отправка string произвольной длины
        public static void SendString(Socket socket, string text)
        {
            //Перевод в byte
            byte[] data = Encoding.Unicode.GetBytes(text);
            //Определение размера
            int dataSize_int = data.Length;
            //Представление размера в виде byte
            byte[] dataSize_byte = BitConverter.GetBytes(dataSize_int);
            socket.Send(dataSize_byte);
            socket.Send(data);
        }

        //Получить строку произвольной длины
        public static string ReceiveString(Socket socket)
        {
            //Выделяем место под размер
            byte[] stringSize_byte = new byte[4];
            //Получаем размер
            socket.Receive(stringSize_byte);
            //Перевод размера в int
            int stringSize_int = BitConverter.ToInt32(stringSize_byte, 0);
            //Выделение места под данные
            byte[] data = new byte[stringSize_int];
            //Получаем данные
            socket.Receive(data);
            //Конвертируем в string
            string receivedString = Encoding.Unicode.GetString(data);
            return receivedString;
        }

        //Отправка двухмерного массива
        public static void SendArray(Socket socket, int[,] array)
        {
            //Число строк
            int N = array.GetLength(0);
            //Число столбцов
            int M = array.GetLength(1);

            //Определяем одномерный массив, в котором будут содержаться последовательно все элементы двумерного 
            int[] sendingArray = new int[array.Length];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    sendingArray[i * N + j] = array[i, j];
                }
            }

            byte[] data = new byte[sendingArray.Length * sizeof(int)];
            Buffer.BlockCopy(sendingArray, 0, data, 0, data.Length);

            //Отправляем размерность строки 
            SendInt(socket, M);

            //Отправляем размер массива байтов
            SendInt(socket, data.Length);

            //Отправляем сам массив байтов
            socket.Send(data);
        }

        //Получить двумерный массив
        public static int[,] ReceiveArray(Socket socket)
        {
            //Получаем размерость строки - число столбцов (итогового двумерного массива)
            int M = ReceiveInt(socket);

            //Получаем размерность массива байтов
            int dataSizeBytes = ReceiveInt(socket);

            //Инициализация массива байтов
            byte[] dataBytes = new byte[dataSizeBytes];
            int bytesReaded = socket.Receive(dataBytes);

            //Определение размера массива int
            int dataSize = dataSizeBytes / sizeof(int);
            //Инициализация массива int
            int[] data = new int[dataSize];

            //Заполнение одномерного массива int
            for (int i = 0; i < dataSize; i++)
            {
                data[i] = BitConverter.ToInt32(dataBytes, i * 4);
            }

            //Получаем число строк (итогового двумерного массива)
            int N = dataSize / M;

            //Инициализация двумерного массива
            int[,] sendingData = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    sendingData[i, j] = data[i * N + j];
                }
            }

            return sendingData;
        }
    }
}
