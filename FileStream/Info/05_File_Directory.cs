using System;
using System.IO;

// Теперь рассмотрим как можно использовать в этих целях
// классы File и Directory
namespace FileStreamSample
{
    class Sample5
    {
        public static void Demo()
        {
            string file = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Console.WriteLine("Полный путь к исполняемому файлу: " + file);

            // Имеются так же функции, которые позволят установить эти свойства (Set...)
            Console.WriteLine("Аттрибут: " + File.GetAttributes(file));
            Console.WriteLine("F02--> " + File.GetAccessControl(file));
            Console.WriteLine("Создан: " + File.GetCreationTime(file));
            Console.WriteLine("Последнее обращение к файлу: " + File.GetLastAccessTime(file));
            Console.WriteLine("Последняя запись в файл: " + File.GetLastWriteTime(file));
            Console.WriteLine(new string('-', 45));

            //
            string filePath = Path.GetDirectoryName(file);
            Console.WriteLine("Директория создана: " + Directory.GetCreationTime(filePath));
            Console.WriteLine("Текущая рабочая директория: " + Directory.GetCurrentDirectory());
            Console.WriteLine("Обращение к директории: " + Directory.GetLastAccessTime(filePath));
            Console.WriteLine("Изменение в директории: " + Directory.GetLastWriteTime(filePath));
            Console.WriteLine("Родительская папка: " + Directory.GetParent(filePath));
            Console.WriteLine("Корневая папка: " + Directory.GetDirectoryRoot(filePath));
            Console.WriteLine(new string('-', 45));

            // ну и, напоследок, список директорий
            string[] ds = Directory.GetDirectories("C:\\");
            foreach (string NameDir in ds)
            {
                Console.WriteLine(NameDir);
            }

        }
    }
}