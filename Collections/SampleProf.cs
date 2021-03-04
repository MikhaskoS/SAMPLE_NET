using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

// Написать метод, который принимает аргумент типа System.Array. 
// Если это массив указателей (void*, int* и т.д.) любой размерности, 
// то метод выводит все элементы массива на консоль в виде чисел (т.е. 
// приведенными к целочисленному типу). В противном случае метод бросает 
// исключение. Можно использовать любые средства. В качестве бонуса: 
// напишите этот метод, не используя unsafe кода.

namespace CollectionsSample
{
    class SampleProf
    {
        public unsafe static void Sample1()
        {
            var arr = new[,]
        {
        {new IntPtr(0).ToPointer(), new IntPtr(10).ToPointer()},
        {new IntPtr(1).ToPointer(), new IntPtr(20).ToPointer()},
        {new IntPtr(2).ToPointer(), new IntPtr(30).ToPointer()}
        };
            Print(arr);
        }

        static unsafe void Print(Array array)
        {
            var arrayType = array.GetType();
            var elementType = arrayType.GetElementType();
            if (!elementType.IsPointer)
                throw new ArgumentException();

            var getMethod = arrayType.GetMethod("Get"); // powerful street magic!
            foreach (var indexes in GetIndexes(array))
            {
                var ptr = (Pointer)getMethod.Invoke(array, indexes.ToArray());
                var p = new IntPtr(Pointer.Unbox(ptr));
                Console.WriteLine(p.ToInt32());
            }
        }

        class Bounds
        {
            public int Upper;
            public int Lower;
        }

        static IEnumerable<IEnumerable<object>> GetIndexes(IEnumerable<Bounds> bounds)
        {
            if (bounds.Any())
            {
                var current = bounds.First();
                for (var i = current.Lower; i <= current.Upper; ++i)
                    foreach (var indexes in GetIndexes(bounds.Skip(1)))
                        yield return new object[] { i }.Concat(indexes);
            }
            else
                yield return Enumerable.Empty<object>();
        }

        static public IEnumerable<IEnumerable<object>> GetIndexes(Array arr)
        {
            var bounds = Enumerable
                .Range(0, arr.Rank)
                .Select(i => new Bounds { Lower = arr.GetLowerBound(i), Upper = arr.GetUpperBound(i) })
                .ToList();

            return GetIndexes(bounds);
        }
    }
}