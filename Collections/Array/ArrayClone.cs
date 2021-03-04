using System;
using System.Collections.Generic;
using System.Text;

class ArrayClone
{
    // создать одномерный массив
    public static void Sample()
    {
        int[] a1 = { 10, 20, 30 };
        // обычное приравнивание
        int[] a2 = a1;
        // клонирование
        int[] a3 = (int[])a1.Clone();
        // копирование
        int[] a4 = new int[3];
        a1.CopyTo(a4, 0);
        
        // можно и так:
        int[] a5 = new int[3];
        Array.Copy(a1, a5, a1.Length);

        a1[0] = 55;
        foreach (int n in a2)
        {
            Console.WriteLine(n); //55 20 30
        }
        foreach (int n in a3)
        {
            Console.WriteLine(n); //10 20 30
        }
        foreach (int n in a4)
        {
            Console.WriteLine(n); //10 20 30
        }
    }
}


