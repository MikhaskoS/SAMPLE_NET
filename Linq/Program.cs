using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSample
{
    class Program
    {
        static void Main()
        {
            // Отложенные операции
            //Where.Demo1();
            //Where.Demo2();
            //Select.Demo1();
            //SelectMany.Demo1();
            //SelectMany.Demo2();
            SelectMany.Demo3();
            //OrderBy.Demo();
            //Range.Demo1();
            //Repeat.Demo1();
            //Empty.Demo1();

            // Неотложенные операции
            //ToArray.Demo();
            //ToDictionary.Demo1();

            Console.Read();
        }
    }

    public static class ExtMethod
    {
        public static void WriteLine<T>(this IEnumerable<T> list)
        {
            foreach (var i in list)
            {
                Console.WriteLine(i + " ");
            }
        }
    }
}
