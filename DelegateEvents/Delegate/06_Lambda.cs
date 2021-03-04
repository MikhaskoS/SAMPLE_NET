using System;


namespace Delegate
{
    class Sample6
    {
        delegate int Sq(int i);

        public static void Demo()
        {
            //(1) мы можем написать метод
            //  static int Square(int x) { return x * x; }
            //  и передать его делегату
            //  Sq d =  Square;   // или Sq d = new Sq(Square);
            //  тогда 3*3 это d(3)

            //(2) можно избежать построения функции, 
            //  воспользовавшись анонимным делегатом
            Sq sqDelegat1 = delegate(int x) { return x * x; };
            Console.WriteLine(sqDelegat1(3));

            //(3) можно использовать лямбда выражения
            Sq sqDelegat2 = x => (x * x);
            Console.WriteLine(sqDelegat2(3));

            // Аналогичные записи:
            // Sq sqDelegat2 = (int)x => (x * x);
            // Sq sqDelegat2 = x => (return x * x);

            // !!! явные типы в списке параметров лямбда выражений
            // необходимы, если делегат имеет out-, ref- параметры.

            // Для ограниченного числа параметров существуют встроенные
            // делегаты Func<>, так что можно не вводить свой делегат и
            // написать так:
            Func<double, double> res = (x) => (x * x);  // Func<in T,out TResult>(T arg)
            Console.WriteLine(res(3));
            //---------------------------------------------------------
            // Вот еще некоторые примеры лямбда-выражений
            // находится ли val между low и hight
            Func<int, int, int, bool> sam2 = (low, hight, val) => val >= low && val <= hight;
            Console.WriteLine(sam2(10,30,15));

            // лямбда выражения могут быть также блочными
            Func<int, int> factorial = (n) =>
            {
                int r = 1;
                for (int i = 1; i <= n; i++) r = i * r;
                return r;
            };
            Console.WriteLine("10! = {0}", factorial(10));

            // Помимо Func есть встроенные делегаты, которые не возвращают значений
            //Action()
            //Action<in T>(T obj)
            //...
            //Action<in T1,in T2,in T3,in T4,in T5,in T6,in T7,in T8,in T9,in T10,in T11,in T12,in T13,in T14,in T15,in T16>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        }
    }
}