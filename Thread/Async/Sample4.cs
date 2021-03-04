using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ThreadSample
{
     // Последовательный и параллельный вызов асинхронных методов
    public  class AsyncSample4
    {
        public static void Demo4a()
        {
            FactorialConsistentlyAsync();
        }
        public static void Demo4b()
        {
            FactorialParallelAsync();
        }

        // определение асинхронного метода
        static async void FactorialConsistentlyAsync()
        {
            await Task.Run(() => Factorial(4));
            await Task.Run(() => Factorial(3));
            await Task.Run(() => Factorial(5));
        }

        // три задачи теперь будут запускаться параллельно, 
        // однако вызывающий метод FactorialAsync благодаря оператору 
        // await все равно будет ожидать, пока они все не завершатся
        static async void FactorialParallelAsync()
        {
            Task t1 = Task.Run(() => Factorial(4));
            Task t2 = Task.Run(() => Factorial(3));
            Task t3 = Task.Run(() => Factorial(5));
            await Task.WhenAll(new[] { t1, t2, t3 });
        }

        public static int Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            Console.WriteLine($"Факториал равен {result}");
            return result;
        }
    }
}
