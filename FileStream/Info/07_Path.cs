using System;
using System.IO;

// Демонстрация возможностей класса Path
namespace FileStreamSample
{
    class Sample7
    {
        public static void Demo()
        {
            string def = "\n" + new string('-', 50) + "\n";
            // настроим окно консоли
            Console.WindowHeight = 60;
            Console.WindowWidth = 110;
            Console.Clear();

            // Сборка, из которой выполняется текущий код
            string assemblyFile = System.Reflection.Assembly.GetExecutingAssembly().Location;

            Console.WriteLine("--> Путь к исполняемому файлу, включая имя файла" +
            "\nи его расширение: " + assemblyFile);

            string fileName = System.IO.Path.GetFileName(assemblyFile);
            Console.WriteLine("--> Имя файла: " + fileName);

            string assemblyPath = System.IO.Path.GetDirectoryName(assemblyFile);
            Console.WriteLine("--> Путь к исполняемому файлу: " + assemblyPath);

            string exeName = System.IO.Path.GetFileNameWithoutExtension(assemblyFile);
            Console.WriteLine("--> Имя исполняемого файла без расширения: " + exeName);

            // Расширение файла (его можно изменить: System.IO.Path.ChangeExtension())
            Console.WriteLine("--> Расширение файла: " +
                System.IO.Path.GetExtension(assemblyFile));

            // еще способ получить полный путь из относительного
            Console.WriteLine("--> Полный путь: " +
                System.IO.Path.GetFullPath(fileName));

            // еще способ получить полный путь из относительного
            Console.WriteLine("--> Корневой каталог: " +
                System.IO.Path.GetPathRoot(assemblyPath));


            // Объединяет две строки пути. 
            string subDir = Path.Combine(assemblyPath, "Data");
            Console.WriteLine("--> Объединение путей: " + subDir);

            Console.WriteLine("--> Случайное имя файла: " +
                System.IO.Path.GetRandomFileName());

            // Возвращает уникальное имя временного файла и создает на диске по этому 
            // имени файл длиной 0 байт.
            string tempFile = Path.GetTempFileName();
            Console.WriteLine("--> Временный файл: " + tempFile);
            System.IO.File.Delete(tempFile); // сразу его удалим :)
            // путь к временной папке
            Console.WriteLine("--> Путь к папке с временными файлами: " +
                Path.GetTempPath());
            //-------------------------------------------------------------------  
            Console.WriteLine(def);

            // Можно также получить некоторые интересующие нас сведения
            Console.WriteLine("--> Есть расширение в имени? - " +
                System.IO.Path.HasExtension(fileName));
            Console.WriteLine("--> Корневой каталог указан в пути? - " +
               System.IO.Path.IsPathRooted(fileName));

            //-------------------------------------------------------------------  
            Console.WriteLine(def);
            //Некоторые символы, необходимые для построения путей
            Console.WriteLine("Path.AltDirectorySeparatorChar = {0}",
            Path.AltDirectorySeparatorChar);
            Console.WriteLine("Path.DirectorySeparatorChar = {0}",
            Path.DirectorySeparatorChar);
            Console.WriteLine("Path.PathSeparator = {0}",
            Path.PathSeparator);
            Console.WriteLine("Path.VolumeSeparatorChar = {0}",
            Path.VolumeSeparatorChar);
            //--------------

        }

    }
}
