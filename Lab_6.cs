using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Рыбченко В.Л. 2КСОР Вариант №9");
            Console.WriteLine("Выберите номер задания (1–8) или 0 для выхода:");
            int task;
            if (!int.TryParse(Console.ReadLine(), out task))
            {
                Console.WriteLine("Введите число!");
                continue;
            }

            switch (task)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                case 5:
                    Task5();
                    break;
                case 6:
                    Task6();
                    break;
                case 7:
                    Task7();
                    break;
                case 8:
                    Task8();
                    break;
                case 0:
                    Console.WriteLine("Выход из программы...");
                    return;
                default:
                    Console.WriteLine("Такого задания нет!");
                    break;
            }

            Console.WriteLine("\nНажмите любую клавишу, чтобы выбрать другое задание...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void Task1()
    {
        bool X = true, Y = false, Z = false;
        bool a = !X || !Y || !Z;
        bool b = (!X || !Y) && (X || Y);
        bool c = (X && Y) || (X && Z) || !Z;

        Console.WriteLine("Задание 1:");
        Console.WriteLine("Вычислить значение логического выражения при следующих значениях логических величин X, Y и Z: X=Истина, Y=Ложь, Z=Ложь: \r\nа) не X или не Y или не Z; \r\nб) (не X или не Y) и (X или Y); \r\nв) X и Y или X и Z или не Z. \r\n");
        Console.WriteLine($"a) {a}");
        Console.WriteLine($"b) {b}");
        Console.WriteLine($"c) {c}");
    }

    static void Task2()
    {
        double x = 3, y = 6;
        bool a = (x < 0) && (y > 5);
        bool b = (x > 10) && (x < 20);
        bool c = (x > 3) || (x < 1);
        bool d = (y > 0) && (y < 4) && (x < 5);

        Console.WriteLine("Задание 2:");
        Console.WriteLine("Записать логические выражения, которые имеют значение «Истина» только при выполнении указанных условий: \r\nа) x < 0 и у > 5; \r\nб) 10 < x < 20; \r\nв) x > 3 или x < 1; \r\nг) 0 < y < 4 и x < 5; \r\n");
        Console.WriteLine($"a) {a}");
        Console.WriteLine($"b) {b}");
        Console.WriteLine($"c) {c}");
        Console.WriteLine($"d) {d}");
    }

    static double GetDoubleInput(string prompt)
    {
        double value;
        Console.WriteLine(prompt);
        while (!double.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Некорректный ввод. Введите числовое значение:");
            Console.WriteLine(prompt);
        }
        return value;
    }

    static void Task3()
    {
        Console.WriteLine("Задание 3:");
        Console.WriteLine("Даны объемы и массы двух тел из разных материалов. Материал какого из тел имеет большую плотность?");

        double m1 = GetDoubleInput("\nВведите массу первого тела (кг):");
        double v1 = GetDoubleInput("Введите объем первого тела (м^3):");
        double m2 = GetDoubleInput("\nВведите массу второго тела (кг):");
        double v2 = GetDoubleInput("Введите объем второго тела (м^3):");

        double p1 = CalculateDensity(m1, v1, "первого");
        double p2 = CalculateDensity(m2, v2, "второго");

        if (p1 == double.NaN || p2 == double.NaN) return; // Выход, если была ошибка расчета плотности

        // Сравнение плотностей и вывод результата
        if (p1 > p2)
            Console.WriteLine("\nПервое тело имеет большую плотность.");
        else if (p2 > p1)
            Console.WriteLine("\nВторое тело имеет большую плотность.");
        else
            Console.WriteLine("\nПлотности одинаковы.");
    }
    static double CalculateDensity(double mass, double volume, string bodyName)
    {
        if (volume == 0)
        {
            Console.WriteLine($"\nОшибка: Объем {bodyName} тела равен нулю. Невозможно рассчитать плотность.");
            return double.NaN; // Возвращаем NaN, чтобы указать на ошибку
        }
        return mass / volume;
    }

    static void Task4()
    {
        int n;

        Console.WriteLine("Задание 4:");
        Console.WriteLine("Дано натуральное число (составное условие не использовать). \r\nа) Верно ли, что оно заканчивается четной цифрой? \r\nб) Верно ли, что оно заканчивается нечетной цифрой?\r\n");

        Console.WriteLine("Введите натуральное число:");
        // Цикл для проверки корректности ввода (должно быть целое число)
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Некорректный ввод. Введите положительное целое число:");
        }

        int last = n % 10;
        bool even = last % 2 == 0;
        bool odd = !even;

        Console.WriteLine($"а) Кончается четной цифрой: {even}");
        Console.WriteLine($"б) Кончается нечетной цифрой: {odd}");
    }

    static double GetDoubleInput(string prompt, bool allowZero = true)
    {
        double value;
        Console.WriteLine(prompt);

        while (!double.TryParse(Console.ReadLine(), out value) || (!allowZero && value == 0))
        {
            Console.WriteLine("Некорректный ввод. Введите вещественное число:");
            if (!allowZero)
                Console.WriteLine("Значение не должно быть равно 0.");
            Console.WriteLine(prompt);
        }
        return value;
    }

    static void Task5()
    {
        Console.WriteLine("Задание 5:");
        Console.WriteLine("Даны вещественные числа a, b, c (a не равно 0). Решить уравнение ax^2+bx+c=0.\nВ числе возможных вариантов учесть вариант равенства корней уравнения.");

        double a = GetDoubleInput("\nВведите коэффициент a (не равный 0):", false); // Не разрешаем ввод 0
        double b = GetDoubleInput("Введите коэффициент b:");
        double c = GetDoubleInput("Введите коэффициент c:");

        double D = b * b - 4 * a * c;

        if (D > 0)
        {
            double x1 = (-b + Math.Sqrt(D)) / (2 * a);
            double x2 = (-b - Math.Sqrt(D)) / (2 * a);
            Console.WriteLine($"Два корня: x1 = {x1:F2}, x2 = {x2:F2}"); // Форматирование вывода
        }
        else if (D == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine($"Один корень: x = {x:F2}"); // Форматирование вывода
        }
        else
        {
            Console.WriteLine("Корней нет (D < 0).");
        }
    }

    static void Task6()
    {
        double x;

        Console.WriteLine("Задание 6:");
        Console.WriteLine("Дано вещественное число. Вывести на экран его абсолютную величину (условно принимая, что соответствующей стандартной функции нет). Полный условный оператор не использовать.");

        Console.WriteLine("\nВведите вещественное число:");

        // Ввод и проверка числа
        while (!double.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("Некорректный ввод. Введите вещественное число:");
        }

        // Вычисление абсолютной величины с использованием тернарного оператора
        double abs = x >= 0 ? x : -x;

        Console.WriteLine($"|{x}| = {abs}");
    }

    static void Task7()
    {
        Console.WriteLine("Задание 7:");
        Console.WriteLine("Составить программу, которая в зависимости от порядкового номера дня месяца (1, 2, …, 12) выводит на экран его название (январь, февраль, …, декабрь).");
        Console.WriteLine("Введите номер месяца (1–12):");
        int m = int.Parse(Console.ReadLine());
        string name = m switch
        {
            1 => "Январь",
            2 => "Февраль",
            3 => "Март",
            4 => "Апрель",
            5 => "Май",
            6 => "Июнь",
            7 => "Июль",
            8 => "Август",
            9 => "Сентябрь",
            10 => "Октябрь",
            11 => "Ноябрь",
            12 => "Декабрь",
            _ => "Неверный номер месяца"
        };

        Console.WriteLine("Задание 7:");
        Console.WriteLine(name);
    }

    static void Task8()
    {
        Console.WriteLine("Задание 8:");
        Console.WriteLine("Даны целое число k (1 ≤ k ≤ 222) и последовательность цифр 123…91011…9899100101…109110, в которой выписаны подряд все натуральные числа от 1 до 110. Определить k-ю цифру. Величины строкового типа не использовать.");
        Console.WriteLine("Введите k (1 ≤ k ≤ 222):");
        int k = int.Parse(Console.ReadLine());
        int count = 0;

        Console.WriteLine("Задание 8:");
        for (int i = 1; i <= 110; i++)
        {
            int temp = i;
            int len = (i < 10) ? 1 : (i < 100 ? 2 : 3);

            for (int j = len - 1; j >= 0; j--)
            {
                int digit = (temp / (int)Math.Pow(10, j)) % 10;
                count++;
                if (count == k)
                {
                    Console.WriteLine($"k-я цифра ({k}) = {digit}");
                    return;
                }
            }
        }
        Console.WriteLine("Значение k выходит за пределы диапазона.");
    }
}
