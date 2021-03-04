using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileStreamSample
{
    class Binary
    {
        public static void DemoWriter()
        {
            // Открыть средство двоичной записи в файл. 
            FileInfo f = new FileInfo(@"C:\MY_TEST\BinFile.dat");


            // используя using мы освобождаем поток автоматически. Если он открыт напрямую, следует
            // закрыть его вручную


            // можно и так в аргументе: File.Open(fileName, FileMode.Create)
            using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
            {
                // Вывести на консоль тип BaseStream 
                // (System.IO.FileStream в этом случае). 
                Console.WriteLine("Base stream is: {0} ", bw.BaseStream);
                // Создать некоторые данные для сохранения в файле. 
                double aDouble = 1234.67;
                int anlnt = 34567;
                string aString = "А, В, C";
                // Записать данные. 
                bw.Write(aDouble);
                bw.Write(anlnt);
                bw.Write(aString);
            }
            Console.WriteLine("Done!");
        }

        public static void DemoReadeer()
        {
            FileInfo f = new FileInfo(@"C:\MY_TEST\BinFile.dat");

            // Читать двоичные данные из потока. 
            // можно и так в аргументе: File.Open(fileName, FileMode.Open)
            using (BinaryReader br = new BinaryReader(f.OpenRead())) 
            {
                Console.WriteLine(br.ReadDouble()); 
                Console.WriteLine(br.ReadInt32()); 
                Console.WriteLine(br.ReadString());
            }
            
            Console.ReadLine();
        }
    }
}
