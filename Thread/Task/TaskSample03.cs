using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    class TaskSample03
    {
        public static void Demo()
        {
            Action<object> action1 = (object count) =>
            {
                for (int i = 0; i < (int)count; i++)
                {
                    Console.Write('.'); Thread.Sleep(100);
                }
            };
            Action<object> action2 = (object count) =>
            {
                for (int i = 0; i < (int)count; i++)
                {
                    Console.Write('+'); Thread.Sleep(100);
                }
            };
            Action<object> action3 = (object count) =>
            {
                for (int i = 0; i < (int)count; i++)
                {
                    Console.Write('*'); Thread.Sleep(100);
                }
            };

            Task[] tasks = new Task[3]
            {
                new Task(action1, 25),
                new Task(action2, 25),
                new Task(action3, 25)
            };
            foreach (var t in tasks)
                t.Start();

            Task[] tasks2 = new Task[3];
            int j = 1;
            for (int i = 0; i < tasks2.Length; i++)
                tasks2[i] = Task.Factory.StartNew(() => Console.WriteLine($"\nTask {j++}"));


            Task.WaitAll(tasks);                  // !!! ожидаем завершения задач 
            Console.WriteLine("\nЗавершение метода Main");
        }
    }
}
