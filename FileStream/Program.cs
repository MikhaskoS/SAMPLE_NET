using System;
using System.Collections.Generic;
using System.IO;

namespace FileStreamSample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Info

            //Sample1.Demo();  // Файлы и папки в текущем каталоге
            //Sample2.Demo();  // Информация о файле
            //Sample3.Demo1();  // Информация о директории
            //Sample3.Demo2();  // Информация о директории

            // Информация о диске
            //Sample4.Demo();

            // Классы File и Directory. Сведения о файлах и каталогах
            // Текущая директория, родительская и т.п.
            //Sample5.Demo();

            // Сведения о системных папках и другие параметры рабочей среды
            //Sample6.Demo();

            // Пути
            //Sample7.Demo();
            #endregion

            #region Stream
            //Binary.DemoWriter();
            //Binary.DemoReadeer();
            #endregion

            //StreamSample.Demo();
            //FileSimple.Demo();

            // Наблюдение за изменениями в каталоге
            //DirectoryWatcher.Demo();

            //---------------------------
            //  СЕРИАЛИЗАЦИЯ
            //---------------------------
            //• BinaryFormatter
            //• SoapFormatter      (устаревший)
            //• XmlSerializer
            //• JSON

            //XMLSerializeSample.Demo();

            //JSON01.Demo();

            mySample.ReadPoints();

            Console.ReadLine();
        }
    }

    public class mySample
    {
        public struct Point
        {
            public string X;
            public string Y;

            public Point(string x, string y)
            {
                X = x;
                Y = y;
            }
        }

        public static List<Point> points = new List<Point>();

        public static void ReadPoints()
        {
            string path = @"c:\Temp\sample2.xml";
            string path1 = @"c:\Temp\sample2_XYZ.txt";

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] str = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (str != null && str.Length > 0 && str[0] == "<spa:Ordinate")
                    {
                        string xs = str[1].Substring(3, str[1].Length - 4);
                        string ys = str[2].Substring(3, str[2].Length - 4);
                        Console.WriteLine($"{xs},{ys}");
                        points.Add(new Point(xs, ys));
                    }
                }
            }


            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path1))
            {
                for (int i = 0; i < points.Count; i++)
                {
                    sw.WriteLine($"{i + 1},{points[i].X}, {points[i].Y}");
                }
            }

        }
    }


}
