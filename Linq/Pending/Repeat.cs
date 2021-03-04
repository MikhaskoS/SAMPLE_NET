using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSample
{
    class Repeat
    {
        public static void Demo1()
        {
            IEnumerable<int> ints = Enumerable.Repeat(2, 10);
            foreach (int i in ints)
                Console.WriteLine(i);
        }
    }
}
