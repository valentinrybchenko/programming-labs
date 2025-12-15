using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Рыбченко В.Л. 2КСОР");
            Console.WriteLine("Лабораторная работа №12");
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
        Console.WriteLine("Задание 1: Дан двумерный массив целых чисел. Для каждого его столбца выяснить:\r\nа) имеются ли в нем элементы, большие некоторого числа d;\r\nб) имеются ли в нем нечетные элементы;\r\nв) упорядочены ли его элементы по убыванию (при просмотре сверху вниз);\r\nг) имеются ли в нем одинаковые элементы.");
        
           
            {
                int rows = ReadPositiveInt("\nВведите количество строк: ");
                int cols = ReadPositiveInt("Введите количество столбцов: ");

                int[,] array = new int[rows, cols];

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

                int d = ReadInt("\nВведите число d: ");

                // Заполнение и вывод массива
                Console.WriteLine("\nМассив:");
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        array[i, j] = fillChoice == 1 ? rnd.Next(min, max + 1) : ReadElement(i, j);
                        Console.Write(array[i, j] + "\t");
                    }
                    Console.WriteLine();
                }

                // Анализ каждого столбца
                for (int j = 0; j < cols; j++)
                {
                    Console.WriteLine($"\nСтолбец {j + 1}:");

                    bool hasGreaterD = false;
                    bool hasOdd = false;
                    bool isDecreasing = true;
                    bool hasDuplicates = false;

                    // Вертикальный вывод элементов столбца
                    for (int i = 0; i < rows; i++)
                    {
                        int value = array[i, j];
                        Console.WriteLine(value);

                        if (value > d)
                            hasGreaterD = true;

                        if (value % 2 != 0)
                            hasOdd = true;

                        if (i > 0 && array[i - 1, j] < value)
                            isDecreasing = false;
                    }

                    // Проверка одинаковых элементов
                    for (int i = 0; i < rows && !hasDuplicates; i++)
                        for (int k = i + 1; k < rows; k++)
                            if (array[i, j] == array[k, j])
                                hasDuplicates = true;

                    // Вывод результатов
                    Console.WriteLine($"а) Есть элементы больше {d}: {(hasGreaterD ? "Да" : "Нет")}");
                    Console.WriteLine($"б) Есть нечетные элементы: {(hasOdd ? "Да" : "Нет")}");
                    Console.WriteLine($"в) Упорядочен по убыванию сверху вниз: {(isDecreasing ? "Да" : "Нет")}");
                    Console.WriteLine($"г) Есть одинаковые элементы: {(hasDuplicates ? "Да" : "Нет")}");
                }
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
    static void Task2() {
        Console.WriteLine("\nЗадание 2: Дан двумерный массив целых чисел. Для каждого его столбца выяснить:\r\nа) имеются ли в нем элементы, большие некоторого числа d;\r\nб) имеются ли в нем нечетные элементы;\r\nв) упорядочены ли его элементы по убыванию (при просмотре сверху вниз);\r\nг) имеются ли в нем одинаковые элементы.");
        {
            int rows = ReadPositiveInt("\nВведите количество строк: ");
            int cols = ReadPositiveInt("Введите количество столбцов: ");

            if (rows != cols)
            {
                Console.WriteLine("\nОшибка! Для диагоналей массив должен быть квадратным.");
                return;
            }

            int[,] array = new int[rows, cols];

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

            // Заполнение и вывод массива
            Console.WriteLine("\nМассив:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = fillChoice == 1
                        ? rnd.Next(min, max + 1)
                        : ReadElement(i, j);

                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int mainDiagSum = 0;
            int sideDiagSum = 0;

            Console.WriteLine("\nЭлементы главной диагонали:");
            for (int i = 0; i < rows; i++)
            {
                mainDiagSum += array[i, i];
                Console.WriteLine(array[i, i]);
            }

            Console.WriteLine("\nЭлементы побочной диагонали:");
            for (int i = 0; i < rows; i++)
            {
                sideDiagSum += array[i, cols - 1 - i];
                Console.WriteLine(array[i, cols - 1 - i]);
            }

            Console.WriteLine($"\nСумма элементов главной диагонали = {mainDiagSum}");
            Console.WriteLine($"Сумма элементов побочной диагонали = {sideDiagSum}");
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
                Console.WriteLine("Ошибка! Введите целое число.");
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
    static void Task3() {
        Console.WriteLine("\nЗадание 3: Дан двумерный массив целых чисел.\r\nа) ко всем четным элементам массива прибавить первый элемент соответствующей строки.\r\nб) все элементы массива, оканчивающиеся на 2, умножить на последний элемент соответствующего столбца.\r\nв) ко всем положительным элементам массива прибавить последний элемент соответствующей строки, а к остальным – первый элемент такой же строки.\r\nг) все элементы массива, сумма индексов которых кратна пяти, заменить нулями.");

        {
            int rows = ReadPositiveInt("\nВведите количество строк: ");
            int cols = ReadPositiveInt("Введите количество столбцов: ");

            int[,] array = new int[rows, cols];

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
            Console.WriteLine("\nИсходный массив:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = fillChoice == 1
                        ? rnd.Next(min, max + 1)
                        : ReadElement(i, j);

                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // а) прибавить первый элемент строки к четным элементам
            Console.WriteLine("\nа) Прибавление первого элемента строки к четным элементам:");
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (array[i, j] % 2 == 0)
                        array[i, j] += array[i, 0];

            PrintArray(array);

            // б) умножить элементы, оканчивающиеся на 2, на последний элемент столбца
            Console.WriteLine("\nб) Умножение элементов, оканчивающихся на 2, на последний элемент столбца:");
            for (int j = 0; j < cols; j++)
                for (int i = 0; i < rows; i++)
                    if (Math.Abs(array[i, j]) % 10 == 2)
                        array[i, j] *= array[rows - 1, j];

            PrintArray(array);

            // в) преобразование в зависимости от знака
            Console.WriteLine("\nв) Преобразование по знаку элемента:");
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    array[i, j] += array[i, j] > 0
                        ? array[i, cols - 1]
                        : array[i, 0];

            PrintArray(array);

            // г) замена элементов, сумма индексов которых кратна 5, нулями
            Console.WriteLine("\nг) Замена элементов с суммой индексов, кратной 5, на 0:");
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if ((i + j) % 5 == 0)
                        array[i, j] = 0;

            PrintArray(array);
        }

        static void PrintArray(int[,] array)
        {
            Console.WriteLine("Результат:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write(array[i, j] + "\t");
                Console.WriteLine();
            }
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
                Console.WriteLine("Ошибка! Введите целое число.");
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
    static void Task4() {
        Console.WriteLine("\nЗадание 4: Дан двумерный массив целых чисел.\r\nа) сформировать одномерный массив, каждый элемент которого равен сумме четных положительных элементов соответствующего столбца двумерного массива.\r\nб) сформировать одномерный массив, каждый элемент которого равен количеству нечетных отрицательных элементов соответствующей строки двумерного массива.\r\nв) сформировать одномерный массив, каждый элемент которого равен количеству отрицательных элементов в соответствующей строке двумерного массива, кратных 3 или 7.\r\nг) сформировать одномерный массив, каждый элемент которого равен сумме положительных элементов в соответствующем столбце двумерного массива, кратных 4 или 5.");

        {
            int rows = ReadPositiveInt("\nВведите количество строк: ");
            int cols = ReadPositiveInt("Введите количество столбцов: ");

            int[,] array = new int[rows, cols];

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

            // Заполнение и вывод двумерного массива
            Console.WriteLine("\nДвумерный массив:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = fillChoice == 1
                        ? rnd.Next(min, max + 1)
                        : ReadElement(i, j);

                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // а) сумма четных положительных элементов столбцов
            int[] a = new int[cols];
            for (int j = 0; j < cols; j++)
                for (int i = 0; i < rows; i++)
                    if (array[i, j] > 0 && array[i, j] % 2 == 0)
                        a[j] += array[i, j];

            PrintOneDimArray("\nа) Сумма четных положительных элементов каждого столбца:", a);

            // б) количество нечетных отрицательных элементов строк
            int[] b = new int[rows];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (array[i, j] < 0 && array[i, j] % 2 != 0)
                        b[i]++;

            PrintOneDimArray("\nб) Количество нечетных отрицательных элементов каждой строки:", b);

            // в) количество отрицательных элементов строки, кратных 3 или 7
            int[] c = new int[rows];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (array[i, j] < 0 && (array[i, j] % 3 == 0 || array[i, j] % 7 == 0))
                        c[i]++;

            PrintOneDimArray("\nв) Количество отрицательных элементов строки, кратных 3 или 7:", c);

            // г) сумма положительных элементов столбцов, кратных 4 или 5
            int[] d = new int[cols];
            for (int j = 0; j < cols; j++)
                for (int i = 0; i < rows; i++)
                    if (array[i, j] > 0 && (array[i, j] % 4 == 0 || array[i, j] % 5 == 0))
                        d[j] += array[i, j];

            PrintOneDimArray("\nг) Сумма положительных элементов столбцов, кратных 4 или 5:", d);
        }

        static void PrintOneDimArray(string title, int[] array)
        {
            Console.WriteLine(title);
            foreach (int x in array)
                Console.Write(x + " ");
            Console.WriteLine();
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
                Console.WriteLine("Ошибка! Введите целое число.");
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
    static void Task5() {
        Console.WriteLine("\nЗадание 5: В каждой строке массива найти количество букв с, расположенных слева от буквы ш (известно, что буква ш в каждой строке единственная).");
        {
            int rows = ReadPositiveInt("Введите количество строк: ");
            int cols = ReadPositiveInt("Введите количество символов в строке: ");

            char[,] array = new char[rows, cols];

            Console.WriteLine("\n1 – Автозаполнение\n2 – Ручной ввод");
            int choice = ReadChoice(1, 2, "Выберите способ заполнения: ");

            if (choice == 1)
                AutoFill(array, rows, cols);
            else
                ManualFill(array, rows, cols);

            // Вывод массива
            Console.WriteLine("\nМассив:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(array[i, j] + " ");
                Console.WriteLine();
            }

            // Подсчёт букв 'с' слева от 'ш'
            Console.WriteLine();
            for (int i = 0; i < rows; i++)
            {
                int count = 0;

                for (int j = 0; j < cols; j++)
                {
                    if (array[i, j] == 'ш')
                        break;

                    if (array[i, j] == 'с')
                        count++;
                }

                Console.WriteLine($"В строке {i + 1} букв 'с' слева от 'ш': {count}");
            }
        }

        // ---------- Автозаполнение с гарантией букв 'с' слева от 'ш' ----------
        static void AutoFill(char[,] array, int rows, int cols)
        {
            Random rnd = new Random();
            char[] otherLetters = { 'а', 'б', 'в', 'г', 'д' }; // остальные буквы, кроме 'с' и 'ш'

            for (int i = 0; i < rows; i++)
            {
                int posSh = rnd.Next(cols); // позиция буквы 'ш'
                int cCount = rnd.Next(0, posSh + 1); // количество букв 'с' слева от 'ш'

                int placedC = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == posSh)
                    {
                        array[i, j] = 'ш';
                    }
                    else if (placedC < cCount)
                    {
                        array[i, j] = 'с';
                        placedC++;
                    }
                    else
                    {
                        array[i, j] = otherLetters[rnd.Next(otherLetters.Length)];
                    }
                }
            }
        }

        // ---------- Ручной ввод ----------
        static void ManualFill(char[,] array, int rows, int cols)
        {
            Console.WriteLine("\nВведите строки (в каждой строке ровно одна буква 'ш'):");

            for (int i = 0; i < rows; i++)
            {
                while (true)
                {
                    Console.Write($"Строка {i + 1}: ");
                    string input = Console.ReadLine();

                    if (input.Length != cols)
                    {
                        Console.WriteLine($"Ошибка! Нужно {cols} символов.");
                        continue;
                    }

                    int countSh = 0;
                    foreach (char c in input)
                        if (c == 'ш') countSh++;

                    if (countSh != 1)
                    {
                        Console.WriteLine("Ошибка! В строке должна быть ровно одна буква 'ш'.");
                        continue;
                    }

                    for (int j = 0; j < cols; j++)
                        array[i, j] = input[j];

                    break;
                }
            }
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

        static int ReadChoice(int min, int max, string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                    return value;
                Console.WriteLine($"Введите число от {min} до {max}.");
            }
        }
    }
}