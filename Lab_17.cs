//Первое задание

//Первый пример

//using System;

//abstract class Person
//{
//    public string Name { get; set; }
//    public string Family { get; set; }

//    public Person(string name, string family)
//    {
//        Name = name;
//        Family = family;
//    }

//    public string Display()
//    {
//        return $"{Family} {Name}";
//    }
//}

//// Класс Student наследуется от Person
//class Student : Person
//{
//    public string Group { get; set; }

//    public Student(string name, string family, string group) : base(name, family)
//    {
//        Group = group;
//    }

//    // Переопределение метода Display с возможностью отображать группу
//    public string Display(bool withGroup)
//    {
//        if (withGroup)
//            return $"{Group} {Display()}";
//        else
//            return Display();
//    }
//}

//// Класс Teacher наследуется от Person
//class Teacher : Person
//{
//    public int Seniority { get; set; }

//    public Teacher(string name, string family, int seniority) : base(name, family)
//    {
//        Seniority = seniority;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        // Создаем студентов
//        Person student = new Student("Вася", "Пупкин", "ГВН-105");
//        Student student1 = new Student("Ваня", "Иванов", "ГВН-105");

//        // Вызываем методы Display
//        Console.WriteLine(student.Display());       // метод абстрактного класса
//        Console.WriteLine(student1.Display(true)); // метод класса Student с группой

//        // Создаем преподавателя
//        Teacher teacher = new Teacher("Игорь", "Сидоров", 10);
//        Console.WriteLine(teacher.Display());      // метод абстрактного класса
//    }
//}

//Второй пример

//using System;

//// Интерфейс IMoneyVault
//interface IMoneyVault
//{
//    int MoneyAdd(int count);    // Метод для добавления денег
//    int MoneyRemove(int count); // Метод для снятия денег
//}

//// Класс Person реализует интерфейс IMoneyVault
//public class Person : IMoneyVault
//{
//    private int currentMoney;

//    public int MoneyAdd(int count)
//    {
//        return currentMoney += count;
//    }

//    public int MoneyRemove(int count)
//    {
//        return currentMoney -= count;
//    }
//}

//// Класс Shop реализует интерфейс IMoneyVault
//public class Shop : IMoneyVault
//{
//    private int currentMoney;
//    private double nalog; // НДС 13%

//    public int CurrentMoney { get => currentMoney; }
//    public double Nalog { get => nalog; }

//    public int MoneyAdd(int count)
//    {
//        currentMoney += count;
//        nalog += 0.13 * currentMoney; // считаем НДС
//        return currentMoney;
//    }

//    public int MoneyRemove(int count)
//    {
//        currentMoney -= count;
//        nalog -= 0.13 * currentMoney; // уменьшаем НДС
//        return currentMoney;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        // Работа с классом Person
//        Person person = new Person();
//        Console.WriteLine(person.MoneyAdd(10));    // Добавили деньги
//        Console.WriteLine(person.MoneyRemove(5));  // Сняли деньги

//        // Работа с классом Shop
//        Shop shop = new Shop();
//        shop.MoneyAdd(1000);
//        Console.WriteLine($"Всего денег: {shop.CurrentMoney}");
//        Console.WriteLine($"В том числе НДС: {shop.Nalog}");
//    }
//}




//Второе задание
//using System;

//// Интерфейс для геометрических фигур
//interface IGeometrical
//{
//    void GetPerimeter();
//    void GetArea();
//}

//// Прямоугольник
//class Rectangle : IGeometrical
//{
//    public double Width { get; set; }
//    public double Height { get; set; }

//    public Rectangle(double width, double height)
//    {
//        Width = width;
//        Height = height;
//    }

//    public void GetPerimeter() => Console.WriteLine($"Периметр прямоугольника: {(Width + Height) * 2}");
//    public void GetArea() => Console.WriteLine($"Площадь прямоугольника: {Width * Height}");
//}

//// Квадрат
//class Square : IGeometrical
//{
//    public double Side { get; set; }
//    public Square(double side) => Side = side;

//    public void GetPerimeter() => Console.WriteLine($"Периметр квадрата: {Side * 4}");
//    public void GetArea() => Console.WriteLine($"Площадь квадрата: {Side * Side}");
//}

//// Круг
//class Circle : IGeometrical
//{
//    public double Radius { get; set; }
//    public Circle(double radius) => Radius = radius;

//    public void GetPerimeter() => Console.WriteLine($"Периметр круга: {2 * Math.PI * Radius}");
//    public void GetArea() => Console.WriteLine($"Площадь круга: {Math.PI * Radius * Radius}");
//}

//// Треугольник
//class Triangle : IGeometrical
//{
//    public double A { get; set; }
//    public double B { get; set; }
//    public double C { get; set; }

//    public Triangle(double a, double b, double c)
//    {
//        A = a;
//        B = b;
//        C = c;
//    }

//    public void GetPerimeter() => Console.WriteLine($"Периметр треугольника: {A + B + C}");
//    public void GetArea()
//    {
//        double s = (A + B + C) / 2;
//        double area = Math.Sqrt(s * (s - A) * (s - B) * (s - C));
//        Console.WriteLine($"Площадь треугольника: {area}");
//    }
//}

//// Трапеция
//class Trapezoid : IGeometrical
//{
//    public double A { get; set; }
//    public double B { get; set; }
//    public double C { get; set; }
//    public double D { get; set; }
//    public double Height { get; set; }

//    public Trapezoid(double a, double b, double c, double d, double height)
//    {
//        A = a;
//        B = b;
//        C = c;
//        D = d;
//        Height = height;
//    }

//    public void GetPerimeter() => Console.WriteLine($"Периметр трапеции: {A + B + C + D}");
//    public void GetArea() => Console.WriteLine($"Площадь трапеции: {(A + B) / 2 * Height}");
//}

//class Program
//{
//    static void Main()
//    {
//        bool continueProgram = true;

//        while (continueProgram)
//        {
//            Console.WriteLine("\nВыберите фигуру:");
//            Console.WriteLine("1 - Прямоугольник");
//            Console.WriteLine("2 - Квадрат");
//            Console.WriteLine("3 - Круг");
//            Console.WriteLine("4 - Треугольник");
//            Console.WriteLine("5 - Трапеция");
//            Console.WriteLine("0 - Выход");

//            int choice = Convert.ToInt32(Console.ReadLine());
//            IGeometrical figure = null;

//            switch (choice)
//            {
//                case 1:
//                    Console.Write("Введите ширину прямоугольника: ");
//                    double w = Convert.ToDouble(Console.ReadLine());
//                    Console.Write("Введите высоту прямоугольника: ");
//                    double h = Convert.ToDouble(Console.ReadLine());
//                    figure = new Rectangle(w, h);
//                    break;

//                case 2:
//                    Console.Write("Введите сторону квадрата: ");
//                    double s = Convert.ToDouble(Console.ReadLine());
//                    figure = new Square(s);
//                    break;

//                case 3:
//                    Console.Write("Введите радиус круга: ");
//                    double r = Convert.ToDouble(Console.ReadLine());
//                    figure = new Circle(r);
//                    break;

//                case 4:
//                    Console.Write("Введите стороны треугольника (a b c через пробел): ");
//                    string[] tri = Console.ReadLine().Split();
//                    figure = new Triangle(
//                        Convert.ToDouble(tri[0]),
//                        Convert.ToDouble(tri[1]),
//                        Convert.ToDouble(tri[2])
//                    );
//                    break;

//                case 5:
//                    Console.Write("Введите стороны трапеции (a b c d через пробел): ");
//                    string[] trap = Console.ReadLine().Split();
//                    Console.Write("Введите высоту трапеции: ");
//                    double height = Convert.ToDouble(Console.ReadLine());
//                    figure = new Trapezoid(
//                        Convert.ToDouble(trap[0]),
//                        Convert.ToDouble(trap[1]),
//                        Convert.ToDouble(trap[2]),
//                        Convert.ToDouble(trap[3]),
//                        height
//                    );
//                    break;

//                case 0:
//                    continueProgram = false;
//                    continue;

//                default:
//                    Console.WriteLine("Неверный выбор!");
//                    continue;
//            }

//            if (figure != null)
//            {
//                figure.GetPerimeter();
//                figure.GetArea();
//            }

//            Console.WriteLine("\nХотите рассчитать другую фигуру? (да/нет)");
//            string answer = Console.ReadLine().ToLower();
//            if (answer != "да" && answer != "yes")
//            {
//                continueProgram = false;
//            }
//        }

//        Console.WriteLine("Программа завершена.");
//    }
//}



//Третье задание


using System;

// Интерфейс для трёхмерных фигур
interface IThreeD
{
    void GetSurfaceArea();  // Площадь поверхности
    void GetVolume();       // Объём
}

// Шар
class Sphere : IThreeD
{
    public double Radius { get; set; }

    public Sphere(double radius)
    {
        Radius = radius;
    }

    public void GetSurfaceArea() => Console.WriteLine($"Площадь поверхности шара: {4 * Math.PI * Radius * Radius}");
    public void GetVolume() => Console.WriteLine($"Объём шара: {(4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3)}");
}

// Параллелепипед
class Parallelepiped : IThreeD
{
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }

    public Parallelepiped(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public void GetSurfaceArea() => Console.WriteLine($"Площадь поверхности параллелепипеда: {2 * (Length * Width + Length * Height + Width * Height)}");
    public void GetVolume() => Console.WriteLine($"Объём параллелепипеда: {Length * Width * Height}");
}

// Куб (наследуемся от параллелепипеда)
class Cube : IThreeD
{
    public double Side { get; set; }

    public Cube(double side)
    {
        Side = side;
    }

    public void GetSurfaceArea() => Console.WriteLine($"Площадь поверхности куба: {6 * Side * Side}");
    public void GetVolume() => Console.WriteLine($"Объём куба: {Math.Pow(Side, 3)}");
}

class Program
{
    static void Main()
    {
        bool continueProgram = true;

        while (continueProgram)
        {
            Console.WriteLine("\nВыберите фигуру:");
            Console.WriteLine("1 - Шар");
            Console.WriteLine("2 - Параллелепипед");
            Console.WriteLine("3 - Куб");
            Console.WriteLine("0 - Выход");

            int choice = Convert.ToInt32(Console.ReadLine());
            IThreeD figure = null;

            switch (choice)
            {
                case 1:
                    Console.Write("Введите радиус шара: ");
                    double r = Convert.ToDouble(Console.ReadLine());
                    figure = new Sphere(r);
                    break;

                case 2:
                    Console.Write("Введите длину параллелепипеда: ");
                    double l = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите ширину параллелепипеда: ");
                    double w = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите высоту параллелепипеда: ");
                    double h = Convert.ToDouble(Console.ReadLine());
                    figure = new Parallelepiped(l, w, h);
                    break;

                case 3:
                    Console.Write("Введите сторону куба: ");
                    double s = Convert.ToDouble(Console.ReadLine());
                    figure = new Cube(s);
                    break;

                case 0:
                    continueProgram = false;
                    continue;

                default:
                    Console.WriteLine("Неверный выбор!");
                    continue;
            }

            if (figure != null)
            {
                figure.GetSurfaceArea();
                figure.GetVolume();
            }

            Console.WriteLine("\nХотите рассчитать другую фигуру? (да/нет)");
            string answer = Console.ReadLine().ToLower();
            if (answer != "да" && answer != "yes")
            {
                continueProgram = false;
            }
        }

        Console.WriteLine("Программа завершена.");
    }
}
