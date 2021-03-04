using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

/* ������. ���������� ��������
 * (� �������������� ����������� ������.)
 * � ���� ����������� ��������� � ���������� ������ ���� �������
 * 100% �� XP � ����� 150% �� Win7  */

namespace ThreadSample
{
    class Sample5
    {
        public static void TestSort()
        {
            long t0 = 0;
            long t1 = 0;

            // ������� ������� ��������� ����� �����������,
            // ��������� ������ �����.

            ThreadStart ts1 = new ThreadStart(run);
            Thread thr1 = new Thread(ts1);
            thr1.Name = "������";
            ThreadStart ts2 = new ThreadStart(run);
            Thread thr2 = new Thread(ts2);
            thr2.Name = "������";

            Console.WriteLine("�������� ����� ��������.");
            t0 = DateTime.Now.Ticks;
            thr1.Start();
            thr2.Start();

            do
            {
                System.Threading.Thread.Sleep(100);
                Console.Write(".");
            }
            // ����� ���� ���������, ��� ������ ���������
            while (thr1.IsAlive && thr2.IsAlive);

            t1 = DateTime.Now.Ticks;
            Console.WriteLine("\n �������: " + (t1 - t0) * 0.0000001f + "���.");

            Console.WriteLine("�������� ����� �������.");
            t0 = DateTime.Now.Ticks;
            run();
            run();
            t1 = DateTime.Now.Ticks;
            Console.WriteLine("\n �������: " + (t1 - t0) * 0.0000001f + "���.");

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

