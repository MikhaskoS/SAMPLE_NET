using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;  // <--

namespace ThreadSample
{
    class Sample3
    {
        // определим процедуру, которая будет запускаться
        // в каждом из потоков
        static void SimpleWork()
        {
            Console.WriteLine("Поток(Id): {0}",
                Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(1000);
        }

        // приоритеты потоков в порядке возрастания
        static ThreadPriority[] priority =
        {ThreadPriority.Lowest, ThreadPriority.BelowNormal, ThreadPriority.Normal, 
            ThreadPriority.AboveNormal, ThreadPriority.Highest};

        public static void ThreadingSample()
        {
            ThreadStart operation = new ThreadStart(SimpleWork);

            Thread[] theThread = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                theThread[i] = new Thread(operation);

                // Каждый следующий поток имеет больший приоритет
                theThread[i].Priority = priority[i];

                theThread[i].Start();
            }

            // Подождем, пока потоки завершатся
            foreach (Thread t in theThread)
            {
                t.Join();
            }

            // Если не использовать Join() эта фраза появиться
            // во время их выполнения
            Console.WriteLine("Потоки завершены!");
        }
    }
}
