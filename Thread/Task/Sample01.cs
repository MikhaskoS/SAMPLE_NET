using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    public class TaskSample01
    {
        public static async void Demo()
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

            Task task1 = new Task(action1, 25);
            Task task2 = new Task(action2, 25);

            //task1.Start();
            //task2.Start();
            // .+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+.+

            await Task.Run(() =>
            {
                for (int i = 0; i < 25; i++)
                {
                    Console.Write('.'); Thread.Sleep(100);
                }
            });
            await Task.Run(() =>
            {
                for (int i = 0; i < 25; i++)
                {
                    Console.Write('+'); Thread.Sleep(100);
                }
            });
            //await task2.Start();
        }
    }
}
