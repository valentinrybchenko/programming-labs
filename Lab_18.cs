//Первое задание

//using System;

//class ComplexNumber
//{
//    public double Real { get; set; }
//    public double Imag { get; set; }

//    public ComplexNumber(double real = 0, double imag = 0)
//    {
//        Real = real;
//        Imag = imag;
//    }

//    // Сложение
//    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
//        => new ComplexNumber(a.Real + b.Real, a.Imag + b.Imag);

//    // Вычитание
//    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
//        => new ComplexNumber(a.Real - b.Real, a.Imag - b.Imag);

//    // Умножение
//    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
//        => new ComplexNumber(
//            a.Real * b.Real - a.Imag * b.Imag,
//            a.Real * b.Imag + a.Imag * b.Real
//        );

//    // Деление с проверкой на ноль
//    public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
//    {
//        double denom = b.Real * b.Real + b.Imag * b.Imag;
//        if (denom == 0) throw new DivideByZeroException("Деление на нулевое комплексное число");
//        return new ComplexNumber(
//            (a.Real * b.Real + a.Imag * b.Imag) / denom,
//            (a.Imag * b.Real - a.Real * b.Imag) / denom
//        );
//    }

//    public override string ToString()
//    {
//        string r = Real.ToString("0.##");
//        string i = Math.Abs(Imag).ToString("0.##");

//        if (Imag == 0) return r;
//        if (Real == 0) return (Imag >= 0 ? "" : "-") + i + "i";
//        return $"{r} {(Imag >= 0 ? "+" : "-")} {i}i";
//    }

//    // Ввод вручную
//    public void FillManual()
//    {
//        Console.Write("Введите действительную часть: ");
//        Real = double.Parse(Console.ReadLine());
//        Console.Write("Введите мнимую часть: ");
//        Imag = double.Parse(Console.ReadLine());
//    }

//    // Случайное заполнение
//    public void FillRandom(int min, int max)
//    {
//        Random rnd = new Random();
//        Real = rnd.Next(min, max + 1);
//        Imag = rnd.Next(min, max + 1);
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        ComplexNumber A = new ComplexNumber();
//        ComplexNumber B = new ComplexNumber();

//        // Ввод для A
//        Console.WriteLine("Заполнить комплексное число A вручную или автоматически? (m/a)");
//        string choice = Console.ReadLine().ToLower();
//        if (choice == "m") A.FillManual();
//        else
//        {
//            Console.Write("Минимальное значение: ");
//            int min = int.Parse(Console.ReadLine());
//            Console.Write("Максимальное значение: ");
//            int max = int.Parse(Console.ReadLine());
//            A.FillRandom(min, max);
//        }

//        // Ввод для B
//        Console.WriteLine("Заполнить комплексное число B вручную или автоматически? (m/a)");
//        choice = Console.ReadLine().ToLower();
//        if (choice == "m") B.FillManual();
//        else
//        {
//            Console.Write("Минимальное значение: ");
//            int min = int.Parse(Console.ReadLine());
//            Console.Write("Максимальное значение: ");
//            int max = int.Parse(Console.ReadLine());
//            B.FillRandom(min, max);
//        }

//        Console.WriteLine($"\nКомплексное число A: {A}");
//        Console.WriteLine($"Комплексное число B: {B}");

//        // Выбор операции
//        Console.WriteLine("Выберите операцию: +, -, *, /");
//        string op = Console.ReadLine();

//        try
//        {
//            ComplexNumber result = op switch
//            {
//                "+" => A + B,
//                "-" => A - B,
//                "*" => A * B,
//                "/" => A / B,
//                _ => throw new InvalidOperationException("Некорректная операция")
//            };

//            Console.WriteLine($"\nРезультат: {result}");
//        }
//        catch (Exception e)
//        {
//            Console.WriteLine("Ошибка: " + e.Message);
//        }
//    }
//}




//Второе задание


//using System;

//class Matrix
//{
//    private double[,] data;

//    public int Rows { get; }
//    public int Cols { get; }

//    public Matrix(int rows, int cols)
//    {
//        Rows = rows;
//        Cols = cols;
//        data = new double[rows, cols];
//    }

//    public double this[int row, int col]
//    {
//        get => data[row, col];
//        set => data[row, col] = value;
//    }

//    public static Matrix operator +(Matrix a, Matrix b)
//    {
//        if (a.Rows != b.Rows || a.Cols != b.Cols)
//            throw new InvalidOperationException("Матрицы должны быть одного размера для сложения.");

//        Matrix result = new Matrix(a.Rows, a.Cols);
//        for (int i = 0; i < a.Rows; i++)
//            for (int j = 0; j < a.Cols; j++)
//                result[i, j] = a[i, j] + b[i, j];

//        return result;
//    }

//    public static Matrix operator -(Matrix a, Matrix b)
//    {
//        if (a.Rows != b.Rows || a.Cols != b.Cols)
//            throw new InvalidOperationException("Матрицы должны быть одного размера для вычитания.");

//        Matrix result = new Matrix(a.Rows, a.Cols);
//        for (int i = 0; i < a.Rows; i++)
//            for (int j = 0; j < a.Cols; j++)
//                result[i, j] = a[i, j] - b[i, j];

//        return result;
//    }

//    public static Matrix operator *(Matrix a, Matrix b)
//    {
//        if (a.Cols != b.Rows)
//            throw new InvalidOperationException("Число столбцов первой матрицы должно совпадать с числом строк второй.");

//        Matrix result = new Matrix(a.Rows, b.Cols);
//        for (int i = 0; i < a.Rows; i++)
//            for (int j = 0; j < b.Cols; j++)
//                for (int k = 0; k < a.Cols; k++)
//                    result[i, j] += a[i, k] * b[k, j];

//        return result;
//    }

//    public void Print()
//    {
//        for (int i = 0; i < Rows; i++)
//        {
//            for (int j = 0; j < Cols; j++)
//                Console.Write(data[i, j] + "\t");
//            Console.WriteLine();
//        }
//        Console.WriteLine();
//    }

//    public void FillManual()
//    {
//        for (int i = 0; i < Rows; i++)
//            for (int j = 0; j < Cols; j++)
//            {
//                Console.Write($"Введите элемент [{i},{j}]: ");
//                data[i, j] = double.Parse(Console.ReadLine());
//            }
//    }

//    public void FillRandom(int min, int max)
//    {
//        Random rnd = new Random();
//        for (int i = 0; i < Rows; i++)
//            for (int j = 0; j < Cols; j++)
//                data[i, j] = rnd.Next(min, max + 1);
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("Введите размеры первой матрицы:");
//        Console.Write("Количество строк: ");
//        int rowsA = int.Parse(Console.ReadLine());
//        Console.Write("Количество столбцов: ");
//        int colsA = int.Parse(Console.ReadLine());

//        Matrix A = new Matrix(rowsA, colsA);

//        Console.WriteLine("Заполнить матрицу вручную или автоматически? (m/a)");
//        string choice = Console.ReadLine().ToLower();

//        if (choice == "m")
//            A.FillManual();
//        else
//        {
//            Console.Write("Минимальное значение: ");
//            int min = int.Parse(Console.ReadLine());
//            Console.Write("Максимальное значение: ");
//            int max = int.Parse(Console.ReadLine());
//            A.FillRandom(min, max);
//        }

//        Console.WriteLine("\nВведите размеры второй матрицы:");
//        Console.Write("Количество строк: ");
//        int rowsB = int.Parse(Console.ReadLine());
//        Console.Write("Количество столбцов: ");
//        int colsB = int.Parse(Console.ReadLine());

//        Matrix B = new Matrix(rowsB, colsB);

//        Console.WriteLine("Заполнить матрицу вручную или автоматически? (m/a)");
//        choice = Console.ReadLine().ToLower();

//        if (choice == "m")
//            B.FillManual();
//        else
//        {
//            Console.Write("Минимальное значение: ");
//            int min = int.Parse(Console.ReadLine());
//            Console.Write("Максимальное значение: ");
//            int max = int.Parse(Console.ReadLine());
//            B.FillRandom(min, max);
//        }

//        Console.WriteLine("\nМатрица A:");
//        A.Print();
//        Console.WriteLine("Матрица B:");
//        B.Print();

//        Console.WriteLine("Выберите операцию: +, -, *");
//        string op = Console.ReadLine();

//        try
//        {
//            Matrix result = op switch
//            {
//                "+" => A + B,
//                "-" => A - B,
//                "*" => A * B,
//                _ => throw new InvalidOperationException("Некорректная операция")
//            };

//            Console.WriteLine("\nРезультат:");
//            result.Print();
//        }
//        catch (Exception e)
//        {
//            Console.WriteLine("Ошибка: " + e.Message);
//        }
//    }
//}


//Третье задание


using System;

class Vector
{
    private double[] data;
    public int Dimension => data.Length;

    public Vector(int dimension)
    {
        data = new double[dimension];
    }

    // Индексатор
    public double this[int index]
    {
        get => data[index];
        set => data[index] = value;
    }

    // Сложение
    public static Vector operator +(Vector a, Vector b)
    {
        if (a.Dimension != b.Dimension)
            throw new InvalidOperationException("Векторы должны иметь одинаковую размерность.");

        Vector result = new Vector(a.Dimension);
        for (int i = 0; i < a.Dimension; i++)
            result[i] = a[i] + b[i];

        return result;
    }

    // Вычитание
    public static Vector operator -(Vector a, Vector b)
    {
        if (a.Dimension != b.Dimension)
            throw new InvalidOperationException("Векторы должны иметь одинаковую размерность.");

        Vector result = new Vector(a.Dimension);
        for (int i = 0; i < a.Dimension; i++)
            result[i] = a[i] - b[i];

        return result;
    }

    // Скалярное произведение
    public static double operator *(Vector a, Vector b)
    {
        if (a.Dimension != b.Dimension)
            throw new InvalidOperationException("Векторы должны иметь одинаковую размерность.");

        double sum = 0;
        for (int i = 0; i < a.Dimension; i++)
            sum += a[i] * b[i];

        return sum;
    }

    // Векторное произведение (только для 3D)
    public static Vector operator ^(Vector a, Vector b)
    {
        if (a.Dimension != 3 || b.Dimension != 3)
            throw new InvalidOperationException("Векторное произведение определено только для 3D-векторов.");

        return new Vector(3)
        {
            [0] = a[1] * b[2] - a[2] * b[1],
            [1] = a[2] * b[0] - a[0] * b[2],
            [2] = a[0] * b[1] - a[1] * b[0]
        };
    }

    // Печать
    public void Print()
    {
        Console.Write("(" + string.Join(", ", data) + ")");
        Console.WriteLine();
    }

    // Ввод вручную
    public void FillManual()
    {
        for (int i = 0; i < Dimension; i++)
        {
            Console.Write($"Введите компоненту [{i}]: ");
            data[i] = double.Parse(Console.ReadLine());
        }
    }

    // Рандомное заполнение
    public void FillRandom(int min, int max)
    {
        Random rnd = new Random();
        for (int i = 0; i < Dimension; i++)
            data[i] = rnd.Next(min, max + 1);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите размерность векторов: ");
        int dim = int.Parse(Console.ReadLine());

        Vector A = new Vector(dim);
        Vector B = new Vector(dim);

        // Ввод для вектора A
        Console.WriteLine("Заполнить вектор A вручную или автоматически? (m/a)");
        string choice = Console.ReadLine().ToLower();
        if (choice == "m") A.FillManual();
        else
        {
            Console.Write("Минимальное значение: ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Максимальное значение: ");
            int max = int.Parse(Console.ReadLine());
            A.FillRandom(min, max);
        }

        // Ввод для вектора B
        Console.WriteLine("Заполнить вектор B вручную или автоматически? (m/a)");
        choice = Console.ReadLine().ToLower();
        if (choice == "m") B.FillManual();
        else
        {
            Console.Write("Минимальное значение: ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Максимальное значение: ");
            int max = int.Parse(Console.ReadLine());
            B.FillRandom(min, max);
        }

        Console.WriteLine("\nВектор A:");
        A.Print();
        Console.WriteLine("Вектор B:");
        B.Print();

        Console.WriteLine("Выберите операцию: +, -, * (скалярное), ^ (векторное для 3D)");
        string op = Console.ReadLine();

        try
        {
            switch (op)
            {
                case "+":
                    (A + B).Print();
                    break;
                case "-":
                    (A - B).Print();
                    break;
                case "*":
                    Console.WriteLine(A * B);
                    break;
                case "^":
                    (A ^ B).Print();
                    break;
                default:
                    Console.WriteLine("Некорректная операция.");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }
    }
}
