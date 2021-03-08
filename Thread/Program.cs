using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreadSample
{
    class Program
    {
        static void Main(string[] args)
        {
            /* - Для отладки потоков полезно окно ПКМ -> "Место отладки", где можно следить за потоками и выбирать их.
             * - Также полезны окна "Потоки" и "Контрольное значение" - они станут доступны в режиме отладки:
             *   Отладка -> Окна ...
             *   Если установить в качестве контрольного значения Thread.CurrentThread.ManagedThreadId можно следить за id потоков
             */

            #region Thread
            //-------------------------------------------------------
            // Как создать поток?
            //Sample1.Demo1();
            //Sample1.ThreadStartSample2();
            //Sample1.ParameterizedThreadStartSample();    // (707)

            // Как получить информацию о текущем потоке?
            //Sample2.ThreadInfo();

            // Как запустить несколько потоков, указать их приоритет
            // и дождаться завершения. Join
            //Sample3.ThreadingSample();

            // Как передать данные потоку
            //Sample4.ParameterizedThreadSample();               

            // Пример сортировки в одном и в двух потоках
            //Sample5.TestSort();

            // Как принудительно остановить поток?
            //Sample6.AbortThreadSample();

            // Атомарные операции для предотвращения коллизий
            //Sample7.InterlockSamle();

            // Несколько спосбов решения проблем параллелизма
            // - маркер блокировки lock
            // - атомарные опрерации
            // - класс Monitor
            // - аттрибут [Synchronization]
            //LockSample01.LockSample();

            // Фоновый поток
            //Sample9.BackThread();        

            // Специально разработанные коллекции, к которым могут обращаться несколько потоков

            #endregion

            //---------------------------------------------------------
            //   Parallel
            //---------------------------------------------------------
            //ParallelSample.Demo1();

            #region Task
            // https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-based-asynchronous-programming

            TaskSample01.Demo();      // способы запуска задачи
            //TaskSample02.Demo();      // вложенные задачи
            //TaskSample03.Demo();        // массивы задач
            //TaskSample04.Demo();      // получение результата из задачи
            //TaskSample10.Demo();

            #endregion

            //---------------------------------------------------------
            //   Async
            //---------------------------------------------------------

            #region Async
            AsyncSample0.Demo1();
            //AsyncSample1.Demo();
            //AsyncSample2.Demo2();
            //AsyncSample3.Demo3a();
            //AsyncSample3.Demo3b();
            //AsyncSample3.Demo3c();
            //AsyncSample3.Demo3d();
            //AsyncSample3.Demo3f();

            //AsyncSample4.Demo4a();
            //AsyncSample4.Demo4b();

            //AsyncSample.Demo5a();
            //AsyncSample.Demo5b();
            //AsyncSample.Demo5c();
            //AsyncSample.Demo5d();

            //AsyncSample.SyncDelegateReview();
            //AsyncSample.ASyncDelegateReview();
            #endregion

            Console.Read();
        }
    }
}
