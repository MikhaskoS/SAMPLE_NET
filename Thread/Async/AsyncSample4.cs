using System;
using System.Threading;
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
            await Task.Run(() => Print('+'));
            await Task.Run(() => Print('*'));
            await Task.Run(() => Print('&'));

            // +++++*****&&&&&
        }

        // три задачи теперь будут запускаться параллельно, 
        // однако вызывающий метод FactorialAsync благодаря оператору 
        // await все равно будет ожидать, пока они все не завершатся
        static async void FactorialParallelAsync()
        {
            Task t1 = Task.Run(() => Print('+'));
            Task t2 = Task.Run(() => Print('*'));
            Task t3 = Task.Run(() => Print('&'));
            await Task.WhenAll(new[] { t1, t2, t3 });

            // +&**&+&*++&**+&
        }


        public static void Print(char ch)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(ch); Thread.Sleep(100);
            }
        }
    }
}
