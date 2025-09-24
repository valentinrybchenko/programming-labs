// Задание №1, часть №1
//using System;

//class Program
//{
//    public void Caller()
//    {
//        int numA = 4;
//        // Call with an int variable.
//        int productA = Square(numA);

//        int numB = 32;
//        // Call with another int variable.
//        int productB = Square(numB);

//        // Call with an integer literal.
//        int productC = Square(12);

//        // Call with an expression that evaluates to int.
//        productC = Square(productA * 3);

//        Console.WriteLine($"productA = {productA}");
//        Console.WriteLine($"productB = {productB}");
//        Console.WriteLine($"productC = {productC}");
//    }

//    int Square(int i)
//    {
//        // Store input argument in a local variable.
//        int input = i;
//        return input * input;
//    }

//    static void Main(string[] args)
//    {
//        Program p = new Program();
//        p.Caller();
//    }
//}

// Задание №1, часть №2
//using System;

//class Car
//{
//    private double mileage;
//    private double fuel;

//    public Car() // объявление конструктора
//    {
//        mileage = 0;
//        fuel = 0;
//        Console.WriteLine($"Пробег: {mileage}, Топливо: {fuel}");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Car newCar = new Car(); // создание объекта и вызов конструктора
//    }
//}


// Задание №1, часть №3
//using System;

//public class Date
//{
//    private int _month = 7; // начальное значение

//    public int Month
//    {
//        get => _month;
//        set
//        {
//            if (value > 0 && value < 13)
//            {
//                _month = value;
//            }
//        }
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Date d = new Date();

//        Console.WriteLine($"Месяц по умолчанию: {d.Month}");

//        d.Month = 12;
//        Console.WriteLine($"После присвоения 12: {d.Month}");

//        d.Month = 15; // недопустимое значение
//        Console.WriteLine($"После присвоения 15: {d.Month}");

//        d.Month = 1;
//        Console.WriteLine($"После присвоения 1: {d.Month}");

//        Console.ReadKey();
//    }
//}

// Задание №2
//using System;

//class Car
//{
//    private double mileage;
//    private double fuel;

//    public Car(double mileage, double fuel)
//    {
//        this.mileage = mileage;
//        this.fuel = fuel;
//    }

//    public void PrintInfo()
//    {
//        Console.WriteLine($"Пробег: {mileage}, Топливо: {fuel}");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Car newCar = new Car(100, 50); // вызов конструктора с параметрами
//        newCar.PrintInfo();            // вывод значений полей
//    }
//}

//Задание №3
//using System;

//class Car
//{
//    private double mileage;
//    private double fuel;

//    public Car()
//    {
//        mileage = 0;
//        fuel = 0;
//    }

//    public Car(double mileage, double fuel)
//    {
//        this.mileage = mileage;
//        this.fuel = fuel;
//    }

//    // третий конструктор
//    public Car(bool defaultValues)
//    {
//        mileage = 100;
//        fuel = 50;
//    }

//    public void PrintInfo()
//    {
//        Console.WriteLine($"Пробег: {mileage}, Топливо: {fuel}");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Car newCar = new Car();             // 0 и 0
//        Car newCar2 = new Car(100, 50);     // указанные параметры
//        Car newCar3 = new Car(true);        // 100 и 50

//        newCar.PrintInfo();
//        newCar2.PrintInfo();
//        newCar3.PrintInfo();
//    }
//}

//Задание №4
//using System;

//class Student
//{
//    private int year; // закрытое поле

//    public int Year   // свойство
//    {
//        get // аксессор чтения
//        {
//            return year;
//        }
//        set // аксессор записи
//        {
//            if (value < 1)
//                year = 1;
//            else if (value > 5)
//                year = 5;
//            else
//                year = value;
//        }
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        Student st1 = new Student();

//        st1.Year = 0; // используем set → попадет ограничение, установится 1
//        Console.WriteLine(st1.Year); // используем get → выведет 1

//        st1.Year = 3; // корректное значение
//        Console.WriteLine(st1.Year); // выведет 3

//        st1.Year = 10; // слишком большое значение
//        Console.WriteLine(st1.Year); // выведет 5

//        Console.ReadKey();
//    }
//}

// Задание №5
using System;

class Car
{
    public double Mileage { get; set; }   // пробег
    public double Fuel { get; set; }      // топливо
}

class Program
{
    static void Main(string[] args)
    {
        Car newCar = new Car();

        newCar.Mileage = 120.5; // задаем пробег
        newCar.Fuel = 45.7;     // задаем количество топлива

        Console.WriteLine($"Пробег: {newCar.Mileage}");
        Console.WriteLine($"Топливо: {newCar.Fuel}");

        Console.ReadKey();
    }
}
