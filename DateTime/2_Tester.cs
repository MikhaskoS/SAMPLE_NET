using System;
using System.Runtime.InteropServices;

namespace TimeSample
{
    class Sample2
    {
        public static void SampleTester()
        {
            // заполним массив произвольным набором чисел
            int n = 10000;
            Random ran = new Random();
            int[] a = new int[n];
            int[] b = new int[n];
            int[] c = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = ran.Next(0, 1000);
                b[i] = a[i];
                c[i] = a[i];
            }

            long t0, t1;

            // первый способ
            t0 = Environment.TickCount;
            Sample<int>.InsertionSort(a);
            t1 = Environment.TickCount;
            Console.WriteLine((t1 - t0) * 0.001f + " сек");

            // второй способ
            t0 = DateTime.Now.Ticks;
            Sample<int>.InsertionSort(b);
            t1 = DateTime.Now.Ticks;
            long dT = (t1 - t0);
            Console.WriteLine(dT * 0.0000001f + " сек");

            // третий способ
            t0 = 0; t1 = 0; long freg = 0;

            if (QueryPerformanceCounter(ref t0) != 0)
            {
                Sample<int>.InsertionSort(c);

                QueryPerformanceCounter(ref t1);
                QueryPerformanceFrequency(ref freg);
                Console.WriteLine("ћинимальный интервал: " + 1.0 / freg);
                Console.WriteLine((t1 - t0) * (1.0 / freg) + " сек");
            }
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        extern static short QueryPerformanceCounter(ref long PerformanceCount);
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        extern static short QueryPerformanceFrequency(ref long PerformanceCount);
    }

    // ѕример тестируемого процесса
    class Sample<T> where T : IComparable<T>
    {
        #region —ортировка вставкой
        public static T[] InsertionSort(T[] a)
        {
            T key;
            int i;
            // проходим элементы массива начина€ с 1-го (а не с нулевого)
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