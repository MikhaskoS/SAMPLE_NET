using System;
using System.Collections.Generic;
using System.Text;

class ArrayIndex
{
    // массивы с произвольной индексацией
    public static void Sample()
    {
        // В этом массиве индексация начинается с 1

        // (тип, количество, начальный индекс)
        Array ar = Array.CreateInstance( typeof(int), new int[] { 3 }, new int[] { 1 });
        ar.SetValue(10, 1);
        ar.SetValue(20, 2);
        ar.SetValue(30, 3);
        //Console.WriteLine("{0}\n{1}\n{2}", 
        //    a7.GetValue(1), a7.GetValue(2), a7.GetValue(3));
    }
}

