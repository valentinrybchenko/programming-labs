using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Рыбченко В.Л. 2КСОР");
            Console.WriteLine("Лабораторная работа №9");
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
    static void Task1() {
        Console.WriteLine("Задание 1: Даны названия двух стран. Присвоить эти названия \r\nпеременным величинам s1 и s2, после чего обменять значения \r\nвеличин s1 и s2.");
        {
            // Ввод названий стран
            Console.WriteLine("\nВведите название первой страны:");
            string s1 = Console.ReadLine();

            Console.WriteLine("Введите название второй страны:");
            string s2 = Console.ReadLine();

            // Вывод исходных значений
            Console.WriteLine($"До обмена: s1 = {s1}, s2 = {s2}");

            // Обмен значений
            string temp = s1;
            s1 = s2;
            s2 = temp;

            // Вывод после обмена
            Console.WriteLine($"После обмена: s1 = {s1}, s2 = {s2}");
        }
    }
    static void Task2() {
        Console.WriteLine("Задание 2:  Дано слово из 12 букв. Поменять местами его трети \r\nследующим образом: \r\nа) первую треть слова разместить на месте третьей, вторую \r\nтреть – на месте первой, третью треть – на месте второй; \r\nб) первую треть слова разместить на месте второй, вторую \r\nтреть – на месте третьей, третью треть – на месте первой.");

        {
            // Ввод слова из 12 букв
            Console.WriteLine("\nВведите слово из 12 букв:");
            string word = Console.ReadLine();

            if (word.Length != 12)
            {
                Console.WriteLine("Ошибка: слово должно состоять из 12 букв.");
                return;
            }

            // Разделение слова на три части по 4 буквы
            string part1 = word.Substring(0, 4);
            string part2 = word.Substring(4, 4);
            string part3 = word.Substring(8, 4);

            // Вариант (а): перестановка
            string variantA = part2 + part3 + part1;
            // Вариант (б): перестановка
            string variantB = part2 + part1 + part3;

            Console.WriteLine($"Исходное слово: {word}");
            Console.WriteLine($"Вариант (а): {variantA}");
            Console.WriteLine($"Вариант (б): {variantB}");
        }
    }
    static void Task3() {
        Console.WriteLine("Задание 3:  Дано слово s. Получить слово t, получаемое путем \r\nпрочтения слова s начиная с его конца.");

        {
            // Ввод слова s
            Console.WriteLine("\nВведите слово:");
            string s = Console.ReadLine();

            // Получение слова t, прочитанного с конца
            string t = "";

            for (int i = s.Length - 1; i >= 0; i--)
            {
                t += s[i];
            }

            Console.WriteLine($"Обратное слово: {t}");
        }
    }
    static void Task4() {
        Console.WriteLine("Задание 4: Дано предложение. Определить, есть ли в нем \r\nбуквосочетания чу или щу.");

        {
            // Ввод предложения
            Console.WriteLine("\nВведите предложение:");
            string sentence = Console.ReadLine();

            // Проверка наличия "чу" и "щу"
            int indexChu = sentence.IndexOf("чу");
            int indexShchu = sentence.IndexOf("щу");

            bool hasChu = indexChu != -1;
            bool hasShchu = indexShchu != -1;

            if (hasChu && hasShchu)
            {
                Console.WriteLine("В предложении есть оба буквосочетания: 'чу' и 'щу'.");
                Console.WriteLine($"Первое из них встречается 'чу' на позиции {indexChu + 1} (нумерация с 1).");
            }
            else if (hasChu)
            {
                Console.WriteLine("В предложении есть только буквосочетание 'чу'.");
                Console.WriteLine($"Оно встречается на позиции {indexChu + 1} (нумерация с 1).");
            }
            else if (hasShchu)
            {
                Console.WriteLine("В предложении есть только буквосочетание 'щу'.");
                Console.WriteLine($"Оно встречается на позиции {indexShchu + 1} (нумерация с 1).");
            }
            else
            {
                Console.WriteLine("В предложении нет буквосочетаний 'чу' и 'щу'.");
            }
        }
    }
    static void Task5() {
        Console.WriteLine("Задание 5: Дано слово. Поменять местами его вторую и пятую буквы.");

        {
            Console.WriteLine("\nВведите слово:");
            string word = Console.ReadLine();

            // Проверка длины слова
            if (word.Length < 5)
            {
                Console.WriteLine("Слово должно содержать как минимум 5 букв.");
                return;
            }

            // Замена букв
            char[] chars = word.ToCharArray();

            // Меняем местами вторую и пятую буквы (индексы 1 и 4)
            char temp = chars[1];
            chars[1] = chars[4];
            chars[4] = temp;

            string result = new string(chars);
            Console.WriteLine("Результат: " + result);
        }
    }
    static void Task6() {
        Console.WriteLine("Задание 6: Дан текст. Найти наибольшее количество идущих подряд \r\nцифр.");

        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();

            int maxCount = 0; // максимально найденное количество подряд идущих цифр
            int currentCount = 0; // текущий счетчик подряд идущих цифр

            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    currentCount++;
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                    }
                }
                else
                {
                    currentCount = 0; // сброс счетчика при встрече нецифрового символа
                }
            }

            Console.WriteLine("Наибольшее количество идущих подряд цифр: " + maxCount);
        }
    }
    static void Task7() {
        Console.WriteLine("Задание 7: Дано предложение. Напечатать его самое длинное слово \r\n(принять, что такое слово – единственное).");

        {
            Console.WriteLine("\nВведите предложение:");
            string sentence = Console.ReadLine();

            // Разделяем предложение на слова по пробелам и знакам препинания
            string[] words = sentence.Split(new char[] { ' ', '\t', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                Console.WriteLine("В предложении нет слов.");
                return;
            }

            string longestWord = "";
            int maxLength = 0;

            foreach (string word in words)
            {
                if (word.Length > maxLength)
                {
                    maxLength = word.Length;
                    longestWord = word;
                }
            }

            Console.WriteLine("Самое длинное слово: " + longestWord);

            if (words.Length == 1)
            {
                Console.WriteLine("Это единственное слово в предложении.");
            }
            else
            {
                Console.WriteLine("В предложении есть несколько слов.");
            }
        }
    }
}