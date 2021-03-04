using System;
using System.Threading.Tasks;


namespace ThreadSample
{

    public static partial class AsyncSample
    {
        //Обработка ошибок в асинхронных методах
        public static void Demo5a()
        {
            FactorialExcAsync(-4);
            FactorialExcAsync(6);

            Console.Read();
        }
        // Исследование исключения
        public static void Demo5b()
        {
            FactorialExc2Async(-4);

            Console.Read();
        }
        // Обработка нескольких исключений. WhenAll
        public static void Demo5c()
        {
            DoMultipleAsync();
        }
        // await в блоках catch и finally
        public static void Demo5d()
        {
            FactorialExc4Async(-4);
        }

        // перехват исключения
        static async void FactorialExcAsync(int n)
        {
            try
            {
                await Task.Run(() => FactorialExc(n));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // При возникновении ошибки у объекта Task, представляющего асинхронную задачу, 
        // в которой произошла ошибка, свойство IsFaulted имеет значение true. 
        // Кроме того, свойство Exception объекта Task содержит всю информацию об ошибке. 
        // Чтобы проинспектировать свойство, изменим метод FactorialAsync следующим образом:
        static async void FactorialExc2Async(int n)
        {
            Task task = null;
            try
            {
                task = Task.Run(() => FactorialExc(n));
                await task;
            }
            catch (Exception ex)  // сюда мы попадаем в режиме (Ctrl F5) - без отладки
            {
                Console.WriteLine(task.Exception.InnerException.Message);
                Console.WriteLine($"IsFaulted: {task.IsFaulted}");
            }
        }
        static async void DoMultipleAsync()
        {
            Task allTasks = null;

            try
            {
                Task t1 = Task.Run(() => FactorialExcAsync(-3));
                Task t2 = Task.Run(() => FactorialExcAsync(-5));
                Task t3 = Task.Run(() => FactorialExcAsync(-10));

                allTasks = Task.WhenAll(t1, t2, t3);
                await allTasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение: " + ex.Message);
                Console.WriteLine("IsFaulted: " + allTasks.IsFaulted);
                foreach (var inx in allTasks.Exception.InnerExceptions)
                {
                    Console.WriteLine("Внутреннее исключение: " + inx.Message);
                }
            }
        }

        //Начиная с версии C# 6.0 в язык была добавлена возможность вызова асинхронного кода
        // в блоках catch и finally. Так, возьмем предыдущий пример с подсчетом факториала:
        static async void FactorialExc4Async(int n)
        {
            try
            {
                await Task.Run(() => FactorialExc(n)); ;
            }
            catch (Exception ex)
            {
                await Task.Run(() => Console.WriteLine(ex.Message));
            }
            finally
            {
                await Task.Run(() => Console.WriteLine("await в блоке finally"));
            }
        }


        static void FactorialExc(int n)
        {
            if (n < 1)
                throw new Exception($"{n} : число не должно быть меньше 1");
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Факториал числа {n} равен {result}");
        }
    }
}
