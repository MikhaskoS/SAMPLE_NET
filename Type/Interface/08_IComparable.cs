using System;

// Интерфейс IComparable имеет метод int CompareTo(object obj),
// принимающий практически все что угодно. Это удобно, но при
// передаче типов-значений может быть потеряна производительность
// из-за операций упаковки.
// В примере показано, как можно оптимизировать код.

namespace ISample
{
    public class Sample8
    {
        public static void Demo()
        {
            SomeValue val1 = new SomeValue(1);
            SomeValue val2 = new SomeValue(2);

            Console.WriteLine(val1.CompareTo(val2));
        }
    }

    public struct SomeValue : IComparable
    {
        public SomeValue(int n)
        {
            this.n = n;
        }

        // можно так:

        //public int CompareTo(object obj)
        //{
        //    if (obj is SomeValue)
        //    {
        //        SomeValue other = (SomeValue)obj;

        //        return n - other.n;
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Wrong Type!");
        //    }
        //}

        // но можно и так, исключив упаковку в вызове CompareTo
        // (это можно увидеть в ILDASM)
        //------------------------------------------------
        int IComparable.CompareTo(object obj)
        {
            if (obj is SomeValue)
            {
                SomeValue other = (SomeValue)obj;

                return n - other.n;
            }
            else
            {
                throw new ArgumentException("Wrong Type!");
            }
        }

        public int CompareTo(SomeValue other)
        {
            return n - other.n;
        }
        //-------------------------------------------------

        private int n;
    }

   
}
