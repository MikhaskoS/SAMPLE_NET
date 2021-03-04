using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

/* Пример. Сортировка вставкой
 * (с использованием обобщенного класса.)
 * У меня двухядерный процессор и применение потока дает выигрыш
 * 100% на XP и почти 150% на Win7  */

namespace ThreadSample
{
    class Sample5
    {
        public static void TestSort()
        {
            long t0 = 0;
            long t1 = 0;

            // попытка сделать программу более эффективной,
            // используя второй поток.

            ThreadStart ts1 = new ThreadStart(run);
            Thread thr1 = new Thread(ts1);
            thr1.Name = "Первый";
            ThreadStart ts2 = new ThreadStart(run);
            Thread thr2 = new Thread(ts2);
            thr2.Name = "Второй";

            Console.WriteLine("Стартуем двумя потоками.");
            t0 = DateTime.Now.Ticks;
            thr1.Start();
            thr2.Start();

            do
            {
                System.Threading.Thread.Sleep(100);
                Console.Write(".");
            }
            // нужно быть уверенным, что потоки завершены
            while (thr1.IsAlive && thr2.IsAlive);

            t1 = DateTime.Now.Ticks;
            Console.WriteLine("\n Длилось: " + (t1 - t0) * 0.0000001f + "сек.");

            Console.WriteLine("Стартуем одним потоком.");
            t0 = DateTime.Now.Ticks;
            run();
            run();
            t1 = DateTime.Now.Ticks;
            Console.WriteLine("\n Длилось: " + (t1 - t0) * 0.0000001f + "сек.");

        }

        static void run()
        {
            int n = 10000;
            Random ran = new Random();
            double[] a = new double[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = (double)ran.Next(0, 1000);

            }
            Sample<double>.InsertionSort(a);
        }
    }


    class Sample<T> where T : IComparable<T>
    {
        #region Сортировка вставкой
        public static T[] InsertionSort(T[] a)
        {
            T key;
            int i;
            // проходим элементы массива начиная с 1-го (а не с нулевого)
            for (int j = 1; j < a.Length; j++)
            {
                // присваиваем текущий элемент
                key = (T)a[j];
                i = j - 1;

                while ((i >= 0) && (a[i].CompareTo(key) > 0))
                {
                    a[i + 1] = a[i];
                    i = i - 1;
                }
                a[i + 1] = key;
            }
            return a;
        }
        #endregion
    }
}

