using System;
using System.Threading;


// Как принудительно остановить поток?
namespace ThreadSample
{
    class Sample6
    {
        static void SimpleWork()
        {
            try
            {
            Console.WriteLine("Шаг1");
            Thread.Sleep(1000); 
            Console.WriteLine("Шаг2");
            Thread.Sleep(1000); 

            
            // Этот фрагмент кода может выполнится 
            // только целиком, но не в обычном приложении, а при работе
            // с хостом (пример будет в ADO.NET). Здесь это не нужно.
           
                Thread.BeginCriticalRegion(); // <--???
                Console.WriteLine("Шаг3");
                Thread.Sleep(1000);
                Console.WriteLine("Шаг4");
                Thread.Sleep(1000);
                Console.WriteLine("Шаг5");
                Thread.Sleep(1000);
                Thread.EndCriticalRegion(); // <--???
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Шаг6");
            Thread.Sleep(1000); 
            Console.WriteLine("Шаг7");
            Thread.Sleep(1000); 
        }

        // Метод, который прерывает поток. Достаточно нажать
        // Enter. Параметр - поток, который следует прервать
        static void AbrtThread(object obj)
        {
            Console.ReadLine();
            Thread theTread = (Thread)obj;
            theTread.Abort();            // Не рекомендуется, очень жестко работает. Может порушить объекты внутри прерываемого потока.
            //theTread.Interrupt()  // срабатывает внутри Sleep либо SpinWait
        }

        public static void AbortThreadSample()
        {
            ThreadStart operation1 = new ThreadStart(SimpleWork);
            Thread theThread1 = new Thread(operation1);
            theThread1.Start();

            ParameterizedThreadStart operation2 = new ParameterizedThreadStart(AbrtThread);
            Thread theThread2 = new Thread(operation2);
            theThread2.Start(theThread1);
        }
    }
}
