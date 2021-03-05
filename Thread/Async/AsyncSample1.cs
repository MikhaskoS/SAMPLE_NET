using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    /*Асинхонный метод обладает следующими признаками:
     * - В заголовке метода используется модификатор async
     * - Метод содержит одно или несколько выражений await
     * - В качестве возвращаемого типа используется один из следующих: 
     * void,  Task, Task<T>,  ValueTask<T>
     * 
     * Асинхронный метод, как и обычный, может использовать любое количество параметров 
     * или не использовать их вообще. Однако асинхронный метод 
     * не может определять параметры с модификаторами out и ref.
     * 
     * Также стоит отметить, что слово async, которое указывается в определении метода, 
     * не делает автоматически метод асинхронным. Оно лишь указывает, что данный метод 
     * может содержать одно или несколько выражений await.
     *
     * Метод, поддерживающий await это просто метод, который возвращает Task<T>
     */
    public class AsyncSample1
    {
        public static void Demo()
        {
            FactorialAsync();

            // мы здесь, а асинхронная функция выполняется в другом потоке
            Console.WriteLine("Введите число: ");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Квадрат числа равен {n * n}");
        }

        // определение асинхронного метода
        public static async void FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно

            // Когда встречается выражение await, вызывающий поток 
            // приостанавливается до тех пор, пока ожидаемая задача не завершится. 
            // Тем временем управление возвращается коду, вызвавшему метод.
            await Task.Run(() => Factorial());                 // выполняется асинхронно
            Console.WriteLine("Конец метода FactorialAsync");
        }

        public static void Factorial()
        {
            int result = 1;
            for (int i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(8000);
            //Task.Delay(80000);
            Console.WriteLine($"Факториал равен {result}");
        }

        public static int Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            
            Console.WriteLine($"Факториал {n} равен {result}");
            return result;
        }
    }
}
