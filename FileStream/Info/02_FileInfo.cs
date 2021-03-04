using System;
using System.IO;

// Получение сведений о файле
namespace FileStreamSample
{
    /*
     * AppendText()          Создает объект StreamWriter и добавляет текст в файл
     * CopyTo()              Копирует существующий файл в новый файл
     * Create()              Создает новый файл и возвращает объект FileStream 
     *                       для взаимодействия с вновь созданным файлом
     * CreateText()          Создает объект StreamWriter, который производит запись в новый текстовый файл
     * Delete()              Удаляет файл, к которому привязан экземпляр Filelnfo
     * Directory             Получает экземпляр родительского каталога
     * DirectoryName         Получает полный путь к родительскому каталогу
     * Length                Получает размер текущего файла
     * MoveTo()              Перемещает указанный файл в новое местоположение, 
     *                       предоставляя возможность указания нового имени для файла
     * Name                  Получает имя файла
     * Open()                Открывает файл с разнообразными привилегиями чтения/записи и совместного доступа
     * OpenRead()            Создает объект FileStream, доступный только для чтения
     * OpenText()            Создает объект StreamReader , который производит чтение из существующего 
     *                       текстового файла
     * OpenWrite()           Создает объект FileStream, доступный только для записи
     */
    class Sample2
    {
        public static void Demo()
        {
            string dir = "C:\\";
            DirectoryInfo di = new DirectoryInfo(dir);
            FileInfo[] files = di.GetFiles();

            // Информация о файлах (в том числе скрытых)
            // на диске C
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine(files[i].FullName);
                FileProp(files[i]);
                Console.WriteLine(new string('*', 40));
            }

        }

        // информация о файле
        static void FileProp(FileInfo file)
        {
            Console.WriteLine("Время создания файла: {0}", file.CreationTime);
            Console.WriteLine("Существует ли файл: {0}", file.Exists);
            Console.WriteLine("Расширение файла: {0}", file.Extension);
            Console.WriteLine("Имя файла: {0}", file.Name);
            Console.WriteLine("Путь к файлу: {0}", file.FullName);
            Console.WriteLine("Время последнего обращения к файлу: {0}", file.LastAccessTime);
            Console.WriteLine("Время последней записи в файл: {0}", file.LastWriteTime);
            Console.WriteLine("Имя файла: {0}", file.Name);

            Console.WriteLine("Папка в которой расположен файл: {0}", file.Directory);
            Console.WriteLine("Имя папки, в которой расположен файл: {0}", file.DirectoryName);
            Console.WriteLine("Можно удалить файл?: {0}", file.IsReadOnly);
            Console.WriteLine("Размер файла: {0}", file.Length);
            Console.WriteLine("Время создания файла: {0}", file.CreationTime);
        }
    }
}