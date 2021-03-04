using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;  

namespace ThreadSample
{
    class Sample2
    {
        public static void ThreadInfo()
        {
            //Получение потока, который в данный момент выполняет
            //данный метод
            Thread currThread = Thread.CurrentThread; // <---
            Console.WriteLine("Приоритет текущего потока: " + currThread.Priority);
            Console.WriteLine(new string('-', 35));

            // Домен приложения, содержащий текущий поток
            AppDomain ad = Thread.GetDomain();
            Console.WriteLine("Текущая  область: " + ad);
            Console.WriteLine(new string('-', 35));

            // Контекст, в рамках которого действует текущий поток
            System.Runtime.Remoting.Contexts.Context ctx = Thread.CurrentContext;
            Console.WriteLine(ctx);
            Console.WriteLine(new string('-', 35));
        }
    }
}
