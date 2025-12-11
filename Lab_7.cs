using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Рыбченко В.Л. 2КСОР\nЛабораторная работа №7\nВариант №9");
            Console.WriteLine("\nВыберите номер задания (1–10) или 0 для выхода:");
            int task;
            if (!int.TryParse(Console.ReadLine(), out task))
            {
                Console.WriteLine("Введите число!");
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
                case 8: Task8(); break;
                case 9: Task9(); break;
                case 10: Task10(); break;
                case 0: Console.WriteLine("Выход из программы..."); return;
                default: Console.WriteLine("Такого задания нет!"); break;
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы выбрать другое задание...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void Task1()
    {
        Console.WriteLine("Задание 1: Напечатать таблицу стоимости 50, 100, 150, …, 1000 г сыра (стоимость 1 кг сыра вводится с клавиатуры).");
        Console.Write("Введите стоимость 1 кг сыра: ");
        double price = double.Parse(Console.ReadLine());
        for (int g = 50; g <= 1000; g += 50)
        {
            double cost = price * g / 1000;
            Console.WriteLine($"{g} г — {cost:F2}");
        }
    }

    static void Task2()
    {
        Console.WriteLine("Задание 2:  Вычислить сумму: x+x3/3+…+x11/11. Условный оператор \r\nи операцию возведения в степень не использовать.");
        Console.Write("Введите x: ");
        double x = double.Parse(Console.ReadLine());
        double sum = 0, xPower = x;
        for (int i = 1; i <= 11; i += 2)
        {
            if (i > 1) xPower *= x * x; // x^3, x^5, x^7 ...
            sum += xPower / i;
        }
        Console.WriteLine($"Сумма = {sum}");
    }

    static void Task3()
    {
        Console.WriteLine("Задание 3: Даны числа a1, a2, …, a10. Определить их среднее \r\nарифметическое.");
        double sum = 0;
        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"Введите a{i}: ");
            double a = double.Parse(Console.ReadLine());
            sum += a;
        }
        Console.WriteLine($"Среднее арифметическое = {sum / 10}");
    }

    static void Task4()
    {
        Console.WriteLine("Задание 4: Дано вещественное число а и натуральное число n. \r\nВычислить значения a1, a2, a3, …, an. Операцию возведения в \r\nстепень не использовать.");
        Console.Write("Введите a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Введите n: ");
        int n = int.Parse(Console.ReadLine());

        double term = a;
        for (int i = 1; i <= n; i++)
        {
            if (i > 1) term *= a;
            Console.WriteLine($"a^{i} = {term}");
        }
    }

    static void Task5()
    {
        Console.WriteLine("Задание 5: Около стены наклонно стоит палка длиной 4,5 м. Один ее \r\nконец находится на расстоянии 3 м от стены. Нижний конец палки \r\nначинает скользить в плоскости, перпендикулярной стене. \r\nОпределить значение угла между палкой и полом (в градусах) с \r\nмомента начала скольжения до падения палки через каждые 0,2 м.");
        double L = 4.5, startX = 3;
        for (double x = startX; x <= L; x += 0.2)
        {
            double angleRad = Math.Asin(x / L);
            double angleDeg = angleRad * 180 / Math.PI;
            Console.WriteLine($"x = {x:F1} м → угол = {angleDeg:F2}°");
        }
    }

    static void Task6()
    {
        Console.WriteLine("Задание 6: Дано вещественное число а (9 < a < 10). Найти такое \r\nнаименьшее n, что 1+1/2+1/3+…+1/n > a.");
        Console.Write("Введите a (9 < a < 10): ");
        double a = double.Parse(Console.ReadLine());
        double sum = 0;
        int n = 0;
        while (sum <= a)
        {
            n++;
            sum += 1.0 / n;
        }
        Console.WriteLine($"Наименьшее n = {n}");
    }

    static void Task7()
    {
        Console.WriteLine("Задание 7: Дано натуральное число. Определить: \r\nа) сколько раз в нем встречается цифра а; \r\nб) количество его цифр, кратных z (значение z вводится с \r\nклавиатуры; z=2,3,4); \r\nв) сумму его цифр, больших a (значение a вводится с \r\nклавиатуры; 0 ≤ a ≤ 8); \r\nг) сколько раз в нем встречаются цифры x и y.");
        Console.Write("Введите натуральное число: ");
        long num = long.Parse(Console.ReadLine());

        Console.Write("Введите цифру a для подсчета: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите z (2,3,4) для кратных: ");
        int z = int.Parse(Console.ReadLine());

        Console.Write("Введите число a для суммы цифр: ");
        int aSum = int.Parse(Console.ReadLine());

        Console.Write("Введите цифры x и y для подсчета: ");
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());

        long temp = num;
        int countA = 0, countZ = 0, sumBiggerA = 0, countXY = 0;

        while (temp > 0)
        {
            int digit = (int)(temp % 10);
            if (digit == a) countA++;
            if (digit % z == 0) countZ++;
            if (digit > aSum) sumBiggerA += digit;
            if (digit == x || digit == y) countXY++;
            temp /= 10;
        }

        Console.WriteLine($"Цифра {a} встречается: {countA} раз");
        Console.WriteLine($"Цифр, кратных {z}: {countZ}");
        Console.WriteLine($"Сумма цифр > {aSum}: {sumBiggerA}");
        Console.WriteLine($"Цифры {x} или {y} встречаются: {countXY} раз");
    }

    static void Task8()
    {
        Console.WriteLine("Задание 8: Дана непустая последовательность целых чисел, \r\nоканчивающаяся числом 100. Определить, есть ли в \r\nпоследовательности число 77? Если имеются несколько таких \r\nчисел, то определить порядковый номер первого из них.");
        Console.WriteLine("Введите числа, заканчивая 100:");

        int index = 0;
        bool found = false;
        int firstIndex = -1;
        while (true)
        {
            int n = int.Parse(Console.ReadLine());
            index++;
            if (n == 100) break;
            if (n == 77 && !found)
            {
                found = true;
                firstIndex = index;
            }
        }

        if (found)
            Console.WriteLine($"Число 77 найдено первым на позиции {firstIndex}");
        else
            Console.WriteLine("Число 77 не встречается.");
    }

    static void Task9()
    {
        Console.WriteLine("Задание 9: Составить программу, которая ведет учет очков, \r\n" +
    "набранных каждой командой при игре в баскетбол. Количество \r\n" +
    "очков, полученных командами в ходе игры, может быть равно 1, 2 \r\n" +
    "или 3. После любого изменения счета выводить на экран. После \r\n" +
    "окончания игры выдать итоговое сообщение и указать номер \r\n" +
    "команды-победительницы. Окончание игры условно моделировать \r\n" +
    "вводом количества очков, равного нулю.");

        int team1 = 0, team2 = 0;

        while (true)
        {
            Console.Write("Введите номер команды (1 или 2) и очки (1–3), 0 для завершения: ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                continue;

            string[] parts = input.Split();
            if (parts.Length != 2)
            {
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                continue;
            }

            bool isTeamParsed = int.TryParse(parts[0], out int team);
            bool isPointsParsed = int.TryParse(parts[1], out int points);

            if (!isTeamParsed || !isPointsParsed)
            {
                Console.WriteLine("Некорректные числа. Попробуйте еще раз.");
                continue;
            }

            if (points == 0)
                break; // завершение игры

            if (team == 1)
            {
                if (points >= 1 && points <= 3)
                    team1 += points;
                else
                {
                    Console.WriteLine("Очки должны быть в диапазоне 1-3.");
                    continue;
                }
            }
            else if (team == 2)
            {
                if (points >= 1 && points <= 3)
                    team2 += points;
                else
                {
                    Console.WriteLine("Очки должны быть в диапазоне 1-3.");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("Неверный номер команды. Введите 1 или 2.");
                continue;
            }

            Console.WriteLine($"Текущий счет: команда 1 = {team1}, команда 2 = {team2}");
        }

        if (team1 > team2)
            Console.WriteLine("Победила команда 1");
        else if (team2 > team1)
            Console.WriteLine("Победила команда 2");
        else
            Console.WriteLine("Итоговая ничья");
    }

    static void Task10()
    {
        Console.WriteLine("Задание 10: Известны сведения о количестве осадков, выпавших за \r\nкаждый день мая. Первого мая осадков не было. Определить, в \r\nтечение какого количества первых дней месяца непрерывно, \r\nначиная с первого мая, осадков не было? Условный оператор не \r\nиспользовать. Рассмотреть два случая: \r\n1) известно, что в какие-то дни мая осадки выпадали; \r\n76 \r\n2) допускается, что осадков могло не быть ни в какой \r\nдень мая.");
        Console.WriteLine("Введите осадки по дням (0 — нет, >0 — есть), всего 31 день:");

        int count = 0;
        for (int i = 1; i <= 31; i++)
        {
            double rain = double.Parse(Console.ReadLine());
            if (rain == 0) count++;
            else break;
        }
        Console.WriteLine($"Количество первых дней без осадков: {count}");
    }
}

