using System;

namespace Template
{
    class Sample
    {
        static void Demo()
        {
            Console.WriteLine("Hello World!");
        }
    }

    class BubbbleSort : ArraySort
    {
        public override void Print(int[] array)
        {
            
        }

        public override void Sort(int[] array)
        {
            
        }
    }

    class InsetrSort : ArraySort
    {
        public override void Print(int[] array)
        {

        }

        public override void Sort(int[] array)
        {

        }
    }


    abstract class ArraySort
    {
        public void SortFull(int[] array)
        {
            Sort(array);
            Print(array);
        }

        public abstract void Sort(int[] array);
        public abstract void Print(int[] array);
    }
}
