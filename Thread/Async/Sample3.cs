using System;
using System.Threading.Tasks;


namespace ThreadSample
{
    // Передача параметров и получение результатов из асинхронных методов
    public class AsyncSample3
    {
        public static void Demo3a()
        {
            FactorialAsync(5);
            FactorialAsync(6);
            Console.WriteLine("Некоторая работа");

            //Начало метода FactorialAsync
            //Начало метода FactorialAsync
            //Некоторая работа
            //Факториал равен 120
            //Факториал равен 720
            //Конец метода FactorialAsync
            //Конец метода FactorialAsync

        }
        public static void Demo3b()
        {
            Factorial2Async(5);
            Console.WriteLine("Некоторая работа");

            //Начало метода FactorialAsync
            //Некоторая работа
            //Факториал равен 120
            //Конец метода FactorialAsync

        }
        public static void Demo3c()
        {
            _ = Factorial3Async(5);
            Console.WriteLine("Некоторая работа");

            //Некоторая работа
            //Факториал равен 120
        }
        public static async void Demo3d()  //<- метод стал асинхронным
        {
            int n1 = await Factorial4Async(5);
            int n2 = await Factorial4Async(6);
            Console.WriteLine($"n1={n1}  n2={n2}");
            Console.Read();

            //Факториал равен 120
            //Факториал равен 720
            //n1 = 120  n2 = 720
        }
        public static async void Demo3f()
        {
            int n1 = await Factorial5Async(5);
            int n2 = await Factorial5Async(6);
            Console.WriteLine($"n1={n1}  n2={n2}");
            Console.Read();
        }

        // определение асинхронного метода с передачей параметра
        static async void FactorialAsync(int n)
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            await Task.Run(() => Factorial(n));                // выполняется асинхронно
            Console.WriteLine("Конец метода FactorialAsync");
        }

        // void
        static async void Factorial2Async(int n)
        {
            Console.WriteLine("Начало метода FactorialAsync");         // выполняется синхронно
            int x = await Task.Run(() => Factorial(n));                // выполняется асинхронно
            Console.WriteLine("Конец метода FactorialAsync");
        }

        // Task
        static async Task Factorial3Async(int n)
        {
            await Task.Run(() => Factorial(n));
        }

        // Task<int>
        static async Task<int> Factorial4Async(int n)
        {
            return await Task.Run(() => Factorial(n));
        }

        // Использование типа ValueTask<T> во многом аналогично применению Task<T>
        // за исключением некоторых различий в работе с памятью, поскольку ValueTask - структура, 
        // а Task - класс. По умолчанию тип ValueTask недоступен, и чтобы использовать его, 
        // вначале надо установить через NuGet пакет System.Threading.Tasks.Extensions.
        static async  ValueTask<int> Factorial5Async(int n)
        {
            return await Task.Run(() => Factorial(n));
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
