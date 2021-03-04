using System;
using System.Collections.Generic;
using System.Text;

class ArrayCreate1
{ 
    // создать одномерный массив
    public static void Sample()
    {
        // для примера создадим int массив {10, 20, 30}
        int[] a1 = new int[3];
        a1[0] = 10; a1[1] = 20; a1[2] = 30;

        // С версии C# 3.0 массивы можно типизировать неявно:
        var a_test = new[] { 10, 20, 30 };
        Console.WriteLine(a_test.GetType());

        //---------------- способ 2 ---------------------------

        int[] a2 = { 10, 20, 30 };

        //---------------- способ 3 ---------------------------

        int[] a3 = new int[] { 10, 20, 30 };

        //---------------- способ 4 ---------------------------

        Array a4 = Array.CreateInstance(typeof(int), 3);  // (тип, размерность)
        a4.SetValue(10, 0);
        a4.SetValue(20, 1);
        a4.SetValue(30, 2);

        //Console.WriteLine(a4.GetValue(0));
        //foreach (int i in a4) { Console.WriteLine(i); }

        //---------------- способ 5 ---------------------------

        Array a5 = new int[] { 10, 20, 30 };
        //foreach (int i in a5) { Console.WriteLine(i); }

        //---------------- способ 6 ---------------------------
        // Вообще говоря, так можно создать массив до трех измерений

        Array a6 = Array.CreateInstance(
            // (тип, количество, начальный индекс)
            typeof(int), new int[] { 3 }, new int[] { 0 });
        a6.SetValue(10, 0);
        a6.SetValue(20, 1);
        a6.SetValue(30, 2);
        //Console.WriteLine(a6.GetValue(0));
        //Console.WriteLine(a6.GetValue(1));
        //Console.WriteLine(a6.GetValue(2));
    }
}


