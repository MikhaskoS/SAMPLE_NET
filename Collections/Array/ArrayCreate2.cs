using System;
using System.Collections.Generic;
using System.Text;

class ArrayCreate2
{
    // создать двуменрный массив
    public static void Sample()
    {
        // для примера создадим int массив 
        // |a00 a01|   =   | 0 10 20|
        // |a10 a11|       | 1 11 21|

        //-----------------------------------------------------
        int[,] b1 = {{ 0, 10, 20},
                     { 1, 11, 21}};

        //for (int i = 0; i != b1.GetLength(0); ++i)
        //{
        //    for (int j = 0; j != b1.GetLength(1); ++j)
        //    {
        //        Console.WriteLine(b1[i, j]);
        //    }
        //}
        //-----------------------------------------------------
        int[,] b2 = new int[3, 2];
        b2[0, 0] = 10; b2[1, 0] = 20; b2[2, 0] = 30;
        b2[0, 1] = 40; b2[1, 1] = 50; b2[2, 1] = 60;

        //for (int i = b2.GetLowerBound(0); i <= b2.GetUpperBound(0); ++i)
        //{
        //    for (int j = b2.GetLowerBound(1); j <= b2.GetUpperBound(1); ++j)
        //    {
        //        Console.WriteLine(b2[i, j]);
        //    }
        //}
        //-----------------------------------------------------
        // еще один способ создания двумерного массива, как
        // массива из одномерных массивов. 
        
        int[][] b3 = 
        {
            new int[]{0, 10, 20},
            new int[]{1, 11, 21},
        
        };
        //-----------------------------------------------------
        
        int[][] b4 = new int[2][];
        b4[0] = new int[] {0, 10, 20};
        b4[1] = new int[] {1, 11, 21 };

        //-----------------------------------------------------
        // Пример рваного массива:
        // 10 20 __  |00 10 __|
        // 30 40 50  |01 11 21|
        // 60 __ __  |02 __ __|

        int[][] c = new int[3][];
        c[0] = new int[2]; c[0][0] = 10; c[0][1] = 20;
        c[1] = new int[3]; c[1][0] = 30; c[1][1] = 40; c[1][2] = 50;
        c[2] = new int[1]; c[2][0] = 60;
        //Console.WriteLine(c[2][0]);
        
        //----------------------------------------------------
        Array b6 = Array.CreateInstance(typeof(int), 2, 3);
        b6.SetValue(0, 0, 0);
        b6.SetValue(1, 1, 0);
        b6.SetValue(10, 0, 1);
        b6.SetValue(11, 1, 1);
        b6.SetValue(20, 0, 2);
        b6.SetValue(21, 1, 2);
        for (int i = 0; i != b6.GetLength(0); ++i)
        {
            for (int j = 0; j != b6.GetLength(1); ++j)
            {
                Console.WriteLine(b6.GetValue(i, j));
            }
        }
        //-----------------------------------------------------
    }
}

