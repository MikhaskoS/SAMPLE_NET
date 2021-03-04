using System;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 5;
            int b = i++;  // i = 6  b = 5    (b = i   i = i + 1)
            Console.WriteLine("i = {0} b = {1}", i, b);

            i = 5;
            b = ++i;     // i = 6  b = 6     (i = i + 1    b = i)
            Console.WriteLine("i = {0} b = {1}", i, b);

            i = 5;
            b = i--;     // i = 4  b = 5     
            Console.WriteLine("i = {0} b = {1}", i, b);

            i = 5;
            b = --i;     // i = 4  b = 4    
            Console.WriteLine("i = {0} b = {1}", i, b);

            Demo1();
        }


        static void Demo1()
        {
            var a = new Fraction(5, 4);
            var b = new Fraction(1, 2);
            Console.WriteLine(-a);   // output: -5 / 4
            Console.WriteLine(a + b);  // output: 14 / 8
            Console.WriteLine(a - b);  // output: 6 / 8
            Console.WriteLine(a * b);  // output: 5 / 8
            Console.WriteLine(a / b);  // output: 10 / 4
        }
    }
}
