using System;
using System.IO;



namespace ThreadSample
{
    public  class AsyncSample2
    {
        // По правилам, асинхронные методы в названии заканчиваются на Async
        // В .NET реализовано достаточно большое количество асинхронных методов

        // Обрати внимание, какая большая работа проделана под капотом. Чтение из файла не
        // начнется, пока не закончена запись
        public static void Demo2()
        {
            ReadWriteAsync();

            Console.WriteLine("Некоторая работа");
        }
        static async void ReadWriteAsync()
        {
            string s = "Hello world! One step at a time";

            // hello.txt - файл, который будет записываться и считываться
            using (StreamWriter writer = new StreamWriter("hello.txt", false))
            {
                Console.WriteLine("асинхронная запись в файл...");
                await writer.WriteLineAsync(s);  // асинхронная запись в файл
            }

            using (StreamReader reader = new StreamReader("hello.txt"))
            {
                Console.WriteLine("асинхронное чтение из файла...");
                string result = await reader.ReadToEndAsync();  //
                Console.WriteLine(result);
            }
        }
    }
}
