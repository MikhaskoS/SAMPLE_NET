using System;
using System.IO;

// Класс DirectoryInfo
// информация о директории
/*
 * Create () CreateSubdirectory()     Создает каталог (или набор подкаталогов) по заданному путевому имени
 * Delete ()                          Удаляет каталог и все его содержимое
 * GetDirectories()                   Возвращает массив объектов Directorylnfo, 
 *                                    которые представляют все подкаталоги в текущем каталоге
 * GetFiles()                         Извлекает массив объектов Filelnfo, представляющий набор файлов в 
 *                                    заданном каталоге
 * MoveTo()                           Перемещает каталог со всем содержимым в новый путь
 * Parent                             Извлекает родительский каталог данного каталога
 * Root                               Получает корневую часть пути

 */

namespace FileStreamSample
{
    class Sample3
    {
        public static void Demo1()
        {

            // создадим объект типа DirectoryInfo
            System.IO.DirectoryInfo df1 = new System.IO.DirectoryInfo("C:\\Program Files");

            // Текущий рабочий каталог
            System.IO.DirectoryInfo df2 = new System.IO.DirectoryInfo(".");
            Console.WriteLine("Рабочий каталог: \t" + df2.FullName);

            // Чтобы создать каталог, нужно его указать
            System.IO.DirectoryInfo df3 = new System.IO.DirectoryInfo("C:\\MY_TEST");
            // создаем папку по этому пути
            df3.Create();

            Console.WriteLine("Извлечем информацию о директории:");

            // время создания текущей директории
            Console.WriteLine("CreationTime: \t" + df1.CreationTime);
            // время последней записи в папку
            Console.WriteLine("LastWriteTime: \t" + df1.LastWriteTime);
            // время последнего доступа к папке (файлу)
            Console.WriteLine("LastAccessTime: \t" + df1.LastAccessTime);
            // родительский каталог
            Console.WriteLine("Parent: \t" + df1.Parent);
            // родительский каталог c полным путем
            Console.WriteLine("Parent.FullName: \t" + df1.Parent.FullName);
            Console.WriteLine("Name: \t" + df1.Name);
            // полный путь директории
            Console.WriteLine("FullName: \t" + df1.FullName);
            // корневой каталог
            Console.WriteLine("Root: \t" + df1.Root);
            // аттрибут директории
            #region Список аттрибутов
            /*     
         * Archive -   Файл находится в состоянии архивирования. 
         *             Приложения используют этот атрибут, чтобы пометить файлы 
         *             для резервного копирования или удаления.  
         * Compressed -Файл сжат. 
         * Device  -   Зарезервировано для дальнейшего использования. 
         * Directory - Файл представляет собой папку. 
         * Encrypted - Файл или папка зашифрованы. Для файла это означает, что все данные 
         *             в файле зашифрованы. Для папки это означает, что шифрование 
         *             производится по умолчанию для вновь создаваемых файлов и папок. 
         * Hidden -    Файл скрытый и, таким образом, не включается в обычный 
         *             список папки.  
         * Normal -    Файл обычный, и другие атрибуты не установлены.
         *             Этот атрибут действителен только, если используется один,
         *             без других атрибутов. 
         * NotContentIndexed - Файл не будет индексироваться службой индексирования
         *             содержания операционной системы.  
         * Offline -   Файл в автономном режиме. Данные этого файла недоступны 
         *             непосредственно. 
         * ReadOnly -  Файл доступен только для чтения.  
         * ReparsePoint -Файл содержит точку повторной обработки, блокирующую 
         *             определяемые пользователем данные, связанные с файлом или папкой.
         * SparseFile -Файл представляет собой разреженный файл. Разреженными файлами 
         *             обычно являются большие файлы, в которых в основном нулевые 
         *             данные. 
         * System -    Файл является системным файлом. Этот файл является частью
         *             операционной системы или используется исключительно 
         *             операционной системой.  
         * Temporary - Временный файл. Файловые системы для ускорения доступа пытаются 
         *             держать все данные в памяти, а не сбрасывать их назад, в массовую память. 
         *             Приложение должно стирать временный файл после того, как он станет ненужен.
        */
            #endregion
            Console.WriteLine("Attributes: \t" + df1.Attributes);
        }

        public static void Demo2()
        {
            // Извлечение информации 
            // путь к исполняемому файлу
            string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Текущая директория : " + baseFolder);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Разместите .exe файл в директории, из которой \n" +
                "нужно удалить файлы (включая субдиректории!).");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Удалить файлы с расширением [.sample]: ");
            string ext = Console.ReadLine();
            DirectoryInfo di = new DirectoryInfo(baseFolder);
            DeleteFile(di, ext);
        }

        //-----------------------------------------------------------------------
        // Удаление файлов с указанным расширением из директории и суб директорий
        //-----------------------------------------------------------------------
        public static void DeleteFile(DirectoryInfo di, string ext)
        {
            FileInfo[] fi = di.GetFiles();
            for (int i = fi.Length - 1; i >= 0; i--)
            {
                if (fi[i].Extension == ext) fi[i].Delete();
            }

            DirectoryInfo[] _d = di.GetDirectories();
            foreach (DirectoryInfo d in _d)
            {
                Console.WriteLine(d.Name);
                DeleteFile(d, ext);
            }
        }
    }
}