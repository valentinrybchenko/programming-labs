using System;

class Program
{
    static void CheckNumber(int n)
    {
        if (n % 2 == 0)
            throw new ArithmeticException();
        else
            throw new OverflowException();
    }

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Рыбченко В.Л. 2КСОР");
            Console.WriteLine("Лабораторная работа №13");
            Console.WriteLine("Вариант №9\n");

            Console.Write("Выберите номер задания (1–5) или 0 для выхода: ");

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
    static void Task1()
    {
        Console.Write("\nЗадание 1: Напишите программу, в которой пользователь вводит через консоль размер целочисленного массива. Массив создается, заполняется натуральными числами, а затем содержимое массива отображается в консольном окне. Предусмотреть обработку исключений, связанных с тем, что пользователь ввел некорректное значение для размера массива или ввел нечисловое значение.");

        {
            int rows = 0, cols = 0;

            // Ввод количества строк с обработкой ошибок
            while (true)
            {
                Console.Write("\n\nВведите количество строк: ");
                string input = Console.ReadLine();

                try
                {
                    rows = int.Parse(input);
                    if (rows <= 0)
                    {
                        Console.WriteLine("Ошибка! Число должно быть положительным.\n");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Ошибка! Введите числовое значение.\n");
                }
            }

            // Ввод количества столбцов с обработкой ошибок
            while (true)
            {
                Console.Write("Введите количество столбцов: ");
                string input = Console.ReadLine();

                try
                {
                    cols = int.Parse(input);
                    if (cols <= 0)
                    {
                        Console.WriteLine("Ошибка! Число должно быть положительным.\n");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Ошибка! Введите числовое значение.\n");
                }
            }

            // Создание и заполнение массива натуральными числами
            int[,] array = new int[rows, cols];
            Random rnd = new Random();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    array[i, j] = rnd.Next(1, 101); // натуральные числа от 1 до 100

            // Вывод массива
            Console.WriteLine("\nСодержимое массива:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(array[i, j] + "\t");
                Console.WriteLine();
            }
        }
    }
    static void Task2()
    {
        Console.WriteLine("\nЗадание 2: Напишите программу, в которой пользователь последовательно вводит два целых числа. Программа вычисляет остаток от деления большего числа на меньшее число. Программный код следует написать с учетом обработки возможных ошибок.");

        {
            int num1 = ReadInt("\nВведите первое целое число: ");
            int num2 = ReadInt("Введите второе целое число: ");

            // Определяем большее и меньшее число
            int max = Math.Max(num1, num2);
            int min = Math.Min(num1, num2);

            try
            {
                if (min == 0)
                {
                    Console.WriteLine("Ошибка! Деление на ноль невозможно.");
                }
                else
                {
                    int remainder = max % min;
                    Console.WriteLine($"\nОстаток от деления {max} на {min} = {remainder}");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка! Произошло переполнение числа.");
            }
        }

        // Метод для безопасного ввода целого числа
        static int ReadInt(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                try
                {
                    value = int.Parse(input);
                    return value;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Введите корректное целое число.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка! Число слишком большое.");
                }
            }
        }
    }
    static void Task3()
    {
        Console.WriteLine("\nЗадание 3: Напишите программу, в которой уравнение вида Ax=B решается на множестве целых чисел. Решением является такое целое число x, которое, будучи умноженным на целое число A, дает целое число B. Решение существует только в том случае, если целое число B без остатка делится на целое число A или если оба параметра A и B равны нулю. Предусмотреть обработку исключительных ситуаций.");
        {
            int A = ReadInt("\nВведите целое число A: ");
            int B = ReadInt("Введите целое число B: ");

            try
            {
                if (A == 0)
                {
                    if (B == 0)
                    {
                        Console.WriteLine("\nУравнение 0*x = 0 имеет бесконечно много решений на множестве целых чисел.");
                    }
                    else
                    {
                        Console.WriteLine("\nРешений нет, так как 0*x не может быть равно " + B);
                    }
                }
                else
                {
                    if (B % A == 0)
                    {
                        int x = B / A;
                        Console.WriteLine($"\nРешение уравнения {A}*x = {B} на множестве целых чисел: x = {x}");
                    }
                    else
                    {
                        Console.WriteLine("\nРешений нет, так как B не делится на A без остатка.");
                    }
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка! Произошло переполнение при вычислениях.");
            }
        }

        // Метод для безопасного ввода целого числа
        static int ReadInt(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                try
                {
                    value = int.Parse(input);
                    return value;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Введите корректное целое число.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка! Число слишком большое.");
                }
            }
        }
    }
    static void Task4()
    {
        Console.WriteLine("\nЗадание 4: Напишите программу, содержащую статический метод, не возвращающий результат. Аргументом методу передается целое число. Если число четное, то метод генерирует исключение класса ArithmeticException, а если число нечетное, то генерируется исключение класса OverflowException. В главном методе выполняется оператор цикла, в котором за каждый цикл пользователь вводит целое число, оно передается аргументом методу. Организовать обработку событий таким образом, чтобы в результате появлялось сообщение о том, четное число или нечетное. Оператор цикла должен завершать работу, если пользователь вводит не число.");

        while (true)
        {
            Console.Write("\nВведите целое число: ");
            string input = Console.ReadLine();

            // Выход из цикла, если введено не число
            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Введено не число. Завершение задания.");
                break;
            }

            try
            {
                CheckNumber(number);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Число нечетное\n");
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Число четное\n");
            }
        }
    }

    static void Task5()
    {
        Console.WriteLine("\nЗадание 5: Написать программу решения квадратного уравнения. Если уравнение не имеет решения, программа должна предложить пользователю ввести новые коэффициенты уравнения до тех пор, пока уравнение не будет иметь решение. Предусмотреть обработку исключительных ситуаций.");

        {
            while (true)
            {
                try
                {
                    Console.Write("Введите a: ");
                    double a = double.Parse(Console.ReadLine());

                    if (a == 0)
                        throw new ArgumentException("Коэффициент a не может быть равен 0.");

                    Console.Write("Введите b: ");
                    double b = double.Parse(Console.ReadLine());

                    Console.Write("Введите c: ");
                    double c = double.Parse(Console.ReadLine());

                    double d = b * b - 4 * a * c;

                    if (d < 0)
                    {
                        Console.WriteLine("Уравнение не имеет действительных корней. Введите коэффициенты заново.\n");
                        continue;
                    }

                    double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(d)) / (2 * a);

                    if (d == 0)
                        Console.WriteLine($"Один корень: x = {x1}");
                    else
                        Console.WriteLine($"Корни уравнения: x1 = {x1}, x2 = {x2}");

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка ввода. Введите числовые значения.\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message + "\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Неожиданная ошибка: " + ex.Message + "\n");
                }
            }
        }
    }
}

