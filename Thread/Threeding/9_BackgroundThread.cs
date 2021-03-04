using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace ThreadSample
{
    public class Sample9
    {
        public static void BackThread()
        {
            Console.WriteLine("***** Background Threads *****\n"); 

            Thread bgroundThread = new Thread(new ThreadStart(Printer9.PrintNumbers));
            
            // Теперь это фоновый поток. Такой поток выполняет некритические задачи и может
            // лекго прерван, как в этом примере
            bgroundThread.IsBackground = true;
            bgroundThread.Start();

        }
    }


    public class Printer9
    {
        public static void PrintNumbers()
        {
            Console.WriteLine("Действия, выполняемые в потоке.");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("{0}, ", i); Thread.Sleep(2000);
            }

            Console.WriteLine("\nДействия в потоке завершены.");
            Console.ReadLine();
        }
    }
}
