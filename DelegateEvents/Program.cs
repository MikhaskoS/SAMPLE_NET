using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------------------------------------
            // Делегаты
            //----------------------------------------
            //Sample1.Demo();
            //Sample2.Demo();
            //Sample3.Demo();
            //Sample4.Demo();
            //Sample5.Demo();
            //Sample6.Demo();

            #region Evolution
            // Вернуть нечетные
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Evo1.Sample(nums).WriteLine();
            //Evo2.Sample(nums).WriteLine();
            #endregion

            //----------------------------------------
            // События
            //----------------------------------------
            // Инициализация события
            EventsSmple.Sample1.EventsSample();

            // Определение события в классе
            //EventsSmple.Sample2.EventsClass();

            // Определение события в канонах .NET: void handler (object sourse, EventArgs arg)
            //EventsSmple.Sample3.HandlerSample();

            // EventHandler - обработка событий, не имеющих данных
            //EventsSmple.Sample4.Demo();

            // События с данными
            //EventsSmple.Sample5.Demo();

            // Пример коллекции с событиями
            //EventsSmple.Sample6.Demo();

            // Простой пример- обработка нажатий клавиатуры
            // в консольном режиме
            //EventsSmple.Sample7.Demo();

            // Лямбда выражения можно применять и с событиями
            //EventsSmple.Sample8.Demo();

            // Общий пример
            //Sample9.Demo();


            Console.Read();
        }
    }


    public static partial class ExtMethod
    {
        // вывод на консоль содержимого массива
        // этот простой вывод мы используем для вывода результата
        // всех методов
        public static void WriteLine(this int[] nums)
        {
            foreach (var i in nums)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
