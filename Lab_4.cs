// Задание №1, часть №1
//using System;
//using System.Collections.Generic; // нужно для List

//class Program
//{
//    static void Main(string[] args)
//    {
//        List<string> teams = new List<string>(); // создание списка 
//        teams.Add("Barcelona"); // добавление элемента 
//        teams.Add("Chelsea");
//        teams.Add("Arsenal");

//        List<string> teams2 = new List<string>() { "Dynamo", "CSKA" }; // инициализация 

//        Console.WriteLine("Список 1:");
//        foreach (string team in teams)
//        {
//            Console.WriteLine(team);
//        }

//        Console.WriteLine("\nСписок 2:");
//        foreach (string team in teams2)
//        {
//            Console.WriteLine(team);
//        }

//        Console.ReadLine(); // чтобы окно не закрывалось сразу
//    }
//}

// Задание №1, часть №2
//using System;
//class Program
//{
//    static void Main(string[] args)
//    {
//        List<int> mylist1 = new List<int>() { 10, 20, 30, 40 };
//        for (int i = 0; i < mylist1.Count; i++)
//        {
//            Console.WriteLine(mylist1[i]);
//        }
//    }
//}

// Задание №1, часть №3
//using System;
//class Program
//{
//    static void Main(string[] args)
//    {  
//     string[] teams = {"Бавария", "Боруссия", "Реал Мадрид","Манчестер Сити", "ПСЖ", "Барселона"};
//     var selectedTeams = from t in teams // определяем каждый объект из teams как t 
//     where t.ToUpper().StartsWith("Б") //фильтрация по критерию 
//     orderby t  // упорядочиваем по возрастанию 
//     select t; // выбираем объект 
//     foreach (string s in selectedTeams)
//     Console.WriteLine(s);
//    }
//}

// Задание №2
//using System;
//using System.Collections.Generic;

//class Program
//{
//    static void Main()
//    {
//        // Создание списка тремя способами
//        List<char> surname1 = new List<char>() { 'Р', 'Ы', 'Б', 'Ч', 'Е', 'Н', 'К', 'О' };
//        List<char> surname2 = new List<char>();
//        foreach (char c in "РЫБЧЕНКО") surname2.Add(c);
//        List<char> surname3 = new List<char>("РЫБЧЕНКО".ToCharArray());

//        // Вывод тремя способами
//        Console.WriteLine(string.Join(", ", surname1));
//        surname2.ForEach(c => Console.Write(c + " "));
//        Console.WriteLine();
//        for (int i = 0; i < surname3.Count; i++) Console.Write(surname3[i] + " ");
//        Console.WriteLine();
//    }
//}

// Задание №3
//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Program
//{
//    static void Main()
//    {
//        List<string> students = new List<string> { "Валентин", "Данил", "Дмитрий", "Никита", "Виктория", "Алиса", "Никита", "Виктория", "Руслан", "Максим", "Иван", "Сергей", "Борис", "Тарас" };

//        // а) только уникальные имена
//        var uniqueNames = students.Distinct();
//        Console.WriteLine("Уникальные имена: " + string.Join(", ", uniqueNames));

//        // б) первые два имени
//        var firstTwo = students.Take(2);
//        Console.WriteLine("Первые два: " + string.Join(", ", firstTwo));

//        // в) имена с третьего по пятое
//        var thirdToFifth = students.Skip(2).Take(3);
//        Console.WriteLine("С 3-го по 5-е: " + string.Join(", ", thirdToFifth));

//        // г) последние два имени
//        var lastTwo = students.Skip(Math.Max(0, students.Count - 2));
//        Console.WriteLine("Последние два: " + string.Join(", ", lastTwo));

//        // д) удалить первый элемент
//        students.RemoveAt(0);
//        Console.WriteLine("После удаления первого: " + string.Join(", ", students));

//        // е) добавить любое имя
//        students.Add("Олег");
//        Console.WriteLine("После добавления имени: " + string.Join(", ", students));

//        // ё) все имена, начинающиеся с С, Б, Т
//        var filtered = students.Where(s => s.StartsWith("С") || s.StartsWith("Б") || s.StartsWith("Т"));
//        Console.WriteLine("Начинающиеся с С, Б, Т: " + string.Join(", ", filtered));

//        // ж) LINQ с сортировкой по убыванию
//        var linqFiltered = students
//            .Where(s => s.StartsWith("С") || s.StartsWith("Б") || s.StartsWith("Т"))
//            .OrderByDescending(s => s);
//        Console.WriteLine("LINQ с сортировкой по убыванию: " + string.Join(", ", linqFiltered));
//    }
//}



// Задание №4
var names = new List<string> { "Данил", "Дмитрий", "Никита", "Виктория", "Валентин", "Алиса", "Никита", "Виктория", "Руслан", "Максим", "Иван" };
var index = names.IndexOf("Валентин");
if (index != -1)
{
    Console.WriteLine($"Мое имя {names[index]} под индексом {index}");
}

var notFound = names.IndexOf("Не найдено");
Console.WriteLine($"Если элемент не найден, индекс возвращается {notFound}");
