//Первое задание

//using System;
//using System.IO;

//class Program
//{
//    static void Main()
//    {
//        DriveInfo[] drives = DriveInfo.GetDrives();

//        foreach (DriveInfo drive in drives)
//        {
//            Console.WriteLine($"Диск: {drive.Name}");
//            Console.WriteLine($"Тип: {drive.DriveType}");

//            if (drive.IsReady)
//            {
//                Console.WriteLine($"Файловая система: {drive.DriveFormat}");
//                Console.WriteLine($"Общий объём: {drive.TotalSize / 1024 / 1024 / 1024} GB");
//                Console.WriteLine($"Свободно: {drive.TotalFreeSpace / 1024 / 1024 / 1024} GB");
//                Console.WriteLine($"Доступно: {drive.AvailableFreeSpace / 1024 / 1024 / 1024} GB");
//            }
//            else
//            {
//                Console.WriteLine("Диск не готов");
//            }

//            Console.WriteLine(new string('-', 40));
//        }

//        Console.ReadKey();
//    }
//}



//Второе задание

using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Список студентов
        string[] students =
        {
            "Рыбченко Валентин",
            "Задорожний Дмитрий",
            "Калинин Никита",
            "Мартиянов Даниил",
            "Цыбуля Иван"
        };

        // Запрос пути у пользователя
        Console.WriteLine("Введите путь для сохранения файла (например: C:\\Users\\User\\Desktop):");
        string folderPath = Console.ReadLine();

        string filePath = Path.Combine(folderPath, "студенты.txt");

        // ===== Способ 1: File.WriteAllLines =====
        File.WriteAllLines(filePath, students);

        // ===== Способ 2: StreamWriter (добавление в файл) =====
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine("\n--- Запись вторым способом ---");
            foreach (string student in students)
            {
                writer.WriteLine(student);
            }
        }

        // ===== Чтение файла и вывод в консоль =====
        Console.WriteLine("\nСодержимое файла студенты.txt:\n");

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}