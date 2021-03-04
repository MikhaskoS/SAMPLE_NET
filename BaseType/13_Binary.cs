using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeBase
{
    class Sample13
    {
        /*
        *     1 & 0 = 0      0 & 0 = 0        0 & 1 = 0             1 & 1 = 1   И    (если оба верны = 1)
        *     1 | 0 = 1      0 | 0 = 0        0 | 1 = 1             1 | 1 = 1   ИЛИ  (если верно хоть одно = 1)
        *     1 ^ 0 = 1      0 ^ 0 = 0        0 ^ 1 = 1             1 ^ 1 = 0   Исключающее ИЛИ (как ИЛИ но 1 ^ 1 = 0 ) 
        *     !1 = 0         !0 = 1
        */

        public static void Demo()
        {
            int a = 12;
            int b = 20;

            // Перевод в двоичный формат
            Console.WriteLine("a = {0} : \t {1}", a, Convert.ToString(a, 2));
            Console.WriteLine("b = {0} : \t {1}", b, Convert.ToString(b, 2));
            a = a << 1; // cдвиг влево на 1 это умножение на 2
            Console.WriteLine("a << 1 = {0} : \t {1}", a, Convert.ToString(a, 2));
            b = b >> 1; // сдвиг вправо на 1 это целочисленное деление на 2
            Console.WriteLine("b >> 1 = {0} : \t {1}", b, Convert.ToString(b, 2));


            string s = "0110110";
            int sI = Convert.ToInt32(s, 2);


            // Инверсия
            Console.WriteLine(s + " : {0}", sI);
            sI = ~sI;
            Console.WriteLine("~sI : {0}", Convert.ToString(sI, 2));

            // Получить отрицательное число (инверсия - 1)
            int k = 54;
            Console.WriteLine("k : {0}", k);
            k = ~k;
            k += 1;
            Console.WriteLine("k : {0}", k);

            // В Unity есть слои, которые представляют из себя набор
            //Layer 0 = 0000 0001 = 1
            //Layer 1 = 0000 0010 = 2
            //Layer 2 = 0000 0100 = 4
            //Layer 3 = 0000 1000 = 8
            //Layer 4 = 0001 0000 = 16
            //Layer 5 = 0010 0000 = 32
            //Layer 6 = 0100 0000 = 64
            //Layer 7 = 1000 0000 = 128
            //...
            //Layer 32 = 1000 0000 0000 0000 0000 0000 0000 0000 = 4294967296

            // Маска слоя - это набор слоев, например
            // LayerMask =  0101 0010  - это слои 1, 4, 6 (положение единичек)
            // Возникают простые задачи
            // 1. Входит ли указанный слой в маску?
            //    Пусть Layer     = 0001 0000 = 4     это то же, что 1 << 4
            //    Пусть LayerMask = 0101 0010
            //    (0001 0000) & (0101 0010) = 0001 0000  != 0 - входит
            //
            //    Пусть Layer     = 0010 0000 = 5     это то же, что 1 << 5
            //    (0010 0000) & (0101 0010) = 0000 0000  == 0 - не входит
            // 
            //    Итак  LayerMask & (1 << Layer)  == 0    -  Layer входит в LayerMask
            //          LayerMask & (1 << Layer)  != 0    -  Layer не входит в LayerMask
            //
            // 2. Составить маску из конкретных слоев
            int l1 = 2;                // 0000 0010
            int l5 = 32;               // 0010 0000
            int LayerMask = l1 | l5;   // 0010 0010
            Console.WriteLine(Convert.ToString(LayerMask, 2));
            //
            //
            //--------------------------------------


            Console.WriteLine(Math.Pow(2, 32));

            BinaryLiterals();

            Console.Read();
        }

        private static void BinaryLiterals()
        {
            Console.WriteLine("=> Use Binary Literals:");
            Console.WriteLine("Sixteen: {0}", 0b0001_0000);
            Console.WriteLine("Thirty Two: {0}", 0b0010_0000);
            Console.WriteLine("Sixty Four: {0}", 0b0100_0000);

            Console.WriteLine(0b0010_0000.GetType());  // Int32
        }


    }
}
