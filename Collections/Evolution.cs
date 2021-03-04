using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionsSample
{
    // Способ 1. Классический.
    static class EvoMethod0
    {
        public static List<double> Transform(List<double> iList)
        {
            List<double> dList = new List<double>();
            foreach (double item in iList)
            {
                dList.Add(item / 3.0);
            }
            return dList;
        }
    }
    //-----------------------------------------------------------------
    // Способ 2. Обобщаем делегатом
    static class EvoMethod1
    {
        public delegate double Operation(double item);

        public static double TransformOperation(double x)
        {
            return x / 3.0;
        }

        public static List<double> Transform(List<double> iList, Operation op)
        {
            List<double> dList = new List<double>();
            foreach (double item in iList)
            {
                dList.Add(op(item));
            }
            return dList;
        }
    }
    //------------------------------------------------------------------
    // Способ 3. Воспользуемся встроенным делегатом
    static class EvoMethod2
    {
        public static double TransformOperation(double x)
        {
            return x / 3.0;
        }

        public static List<double> Transform(List<double> iList, Func<double, double> op)
        {
            List<double> dList = new List<double>();
            foreach (double item in iList)
            {
                dList.Add(op(item));
            }
            return dList;
        }
    }
    //------------------------------------------------------------------
    // Способ 4. Оператор yield и обобщение
    static class EvoMethod3
    {
        public static IEnumerable<R> Transform<T, R>(List<T> iList, Func<T, R> op)
        {
            foreach (var item in iList)
            {
                yield return op(item);
            }
        }
    }
    //------------------------------------------------------------------
    // Способ 5. Как расширяющий метод
    static class Method4
    {
        public static IEnumerable<R> Transform<T, R>(this List<T> iList, Func<T, R> op)
        {
            foreach (var item in iList)
            {
                yield return op(item);
            }
        }
    }
}
