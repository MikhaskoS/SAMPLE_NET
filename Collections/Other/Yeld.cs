using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionsSample
{
    class YeldSample
    {
        public static void Sample1()
        {
            foreach (int i in Power(3, 10))
            {
                Console.Write("{0} ", i);
            }
        }
        public static void Sample2()
        {
            foreach (int i in GetSomrNumbers())
            {
                Console.Write("{0} ", i);
            }
        }
        public static void Sample3()
        {
            DaysOfTheWeek week = new DaysOfTheWeek();
            foreach (string day in week)
            {
                System.Console.Write(day + " ");
            }
        }

        // вывести числа от 0 до exponent, кратные number
        // т.е. при number = 3 и exponent = 10 получим
        // 3 9 27 81 243 729 2187 6561 19683 59049 
        // 0 1  2  3  4   5   6    7     8    9     
        public static IEnumerable Power(int number, int exponent)
        {
            int counter = 0;
            int result = 1;
            while (counter++ < exponent)
            {
                result = result * number;
                // yield - сохраняет текущее положение (как бы значение counter) при
                // выходе и при следующем обращении возвращается
                // к нему. Иными словами это итератор.
                yield return result;
            }
        }

        public static IEnumerable<int> GetSomrNumbers()
        {
            // а здесь ясно видно, что yield помнит именно место
            // выхода из функции. При следующем обращении функция
            // заоаботает с того места, откуда вышли и нее,
            // т.е. результат будет 1 2 3
            yield return 1;
            yield return 2;
            yield return 3;
        }

        // еще пример
        public class DaysOfTheWeek : IEnumerable
        {
            string[] m_Days = { "Sun", "Mon", "Tue", "Wed", "Thr", "Fri", "Sat" };

            // Реализация интерфейса IEnumerable
            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < m_Days.Length; i++)
                {
                    yield return m_Days[i];
                }
            }
        }
    }
}
