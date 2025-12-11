using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Рыбченко В.Л. 2КСОР");
            Console.WriteLine("Лабораторная работа №8");
            Console.WriteLine("Вариант №9\n");

            Console.Write("Выберите номер задания (1–7) или 0 для выхода: ");

            if (!int.TryParse(Console.ReadLine(), out int task))
            {
                Console.WriteLine("Ошибка: введите число!");
                Wait();
                continue;
            }

            switch (task)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break;
                case 6: Task6(); break;
                case 7: Task7(); break;

                case 0:
                    Console.WriteLine("Выход из программы...");
                    return;

                default:
                    Console.WriteLine("Такого задания нет!");
                    break;
            }

            Wait();
        }
    }

    static void Wait()
    {
        Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();
    }

    // ---------- TASK 1 ----------
    static void Task1()
    {
        Console.Write("\nЗадание 1: Найти сумму положительных нечетных чисел в определнном диапазоне");
        Console.Write("\n\nВведите верхний предел диапазона: ");

        if (!int.TryParse(Console.ReadLine(), out int limit))
        {
            Console.WriteLine("Ошибка: введите число!");
            return;
        }

        if (limit <= 0)
        {
            Console.WriteLine("Предел должен быть больше нуля.");
            return;
        }

        int sum = 0;
        for (int i = 1; i < limit; i += 2)
            sum += i;

        Console.WriteLine($"Сумма положительных нечётных чисел, меньших {limit}, равна {sum}");
    }

    static void Task2()
    {
        Console.Write("\nЗадание 2: Известны данные о стоимости каждого товара из группы. \r\nНайти общую стоимость тех товаров, которые стоят дороже 1000 \r\nрублей (количество таких товаров неизвестно). ");
        double totalSum = 0;
        Console.WriteLine("\n\nВведите стоимости товаров. Для завершения введите отрицательное число.");

        while (true)
        {
            Console.Write("Стоимость товара: ");
            if (double.TryParse(Console.ReadLine(), out double price))
            {
                if (price < 0)
                {
                    // Завершение ввода
                    break;
                }

                if (price > 1000)
                {
                    totalSum += price;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
            }
        }

        Console.WriteLine($"Общая стоимость товаров, дороже 1000 рублей: {totalSum} рублей");
    }
    static void Task3()
    {

        Console.Write("\nЗадание 3: Дана последовательность из m единиц и нулей. \r\nРассмотреть отрезки nэтой последовательности \r\n(подпоследовательности идущих подряд чисел), состоящие из \r\nодних нулей. Получить наименьшую из длин рассматриваемых \r\nотрезков.");
        Console.WriteLine("\n\nВведите последовательность нулей и единиц, разделённых пробелами:");
        string input = Console.ReadLine();
        string[] parts = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        List<int> sequence = new List<int>();
        foreach (var part in parts)
        {
            if (int.TryParse(part, out int num) && (num == 0 || num == 1))
            {
                sequence.Add(num);
            }
            else
            {
                Console.WriteLine($"Некорректный ввод: {part}. Введите только 0 или 1.");
                return;
            }
        }

        int minLength = int.MaxValue;
        int currentLength = 0;
        bool zeroSegmentExists = false;

        foreach (int num in sequence)
        {
            if (num == 0)
            {
                currentLength++;
                zeroSegmentExists = true;
            }
            else
            {
                if (currentLength > 0 && currentLength < minLength)
                {
                    minLength = currentLength;
                }
                currentLength = 0;
            }
        }

        // Проверка для последнего сегмента
        if (currentLength > 0 && currentLength < minLength)
        {
            minLength = currentLength;
        }

        if (zeroSegmentExists)
        {
            Console.WriteLine($"Наименьшая длина отрезка, состоящего только из нулей: {minLength}");
        }
        else
        {
            Console.WriteLine("В последовательности нет нулей.");
        }
    }
    static void Task4()
    {
        Console.Write("\nЗадание 4: Известно количество осадков, выпавших за каждый день \r\nфевраля. Верно ли, что общее количество осадков за этот месяц \r\nпревысило соответствующее количество прошлого года?");
        const int daysInFebruary = 28;
        int[] currentYearPrecipitation = new int[daysInFebruary];
        int[] lastYearPrecipitation = new int[daysInFebruary];

        Console.WriteLine("\n\nВведите количество осадков за каждый день февраля текущего года:");
        int totalCurrentYear = 0;
        for (int i = 0; i < daysInFebruary; i++)
        {
            Console.Write($"День {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out currentYearPrecipitation[i]) || currentYearPrecipitation[i] < 0)
            {
                Console.WriteLine("Некорректный ввод. Введите неотрицательное число.");
                Console.Write($"День {i + 1}: ");
            }
            totalCurrentYear += currentYearPrecipitation[i];
        }

        Console.WriteLine("Введите количество осадков за каждый день февраля прошлого года:");
        int totalLastYear = 0;
        for (int i = 0; i < daysInFebruary; i++)
        {
            Console.Write($"День {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out lastYearPrecipitation[i]) || lastYearPrecipitation[i] < 0)
            {
                Console.WriteLine("Некорректный ввод. Введите неотрицательное число.");
                Console.Write($"День {i + 1}: ");
            }
            totalLastYear += lastYearPrecipitation[i];
        }

        if (totalCurrentYear > totalLastYear)
        {
            Console.WriteLine("Общее количество осадков за февраль этого года превысило прошлогоднее.");
        }
        else
        {
            Console.WriteLine("Общее количество осадков за февраль этого года не превысило прошлогоднее.");
        }
    }
    static void Task5()
    {
        Console.Write("\nЗадание 5: Напечатать числа в виде следующей таблицы: ");

        int n = 5;

        // а) Таблица с увеличением количества чисел "5"
        Console.WriteLine("\n\nа)");
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("5 ");
            }
            Console.WriteLine();
        }

        Console.WriteLine(); // пустая строка для разделения

        // б) Таблица с убывающим количеством чисел "1"
        Console.WriteLine("б)");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i; j++)
            {
                Console.Write("1 ");
            }
            Console.WriteLine();
        }
    }
    static void Task6()
    {
        Console.Write("\nЗадание 6: Раньше в соревнованиях по фигурному катанию \r\nспортсмены выступали в трех видах многоборья (обязательная, \r\nкороткая и произвольная программы). Известны результаты (в \r\nбаллах) каждого из 15 участников соревнований: \n\nа) среднее количество баллов, полученных каждым \r\nспортсменом; \r\nб) среднее количество баллов, полученных по каждому виду \r\nпрограммы. ");
        int numberOfParticipants = 15;
        string[] programs = { "Обязательная", "Короткая", "Произвольная" };
        double[,] scores = new double[numberOfParticipants, 3];

        // Ввод данных
        for (int i = 0; i < numberOfParticipants; i++)
        {
            Console.WriteLine($"\n\nВведите результаты спортсмена {i + 1}:");
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"  {programs[j]} программа: ");
                scores[i, j] = Convert.ToDouble(Console.ReadLine());
            }
        }

        // a) Среднее количество баллов каждого спортсмена
        Console.WriteLine("\nСредние баллы каждого спортсмена:");
        for (int i = 0; i < numberOfParticipants; i++)
        {
            double sum = 0;
            for (int j = 0; j < 3; j++)
            {
                sum += scores[i, j];
            }
            double average = sum / 3;
            Console.WriteLine($"Спортсмен {i + 1}: {average:F2}");
        }

        // б) Среднее количество баллов по каждому виду программы
        Console.WriteLine("\nСредние баллы по каждому виду программы:");
        for (int j = 0; j < 3; j++)
        {
            double sum = 0;
            for (int i = 0; i < numberOfParticipants; i++)
            {
                sum += scores[i, j];
            }
            double average = sum / numberOfParticipants;
            Console.WriteLine($"{programs[j]} программа: {average:F2}");
        }
    }
    static void Task7()
    {
        Console.Write("\nЗадание 7: Найти натуральное число из интервала от a до b, у \r\nкоторого количество делителей максимально. Если таких чисел \r\nнесколько, то должно быть найдено: \r\nа) максимальное из них; \r\nб) минимальное из них.");

        {
            Console.Write("\n\nВведите значение a: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите значение b: ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("Выберите вариант:");
            Console.WriteLine("1 - Найти число с максимальным количеством делителей, при равенстве взять максимальное");
            Console.WriteLine("2 - Найти число с максимальным количеством делителей, при равенстве взять минимальное");
            int choice = int.Parse(Console.ReadLine());

            int maxDivisorsCount = -1;
            int resultNumber = a;

            for (int num = a; num <= b; num++)
            {
                int countDivisors = CountDivisors(num);

                if (countDivisors > maxDivisorsCount)
                {
                    maxDivisorsCount = countDivisors;
                    resultNumber = num;
                }
                else if (countDivisors == maxDivisorsCount)
                {
                    if (choice == 1)
                    {
                        // взять максимальное число
                        if (num > resultNumber)
                            resultNumber = num;
                    }
                    else if (choice == 2)
                    {
                        // взять минимальное число
                        if (num < resultNumber)
                            resultNumber = num;
                    }
                }
            }

            Console.WriteLine($"Ответ: {resultNumber} (Количество делителей: {maxDivisorsCount})");
        }

        static int CountDivisors(int n)
        {
            int count = 0;
            int sqrtN = (int)Math.Sqrt(n);
            for (int i = 1; i <= sqrtN; i++)
            {
                if (n % i == 0)
                {
                    count += 2; // i и n/i
                }
            }
            if (sqrtN * sqrtN == n)
                count--; // если квадрат, то посчитали лишний раз
            return count;
        }
    }

}