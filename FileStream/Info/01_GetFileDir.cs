using System;
using System.IO;

// Пример того, как получить список файлов и папок  
// в указанной директории. 

namespace FileStreamSample
{
    class A
    {
        private int t;

        private int T { get => t; set => t = value; }
    }
    // Файлы и папки в текущем каталоге
    public class Sample1
    {
        public Sample1():base()
        { }


        public static void Demo()
        {

            string dir = "C:\\";
            DirectoryInfo di = new DirectoryInfo(dir);
            ShowDirectory(di);
        }

        // отображение вложеных папок и файлов
        static void ShowDirectory(DirectoryInfo dir)
        {
            // Список директорий
            foreach (DirectoryInfo subDir in dir.GetDirectories())
            {
                Console.WriteLine(subDir.FullName);
            }
            // Список файлов
            foreach (FileInfo fi in dir.GetFiles())
            {
                Console.WriteLine(fi.FullName);
            }
        }
    }
}