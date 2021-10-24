using System;
using System.Collections.Generic;
using System.Linq;
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
            switch (typeOfCommand)
            {
                //тренировка
                case 11:
                    TrainingTask1(socket);
                    break;
                case 12:
                    TrainingTask2(socket);
                    break;
                case 13:
                    TrainingTask3(socket);
                    break;

                //первые задачи
                case 201:
                    ////Ввести три числа, вывести наибольшее
                    Task1_201(socket);
                    break;
                case 202:
                    //Ввести три числа, вывести их произведение.
                    Task1_202(socket);
                    break;
                case 203:
                    //Ввести три числа, вывести их квадраты.
                    Task1_203(socket);
                    break;
                case 204:
                    //Ввести три числа, вывести их сумму.
                    Task1_204(socket);
                    break;
                case 205:
                    //Ввести три числа, вывести их среднее арифметическое.
                    Task1_205(socket);
                    break;
                case 206:
                    //Вводить числа, пока не будет введен 0. Вернуть количество ненулевых чисел.
                    Task1_206(socket);
                    break;
                case 207:
                    //Ввести три числа, вывести количество кратных трем.
                    Task1_207(socket);
                    break;
                case 208:
                    //Ввести число, вывести составляющие его цифры (можно одной строкой, через запятую).
                    Task1_208(socket);
                    break;
                case 209:
                    //Ввести 2 числа, вывести их произведение и сумму.
                    Task1_209(socket);
                    break;
                case 210:
                    //Ввести одно число, вывести его столько же раз
                    Task1_210(socket);
                    break;
                case 211:
                    //Ввести два числа, вывести делится ли второе на первое без остатка
                    Task1_211(socket);
                    break;
                case 212:
                    //Ввести 4 числа, вывести две суммы –первое + второе и третье + четвертое.
                    Task1_212(socket);
                    break;
                case 213:
                    //Ввести 2 числа, если первое больше второго вернуть их сумму, если нет то их квадраты
                    Task1_213(socket);
                    break;
                case 214:
                    //Ввести 2 числа, вывести их разность, и если она меньше нуля, вернуть их сумму
                    Task1_214(socket);
                    break;

                //вторые задачи
                case 301:
                    //Ввести массив числе из N элементов, вывести массив их квадратов, и массив их кубов
                    Task2_301(socket);
                    break;
                case 302:
                    //Ввести массив из N элементов, вывести массив четных (по номеру) элементов, вывести массив нечетных (по номеру)
                    Task2_302(socket);
                    break;
                case 303:
                    //Ввести массив строк из N строк, ввести букву. Вернуть массив строк, в которых отсутствует введённая буква
                    Task2_303(socket);
                    break;
                case 304:
                    //Ввести квадратное уравнение (три числа), решить его на сервере и вернуть два корня, или один корень или «корней нет». На клиенте вычислений не проводить!
                    Task2_304(socket);
                    break;
                case 305:
                    //Ввести массив из N чисел, если их сумма больше их количества вернуть три максимальных, если нет вернуть квадраты элементов массива
                    Task2_305(socket);
                    break;
                case 306:
                    //Ввести массив из N чисел и M строк. Вернуть массив строк, как их декартово произведение
                    //Например, числа 1, 2;строки: «мир», «труд», «май»; результат:«1 мир»,«1 труд», «1 май», «2 мир», «2 труд», «2 май»
                    Task2_306(socket);
                    break;
                case 307:
                    //Ввести массив N*M, передать его на сервер и вернуть обратно
                    Task2_307(socket);
                    break;
                case 308:
                    //Ввести сгенерировать на сервере случайное число, передать на клиент.
                    //Попросить клиента ввести массив строк в размере этого числа, передать массив на сервер и вернуть конкатенацию этих строк
                    Task2_308(socket);
                    break;
                case 309:
                    //Ввести число, если оно равно 0, отправить на сервер массив из N строк и вернуть их конкатенацию, если не 0, отправить на сервер массив чисел и вернуть их среднее
                    Task2_309(socket);
                    break;
                case 310:
                    //Ввести строку. Отправить ее на сервер и получить массив из слов этой строки
                    Task2_310(socket);
                    break;
                case 311:
                    //Ввести три числа, отправить на сервер. Если их сумма четная, клиент должен отправить строку и получить количество символов.
                    //Если нет, клиент отправляет массив из N символов и получает их сумму
                    Task2_311(socket);
                    break;
                case 312:
                    //Ввести строку, вывести количество букв и слов в ней и четные (по номеру) слова
                    Task2_312(socket);
                    break;
                case 313:
                    //Сгенерировать случайное число. R от 1 до 20, создать массив случайных чисел от -10 до 10 и отправить его на сервер, вывести количество ненулевых элементов
                    Task2_313(socket);
                    break;

                default:
                    break;
            }
        }

        #region Task2

        private static void Task2_313(Socket socket)
        {
            var mas = SocketMethods.ReceiveArrayInt(socket);
            int n = 0;
            for(int i = 0; i < mas.Length; ++i)
            {
                if (mas[i] != 0) n++;
            }
            SocketMethods.SendInt(socket, n);
        }

        private static void Task2_312(Socket socket)
        {
            var text = SocketMethods.ReceiveString(socket);
            var masletter = text.Replace(" ", "");
            var masWord = text.Split(' ');
            SocketMethods.SendInt(socket, masletter.Length);
            SocketMethods.SendInt(socket, masWord.Length);
            string result = "";
            for(int i = 0; i < masWord.Length; ++i)
            {
                if(i % 2 == 0) result += masWord[i] + " ";
            }
            SocketMethods.SendString(socket, result);
        }

        private static void Task2_311(Socket socket)
        {
            int N = SocketMethods.ReceiveInt(socket);
            switch (N)
            {
                case 1:
                    var mas = SocketMethods.ReceiveArrayInt(socket);
                    var sum = mas.Sum();
                    if (sum % 2 == 0) SocketMethods.SendInt(socket, 2);
                    else SocketMethods.SendInt(socket, 0);
                    return;
                case 2:
                    var masString = SocketMethods.ReceiveString(socket);
                    SocketMethods.SendInt(socket, masString.Length);
                    return;
                case 3:
                    var masString2 = SocketMethods.ReceiveArrayString(socket);
                    string text = "";
                    for(int i = 0; i < masString2.Length; ++i)
                    {
                        text += masString2[i];
                    }
                    SocketMethods.SendString(socket, text);
                    return;
            }
        }

        private static void Task2_310(Socket socket)
        {
            var text = SocketMethods.ReceiveString(socket);
            var N = text.Length;
            var mas = text.Split(' ');
            SocketMethods.SendArrayString(socket, mas);
        }

        private static void Task2_309(Socket socket)
        {
            int N = SocketMethods.ReceiveInt(socket);
            switch (N)
            {
                case 0:
                    var mas = SocketMethods.ReceiveArrayString(socket);
                    string text = "";
                    for(int i = 0; i < mas.Length; ++i)
                    {
                        text += mas[i];
                    }
                    SocketMethods.SendString(socket, text);
                    return;
                case 1:
                    var masInt = SocketMethods.ReceiveArrayInt(socket);
                    SocketMethods.SendDouble(socket, masInt.Sum() / (masInt.Length * 1.0));
                    return;
                default:
                    return;
            }
        }

        private static void Task2_308(Socket socket)
        {
            int N = SocketMethods.ReceiveInt(socket);
            switch (N)
            {
                case 1:
                    var random = new Random();
                    SocketMethods.SendInt(socket, random.Next(0, 5));
                    return;
                case 2:
                    var mas = SocketMethods.ReceiveArrayString(socket);
                    string text = "";
                    for(int i = 0; i < mas.Length; ++i)
                    {
                        text += mas[i] + " ";
                    }
                    SocketMethods.SendString(socket, text);
                    return;
                default:
                    return;
            }
        }

        private static void Task2_307(Socket socket)
        {
            var mas = SocketMethods.ReceiveArrayInt2(socket);
            SocketMethods.SendArrayInt2(socket, mas);
        }

        private static void Task2_306(Socket socket)
        {
            var masInt = SocketMethods.ReceiveArrayInt(socket);
            var masString = SocketMethods.ReceiveArrayString(socket);

            int NInt = masInt.Length;
            int NString = masString.Length;

            int length = 0;
            if (NInt > NString) length = NInt;
            else length = NString;

            var result = new string[length];
            for(int i = 0; i < length; ++i)
            {
                if( i < masInt.Length && i < masString.Length)
                {
                    result[i] = masInt[i].ToString() + " " + masString[i];
                }
                else
                {
                    if(i < masInt.Length)
                    {
                        result[i] = masInt[i].ToString() + " ";
                    }
                    if(i < masString.Length)
                    {
                        result[i] = masString[i] + " ";
                    }
                }
            }
            SocketMethods.SendArrayString(socket, result);
        }

        private static void Task2_305(Socket socket)
        {
            var mas = SocketMethods.ReceiveArrayInt(socket);
            int sum = 0;
            for(int i = 0; i < mas.Length; ++i)
            {
                sum += mas[i];
            }
            if(sum > mas.Length)
            {
                int max = mas[0];
                int imax = 0;
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i] > max)
                    {
                        max = mas[i];
                        imax = i;
                        break;
                    }
                }
                int max1 = max;
                int imax1 = imax + 1;
                for (int i = imax; i < mas.Length; i++)
                {
                    if (mas[i] > max)
                    {
                        max1 = mas[i];
                        imax1 = i;
                        break;
                    }
                }
                int max2 = max1;
                int imax2 = imax1 + 1;
                for (int i = imax2; i < mas.Length; i++)
                {
                    if (mas[i] > max)
                    {
                        max2 = mas[i];
                        break;
                    }
                }

                var masMax = new int[] { max, max1, max2 };
                SocketMethods.SendArrayInt(socket, masMax);
            }
            else
            {
                for(int i = 0; i < mas.Length; ++i)
                {
                    mas[i] = (int)Math.Pow(mas[i], 2);
                }
                SocketMethods.SendArrayInt(socket, mas);
            }
        }

        private static void Task2_303(Socket socket)
        {
            var array = SocketMethods.ReceiveArrayString(socket);
            var letter = SocketMethods.ReceiveString(socket);

            for(int i = 0; i < array.Length; ++i)
            {
                array[i] = array[i].Replace(letter, "");
            }

            SocketMethods.SendArrayString(socket, array);
        }

        private static void Task2_304(Socket socket)
        {
            var a = SocketMethods.ReceiveDouble(socket);
            var b = SocketMethods.ReceiveDouble(socket);
            var c = SocketMethods.ReceiveDouble(socket);

            double D = Math.Pow(b, 2) - 4 * a * c;
            if(D >= 0)
            {
                SocketMethods.SendInt(socket, 1);

                double x1 = (-b + Math.Sqrt(D)) / (2 * a);
                double x2 = (-b - Math.Sqrt(D)) / (2 * a);

                SocketMethods.SendDouble(socket, x1);
                SocketMethods.SendDouble(socket, x2);
            }
            else
            {
                SocketMethods.SendInt(socket, -1);
            }
        }

        private static void Task2_302(Socket socket)
        {
            var mas = SocketMethods.ReceiveArrayInt(socket);
            
            int N = mas.Length / 2;
            int e, o;
            e = o = N;

            if (mas.Length % 2 == 1) e++;

            var even = new int[e];
            var odd = new int[o];

            for (int i = 0, j = 0, k = 0; i < mas.Length; ++i)
            {
                if(i % 2 == 0)
                {
                    even[j] = mas[i];
                    j++;
                }
                else
                {
                    odd[k] = mas[i];
                    k++;
                }
            }

            SocketMethods.SendArrayInt(socket, even);
            SocketMethods.SendArrayInt(socket, odd);
        }

        private static void Task2_301(Socket socket)
        {
            var mas = SocketMethods.ReceiveArrayInt(socket);

            var x2 = new int[mas.Length];
            var x3 = new int[mas.Length];
            for(int i = 0; i < mas.Length; ++i)
            {
                x2[i] = (int)Math.Pow(mas[i], 2);
                x3[i] = (int)Math.Pow(mas[i], 3);
            }

            SocketMethods.SendArrayInt(socket, x2);
            SocketMethods.SendArrayInt(socket, x3);
        }

        #endregion

        #region Task1

        private static void Task1_214(Socket socket)
        {
            int a1 = SocketMethods.ReceiveInt(socket);
            int a2 = SocketMethods.ReceiveInt(socket);

            int x = a1 - a2;
            if(x < 0) SocketMethods.SendInt(socket, a1 + a2);
            else SocketMethods.SendInt(socket, x);
        }

        private static void Task1_213(Socket socket)
        {
            int a1 = SocketMethods.ReceiveInt(socket);
            int a2 = SocketMethods.ReceiveInt(socket);

            if (a1 > a2)
            {
                SocketMethods.SendInt(socket, 1);
                SocketMethods.SendInt(socket, a1 + a2);
            }
            else
            {
                SocketMethods.SendInt(socket, 0);
                SocketMethods.SendInt(socket, (int)Math.Pow(a1, 2));
                SocketMethods.SendInt(socket, (int)Math.Pow(a2, 2));
            }
        }

        private static void Task1_212(Socket socket)
        {
            int a1 = SocketMethods.ReceiveInt(socket);
            int a2 = SocketMethods.ReceiveInt(socket);
            int a3 = SocketMethods.ReceiveInt(socket);
            int a4 = SocketMethods.ReceiveInt(socket);
            SocketMethods.SendInt(socket, a1 + a2);
            SocketMethods.SendInt(socket, a3 + a4);
        }

        private static void Task1_211(Socket socket)
        {
            int a1 = SocketMethods.ReceiveInt(socket);
            int a2 = SocketMethods.ReceiveInt(socket);
            if (a1 % a2 == 0) SocketMethods.SendInt(socket, 1);
            else SocketMethods.SendInt(socket, 0);
        }

        private static void Task1_210(Socket socket)
        {
            int x = SocketMethods.ReceiveInt(socket);
            for(int i = 0; i < x; ++i)
            {
                SocketMethods.SendInt(socket, x);
            }
        }

        private static void Task1_209(Socket socket)
        {
            int a1 = SocketMethods.ReceiveInt(socket);
            int a2 = SocketMethods.ReceiveInt(socket);
            SocketMethods.SendInt(socket, a1 * a2);
            SocketMethods.SendInt(socket, a1 + a2);
        }

        private static void Task1_208(Socket socket)
        {
            int x = SocketMethods.ReceiveInt(socket);
            var digit = x.ToString().Distinct().ToArray();
            var mas = new int[digit.Length];
            for(int i = 0; i < mas.Length; ++i)
            {
                mas[i] = Int32.Parse(digit[i].ToString());
            }
            SocketMethods.SendArrayInt(socket, mas);
        }

        private static void Task1_207(Socket socket)
        {
            var arrayInt = SocketMethods.ReceiveArrayInt(socket);
            int x = 0;
            for (int i = 0; i < arrayInt.Length; ++i)
            {
                if (arrayInt[i] % 3 == 0) x++;
            }
            SocketMethods.SendInt(socket, x);
        }

        private static void Task1_206(Socket socket)
        {
            var value = SocketMethods.ReceiveInt(socket);
            int result = 0;
            while(value != 0)
            {
                value = SocketMethods.ReceiveInt(socket);
                result++;
            }
            SocketMethods.SendInt(socket, result);
        }

        private static void Task1_205(Socket socket)
        {
            var arrayInt = SocketMethods.ReceiveArrayInt(socket);
            double sum = 0;
            for (int i = 0; i < arrayInt.Length; ++i)
            {
                sum += arrayInt[i];
            }
            sum /= 3.0;
            SocketMethods.SendDouble(socket, sum);
        }

        private static void Task1_204(Socket socket)
        {
            var arrayInt = SocketMethods.ReceiveArrayInt(socket);
            int sum = 0;
            for (int i = 0; i < arrayInt.Length; ++i)
            {
                sum += arrayInt[i];
            }
            SocketMethods.SendInt(socket, sum);
        }

        private static void Task1_203(Socket socket)
        {
            var arrayInt = SocketMethods.ReceiveArrayInt(socket);
            for(int i = 0; i < arrayInt.Length; ++i)
            {
                arrayInt[i] = (int)Math.Pow(arrayInt[i], 2);
            }
            SocketMethods.SendArrayInt(socket, arrayInt);
        }

        private static void Task1_202(Socket socket)
        {
            var arrayInt = SocketMethods.ReceiveArrayInt(socket);
            int x = 1;
            for(int i = 0; i < arrayInt.Length; ++i)
            {
                x *= arrayInt[i];
            }
            SocketMethods.SendInt(socket, x);
        }

        private static void Task1_201(Socket socket)
        {
            var arrayInt = SocketMethods.ReceiveArrayInt(socket);
            int max = arrayInt.Max();
            SocketMethods.SendInt(socket, max);
        }

        #endregion

        #region TrainingTask

        private static void TrainingTask3(Socket socket)
        {
            var n = SocketMethods.ReceiveInt(socket);
            x:
            switch (n)
            {
                case 0:
                    var n2 = SocketMethods.ReceiveInt(socket);
                    var result = (int)Math.Pow(n2, 2);
                    SocketMethods.SendInt(socket, result);
                    return;
                case 1:
                    n = SocketMethods.ReceiveInt(socket);
                    goto x;
            }
        }

        private static void TrainingTask2(Socket socket)
        {
            var str1 = SocketMethods.ReceiveString(socket);
            var str2 = SocketMethods.ReceiveString(socket);
            SocketMethods.SendString(socket, str1 + str2);
        }

        private static void TrainingTask1(Socket socket)
        {
            var arrayInt = SocketMethods.ReceiveArrayInt(socket);
            for(int i = 0; i < arrayInt.Length; ++i)
            {
                arrayInt[i] = (int)Math.Pow(arrayInt[i], 2);
            }
            SocketMethods.SendArrayInt(socket, arrayInt);
        }

        #endregion
    }
}
