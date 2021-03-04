using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreamSample
{
    //Наюлюдение за директориями (763)

    class DirectoryWatcher
    {
        public static void Demo()
        {
            Console.WriteLine("***** The Amazing File Watcher App *****\n");

            // Установить путь к каталогу, за которым нужно наблюдать.
            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                System.IO.DirectoryInfo df2 = new System.IO.DirectoryInfo("..\\..\\Stream");

                watcher.Path = df2.FullName;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            // Указать цели наблюдения.
            watcher.NotifyFilter = NotifyFilters.LastAccess
              | NotifyFilters.LastWrite
              | NotifyFilters.FileName
              | NotifyFilters.DirectoryName;

            // Следить только за текстовыми файлами.
            watcher.Filter = "*.txt";

            // Добавить обработчики событии.
            watcher.Changed += (s, e) =>
            {
                Console.WriteLine("File: {0} {1}!", e.FullPath, e.ChangeType);
            };

            watcher.Created += (s, e) =>
            {
                Console.WriteLine("File: {0} {1}!", e.FullPath, e.ChangeType);
            };

            watcher.Deleted += (s, e) =>
            {
                Console.WriteLine("File: {0} {1}!", e.FullPath, e.ChangeType);
            };

            watcher.Renamed += (s, e) =>
            {
                Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
            };

            // Начать наблюдение за каталогом
            watcher.EnableRaisingEvents = true;

            // Ожидать от пользователя команду завершения программы.
            Console.WriteLine(@"Press 'q' to quit app.");
            while (Console.Read() != 'q') ;
        }
    }
}
