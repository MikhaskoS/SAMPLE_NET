using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    // https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/async/
    class AsyncSample0
    {
        public async static void Demo1()
        {
            //FryEggs();
            //FryBacon();
            //PourCoffee();

            // запускаем задачи в асинхронном режиме
            Task<Egg> EggTask =  FryEggsAsync();
            Task<Bacon> BaconTask =  FryBaconAsync();
            var breakfastTasks = new List<Task> { EggTask, BaconTask };
            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if (finishedTask == EggTask)
                {
                    Console.WriteLine("\neggs are ready");
                }
                else if (finishedTask == BaconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
           
                breakfastTasks.Remove(finishedTask);
            }
            PourCoffee();
        }

        #region 
        // жарим яйца
        public static Egg FryEggs()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.Write('g'); Thread.Sleep(100);
            }
            return new Egg();
        }
        // жарим бекон
        public static Bacon FryBacon()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.Write('b'); Thread.Sleep(100);
            }
            return new Bacon();
        }
        // наливаем кофе
        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
        #endregion

        //---------------------------------------

        #region 
        // жарим яйца
        public static async Task<Egg> FryEggsAsync()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.Write('g'); 
                //Thread.Sleep(100);
                await Task.Delay(100);
            }
            return new Egg();
        }
        // жарим бекон
        public static async Task<Bacon> FryBaconAsync()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.Write('b'); 
                //Thread.Sleep(100);
                await Task.Delay(100);
            }
            return new Bacon();
        }
        #endregion
    }

    public class Coffee { }
    public class Egg { }
    public class Bacon { }
    public class Toast { }
    public class Juice { }
}
