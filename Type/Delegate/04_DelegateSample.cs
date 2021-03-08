/* -------------------------------------------------------------
 * Практический пример использования делегата
 * -------------------------------------------------------------*/
using System;
using System.Collections;
using System.IO;

// Описание: в указанном каталоге выбираются файлы, созданные 
// в 2007 году. Из них формируется строковый массив и его 
// содержимое выводится на экран.
namespace Delegate
{
    class Sample4
    {
        // объявляем делегат
        public delegate bool GetFilesFilter(string files);

        public static void Demo()
        {
            string Path = @"M:\BOOK";
            // выбираем файлы
            string[] Files = GetFiles(Path, new GetFilesFilter(FilterFiles));
            // отображаем их
            foreach (string file in Files)
                Console.WriteLine(file);
        }


        static bool FilterFiles(string file)
        {
            // в массив войдут имена файлов, созданных
            // только в 2007 году. Т.е. функция вернет
            // true, если файлы созданы в этом году
            return (File.GetCreationTime(file).Year == 2007);
        }

        // получение строкового массива из имен файлов, отфильтрованных
        // делегатом.
        public static string[] GetFiles(string path, GetFilesFilter filter)
        {
            ArrayList res = new ArrayList();
            foreach (string file in Directory.GetFiles(path))
            {
                // файл включается только с разрешения метода filter
                // он у нас FilterFiles
                if (filter == null || filter(file))
                    res.Add(file);
            }

            // углубляемся внутрь директорий
            foreach (string dir in Directory.GetDirectories(path))
                // AddRange дописывает элементы коллекции (string[]) 
                // в конец данной коллекции
                res.AddRange(GetFiles(dir, filter)); // рекурсия!

            return (string[])res.ToArray(typeof(string));
        }
    }
}