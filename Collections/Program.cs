using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Демогстрация перечислений
            EnumSample.Sample();

            //YeldSample.Sample1();
            //YeldSample.Sample2();
            //YeldSample.Sample3();

            #region Evolution!
            // Задача: элементы массива разделить на 3
            List<double> testList = new List<double>() { 1.0, 2.0, 3.0 };

            // Способ 1
            //EvoMethod0.Transform(testList).WriteLine();

            // Способ 2
            //EvoMethod1.Transform(testList, EvoMethod1.TransformOperation).WriteLine();
            // или так:
            //EvoMethod1.Transform(testList, x => (x / 3)).WriteLine();

            // Способ 3
            //EvoMethod2.Transform(testList, EvoMethod2.TransformOperation).WriteLine();
            // или так:
            //EvoMethod2.Transform(testList, x => (x / 3)).WriteLine();

            // способ 4
            //var L = EvoMethod3.Transform(testList, x => (x / 3));
            //L.WriteLine();
            // или так:
            //EvoMethod3.Transform(testList, x => (x / 3)).WriteLine();

            // способ 5
            //testList.Transform(x => x / 3).WriteLine();
            #endregion

            // Построение коллеции Vector вручную. Пример обязателен кпросмотру, т.к.
            // поясняет смысл интерфейсов IEnumerator и IEnumerable
            //SampleVector.Demo();

            // Ядреный пример с указателями для разборки
            //SampleProf.Sample1();

            //ArraySet.Demo();

            // Индексаторы
            //SampleIndexer.Demo();

            CollectionProxy.Demo();

            Console.Read();
            
        }
    }

    // Некоторые расширяющие методы для простоты вывода данных
    public static class ExtMethod
    {
        // вывод на консоль содержимого массива
        // этот простой вывод мы используем для вывода результата
        // всех методов
        public static void WriteLine(this List<double> list)
        {
            foreach (var i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public static void WriteLine<T>(this IEnumerable<T> list)
        {
            foreach (var i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
