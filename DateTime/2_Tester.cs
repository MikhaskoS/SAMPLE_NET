using System;
using System.Runtime.InteropServices;

namespace TimeSample
{
    class Sample2
    {
        public static void SampleTester()
        {
            // �������� ������ ������������ ������� �����
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

            // ������ ������
            t0 = Environment.TickCount;
            Sample<int>.InsertionSort(a);
            t1 = Environment.TickCount;
            Console.WriteLine((t1 - t0) * 0.001f + " ���");

            // ������ ������
            t0 = DateTime.Now.Ticks;
            Sample<int>.InsertionSort(b);
            t1 = DateTime.Now.Ticks;
            long dT = (t1 - t0);
            Console.WriteLine(dT * 0.0000001f + " ���");

            // ������ ������
            t0 = 0; t1 = 0; long freg = 0;

            if (QueryPerformanceCounter(ref t0) != 0)
            {
                Sample<int>.InsertionSort(c);

                QueryPerformanceCounter(ref t1);
                QueryPerformanceFrequency(ref freg);
                Console.WriteLine("����������� ��������: " + 1.0 / freg);
                Console.WriteLine((t1 - t0) * (1.0 / freg) + " ���");
            }
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        extern static short QueryPerformanceCounter(ref long PerformanceCount);
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        extern static short QueryPerformanceFrequency(ref long PerformanceCount);
    }

    // ������ ������������ ��������
    class Sample<T> where T : IComparable<T>
    {
        #region ���������� ��������
        public static T[] InsertionSort(T[] a)
        {
            T key;
            int i;
            // �������� �������� ������� ������� � 1-�� (� �� � ��������)
            for (int j = 1; j < a.Length; j++)
            {
                // ����������� ������� �������
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