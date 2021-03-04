using System;
using System.Collections;
using System.Collections.Generic;

// Анонимные делегаты, лямбда выражения
// Задача: имеем массив из целых чисел. Отфильтровать
// его различными способами.

namespace Delegate
{
    public class Evo1
    {
        //---------------------------------------
        // способ 1. Традиционный способ
        //---------------------------------------
        // делегат
        public delegate bool Filter(int i);
        // общий фильтрующий метод с ипользованием делегата
        public static int[] FilterArray(int[] ar, Filter filter)
        {
            ArrayList aList = new ArrayList();
            foreach (int i in ar)
            {
                if (filter(i))
                {
                    aList.Add(i);
                }
            }
            return ((int[])aList.ToArray(typeof(int)));
        }

        // проверка на нечетность
        public static bool IsOdd(int i)
        {
            return ((i & 1) == 1);
        }

        public static int[] Sample(int[] nums)
        {
            int[] OddNums = FilterArray(nums, IsOdd);
            return OddNums;
        }
    }

    public class Evo2
    {
        //--------------------------------------
        // делегат
        public delegate bool Filter(int i);
        // общий фильтрующий метод с ипользованием делегата
        public static int[] FilterArray(int[] ar, Filter filter)
        {
            ArrayList aList = new ArrayList();
            foreach (int i in ar)
            {
                if (filter(i))
                {
                    aList.Add(i);
                }
            }
            return ((int[])aList.ToArray(typeof(int)));
        }
        //---------------------------------------
        // способ 2. Используем анонимный делегат
        // (избавляемся от IsOdd() )
        //---------------------------------------
        public static int[] Sample(int[] nums)
        {
            int[] OddNums = FilterArray(nums, delegate(int i) { return (i & 1) == 1; });
            return OddNums;
        }
    }

    public class Evo3
    {
        // делегат
        public delegate bool Filter(int i);
        // общий фильтрующий метод с ипользованием делегата
        public static int[] FilterArray(int[] ar, Filter filter)
        {
            ArrayList aList = new ArrayList();
            foreach (int i in ar)
            {
                if (filter(i))
                {
                    aList.Add(i);
                }
            }
            return ((int[])aList.ToArray(typeof(int)));
        }
        //---------------------------------------
        // способ 3. Используем синтаксис
        // лямбда выражений
        //---------------------------------------
        public static int[] Sample(int[] nums)
        {
            int[] OddNums = FilterArray(nums, i => ((i & 1) == 1));
            return OddNums;
        }
    }

    public class Evo4
    {
        // общий фильтрующий метод с ипользованием делегата
        public static int[] FilterArray(int[] ar, Func<int, bool> filter)
        {
            ArrayList aList = new ArrayList();
            foreach (int i in ar)
            {
                if (filter(i))
                {
                    aList.Add(i);
                }
            }
            return ((int[])aList.ToArray(typeof(int)));
        }
        //---------------------------------------
        // способ 4. Воспользуемся встроенным делегатом Func<>
        //---------------------------------------
        public static int[] Sample(int[] nums)
        {
            int[] OddNums = FilterArray(nums, i => ((i & 1) == 1));
            return OddNums;
        }
    }

    // Еще один расширяющий метод
    public static partial class ExtMethod
    {
        public static IEnumerable<R> Filter3<T, R>(this IEnumerable<T> input, Func<T, R> fm)
        {
            foreach (var item in input)
            {
                yield return fm(item);
            }
        }
    }
    public class Evo5
    {
        //---------------------------------------
        // способ 5. Используем расширяющий метод
        //---------------------------------------
        public static IEnumerable<double> Sample(int[] nums)
        {
            IEnumerable<double> res = nums.Filter3(new Func<int, double>(i => (double)i / 3));
            return res;
        }
    }
}
