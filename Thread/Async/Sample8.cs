using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadSample
{
    public static partial  class AsyncSample
    {
        public delegate int BinaryOp(int x, int y);

        // Обычный (синхронный) режим работы
        public static void SyncDelegateReview()
        {
            Console.WriteLine("*****Synch Delegate Review * ****");
            // Вывести идентификатор выполняющегося потока. 
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            // Вызвать Add() в синхронном режиме. 
            BinaryOp b = new BinaryOp(Add);
            // Можно было бы также написать b.Invoke(10, 10); 
            int answer = b(10, 10) ;
           
            // Эти строки кода не выполнятся до тех пор, 
            // пока не завершится метод Add(). 
            Console.WriteLine("Doing more work m Main()'"); 
            Console.WriteLine("10 + 10 is {0}.", answer); 
            Console.ReadLine();

        }

       
        public static void ASyncDelegateReview()
        {
            Console.WriteLine("***** Async Delegate Invocation *****");
            // Вывести идентификатор выполняющегося потока. 
            Console .WriteLine ("Main () invoked on thread {0}", Thread.CurrentThread.ManagedThreadId);
            
            
            // Вызвать Add() во вторичном потоке. 
            BinaryOp b = new BinaryOp(Add); 
            IAsyncResult ar = b.BeginInvoke(10, 10, null, null);  // Не работает в NET Core
            
            // Выполнить другую работу в первичном потоке... 
            Console .WriteLine ("Doing more work in Main () ! ") ;

            // По готовности получить результат выполнения метода Add(). 
            int answer = b.EndInvoke(ar); 
            Console.WriteLine ("10 + 10 is {0}.", answer); 
            Console.ReadLine();

        }

        static int Add(int x, int y)
        {
            // Вывести идентификатор выполняющегося потока. 
            Console.WriteLine("Add () invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            // Сделать паузу для моделирования длительной операции. 
            Thread.Sleep(5000); 
            return x + y;
        }

    }
}
