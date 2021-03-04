using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSample
{
    class Empty
    {
        public static void Demo1()
        {
            IEnumerable<string> strings = Enumerable.Empty<string>();
            foreach (string s in strings)
                Console.WriteLine(s);
            Console.WriteLine(strings.Count());
        }
    }
}
