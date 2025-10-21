using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Рыбченко В.Л. 2КСОР, Вариант №9");
            Console.WriteLine("Выбери номер задачи (1–7) или 0 для выхода:");
            int task = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (task == 0)
            {
                Console.WriteLine("Выход из программы...");
                break;
            }

            switch (task)
            {
                case 1:
                    Console.WriteLine(5);
                    Console.WriteLine(10);
                    Console.WriteLine(21);
                    break;

                case 2:
                    Console.Write("a = "); double a = double.Parse(Console.ReadLine());
                    Console.Write("b = "); double b = double.Parse(Console.ReadLine());
                    Console.Write("h = "); double h = double.Parse(Console.ReadLine());
                    double volume = a * b * h;
                    double lateralArea = 2 * h * (a + b);
                    Console.WriteLine($"Объем = {volume}");
                    Console.WriteLine($"Площадь боковой поверхности = {lateralArea}");
                    break;

                case 3:
                    Console.Write("a = "); double x = double.Parse(Console.ReadLine());
                    double a2 = x * x;             // 1
                    double a3 = a2 * x;            // 2
                    double a5 = a2 * a3;           // 3
                    double a10 = a5 * a5;          // 4
                    Console.WriteLine($"a^3 = {a3}, a^10 = {a10}");
                    double b2 = x * x;             // 1
                    double b4 = b2 * b2;           // 2
                    double b5 = b4 * x;            // 3
                    double b10 = b5 * b5;          // 4
                    double b20 = b10 * b10;        // 5
                    Console.WriteLine($"a^4 = {b4}, a^20 = {b20}");
                    break;

                case 4:
                    Console.Write("Масса (кг) = ");
                    double kg = double.Parse(Console.ReadLine());
                    long centners = (long)(kg / 100);
                    Console.WriteLine($"Полных центнеров: {centners}");
                    break;

                case 5:
                    Console.Write("Четырёхзначное число = ");
                    int n = int.Parse(Console.ReadLine());
                    n = Math.Abs(n);
                    int d1 = (n / 1000) % 10;
                    int d2 = (n / 100) % 10;
                    int d3 = (n / 10) % 10;
                    int d4 = n % 10;
                    int sum = d1 + d2 + d3 + d4;
                    int prod = d1 * d2 * d3 * d4;
                    Console.WriteLine($"Сумма цифр = {sum}");
                    Console.WriteLine($"Произведение цифр = {prod}");
                    break;

                case 6:
                    int X = 456;
                    Console.WriteLine($"Искомое число x = {X}");
                    break;

                case 7:
                    Console.Write("k (1..180) = ");
                    int k = int.Parse(Console.ReadLine());
                    if (k < 1 || k > 180)
                    {
                        Console.WriteLine("k вне диапазона 1–180");
                        break;
                    }
                    int pairIndex = (k + 1) / 2;
                    int twoDigit = 9 + pairIndex;
                    int digit = (k % 2 == 1) ? (twoDigit / 10) : (twoDigit % 10);
                    Console.WriteLine($"Номер пары = {pairIndex}");
                    Console.WriteLine($"Двузначное число = {twoDigit}");
                    Console.WriteLine($"k-я цифра = {digit}");
                    break;

                default:
                    Console.WriteLine("Нет такой задачи. Введите число от 1 до 7.");
                    break;
            }

            Console.WriteLine("\nНажми Enter, чтобы продолжить...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
