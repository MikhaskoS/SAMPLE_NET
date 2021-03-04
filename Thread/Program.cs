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
            #region Thread
            //-------------------------------------------------------
            // Как создать поток?
            //Sample1.ThreadStartSample1();
            //Sample1.ThreadStartSample2();
            //Sample1.ParameterizedThreadStartSample();    // (707)

            // Как получить информацию о текущем потоке?
            //Sample2.ThreadInfo();

            // Как запустить несколько потоков, указать их приоритет
            // и дождаться завершения?
            //Sample3.ThreadingSample();

            // Как передать данные потоку?
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
            //Sample8.lockSample();

            //Sample9.BackThread();
            #endregion

            //---------------------------------------------------------
            //   Parallel
            //---------------------------------------------------------
            //ParallelSample.Demo1();

            #region Task

            //TaskSample01.Demo();

            #endregion

            //---------------------------------------------------------
            //   Async
            //---------------------------------------------------------

            #region Async
            //AsyncSample1.Demo();
            //AsyncSample2.Demo2();
            //AsyncSample3.Demo3a();
            //AsyncSample3.Demo3b();
            //AsyncSample3.Demo3c();
            //AsyncSample3.Demo3d();
            //AsyncSample3.Demo3f();

            //AsyncSample.Demo4a();
            //AsyncSample.Demo4b();

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
