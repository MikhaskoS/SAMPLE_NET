using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    class TaskSample02
    {
        // Здесь присутствует вложенная задача, которая запускается из внешней
        // В таком виде внутренняя задача будет работать даже после завершения Main
        /*
Outer task starting...
.
Inner task starting...
+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+
End of Main
+++++
Inner task finished.
         */
        public static void Demo()
        {
            Action<object> action2 = (object count) =>
            {
                Console.WriteLine("\nInner task starting...");
                for (int i = 0; i < (int)count; i++)
                {
                    Console.Write('+'); Thread.Sleep(100);
                }
                Console.WriteLine("\nInner task finished.");
            };

            Action<object> action1 = (object count) =>
            {
                Console.WriteLine("Outer task starting...");
                var inner = Task.Factory.StartNew(action2, 30);
                // так можно синхронизировать вложенную задачу с внешней
                //var inner = Task.Factory.StartNew(action2, 30, TaskCreationOptions.AttachedToParent);
                /*
Outer task starting...
.
Inner task starting...
+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.++++++
Inner task finished.

End of Main
                 */
                for (int i = 0; i < (int)count; i++)
                {
                    Console.Write('.'); Thread.Sleep(100);
                }
            };
           


            var outer = Task.Factory.StartNew(action1, 25);
            outer.Wait();

            Console.WriteLine("\nEnd of Main");
        }
    }
}
