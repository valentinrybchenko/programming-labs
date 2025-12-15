using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Рыбченко В.Л. 2КСОР");
            Console.WriteLine("Лабораторная работа №11");
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
    static void Task1() {
        Console.WriteLine("\nЗадание 1: Составить программу:\r\nа) расчета суммы двух любых элементов двумерного массива;\r\nб) расчета среднего арифметического трех любых элементов двумерного массива.");

        {
            Console.Write("\nВведите количество строк: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов: ");
            int cols = int.Parse(Console.ReadLine());

            int[,] array = new int[rows, cols];

            Console.WriteLine("\n1 – Автозаполнение\n2 – Ручной ввод");
            int fillChoice = int.Parse(Console.ReadLine());

            Random rnd = new Random();

            // Заполнение массива
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    array[i, j] = fillChoice == 1 ? rnd.Next(1, 10) : ReadElement(i, j);

            // Вывод массива
            Console.WriteLine("\nМассив:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(array[i, j] + "\t");
                Console.WriteLine();
            }

            // Сумма двух элементов
            Console.WriteLine("\nСумма двух элементов");
            int x1 = SelectElement(array, rows, cols, "первого");
            int x2 = SelectElement(array, rows, cols, "второго");

            Console.WriteLine($"\nПример: {x1} + {x2} = {x1 + x2}");

            // Среднее трех элементов
            Console.WriteLine("\nСреднее арифметическое трех элементов");
            int y1 = SelectElement(array, rows, cols, "первого");
            int y2 = SelectElement(array, rows, cols, "второго");
            int y3 = SelectElement(array, rows, cols, "третьего");

            double avg = (y1 + y2 + y3) / 3.0;
            Console.WriteLine($"\nПример: ({y1} + {y2} + {y3}) / 3 = {avg}");
        }

        static int ReadElement(int i, int j)
        {
            Console.Write($"Введите элемент [{i + 1},{j + 1}]: ");
            return int.Parse(Console.ReadLine());
        }

        static int SelectElement(int[,] array, int rows, int cols, string name)
        {
            int r, c;

            while (true)
            {
                Console.WriteLine($"Введите номер строки и столбца {name} элемента (нумерация с 1):");

                Console.Write("Строка: ");
                r = int.Parse(Console.ReadLine()) - 1;

                Console.Write("Столбец: ");
                c = int.Parse(Console.ReadLine()) - 1;

                if (r >= 0 && r < rows && c >= 0 && c < cols)
                    break;

                Console.WriteLine("Ошибка! Такого элемента нет. Повторите ввод.\n");
            }

            int value = array[r, c];
            Console.WriteLine($"Выбран элемент: {value}");

            return value;
        }
    }
    static void Task2() {
        Console.WriteLine("\nЗадание 2: Заполнить массив размером 6х6 так, как показано на рисунках а и б:");

        {
            int n = 6;
            int[,] table1 = new int[n, n];

            // Заполнение таблицы 1
            for (int i = 0; i < n; i++)
            {
                table1[i, 0] = 1;
                table1[0, i] = 1;
            }

            for (int i = 1; i < n; i++)
                for (int j = 1; j < n; j++)
                    table1[i, j] = table1[i - 1, j] + table1[i, j - 1];

            Console.WriteLine("\nТаблица а:");
            PrintArray(table1);

            // -----------------------------

            int[,] table2 = new int[n, n];

            // Заполнение таблицы 2
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    table2[i, j] = (i + j) % n + 1;

            Console.WriteLine("\nТаблица б:");
            PrintArray(table2);
        }

        static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write(arr[i, j] + "\t");
                Console.WriteLine();
            }
        }
    }
    static void Task3() {
        Console.Write("\nЗадание 3: Дан двумерный массив целых чисел. Определить: \r\nа) сумму четных элементов массива; \r\nб) количество элементов массива, меньших 50; \r\nв) среднее арифметическое нечетных элементов массива; \r\nг) сумму тех элементов массива, сумма индексов которых кратна трем. \r\n");

        {
            Console.Write("\nВведите количество строк: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов: ");
            int cols = int.Parse(Console.ReadLine());

            int[,] array = new int[rows, cols];

            Console.WriteLine("\n1 – Автозаполнение\n2 – Ручной ввод");
            int fillChoice = int.Parse(Console.ReadLine());

            int min = 0, max = 0;
            Random rnd = new Random();

            // Ввод диапазона
            if (fillChoice == 1)
            {
                Console.Write("Введите минимальное значение: ");
                min = int.Parse(Console.ReadLine());

                Console.Write("Введите максимальное значение: ");
                max = int.Parse(Console.ReadLine());

                if (min > max)
                {
                    int temp = min;
                    min = max;
                    max = temp;
                }
            }

            // Заполнение массива
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    array[i, j] = fillChoice == 1
                        ? rnd.Next(min, max + 1)
                        : ReadElement(i, j);

            // Вывод массива
            Console.WriteLine("\nМассив:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(array[i, j] + "\t");
                Console.WriteLine();
            }

            int sumEven = 0;
            int countLess50 = 0;
            int sumOdd = 0;
            int countOdd = 0;
            int sumIndexMultiple3 = 0;

            // Обработка массива
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int value = array[i, j];

                    if (value % 2 == 0)
                        sumEven += value;

                    if (value < 50)
                        countLess50++;

                    if (value % 2 != 0)
                    {
                        sumOdd += value;
                        countOdd++;
                    }

                    if ((i + j) % 3 == 0)
                        sumIndexMultiple3 += value;
                }
            }

            // Вывод результатов
            Console.WriteLine("\nРезультаты:");
            Console.WriteLine("а) Сумма четных элементов массива: " + sumEven);
            Console.WriteLine("б) Количество элементов массива, меньших 50: " + countLess50);

            if (countOdd > 0)
                Console.WriteLine("в) Среднее арифметическое нечетных элементов: " +
                                  (sumOdd / (double)countOdd));
            else
                Console.WriteLine("в) Нечетных элементов нет");

            Console.WriteLine("г) Сумма элементов, сумма индексов которых кратна 3: " +
                              sumIndexMultiple3);
        }

        static int ReadElement(int i, int j)
        {
            Console.Write($"Введите элемент [{i + 1},{j + 1}]: ");
            return int.Parse(Console.ReadLine());
        }
    }
    static void Task4() {
        Console.Write("\nЗадание 4: Составить программу: \r\nа) нахождения номера столбца, в котором расположен максимальный элемент любой строки двумерного массива. Если элементов с максимальным значением в этой строке несколько, то должен быть найден номер столбца самого правого из них; \r\nб) нахождения номера строки, в которой расположен минимальный элемент любого столбца двумерного массива. Если элементов с минимальным значением в этом столбце несколько, то должен быть найден номер строки самого нижнего из них. \r\n");

        {
            Console.Write("\nВведите количество строк: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов: ");
            int cols = int.Parse(Console.ReadLine());

            int[,] array = new int[rows, cols];

            Console.WriteLine("\n1 – Автозаполнение\n2 – Ручной ввод");
            int fillChoice = int.Parse(Console.ReadLine());

            int min = 0, max = 0;
            Random rnd = new Random();

            // Диапазон значений
            if (fillChoice == 1)
            {
                Console.Write("Введите минимальное значение: ");
                min = int.Parse(Console.ReadLine());

                Console.Write("Введите максимальное значение: ");
                max = int.Parse(Console.ReadLine());

                if (min > max)
                {
                    int temp = min;
                    min = max;
                    max = temp;
                }
            }

            // Заполнение массива
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    array[i, j] = fillChoice == 1
                        ? rnd.Next(min, max + 1)
                        : ReadElement(i, j);

            // Вывод массива
            Console.WriteLine("\nМассив:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(array[i, j] + "\t");
                Console.WriteLine();
            }

            // а) для каждой строки — номер столбца с максимальным элементом (самый правый)
            Console.WriteLine("\nа) Номера столбцов с максимальным элементом в каждой строке:");

            for (int i = 0; i < rows; i++)
            {
                int maxValue = array[i, 0];
                int maxCol = 0;

                for (int j = 1; j < cols; j++)
                {
                    if (array[i, j] >= maxValue)
                    {
                        maxValue = array[i, j];
                        maxCol = j; // берём самый правый
                    }
                }

                Console.WriteLine($"Строка {i + 1}: столбец {maxCol + 1} (значение {maxValue})");
            }

            // б) для каждого столбца — номер строки с минимальным элементом (самый нижний)
            Console.WriteLine("\nб) Номера строк с минимальным элементом в каждом столбце:");

            for (int j = 0; j < cols; j++)
            {
                int minValue = array[0, j];
                int minRow = 0;

                for (int i = 1; i < rows; i++)
                {
                    if (array[i, j] <= minValue)
                    {
                        minValue = array[i, j];
                        minRow = i; // берём самый нижний
                    }
                }

                Console.WriteLine($"Столбец {j + 1}: строка {minRow + 1} (значение {minValue})");
            }
        }

        static int ReadElement(int i, int j)
        {
            Console.Write($"Введите элемент [{i + 1},{j + 1}]: ");
            return int.Parse(Console.ReadLine());
        }
    }
    static void Task5() {
        Console.Write("\nЗадание 5: Дан двумерный массив размером nхn, заполненный целыми числами. Выяснить, является ли массив магическим квадратом. В магическом квадрате суммы элементов по всем строкам, столбцам и двум диагоналям равны. Значение, которому должны быть равны указанные суммы, определить самостоятельно.");

        {
            int n = ReadPositiveInt("\n\nВведите размер массива n (nхn): ");

            int[,] array = new int[n, n];

            Console.WriteLine("\n1 – Автозаполнение\n2 – Ручной ввод");
            int fillChoice = ReadChoice(1, 2, "Выберите способ заполнения: ");

            int min = 0, max = 0;
            Random rnd = new Random();

            if (fillChoice == 1)
            {
                min = ReadInt("Введите минимальное значение: ");
                max = ReadInt("Введите максимальное значение: ");
                if (min > max)
                {
                    int temp = min;
                    min = max;
                    max = temp;
                }
            }

            // Заполнение массива
            Console.WriteLine("\nЗаполнение массива:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = fillChoice == 1 ? rnd.Next(min, max + 1) : ReadElement(i, j);
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nПошаговая проверка магического квадрата:");

            int magicSum = 0;
            Console.WriteLine("\nСумма первой строки:");
            for (int j = 0; j < n; j++)
            {
                magicSum += array[0, j];
                Console.Write(array[0, j] + (j < n - 1 ? " + " : " = " + magicSum + "\n"));
            }

            bool isMagic = true;

            // Проверка остальных строк
            for (int i = 1; i < n; i++)
            {
                int rowSum = 0;
                Console.WriteLine($"\nСумма строки {i + 1}:");
                for (int j = 0; j < n; j++)
                {
                    rowSum += array[i, j];
                    Console.Write(array[i, j] + (j < n - 1 ? " + " : " = " + rowSum + "\n"));
                }
                if (rowSum != magicSum)
                {
                    Console.WriteLine("Сумма не равна магической!");
                    isMagic = false;
                }
            }

            // Проверка столбцов
            for (int j = 0; j < n; j++)
            {
                int colSum = 0;
                Console.WriteLine($"\nСумма столбца {j + 1}:");
                for (int i = 0; i < n; i++)
                {
                    colSum += array[i, j];
                    Console.Write(array[i, j] + (i < n - 1 ? " + " : " = " + colSum + "\n"));
                }
                if (colSum != magicSum)
                {
                    Console.WriteLine("Сумма не равна магической!");
                    isMagic = false;
                }
            }

            // Главная диагональ
            int diag1 = 0;
            Console.WriteLine("\nСумма главной диагонали:");
            for (int i = 0; i < n; i++)
            {
                diag1 += array[i, i];
                Console.Write(array[i, i] + (i < n - 1 ? " + " : " = " + diag1 + "\n"));
            }
            if (diag1 != magicSum)
            {
                Console.WriteLine("Сумма не равна магической!");
                isMagic = false;
            }

            // Побочная диагональ
            int diag2 = 0;
            Console.WriteLine("\nСумма побочной диагонали:");
            for (int i = 0; i < n; i++)
            {
                diag2 += array[i, n - 1 - i];
                Console.Write(array[i, n - 1 - i] + (i < n - 1 ? " + " : " = " + diag2 + "\n"));
            }
            if (diag2 != magicSum)
            {
                Console.WriteLine("Сумма не равна магической!");
                isMagic = false;
            }

            // Вывод результата
            Console.WriteLine("\nРезультат:");
            if (isMagic)
                Console.WriteLine($"Массив является магическим квадратом. Магическая сумма = {magicSum}");
            else
                Console.WriteLine($"Массив не является магическим квадратом. Магическая сумма = {magicSum}");
        }

        static int ReadElement(int i, int j)
        {
            return ReadInt($"Введите элемент [{i + 1},{j + 1}]: ");
        }

        static int ReadPositiveInt(string message)
        {
            int value;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out value) || value <= 0);
            return value;
        }

        static int ReadInt(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value))
                    return value;
                Console.WriteLine("Ошибка ввода! Введите целое число.");
            }
        }

        static int ReadChoice(int min, int max, string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                    return value;
                Console.WriteLine($"Ошибка! Введите число от {min} до {max}.");
            }
        }
    }
}