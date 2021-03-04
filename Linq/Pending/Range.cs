using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSample
{
    class Range
    {
        public static void Demo1()
        {
            IEnumerable<int> ints = Enumerable.Range(1, 10);
            foreach (int i in ints)
                Console.WriteLine(i);
        }
    }
}
