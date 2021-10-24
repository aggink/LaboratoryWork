using NewInfoTech.Lab4.SendAndReceive;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NewInfoTech.Lab4.Client
{
    class Program
    {
        private const string IP = "127.0.0.1";
        private const int Port = 1213;

        private static List<String> menu = new List<string>()
        {
            "МЕНЮ:",
            "Разминка:",
            "11. Отправить с клиента 3 числа(ввести с клавиатуры), получить их возведённые в квадрат(тоже три).",
            "12. Отправить на север 2 строки (ввод с клавиатуры), получить их конкатенацию (сумму).",
            "13. Реализовать следующий протокол: Клиент отправляет серверу команду (число). Если команда == 0, сервер ожидает приёма другого числа, и возвращает квадрат этого числа. Если команда == 1, сервер ждет приема.",
            "Первые задачи:",
            "201. Ввести три числа, вывести наибольшее.",
            "202. Ввести три числа, вывести их произведение.",
            "203. Ввести три числа, вывести их квадраты.",
            "204. Ввести три числа, вывести их сумму.",
            "205. Ввести три числа, вывести их среднее арифметическое.",
            "206. Вводить числа, пока не будет введен 0. Вернуть количество ненулевых чисел.",
            "207. Ввести три числа, вывести количество кратных трем.",
            "208. Ввести число, вывести составляющие его цифры (можно одной строкой, через запятую).",
            "209. Ввести 2 числа, вывести их произведение и сумму.",
            "210. Ввести одно число, вывести его столько же раз (ввожу 5, затем пять раз вывожу 5. Ввожу 3, затем 3 раза вывожу три ). Каждое выведенное число, отдельное сообщение от сервера.",
            "211. Ввести два числа, вывести делится ли второе на первое без остатка.",
            "212. Ввести 4 числа, вывести две суммы –первое + второе и третье + четвертое.",
            "213. Ввести 2 числа, если первое больше второго вернуть их сумму, если нет то их квадраты.",
            "214. Ввести 2 числа, вывести их разность, и если она меньше нуля, вернуть их сумму.",
            "Вторые задачи:",
            "301. Ввести массив числе из N элементов, вывести массив их квадратов, и массив их кубов.",
            "302. Ввести массив из N элементов, вывести массив четных (по номеру) элементов, вывести массив нечетных (по номеру).",
            "303. Ввести массив строк из N строк, ввести букву. Вернуть массив строк, в которых отсутствует введённая буква.",
            "304. Ввести квадратное уравнение (три числа), решить его на сервере и вернуть два корня, или один корень или «корней нет». На клиенте вычислений не проводить!",
            "305. Ввести массив из N чисел, если их сумма больше их количества вернуть три максимальных, если нет вернуть квадраты элементов массива.",
            "306. Ввести массив из N чисел и M строк. Вернуть массив строк, как их декартово произведение. Например, числа 1, 2;строки: «мир», «труд», «май»; результат:«1 мир»,«1 труд», «1 май», «2 мир», «2 труд», «2 май».",
            "307. Ввести массив N*M, передать его на сервер и вернуть обратно.",
            "308. Ввести сгенерировать на сервере случайное число, передать на клиент. Попросить клиента ввести массив строк в размере этого числа, передать массив на сервер и вернуть конкатенацию этих строк.",
            "309. Ввести число, если оно равно 0, отправить на сервер массив из N строк и вернуть их конкатенацию, если не 0, отправить на сервер массив чисел и вернуть их среднее.",
            "310. Ввести строку. Отправить ее на сервер и получить массив из слов этой строки.",
            "311. Ввести три числа, отправить на сервер. Если их сумма четная, клиент должен отправить строку и получить количество символов. Если нет, клиент отправляет массив из N символов и получает их сумму.",
            "312. Ввести строку, вывести количество букв и слов в ней и четные(по номеру) слова.",
            "313. Сгенерировать случайное число. R от 1 до 20, создать массив случайных чисел от -10 до 10 и отправить его на сервер, вывести количество ненулевых элементов.",
            "Для выхода введите любое число не из нумерации меню."
        };

        public static void Main(string[] args)
        {
            try
            {
                bool start = true;

                while (start)
                {
                    Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint ip = new IPEndPoint(IPAddress.Parse(IP), Port);

                    // Соединяем сокет с удаленной точкой
                    socket.Connect(ip);

                    // Выводим текст меню
                    foreach(var item in menu)
                    {
                        Console.WriteLine(item);
                    }

                    // Действия с меню
                    bool type = false;
                    int typeOfCommand = 0;
                    while (!type)
                    {
                        Console.Write("Введите номер пункта меню: ");
                        type = Int32.TryParse(Console.ReadLine(), out typeOfCommand);
                        Console.WriteLine();
                    }

                    switch (typeOfCommand)
                    {
                        //тренировка
                        case 11:
                            TrainingTask1(socket, 11);
                            break;
                        case 12:
                            TrainingTask2(socket, 12);
                            break;
                        case 13:
                            TrainingTask3(socket, 13);
                            break;
                        
                        //первые задачи
                        case 201:
                            ////Ввести три числа, вывести наибольшее
                            Task1_Number3(socket, 201, "Наибольшее число");
                            break;
                        case 202:
                            //Ввести три числа, вывести их произведение.
                            Task1_Number3(socket, 202, "Произведение чисел");
                            break;
                        case 203:
                            //Ввести три числа, вывести их квадраты.
                            TrainingTask1(socket, 11);
                            break;
                        case 204:
                            //Ввести три числа, вывести их сумму.
                            Task1_Number3(socket, 204, "Сумма чисел");
                            break;
                        case 205:
                            //Ввести три числа, вывести их среднее арифметическое.
                            Task2_205(socket, 205, "Среднее арифметическое чисел");
                            break;
                        case 206:
                            //Вводить числа, пока не будет введен 0. Вернуть количество ненулевых чисел.
                            Task2_206(socket, 206);
                            break;
                        case 207:
                            //Ввести три числа, вывести количество кратных трем.
                            Task1_Number3(socket, 207, "Кол-во чисел кратных 3");
                            break;
                        case 208:
                            //Ввести число, вывести составляющие его цифры (можно одной строкой, через запятую).
                            Task1_208(socket, 208);
                            break;
                        case 209:
                            //Ввести 2 числа, вывести их произведение и сумму.
                            Task1_209(socket, 209);
                            break;
                        case 210:
                            //Ввести одно число, вывести его столько же раз
                            Task1_210(socket, 210);
                            break;
                        case 211:
                            //Ввести два числа, вывести делится ли второе на первое без остатка
                            Task1_211(socket, 211);
                            break;
                        case 212:
                            //Ввести 4 числа, вывести две суммы –первое + второе и третье + четвертое.
                            Task1_212(socket, 212);
                            break;
                        case 213:
                            //Ввести 2 числа, если первое больше второго вернуть их сумму, если нет то их квадраты
                            Task1_213(socket, 213);
                            break;
                        case 214:
                            //Ввести 2 числа, вывести их разность, и если она меньше нуля, вернуть их сумму
                            Task1_214(socket, 214);
                            break;

                        //вторые задачи
                        case 301:
                            //Ввести массив числе из N элементов, вывести массив их квадратов, и массив их кубов
                            Task2_ArrayIntOut2(socket, 301, "Массив квадратов данных чисел", "Массив кубов данных чисел");
                            break;
                        case 302:
                            //Ввести массив из N элементов, вывести массив четных (по номеру) элементов, вывести массив нечетных (по номеру)
                            Task2_ArrayIntOut2(socket, 302, "Массив четных элементов (по номеру)", "Массив нечетных элементов (по номеру)");
                            break;
                        case 303:
                            //Ввести массив строк из N строк, ввести букву. Вернуть массив строк, в которых отсутствует введённая буква
                            Task2_303(socket, 303);
                            break;
                        case 304:
                            //Ввести квадратное уравнение (три числа), решить его на сервере и вернуть два корня, или один корень или «корней нет». На клиенте вычислений не проводить!
                            Task2_304(socket, 304);
                            break;
                        case 305:
                            //Ввести массив из N чисел, если их сумма больше их количества вернуть три максимальных, если нет вернуть квадраты элементов массива
                            Task2_305(socket, 305);
                            break;
                        case 306:
                            //Ввести массив из N чисел и M строк. Вернуть массив строк, как их декартово произведение
                            //Например, числа 1, 2;строки: «мир», «труд», «май»; результат:«1 мир»,«1 труд», «1 май», «2 мир», «2 труд», «2 май»
                            Task2_306(socket, 306);
                            break;
                        case 307:
                            //Ввести массив N*M, передать его на сервер и вернуть обратно
                            Task2_307(socket, 307);
                            break;
                        case 308:
                            //Ввести сгенерировать на сервере случайное число, передать на клиент.
                            //Попросить клиента ввести массив строк в размере этого числа, передать массив на сервер и вернуть конкатенацию этих строк
                            Task2_308(socket, 308);
                            break;
                        case 309:
                            //Ввести число, если оно равно 0, отправить на сервер массив из N строк и вернуть их конкатенацию, если не 0, отправить на сервер массив чисел и вернуть их среднее
                            Task2_309(socket, 309);
                            break;
                        case 310:
                            //Ввести строку. Отправить ее на сервер и получить массив из слов этой строки
                            Task2_310(socket, 310);
                            break;
                        case 311:
                            //Ввести три числа, отправить на сервер. Если их сумма четная, клиент должен отправить строку и получить количество символов.
                            //Если нет, клиент отправляет массив из N символов и получает их сумму
                            Task2_311(socket, 311);
                            break;
                        case 312:
                            //Ввести строку, вывести количество букв и слов в ней и четные (по номеру) слова
                            Task2_312(socket, 312);
                            break;
                        case 313:
                            //Сгенерировать случайное число. R от 1 до 20, создать массив случайных чисел от -10 до 10 и отправить его на сервер, вывести количество ненулевых элементов
                            Task2_313(socket, 313);
                            break;
     
                        default:
                            start = false;
                            break;
                    }

                    // Освобождаем сокет
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();

                    Console.WriteLine("Нажмите что-нибудь, чтобы продолжить...");
                    Console.ReadKey();
                    Console.Clear();
                }

                Console.Clear();
                Console.WriteLine("Программа завершена. Нажмите что-нибудь!");
                Console.ReadKey();
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

        #region TrainingTask

        private static void TrainingTask1(Socket socket, int command)
        {
            //Отправить с клиента 3 числа(ввести с клавиатуры), получить их возведённые в квадрат(тоже три).
            Console.Write("Введите 3 числа через пробел: ");
            string text = Console.ReadLine();
            var mas = text.Split(' ');
            int[] masInt = new int[mas.Length];
            
            for(int i = 0; i < mas.Length; ++i)
            {
                masInt[i] = Int32.Parse(mas[i]);
            }

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendArrayInt(socket, masInt);

            var result = SocketMethods.ReceiveArrayInt(socket);

            Console.WriteLine("Результаты: ");
            for (int i = 0; i < result.Length; ++i)
            {
                Console.WriteLine($"{masInt[i]} - {result[i]}");
            }
        }

        private static void TrainingTask2(Socket socket, int command)
        {
            //Отправить на север 2 строки (ввод с клавиатуры), получить их конкатенацию (сумму).
            Console.WriteLine("Введите две строки: ");
            string[] text = new string[2];
            for(int i = 0; i < text.Length; ++i)
            {
                text[i] = Console.ReadLine();
            }

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendString(socket, text[0]);
            SocketMethods.SendString(socket, text[1]);

            var result = SocketMethods.ReceiveString(socket);
            Console.WriteLine("Результаты: " + result);
        }

        private static void TrainingTask3(Socket socket, int command)
        {
            //Реализовать следующий протокол: Клиент отправляет серверу команду (число).
            //Если команда == 0, сервер ожидает приёма другого числа, и возвращает квадрат этого числа. Если команда == 1, сервер ждет приема.
            Console.Write("Введите номер команды 0 или 1: ");
            int value = Int32.Parse(Console.ReadLine());

            SocketMethods.SendInt(socket, command);
            x:
            switch (value)
            {
                case 0:
                    SocketMethods.SendInt(socket, value);
                    Console.Write("Введите число: ");
                    var n = Int32.Parse(Console.ReadLine());
                    SocketMethods.SendInt(socket, n);
                    var n2 = SocketMethods.ReceiveInt(socket);
                    Console.WriteLine("Результаты: ");
                    Console.WriteLine($"{n} - {n2}");
                    break;
                case 1:
                    SocketMethods.SendInt(socket, 1);
                    Console.Write("Введите номер команды 0 или 1: ");
                    value = Int32.Parse(Console.ReadLine());
                    goto x;
            }

        }

        #endregion

        #region Task1

        private static void Task1_Number3(Socket socket, int command, string textResult)
        {
            Console.Write("Введите 3 числа через пробел: ");
            string text = Console.ReadLine();
            var mas = text.Split(' ');
            int[] masInt = new int[mas.Length];
            for(int i = 0; i < masInt.Length; ++i)
            {
                masInt[i] = Int32.Parse(mas[i]);
            }

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendArrayInt(socket, masInt);

            int max = SocketMethods.ReceiveInt(socket);

            Console.WriteLine("Результаты: ");
            Console.WriteLine($"{textResult}: {max}");
        }

        private static void Task2_205(Socket socket, int command, string textResult)
        {
            Console.Write("Введите 3 числа через пробел: ");
            string text = Console.ReadLine();
            var mas = text.Split(' ');
            int[] masInt = new int[mas.Length];
            for (int i = 0; i < masInt.Length; ++i)
            {
                masInt[i] = Int32.Parse(mas[i]);
            }

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendArrayInt(socket, masInt);

            var max = SocketMethods.ReceiveDouble(socket);

            Console.WriteLine("Результаты: ");
            Console.WriteLine($"{textResult}: {max}");
        }

        //Вводить числа, пока не будет введен 0. Вернуть количество ненулевых чисел.
        private static void Task2_206(Socket socket, int command)
        {
            Console.Write("Введите число: ");
            int n = Int32.Parse(Console.ReadLine());
            SocketMethods.SendInt(socket, command);
            while(n != 0)
            {
                SocketMethods.SendInt(socket, n);
                Console.Write("Введите число: ");
                n = Int32.Parse(Console.ReadLine());
            }
            SocketMethods.SendInt(socket, n);
            int result = SocketMethods.ReceiveInt(socket);
            Console.WriteLine("Результаты: ");
            Console.WriteLine($"Количество ненулевых чисел - {result}");
        }

        //Ввести число, вывести составляющие его цифры (можно одной строкой, через запятую).
        private static void Task1_208(Socket socket, int command)
        {
            Console.Write("Введите число: ");
            string text = Console.ReadLine();
            SocketMethods.SendInt(socket, command);
            SocketMethods.SendInt(socket, Int32.Parse(text));

            int[] result = SocketMethods.ReceiveArrayInt(socket);

            Console.WriteLine("Результаты: ");

            Console.Write("Составляющие числа: ");
            for(int i = 0; i < result.Length; ++i)
            {
                Console.Write($"{ result[i]} ");
            }
            Console.WriteLine();
        }

        //Ввести 2 числа, вывести их произведение и сумму.
        private static void Task1_209(Socket socket, int command)
        {
            Console.Write("Введите 2 числа через пробел: ");
            string text = Console.ReadLine();
            var textInt = text.Split(' ');
            int[] masInt = new int[textInt.Length];
            for(int i = 0; i < masInt.Length; ++i)
            {
                masInt[i] = Int32.Parse(textInt[i]);
            }

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendInt(socket, masInt[0]);
            SocketMethods.SendInt(socket, masInt[1]);

            var pro = SocketMethods.ReceiveInt(socket);
            var sum = SocketMethods.ReceiveInt(socket);

            Console.WriteLine("Результаты:");
            Console.WriteLine($"Произведение чисел: {pro}");
            Console.WriteLine($"Сумма чисел: {sum}");
        }

        //Ввести одно число, вывести его столько же раз
        private static void Task1_210(Socket socket, int command)
        {
            Console.Write("Введите число: ");
            string text = Console.ReadLine();
            int value = Int32.Parse(text);

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendInt(socket, value);

            var result = new int[value];
            for(int i = 0; i < value; ++i)
            {
                result[i] = SocketMethods.ReceiveInt(socket);
            }

            Console.Write("Результат: ");
            for(int i = 0; i < result.Length; ++i)
            {
                Console.Write($"{result[i] } ");
            }
            Console.WriteLine();
        }

        //Ввести два числа, вывести делится ли второе на первое без остатка
        private static void Task1_211(Socket socket, int command)
        {
            Console.Write("Введите 2 числа через пробел: ");
            string text = Console.ReadLine();
            var textInt = text.Split(' ');
            int[] masInt = new int[textInt.Length];
            for (int i = 0; i < masInt.Length; ++i)
            {
                masInt[i] = Int32.Parse(textInt[i]);
            }

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendInt(socket, masInt[0]);
            SocketMethods.SendInt(socket, masInt[1]);

            int result = SocketMethods.ReceiveInt(socket);

            Console.WriteLine("Результаты:");
            if (result == 0)
            {
                Console.WriteLine($"Число {masInt[1]} НЕ делится на число {masInt[0]} БЕЗ остатка");
            }
            else
            {
                Console.WriteLine($"Число {masInt[1]} делится на число {masInt[0]} БЕЗ остатка");
            }
        }

        //Ввести 4 числа, вывести две суммы – первое + второе и третье + четвертое.
        private static void Task1_212(Socket socket, int command)
        {
            Console.Write("Введите 4 числа через пробел: ");
            string text = Console.ReadLine();
            var textInt = text.Split(' ');
            int[] masInt = new int[textInt.Length];
            for (int i = 0; i < masInt.Length; ++i)
            {
                masInt[i] = Int32.Parse(textInt[i]);
            }

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendInt(socket, masInt[0]);
            SocketMethods.SendInt(socket, masInt[1]);
            SocketMethods.SendInt(socket, masInt[2]);
            SocketMethods.SendInt(socket, masInt[3]);

            int value12 = SocketMethods.ReceiveInt(socket);
            int value34 = SocketMethods.ReceiveInt(socket);

            Console.WriteLine("Результаты:");
            Console.WriteLine($"{masInt[0]} + {masInt[1]} = {value12}");
            Console.WriteLine($"{masInt[2]} + {masInt[3]} = {value34}");
        }

        private static void Task1_213(Socket socket, int command)
        {
            Console.Write("Введите 2 числа через пробел: ");
            string text = Console.ReadLine();
            var mas = text.Split(' ');
            int[] masInt = new int[mas.Length];
            for (int i = 0; i < masInt.Length; ++i)
            {
                masInt[i] = Int32.Parse(mas[i]);
            }

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendInt(socket, masInt[0]);
            SocketMethods.SendInt(socket, masInt[1]);

            var result = SocketMethods.ReceiveInt(socket);
            Console.WriteLine("Результаты:");
            if (result == 1)
            {
                var a = SocketMethods.ReceiveInt(socket);
                Console.WriteLine($"Сумма чисел - { a }");
            }
            else
            {
                var a = SocketMethods.ReceiveInt(socket);
                var b = SocketMethods.ReceiveInt(socket);
                Console.WriteLine($"{masInt[0]}^2 - { a }");
                Console.WriteLine($"{masInt[1]}^2 - { b }");
            }
        }

        //Ввести 2 числа, вывести их разность, и если она меньше нуля, вернуть их сумму
        private static void Task1_214(Socket socket, int command)
        {
            Console.Write("Введите 2 числа через пробел: ");
            string text = Console.ReadLine();
            var mas = text.Split(' ');
            int[] masInt = new int[mas.Length];
            for (int i = 0; i < masInt.Length; ++i)
            {
                masInt[i] = Int32.Parse(mas[i]);
            }

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendInt(socket, masInt[0]);
            SocketMethods.SendInt(socket, masInt[1]);

            var result = SocketMethods.ReceiveInt(socket);

            Console.WriteLine("Результаты:");
            Console.WriteLine($"Вывести их разность, и если она меньше нуля, вернуть их сумму - { result }");
        }

        #endregion

        #region Task2

        private static void Task2_ArrayIntOut2(Socket socket, int command, string textResult1, string textResult2)
        {
            Console.Write("Введите массив из N элементов через пробел: ");
            string text = Console.ReadLine();
            var mas = text.Split(' ');
            int[] masInt = new int[mas.Length];
            for(int i = 0; i < masInt.Length; ++i)
            {
                masInt[i] = Int32.Parse(mas[i]);
            }

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendArrayInt(socket, masInt);

            var result1 = SocketMethods.ReceiveArrayInt(socket);
            var result2 = SocketMethods.ReceiveArrayInt(socket);

            Console.WriteLine("Результаты: ");

            Console.Write($"{textResult1}: ");
            for(int i = 0; i < result1.Length; ++i)
            {
                Console.Write($"{result1[i]} ");
            }
            Console.WriteLine();

            Console.Write($"{textResult2}: ");
            for (int i = 0; i < result2.Length; ++i)
            {
                Console.Write($"{result2[i]} ");
            }
            Console.WriteLine();
        }

        //Ввести массив строк из N строк, ввести букву. Вернуть массив строк, в которых отсутствует введённая буква
        private static void Task2_303(Socket socket, int command)
        {
            Console.Write("Введите количество строк в массиве: ");
            int N = Int32.Parse(Console.ReadLine());
            string[] array = new string[N];
            for(int i = 0; i < N; ++i)
            {
                array[i] = Console.ReadLine();
            }

            Console.Write("Введите букву: ");
            string letter = Console.ReadLine();

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendArrayString(socket, array);
            SocketMethods.SendString(socket, letter);

            array = SocketMethods.ReceiveArrayString(socket);

            Console.WriteLine("Результаты: ");
            for(int i = 0; i < array.Length; ++i)
            {
                Console.WriteLine(array[i]);
            }
        }

        //Ввести квадратное уравнение (три числа), решить его на сервере и вернуть два корня, или один корень или «корней нет». На клиенте вычислений не проводить!
        private static void Task2_304(Socket socket, int command)
        {
            Console.WriteLine("a * x^2 + b * x + c = 0");
            Console.WriteLine("Ввежите коэффициенты уравнения - a, b, c");
            Console.Write("Введите a: ");
            var a = Double.Parse(Console.ReadLine());
            Console.Write("Введите b: ");
            var b = Double.Parse(Console.ReadLine());
            Console.Write("Введите c: ");
            var c = Double.Parse(Console.ReadLine());

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendDouble(socket, a);
            SocketMethods.SendDouble(socket, b);
            SocketMethods.SendDouble(socket, c);

            int result = SocketMethods.ReceiveInt(socket);

            Console.WriteLine("Результаты: ");
            if(result <= 0)
            {
                Console.WriteLine("Корней нет!");
                return;
            }

            var x1 = SocketMethods.ReceiveDouble(socket);
            var x2 = SocketMethods.ReceiveDouble(socket);

            if (x1 == x2)
            {
                Console.WriteLine($"x = {x1}");
                return;
            }

            Console.WriteLine($"x1 = {x1}");
            Console.WriteLine($"x2 = {x2}");

        }

        //Ввести массив из N чисел, если их сумма больше их количества вернуть три максимальных, если нет вернуть квадраты элементов массива
        private static void Task2_305(Socket socket, int command)
        {
            Console.Write("Введите массив из N чисел через пробел: ");
            var text = Console.ReadLine();
            var masString = text.Split(' ');
            var masInt = new int[masString.Length];
            for(int i = 0; i < masInt.Length; ++i)
            {
                masInt[i] = Int32.Parse(masString[i]);
            }

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendArrayInt(socket, masInt);

            var result = SocketMethods.ReceiveArrayInt(socket);

            Console.WriteLine("Результаты: ");
            for (int i = 0; i < result.Length; ++i)
            {
                Console.Write($"{result[i]} ");
            }
            Console.WriteLine();
        }

        //Ввести массив из N чисел и M строк. Вернуть массив строк, как их декартово произведение
        //Например, числа 1, 2;строки: «мир», «труд», «май»; результат:«1 мир»,«1 труд», «1 май», «2 мир», «2 труд», «2 май»
        private static void Task2_306(Socket socket, int command)
        {
            Console.Write("Введите массив чисел через пробел: ");
            var textInt = Console.ReadLine();

            var mas = textInt.Split(' ');
            int[] masInt = new int[mas.Length];
            for (int i = 0; i < masInt.Length; ++i)
            {
                masInt[i] = Int32.Parse(mas[i]);
            }

            Console.Write("Введите массив слов через пробел: ");
            var text = Console.ReadLine();

            var masString = text.Split(' ');

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendArrayInt(socket, masInt);
            SocketMethods.SendArrayString(socket, masString);

            var result = SocketMethods.ReceiveArrayString(socket);

            Console.WriteLine("Результаты: ");
            for(int i = 0; i < result.Length; ++i)
            {
                Console.WriteLine(result[i]);
            }
        }


        //Ввести массив N*M, передать его на сервер и вернуть обратно
        private static void Task2_307(Socket socket, int command)
        {
            Console.Write("Введите количество строк в массиве: ");
            int N = Int32.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов в массиве: ");
            int M = Int32.Parse(Console.ReadLine());

            int[,] array2 = new int[N, M];
            for(int i = 0; i < N; ++i)
            {
                Console.Write($"Введите числа через пробел (строка {i + 1}): ");
                var text = Console.ReadLine();
                var mas = text.Split(' ');
                for(int j = 0; j < mas.Length && j < M; ++j)
                {
                    array2[i, j] = Int32.Parse(mas[j]);
                }
            }

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendArrayInt2(socket, array2);

            var result = SocketMethods.ReceiveArrayInt2(socket);
            int N1 = result.GetLength(0);
            int M1 = result.GetLength(1);

            Console.WriteLine("Результаты: ");
            for(int i = 0; i < N1; ++i)
            {
                for(int j = 0; j < M1; ++j)
                {
                    Console.Write($"{result[i, j]} ");
                }
                Console.WriteLine();
            }
        }


        //Ввести сгенерировать на сервере случайное число, передать на клиент.
        //Попросить клиента ввести массив строк в размере этого числа, передать массив на сервер и вернуть конкатенацию этих строк
        private static void Task2_308(Socket socket, int command)
        {
            SocketMethods.SendInt(socket, command);
            SocketMethods.SendInt(socket, 1);
            int N = SocketMethods.ReceiveInt(socket);
            Console.WriteLine($"Введите {N} строк:");
            var mas = new string[N];
            for(int i = 0; i < N; ++i)
            {
                Console.Write($"Строка {i + 1}: ");
                mas[i] = Console.ReadLine(); 
            }

            Socket socket2 = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(IP), Port);
            socket2.Connect(ip);

            SocketMethods.SendInt(socket2, command);
            SocketMethods.SendInt(socket2, 2);
            SocketMethods.SendArrayString(socket2, mas);

            var result = SocketMethods.ReceiveString(socket2);
            Console.WriteLine("Результаты: ");
            Console.WriteLine($"{result}");

            socket2.Shutdown(SocketShutdown.Both);
            socket2.Close();
        }

        //Ввести число, если оно равно 0, отправить на сервер массив из N строк и вернуть их конкатенацию, если не 0, отправить на сервер массив чисел и вернуть их среднее
        private static void Task2_309(Socket socket, int command)
        {
            Console.Write("Введите число: ");
            int a = Int32.Parse(Console.ReadLine());

            if(a == 0)
            {
                Console.Write("Введите число строк массива: ");
                int N = Int32.Parse(Console.ReadLine());

                Console.WriteLine($"Введите {N} строк:");
                var mas = new string[N];
                for (int i = 0; i < N; ++i)
                {
                    Console.Write($"Строка {i + 1}: ");
                    mas[i] = Console.ReadLine();
                }

                SocketMethods.SendInt(socket, command);
                SocketMethods.SendInt(socket, 0);
                SocketMethods.SendArrayString(socket, mas);

                var result = SocketMethods.ReceiveString(socket);
                Console.WriteLine("Результаты: ");
                Console.WriteLine($"{result}");
            }
            else
            {
                Console.Write("Введите массив чисел через побел: ");
                var text = Console.ReadLine();
                var mas = text.Split(' ');
                var masInt = new int[mas.Length];
                for(int i = 0; i < masInt.Length; ++i)
                {
                    masInt[i] = Int32.Parse(mas[i]);
                }

                SocketMethods.SendInt(socket, command);
                SocketMethods.SendInt(socket, 1);
                SocketMethods.SendArrayInt(socket, masInt);

                var cr = SocketMethods.ReceiveDouble(socket);
                Console.WriteLine("Результаты: ");
                Console.WriteLine($"Среднее значение чисел в массиве: {cr}");
            }
        }

        //Ввести строку. Отправить ее на сервер и получить массив из слов этой строки
        private static void Task2_310(Socket socket, int command)
        {
            Console.Write("Введите строку: ");
            var text = Console.ReadLine();

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendString(socket, text);

            var result = SocketMethods.ReceiveArrayString(socket);
            Console.WriteLine("Результаты: ");
            for(int i = 0; i < result.Length; ++i)
            {
                Console.WriteLine($"{result[i]}");
            }
            Console.WriteLine();
        }

        //Ввести три числа, отправить на сервер. Если их сумма четная, клиент должен отправить строку и получить количество символов.
        //Если нет, клиент отправляет массив из N символов и получает их сумму
        private static void Task2_311(Socket socket, int command)
        {
            Console.Write("Введите 3 числа через пробел: ");
            var text = Console.ReadLine();
            var mas = text.Split(' ');
            var masInt = new int[3];
            for(int i = 0; i < 3 && i < mas.Length; ++i)
            {
                masInt[i] = Int32.Parse(mas[i]);
            }

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendInt(socket, 1);
            SocketMethods.SendArrayInt(socket, masInt);

            int x = SocketMethods.ReceiveInt(socket);

            Socket socket2 = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(IP), Port);
            socket2.Connect(ip);

            if (x == 2)
            {
                Console.Write("Введите строку: ");
                var str = Console.ReadLine();
                SocketMethods.SendInt(socket2, command);
                SocketMethods.SendInt(socket2, 2);
                SocketMethods.SendString(socket2, str);

                var N = SocketMethods.ReceiveInt(socket2);

                Console.WriteLine("Результаты: ");
                Console.WriteLine($"Количество символов: {N}");
            }
            else
            {
                Console.Write("Введите массив символов через пробел: ");
                var str = Console.ReadLine();
                var masString = str.Split(' ');
                SocketMethods.SendInt(socket2, command);
                SocketMethods.SendInt(socket2, 3);
                SocketMethods.SendArrayString(socket2, masString);

                var sum = SocketMethods.ReceiveString(socket2);

                Console.WriteLine("Результаты: ");
                Console.WriteLine($"Сумма символов: {sum}");
            }

            socket2.Shutdown(SocketShutdown.Both);
            socket2.Close();
        }

        //Ввести строку, вывести количество букв и слов в ней и четные (по номеру) слова
        private static void Task2_312(Socket socket, int command)
        {
            Console.Write("Введите строку: ");
            var text = Console.ReadLine();

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendString(socket, text);

            var Nletter = SocketMethods.ReceiveInt(socket);
            var Nword = SocketMethods.ReceiveInt(socket);
            var result = SocketMethods.ReceiveString(socket);

            Console.WriteLine("Результаты: ");
            Console.WriteLine($"Количество букв: {Nletter}");
            Console.WriteLine($"Количество слов: {Nword}");
            Console.WriteLine($"Четные (по номеру) слова: {result}");
        }

        //Сгенерировать случайное число. R от 1 до 20, создать массив случайных чисел от -10 до 10 и отправить его на сервер, вывести количество ненулевых элементов
        private static void Task2_313(Socket socket, int command)
        {
            var random = new Random();
            int N = random.Next(1, 20);
            int[] masInt = new int[N];
            for(int i = 0; i < N; ++i)
            {
                masInt[i] = random.Next(-10, 10);
            }

            SocketMethods.SendInt(socket, command);
            SocketMethods.SendArrayInt(socket, masInt);
            Console.WriteLine($"Сгенерированное случаное число: {N}");
            Console.WriteLine("Сгенерированный массив: ");
            for(int i = 0; i < masInt.Length; ++i)
            {
                Console.Write($"{masInt[i]} ");
            }
            Console.WriteLine();

            int result = SocketMethods.ReceiveInt(socket);
            Console.WriteLine("Результаты: ");
            Console.WriteLine($"Количество ненулевых элементов: {result}");
        }
        #endregion
    }
}
