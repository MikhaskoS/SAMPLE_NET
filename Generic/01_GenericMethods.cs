using System;

// ���������� ������. ������������ ����������� �����.

namespace GenericsDemo
{
    class Sample1
    {
        public static void Demo()
        {
            Console.WriteLine("***** ���������� � Generics *****\n");
            // Swap 2 ints.
            int a = 10, b = 90;
            Console.WriteLine("Before swap: {0}, {1}", a, b);
            Swap<int>(ref a, ref b);
            Console.WriteLine("After swap: {0}, {1}", a, b);
            Console.WriteLine();
            // Swap 2 strings.
            string s1 = "Hello", s2 = "There";
            Console.WriteLine("Before swap: {0} {1}!", s1, s2);
            Swap<string>(ref s1, ref s2);
            Console.WriteLine("After swap: {0} {1}!", s1, s2);
            Console.ReadLine();
        }

        static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("��������� Swap() ����� � {0}", typeof(T));
            T temp;
            temp = a;
            a = b;
            b = temp;
        }
    }
}
