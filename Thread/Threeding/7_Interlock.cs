using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace ThreadSample
{
    class Sample7
    {
        public static void InterlockSamle()
        {
            ThreadStart startrer = new ThreadStart(UpdateCount);
            Thread[] _tread = new Thread[10];
            for (int x = 0; x < 10; ++x)
            {
                _tread[x] = new Thread(startrer);
                _tread[x].Start();
            }

            for (int x = 0; x < 10; ++x)
            {
                _tread[x].Join();
            }

            // Ожидаемый результат 10000. Однако, если не применять атомарную операцию,
            // на многопроцессорной машине он может быть другим.
            Console.WriteLine("Total: {0}", Counter.count);
        }

        public class Counter
        { public static int count; }

        static void UpdateCount()
        {
            for (int x = 1; x <= 10000; x++)
            {
                // Это приведет к ошибке. Когда значение помещается в регистре процессора
                // к нему могут обратиться сразу несколько потоков. Из-за этого
                // часть итераций может потерятся.
                // Counter.count = Counter.count + 1;

                // Атомарная операция дает нужный результат, но ее минус в том, что она не работает
                // со всеми типами данных
                Interlocked.Increment(ref Counter.count);
            }
        }
    }
}
