using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsDemo
{
    class Sample4
    {
        // Используем Generic в определении делегата
        public delegate void MyGenericDelegate<T>(T arg);

        public static void Demo()
        {
            Console.WriteLine("***** Generic Delegates *****\n");
            // определим делегат("классическим" способом)
            MyGenericDelegate<string> strTarget =
                new MyGenericDelegate<string>(StringTarget);
            strTarget("Some string data");

            // Более "быстрый" способ определения делегата
            MyGenericDelegate<int> intTarget = IntTarget;
            intTarget(9);

            Console.ReadLine();
        }
        static void StringTarget(string arg)
        {
            Console.WriteLine("arg in uppercase is: {0}", arg.ToUpper());
        }
        static void IntTarget(int arg)
        {
            Console.WriteLine("++arg is: {0}", ++arg);
        }
    }
}
