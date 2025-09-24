// Первое задание
//using System;

//class Area
//{
//    public static double Trapezoid(int a, int b, int h) // Площадь трапеции
//    {
//        return (a + b) / 2.0 * h;
//    }

//    public static double Triangle(int a, int h) // Площадь треугольника
//    {
//        return 0.5 * a * h;
//    }

//    public static int Rectangle(int a, int b) // Площадь прямоугольника 
//    {
//        return a * b;
//    }

//    public static double Circle(int r) // Площадь круга
//    {
//        return Math.PI * r * r;
//    }
//}

// Второе задание
//class Program
//{
//    static void Main()
//    {
//        // Исходные данные
//        int a = 10;
//        int b = 6;
//        int h = 5;
//        int r = 4;

//        Console.WriteLine("Площадь трапеции = " + Area.Trapezoid(a, b, h));
//        Console.WriteLine("Площадь треугольника = " + Area.Triangle(a, h));
//        Console.WriteLine("Площадь прямоугольника = " + Area.Rectangle(a, b));
//        Console.WriteLine("Площадь круга = " + Area.Circle(r));

//        Console.ReadKey();
//    }
//}

// Третье задание, первый пример
//using System;

//class Program
//{
//    static void Main()
//    {
//        // Константы разных типов
//        const int myInt = 10;
//        const string myString = "2КСОР Рыбченко В.Л.";
//        const bool myBool = true;
//        const char myChar = 'A';
//        const double myDouble = 3.14;

//        // Вывод констант
//        Console.WriteLine("Константы:");
//        Console.WriteLine($"int: {myInt}");
//        Console.WriteLine($"string: {myString}");
//        Console.WriteLine($"bool: {myBool}");
//        Console.WriteLine($"char: {myChar}");
//        Console.WriteLine($"double: {myDouble}");
//        Console.WriteLine();

//        // Переменные для демонстрации инкремента и декремента
//        int a = 14;
//        int b = 9;

//        Console.WriteLine("Инкремент и декремент:");
//        Console.WriteLine($"Исходное значение a = {a}");
//        a++; // инкремент
//        Console.WriteLine($"После a++ : {a}");
//        a--; // декремент
//        Console.WriteLine($"После a-- : {a}");

//        Console.WriteLine($"Исходное значение b = {b}");
//        Console.WriteLine($"++b = {++b}"); // префиксный инкремент
//        Console.WriteLine($"b-- = {b--}"); // постфиксный декремент
//        Console.WriteLine($"Текущее значение b = {b}");
//    }
//}

// Третье задание, второй пример
//using System;
//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("Привет!");
//    }
//}

//using System;

//class Program
//{
//    static void Main(string[] args)
//    {
//        int a; // объявляем переменную a типа int 
//        a = 5; // записываем в переменную a число 5 

//        int b = 10, c = 15; // объявляем несколько переменных с инициализацией

//        bool d; // объявляем переменную d типа bool 
//        d = true; // присваиваем значение true (истина)

//        long e = 1000000000; // инициализация long
//        float f = 5.5f; // число с плавающей точкой типа float, суффикс f
//        char g = 'g'; // символьная переменная с инициализацией

//        // Выводим все переменные на экран
//        Console.WriteLine($"a = {a}");
//        Console.WriteLine($"b = {b}");
//        Console.WriteLine($"c = {c}");
//        Console.WriteLine($"d = {d}");
//        Console.WriteLine($"e = {e}");
//        Console.WriteLine($"f = {f}");
//        Console.WriteLine($"g = {g}");
//    }
//}

// Третье задание, третий пример
//using System;
//class Program
//{
//    static void Main(string[] args)
//    {
//        const int months = 12; // объявление константы 

//        Console.WriteLine("Константа:");
//        Console.WriteLine($"a = {months}");
//    }
//}

// Третье задание, четвертый пример
//using System;

//class Program
//{
//    static void Main()
//    {
//        // double в int
//        double dNumber = 12.34;
//        int iNumber = (int)dNumber; // явное преобразование
//        Console.WriteLine($"Double {dNumber} как int: {iNumber}");

//        // int в double
//        int a = 7;
//        double b = a; // неявное преобразование
//        Console.WriteLine($"Int {a} как double: {b}");

//        // int в string
//        string str = a.ToString();
//        Console.WriteLine($"Int {a} как string: {str}");

//        // string в int
//        string strNumber = "25";
//        int parsedNumber = Convert.ToInt32(strNumber);
//        Console.WriteLine($"Строка \"{strNumber}\" как int: {parsedNumber}");

//        // int в bool
//        bool boolValue = Convert.ToBoolean(a); // 0 → false, всё остальное → true
//        Console.WriteLine($"Int {a} как bool: {boolValue}");
//    }
//}
// Третье задание, пятый пример
//using System; 
//namespace ConsoleApp1
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");
//        }
//    }
//}

// Четвертое задание
using System;

class Program
{
    static void Main()
    {
        // Преобразование double в int
        double dNumber = 12.75;
        int iNumber = Convert.ToInt32(dNumber); // округляет до ближайшего целого
        Console.WriteLine($"Double {dNumber} преобразован в int: {iNumber}");

        // Преобразование int в double
        int a = 7;
        double b = Convert.ToDouble(a);
        Console.WriteLine($"Int {a} преобразован в double: {b}");

        // Преобразование int в string
        string str = Convert.ToString(a);
        Console.WriteLine($"Int {a} преобразован в string: \"{str}\"");

        // Преобразование string в int
        string strNumber = "25";
        int parsedNumber = Convert.ToInt32(strNumber);
        Console.WriteLine($"Строка \"{strNumber}\" преобразована в int: {parsedNumber}");

        // Преобразование int в bool
        bool boolValue = Convert.ToBoolean(a); // 0 → false, все остальное → true
        Console.WriteLine($"Int {a} преобразован в bool: {boolValue}");

        // Преобразование bool в string
        string boolStr = Convert.ToString(boolValue);
        Console.WriteLine($"Bool {boolValue} преобразован в string: \"{boolStr}\"");
    }
}