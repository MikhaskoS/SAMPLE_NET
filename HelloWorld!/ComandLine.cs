using System;

// Внимание, установлены параметры командной строки: 
// -foo -bar -GODMODE
// В MS 2008 это можно сделать так:
// Project -> /имя пректа/ Properties -> Debug -> Comand line arguments
//                                    -> Отладка -> Аргументы командной строки


namespace HelloWorld
{
    public partial class SampleProgram
    {
        // Точка входа в программу.
        static void ComandLine(string[] args)
        {
            // Демонстрируем способы извлечения командной строки.

            // -- через цикл for
            Console.WriteLine("***** Аргументы командной строки. *****");
            for (int x = 0; x < args.Length; x++)
            {
                Console.WriteLine("Arg: {0}", args[x]);
            }

            // -- теперь через foreach
            Console.WriteLine("\n***** То же, но с применение foreach *****");
            foreach (string s in args)
                Console.WriteLine("Arg: {0}", s);

            // -- теперь используем System.Environment
            // Этот способ очень удобен, если командная строка потребуется
            // где-то в глубине прочих методов
            Console.WriteLine("\n***** То же, но с применением  Environment.GetCommandLineArgs()*****");
            string[] theArgs = Environment.GetCommandLineArgs();
            Console.WriteLine("Путь к приложению: {0}", theArgs[0]);

            for (int i = 1; i < theArgs.Length; i++)
                Console.WriteLine("Аргументы ком. строки: {0}", theArgs[i]);
            Console.WriteLine();
            //--------------------------------------------------------------
            // Часто нас будет интересовать информация об окружающей
            // нас среде. Для этой цели может понадобиться класс
            // System.Environment. Вот кое-что, что уже можно узнать.

            // OS?
            Console.WriteLine("Текущая OS: {0} ", Environment.OSVersion);

            // Директория?
            Console.WriteLine("Текущая директория: {0} ",
                Environment.CurrentDirectory);

            // Информация о дисках.
            string[] drives = Environment.GetLogicalDrives();
            for (int i = 0; i < drives.Length; i++)
                Console.WriteLine("Диск {0} : {1} ", i, drives[i]);

            // Версия .NET?
            Console.WriteLine("Выполняемая версия .NET: {0} ",
                Environment.Version);

            // Количество процессоров? Может понадобиться при
            // реализации многопоточныхх приложений
            Console.WriteLine("Количество процессоров: " + Environment.ProcessorCount);

            // Миллисекунд с момента запуска системы?
            Console.WriteLine("Миллисекунд с момента запуска системы: " + 
                Environment.TickCount);

            Console.WriteLine();

            Console.ReadLine();
        }
    }
}