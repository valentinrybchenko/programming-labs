using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Рыбченко В.Л. 2КСОР");
            Console.WriteLine("Лабораторная работа №19");
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
        Console.WriteLine("\nЗадание 1: Написать программу для замены всех URL в текстовом файле на ссылку “[URL]”.");

        {
            Console.Write("\nВведите путь к исходному файлу: ");
            string inputPath = Console.ReadLine();

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            string text = File.ReadAllText(inputPath);

            // Регулярное выражение для URL
            string pattern = @"https?:\/\/[^\s]+";
            string replaced = Regex.Replace(text, pattern, "[URL]");

            Console.Write("Введите путь для сохранения нового файла: ");
            string outputPath = Console.ReadLine();

            File.WriteAllText(outputPath, replaced);
            Console.WriteLine("Все URL заменены и файл сохранён.");
        }
    }
    static void Task2() {
        Console.WriteLine("\nЗадание 2: Написать программу для подсчета количества слов, начинающихся с заглавной буквы, в введенной строке.");

        {
            Console.WriteLine("\nВведите строку:");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Строка пуста.");
                return;
            }

            // Разделяем строку на слова
            string[] words = input.Split(new char[] { ' ', '\t', '.', ',', ';', ':', '!', '?' },
                                         StringSplitOptions.RemoveEmptyEntries);

            int count = 0;

            foreach (string word in words)
            {
                if (char.IsUpper(word[0]))
                    count++;
            }

            Console.WriteLine($"Количество слов, начинающихся с заглавной буквы: {count}");
        }
    }
    static void Task3() {
        Console.WriteLine("\nЗадание 3: Написать программу для извлечения всех чисел из введенной строки и суммирования их.");

        {
            Console.WriteLine("\nВведите строку:");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Строка пуста.");
                return;
            }

            // Регулярное выражение для чисел (целые и дробные)
            string pattern = @"-?\d+(\.\d+)?";
            var matches = Regex.Matches(input, pattern);

            double sum = 0;

            foreach (Match match in matches)
            {
                sum += double.Parse(match.Value);
            }

            Console.WriteLine($"Сумма всех чисел в строке: {sum}");
        }
    }
    static void Task4() {
        Console.WriteLine("\nЗадание 4: Написать программу для проверки, является ли введенный пользователем пароль допустимым.");

        {
            string specialChars = "@#$";

            Console.WriteLine("\nПароль должен соответствовать следующим правилам:");
            Console.WriteLine("- Содержать хотя бы одну цифру");
            Console.WriteLine("- Содержать хотя бы одну заглавную букву");
            Console.WriteLine($"- Содержать хотя бы один специальный символ ({specialChars})");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();

                if (string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Пароль пустой. Попробуйте снова.\n");
                    continue;
                }

                bool hasDigit = false;
                bool hasUpper = false;
                bool hasSpecial = false;

                foreach (char c in password)
                {
                    if (char.IsDigit(c)) hasDigit = true;
                    else if (char.IsUpper(c)) hasUpper = true;
                    else if (specialChars.Contains(c)) hasSpecial = true;
                }

                if (hasDigit && hasUpper && hasSpecial)
                {
                    Console.WriteLine("Пароль допустим!");
                    break; // пароль корректный — выходим из цикла
                }
                else
                {
                    Console.WriteLine("Пароль недопустим. Он должен содержать:");
                    if (!hasDigit) Console.WriteLine("- хотя бы одну цифру");
                    if (!hasUpper) Console.WriteLine("- хотя бы одну заглавную букву");
                    if (!hasSpecial) Console.WriteLine($"- хотя бы один специальный символ ({specialChars})");
                    Console.WriteLine("Попробуйте снова.\n");
                }
            }
        }
    }
    static void Task5()
    {
        Console.WriteLine("\nЗадание 5: Написать программу для проверки корректности ввода серии и номера паспорта РФ.");

        {
            Console.WriteLine("Серия: 4 цифры, Номер: 6 цифр\n");

            while (true)
            {
                Console.Write("Введите серию паспорта (4 цифры): ");
                string series = Console.ReadLine();

                Console.Write("Введите номер паспорта (6 цифр): ");
                string number = Console.ReadLine();

                // Проверка с помощью регулярного выражения
                if (Regex.IsMatch(series, @"^\d{4}$") && Regex.IsMatch(number, @"^\d{6}$"))
                {
                    Console.WriteLine($"Паспорт {series} {number} корректен.");
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка: серия или номер введены некорректно. Попробуйте снова.\n");
                }
            }
        }
    }
}