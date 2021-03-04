using System;
using System.IO;


namespace FileStreamSample
{
    class StreamSample
    {
        public static void Demo()
        {
            // Указание имени файла
            System.IO.DirectoryInfo df2 = new System.IO.DirectoryInfo("..\\..\\Stream");
            // путь к фйлу
            //string baseFolder = AppDomain.CurrentDomain.BaseDirectory;  // путь к исполню файлу

            string filePath = Path.Combine(df2.FullName, "TestFile.txt");

            Console.WriteLine(filePath);

            SampleReadWrite(filePath);


           
        }

        static void SampleReadWrite(string filePath)
        {
            using (Stream s = new FileStream(filePath, FileMode.Create))
            {
                Console.WriteLine(s.CanRead); // True 
                Console.WriteLine(s.CanWrite); // True 
                Console.WriteLine(s.CanSeek); //True  (возможность поиска в потоке)

                s.WriteByte(101);                 //запись байта
                s.WriteByte(102);
                byte[] block = { 1, 2, 3, 4, 5 };

                s.Write(block, 0, block.Length); // Записать блок из 5 байтов 

                Console.WriteLine(s.Length); // 7 
                Console.WriteLine(s.Position); // 7 

                s.Position = 0; // Переместиться обратно в начало 

                Console.WriteLine(s.ReadByte()); // 101 
                Console.WriteLine(s.ReadByte()); // 102

                // Читать из потока в массив block: 
                Console.WriteLine(s.Read(block, 0, block.Length)); // 5
                //Предполагая, что последний вызов Read возвратил 5, 
                //мы находимся в конце файла, и Read теперь возвратит 0: 
                Console.WriteLine(s.Read(block, 0, block.Length)); // 0
            }
        }

        // .NET > 4.5
        async static void AsyncDemo()
        {
            using (Stream s = new FileStream("test.txt", FileMode.Create))
            {
                byte[] block = { 1, 2, 3, 4, 5 };
                await s.WriteAsync(block, 0, block.Length);   // Выполнить запись асинхронно 
                s.Position = 0;                               // Переместиться обратно в начало
                // Читать из потока в массив block: 
                Console.WriteLine(await s.ReadAsync(block, 0, block.Length)); // 5
            }
        }


    }
}
