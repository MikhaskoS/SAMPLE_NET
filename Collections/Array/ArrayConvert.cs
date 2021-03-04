using System;
using System.Collections.Generic;
using System.Text;

class ArrayConvert
{
    // массивы с произвольной индексацией
    public static void Sample()
    {
        // Конвертирование в обычный массив.

        // int массив {10, 20, 30} - способ 6
        Array ar = Array.CreateInstance(
            // (тип, количество, начальный индекс)
            typeof(int), new int[] { 3 }, new int[] { 0 });
        ar.SetValue(10, 0);
        ar.SetValue(20, 1);
        ar.SetValue(30, 2);

        //----------------------------------------------------
        // преобразование к int[]. Нумерация только с нуля!
        // иначе нужно использовать методы SetValue(), GetValue()
        int[] aI = (int[])ar;
        aI[0] = 10; aI[1] = 20; aI[2] = 30;

        //Console.WriteLine("{0}\n{1}\n{2}", a8[0], a8[1], a8[2]);

        //----------------------------------------------------
        // можно напрямую
        int[] aI1 = (int[])Array.CreateInstance( typeof(int), new int[] { 3 }, new int[] { 0 });
        aI1[0] = 10; aI1[1] = 20; aI1[2] = 30;
        //Console.WriteLine("{0}\n{1}\n{2}", a8[0], a8[1], a8[2]);

    }
}

