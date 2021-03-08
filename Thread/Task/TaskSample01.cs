using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    class TaskSample01 
    {
        public static void Demo()
        {
            //--------
            Task task1 = new Task(() => Console.WriteLine("Task1 is executed"));
            task1.Start();
            //--------
            Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed"));
            //--------
            Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));
            //--------
            Action<object> action1 = (object count) =>
            {
                for (int i = 0; i < (int)count; i++)
                {
                    Console.Write('.'); Thread.Sleep(100);
                }
            };
            Task task4 = new Task(action1, 10);
            task4.Start();

            Console.WriteLine("task4 completed: {0}, Status: {1}", task4.IsCompleted, task4.Status);
            task4.Wait();
            Console.WriteLine("\ntask4 completed: {0}, Status: {1}", task4.IsCompleted, task4.Status);
            //--------
            Task task5 = Task.Factory.StartNew(
                (object customData) => 
                {
                    AnyData data = customData as AnyData;
                    if (data == null) return;
                    Console.WriteLine("Task5 is executed");
                    for (int i = 0; i < data.count; i++)
                    {
                        Console.Write(data.ch); Thread.Sleep(100);
                    }
                },
                new AnyData { ch = '@', count = 30}); 

        }
    }

    class AnyData
    {
        public char ch;
        public int count;
    }
}
