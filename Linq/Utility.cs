using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSample
{
    static class Utility
    {
        public static void PrintArray<T,V>(this Dictionary<T, V> dict)
        {
            foreach (T t in dict.Keys)
                Console.WriteLine($"[{t}]: {dict[t]}");
        }
    }
}
