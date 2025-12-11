using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Рыбченко В.Л. 2КСОР");
            Console.WriteLine("Лабораторная работа №10");
            Console.WriteLine("Вариант №9\n");

            Console.Write("Выберите номер задания (1–8) или 0 для выхода: ");

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
                case 8: Task8(); break;

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
        Console.WriteLine("\nЗадание 1: Заполнить массив из восьми элементов следующими \r\nзначениями: первый элемент массива равен 37, второй – 0, третий – 50, четвертый – 46, пятый – 34, шестой – 46, седьмой – 0, восьмой –13.");
        {
            int[] array = new int[8]
            {
            37, // первый элемент
            0,  // второй элемент
            50, // третий элемент
            46, // четвертый элемент
            34, // пятый элемент
            46, // шестой элемент
            0,  // седьмой элемент
            13  // восьмой элемент
            };

            // Вывод массива на экран
            Console.WriteLine("\nМассив:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Элемент {i + 1}: {array[i]}");
            }
        }
    }
    static void Task2()
    {
        Console.WriteLine("\nЗадание 2: Дан массив. Все его элементы: \r\nа) уменьшить на 20; \r\nб) умножить на последний элемент; \r\nв) увеличить на число В.");
        {
            Console.Write("\nВведите размер массива: ");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.Write("Некорректный ввод. Пожалуйста, введите положительное число: ");
            }

            int[] array = new int[size];

            // Заполнение массива пользователем
            Console.WriteLine("Выберите способ заполнения массива:");
            Console.WriteLine("1 - Ввести вручную");
            Console.WriteLine("2 - Заполнить случайными числами");
            Console.Write("Ваш выбор: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.Write("Некорректный ввод. Выберите 1 или 2: ");
            }

            if (choice == 1)
            {
                for (int i = 0; i < size; i++)
                {
                    Console.Write($"Введите элемент {i + 1}: ");
                    while (!int.TryParse(Console.ReadLine(), out array[i]))
                    {
                        Console.Write("Некорректный ввод. Попробуйте еще раз: ");
                    }
                }
            }
            else
            {
                Random rand = new Random();
                for (int i = 0; i < size; i++)
                {
                    array[i] = rand.Next(1, 101); // случайные числа от 1 до 100
                }
                Console.WriteLine("Массив случайных чисел: " + string.Join(", ", array));
            }

            // Выбор операции
            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1 - Уменьшить все элементы на 20");
            Console.WriteLine("2 - Умножить все элементы на последний элемент");
            Console.WriteLine("3 - Увеличить все элементы на число B");
            Console.Write("Ваш выбор: ");
            int operation;
            while (!int.TryParse(Console.ReadLine(), out operation) || (operation < 1 || operation > 3))
            {
                Console.Write("Некорректный ввод. Выберите 1, 2 или 3: ");
            }

            switch (operation)
            {
                case 1:
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] -= 20;
                    }
                    Console.WriteLine("После уменьшения на 20: " + string.Join(", ", array));
                    break;

                case 2:
                    int lastElement = array[array.Length - 1];
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] *= lastElement;
                    }
                    Console.WriteLine("После умножения на последний элемент: " + string.Join(", ", array));
                    break;

                case 3:
                    Console.Write("Введите число B: ");
                    int B;
                    while (!int.TryParse(Console.ReadLine(), out B))
                    {
                        Console.Write("Некорректный ввод. Попробуйте еще раз: ");
                    }
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] += B;
                    }
                    Console.WriteLine($"После увеличения на {B}: " + string.Join(", ", array));
                    break;
            }
        }

    }
    static void Task3()
    {
        Console.WriteLine("\nЗадание 3: Дан массив целых чисел. Вывести на экран сначала его \r\nчетные элементы, затем нечетные.");

        {
            Random rand = new Random();
            int[] array;
            Console.WriteLine("\nВыберите режим заполнения массива:");
            Console.WriteLine("1 - Вручную");
            Console.WriteLine("2 - Автоматически (случайные числа)");
            Console.Write("Ваш выбор: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.Write("Некорректный ввод. Пожалуйста, введите 1 или 2: ");
            }

            // Ввод размера массива
            Console.Write("Введите размер массива: ");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.Write("Некорректный ввод. Пожалуйста, введите положительное число: ");
            }

            array = new int[size];

            if (choice == 1)
            {
                // Ввод элементов вручную
                for (int i = 0; i < size; i++)
                {
                    Console.Write($"Введите элемент {i + 1}: ");
                    while (!int.TryParse(Console.ReadLine(), out array[i]))
                    {
                        Console.Write("Некорректный ввод. Попробуйте еще раз: ");
                    }
                }
            }
            else
            {
                // Заполнение случайными числами
                for (int i = 0; i < size; i++)
                {
                    array[i] = rand.Next(1, 101); // числа от 1 до 100
                }
                Console.WriteLine("Массив заполнен случайными числами.");
            }

            // Вывод всего массива
            Console.WriteLine("\nВесь массив:");
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Вывод четных чисел
            Console.WriteLine("\nЧетные числа:");
            bool hasEven = false;
            foreach (int num in array)
            {
                if (num % 2 == 0)
                {
                    Console.Write(num + " ");
                    hasEven = true;
                }
            }
            if (!hasEven)
            {
                Console.WriteLine("\nНет четных чисел.");
            }
            else
            {
                Console.WriteLine();
            }

            // Вывод нечетных чисел
            Console.WriteLine("\nНечетные числа:");
            bool hasOdd = false;
            foreach (int num in array)
            {
                if (num % 2 != 0)
                {
                    Console.Write(num + " ");
                    hasOdd = true;
                }
            }
            if (!hasOdd)
            {
                Console.WriteLine("\nНет нечетных чисел.");
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
    static void Task4()
    {
        Console.WriteLine("\nЗадание 4: Количество осадков (в миллиметрах), выпавших за \r\nкаждый день января, хранится в массиве. Определить количество \r\nдней, в которые выпало осадков больше, чем в среднем за один \r\nдень месяца, и напечатать их дату (число месяца).");

        {
            Random rand = new Random();
            int[] rainfall = new int[31];
            Console.WriteLine("\nВыберите режим заполнения данных о осадках:");
            Console.WriteLine("1 - Вручную");
            Console.WriteLine("2 - Автоматически (случайные значения)");
            Console.Write("Ваш выбор: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.Write("Некорректный ввод. Пожалуйста, введите 1 или 2: ");
            }

            if (choice == 1)
            {
                // Ввод данных вручную
                for (int i = 0; i < 31; i++)
                {
                    Console.Write($"Введите количество осадков за день {i + 1}: ");
                    while (!int.TryParse(Console.ReadLine(), out rainfall[i]) || rainfall[i] < 0)
                    {
                        Console.Write("Некорректный ввод. Попробуйте еще раз: ");
                    }
                }
            }
            else
            {
                // Заполнение рандомом
                for (int i = 0; i < 31; i++)
                {
                    rainfall[i] = rand.Next(0, 51); // значения от 0 до 50 мм
                }
                Console.WriteLine("Данные о осадках заполнены случайными значениями.");
            }

            // Вывод данных
            Console.WriteLine("\nКоличество осадков за каждый день января:");
            for (int i = 0; i < 31; i++)
            {
                Console.WriteLine($"День {i + 1}: {rainfall[i]} мм");
            }

            // Расчет среднего
            double average = 0;
            int sum = 0;
            foreach (int rain in rainfall)
            {
                sum += rain;
            }
            average = (double)sum / 31;

            Console.WriteLine($"\nСреднее количество осадков за месяц: {average:F2} мм");

            // Определение дней с осадками больше среднего и вывод с количеством
            Console.WriteLine("Дни, когда количество осадков было больше среднего:");
            bool found = false;
            for (int i = 0; i < 31; i++)
            {
                if (rainfall[i] > average)
                {
                    Console.WriteLine($"День {i + 1}: {rainfall[i]} мм");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Таких дней нет.");
            }
        }
    }
    static void Task5()
    {
        Console.WriteLine("\nЗадание 5: Известен вес каждого человека из группы. Верно ли, что \r\nвес самого тяжелого из них превышает массу самого легкого более \r\nчем в 2 раза? ");

        {
            Random rand = new Random();

            // Ввод количества человек
            Console.Write("\nВведите количество людей в группе: ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            {
                Console.Write("Некорректный ввод. Введите положительное число: ");
            }

            // Выбор режима заполнения весов
            Console.WriteLine("\nВыберите режим заполнения весов:");
            Console.WriteLine("1 - Вручную (значения от 45 до 150 кг)");
            Console.WriteLine("2 - Автоматически (случайные значения от 45 до 150 кг)");
            Console.Write("Ваш выбор: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.Write("Некорректный ввод. Пожалуйста, введите 1 или 2: ");
            }

            int[] weights = new int[count];

            if (choice == 1)
            {
                // Ввод весов вручную, начиная с 45 кг
                for (int i = 0; i < count; i++)
                {
                    Console.Write($"Введите вес человека {i + 1} (кг, не менее 45): ");
                    while (!int.TryParse(Console.ReadLine(), out weights[i]) || weights[i] < 45 || weights[i] > 150)
                    {
                        Console.Write("Некорректный ввод. Введите число от 45 до 150: ");
                    }
                }
            }
            else
            {
                // Заполнение рандомом от 45 до 150 кг
                for (int i = 0; i < count; i++)
                {
                    weights[i] = rand.Next(45, 151); // значения от 45 до 150 кг
                }
                Console.WriteLine("Весовые данные заполнены случайными значениями от 45 до 150 кг.");
            }

            // Вывод списка людей и их весов
            Console.WriteLine("\nСписок людей и их вес:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Человек {i + 1}: {weights[i]} кг");
            }

            // Определение минимального и максимального веса
            int minWeight = weights[0];
            int maxWeight = weights[0];

            foreach (int w in weights)
            {
                if (w < minWeight) minWeight = w;
                if (w > maxWeight) maxWeight = w;
            }

            // Проверка условия
            if (maxWeight > 2 * minWeight)
            {
                Console.WriteLine($"\nДа, вес самого тяжелого человека ({maxWeight} кг) превышает вес самого легкого ({minWeight} кг) более чем в 2 раза.");
            }
            else
            {
                Console.WriteLine($"\nНет, вес самого тяжелого человека ({maxWeight} кг) не превышает вес самого легкого ({minWeight} кг) более чем в 2 раза.");
            }
        }
    }
    static void Task6()
    {
        Console.WriteLine("\nЗадание 6: Дан массив из четного числа элементов. Поменять \r\nместами: \r\nа) его половины; \r\nб) первый элемент со вторым, третий – с четвертым и т. д.; \r\nв) его половины следующим способом: первый элемент \r\nпоменять с последним, второй – с предпоследним и т. д. ");
        {
            // Ввод длины массива (должна быть четной)
            int n;
            Console.Write("Введите четное число элементов массива: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n % 2 != 0)
            {
                Console.Write("Некорректный ввод. Введите положительное четное число: ");
            }

            int[] array = new int[n];

            // Выбор режима заполнения массива
            Console.WriteLine("Выберите способ заполнения массива:");
            Console.WriteLine("1 - Вручную");
            Console.WriteLine("2 - Автоматически (случайные числа от 1 до 100)");
            Console.Write("Ваш выбор: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.Write("Некорректный ввод. Пожалуйста, введите 1 или 2: ");
            }

            Random rand = new Random();

            if (choice == 1)
            {
                // Ввод элементов вручную
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Введите элемент массива {i + 1} (от 1 до 100): ");
                    while (!int.TryParse(Console.ReadLine(), out array[i]) || array[i] < 1 || array[i] > 100)
                    {
                        Console.Write("Некорректный ввод. Введите число от 1 до 100: ");
                    }
                }
            }
            else
            {
                // Заполнение массива случайными числами
                for (int i = 0; i < n; i++)
                {
                    array[i] = rand.Next(1, 101);
                }
                Console.WriteLine("Массив заполнен случайными числами от 1 до 100.");
            }

            // Вывод исходного массива
            Console.WriteLine("Исходный массив:");
            Console.WriteLine(string.Join(" ", array));

            int half = n / 2;

            // а) Поменять местами половины массива
            for (int i = 0; i < half; i++)
            {
                int temp = array[i];
                array[i] = array[i + half];
                array[i + half] = temp;
            }
            Console.WriteLine("После обмена половин:");
            Console.WriteLine(string.Join(" ", array));

            // б) Поменять местами элементы попарно: первый со вторым, третий с четвертым и т.д.
            for (int i = 0; i < n; i += 2)
            {
                int temp = array[i];
                array[i] = array[i + 1];
                array[i + 1] = temp;
            }
            Console.WriteLine("После попарного обмена элементов:");
            Console.WriteLine(string.Join(" ", array));

            // в) Поменять местами половину массива: первый элемент с последним, второй – с предпоследним и т.д.
            for (int i = 0; i < half; i++)
            {
                int temp = array[i];
                array[i] = array[n - 1 - i];
                array[n - 1 - i] = temp;
            }
            Console.WriteLine("После обмена половины с зеркалом:");
            Console.WriteLine(string.Join(" ", array));
        }
    }
    static void Task7()
    {
        Console.WriteLine("\nЗадание 7: Дан массив, упорядоченный по возрастанию, и число a, о \r\nкотором известно следующее: оно не равно ни одному из элементов \r\nмассива, больше первого и меньше последнего элемента. \r\nа) вывести все элементы массива, меньшие a. \r\nб) найти два элемента массива (их порядковые номера и \r\nзначение), в интервале, между которыми находится \r\nзначение n. \r\nв) найти элемент массива (его порядковый номер и \r\nзначение), ближайший к a. \r\nВ задачах (а) и (б) условный оператор не использовать. ");
        {
            // Ввод массива
            Console.WriteLine("\nВведите отсортированный по возрастанию массив через пробел:");
            var inputArray = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // Ввод числа a
            Console.WriteLine("Введите число a (больше первого и меньше последнего элемента массива):");
            int a = int.Parse(Console.ReadLine());

            // Ввод числа n
            Console.WriteLine("Введите число n:");
            int n = int.Parse(Console.ReadLine());

            // 1. Все элементы, меньшие a (без условных операторов)
            var lessThanA = inputArray.TakeWhile(x => x < a).ToArray();
            Console.WriteLine("\nЭлементы массива, меньшие a:");
            Console.WriteLine(string.Join(", ", lessThanA));

            // 2. Интервал, между которыми находится n
            var interval = inputArray
                .Zip(inputArray.Skip(1), (x, y) => new { x, y })
                .Select((pair, index) => new { pair.x, pair.y, index })
                .Where(p => p.x < n && n < p.y)
                .FirstOrDefault();

            if (interval != null)
            {
                Console.WriteLine($"\nДва элемента, между которыми находится n={n}:");
                Console.WriteLine($"Индексы: {interval.index} ({inputArray[interval.index]}), {interval.index + 1} ({inputArray[interval.index + 1]})");
            }
            else
            {
                Console.WriteLine($"\nИнтервал, в который входит n={n}, не найден");
            }

            // 3. Элемент, ближайший к a
            var closest = inputArray
                .Select((value, index) => new { value, index })
                .OrderBy(x => Math.Abs(x.value - a))
                .First();

            Console.WriteLine($"\nЭлемент, ближайший к a={a}:");
            Console.WriteLine($"Индекс: {closest.index}, Значение: {closest.value}");
        }
    }
    static void Task8()
    {
        Console.WriteLine("\nЗадание 8: Размеры 12 параллелепипедов (длина, ширина, высота) \r\nхранятся в трех массивах. Вывести на экран объемы каждой \r\nфигуры. \r\nЗадачу решить двумя способами: \r\n1) без использования дополнительного (третьего) массива; \r\n2) с использованием дополнительного массива. ");

        {
            Console.Write("\nВведите количество параллелепипедов: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Некорректный ввод. Введите положительное целое число: ");
            }

            int[] lengths = new int[n];
            int[] widths = new int[n];
            int[] heights = new int[n];

            // Ввод размеров каждого параллелепипеда
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nВведите размеры для параллелепипеда {i + 1}:");

                Console.Write("Длина: ");
                while (!int.TryParse(Console.ReadLine(), out lengths[i]) || lengths[i] <= 0)
                {
                    Console.Write("Некорректный ввод. Введите положительное целое число: ");
                }

                Console.Write("Ширина: ");
                while (!int.TryParse(Console.ReadLine(), out widths[i]) || widths[i] <= 0)
                {
                    Console.Write("Некорректный ввод. Введите положительное целое число: ");
                }

                Console.Write("Высота: ");
                while (!int.TryParse(Console.ReadLine(), out heights[i]) || heights[i] <= 0)
                {
                    Console.Write("Некорректный ввод. Введите положительное целое число: ");
                }
            }

            Console.WriteLine("\nВыберите способ решения задачи:");
            Console.WriteLine("1 - Без использования дополнительного массива");
            Console.WriteLine("2 - С использованием дополнительного массива");
            Console.Write("Введите номер способа (1 или 2): ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.Write("Некорректный ввод. Введите 1 или 2: ");
            }

            if (choice == 1)
            {
                // Способ 1: без дополнительного массива
                Console.WriteLine("\nОбъемы параллелепипедов:");
                for (int i = 0; i < n; i++)
                {
                    int volume = lengths[i] * widths[i] * heights[i];
                    Console.WriteLine($"Параллелепипед {i + 1}: объем = {volume}");
                }
            }
            else
            {
                // Способ 2: с использованием дополнительного массива
                int[] volumes = new int[n];

                for (int i = 0; i < n; i++)
                {
                    volumes[i] = lengths[i] * widths[i] * heights[i];
                }

                Console.WriteLine("\nОбъемы параллелепипедов:");
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Параллелепипед {i + 1}: объем = {volumes[i]}");
                }
            }
        }
    }
}