using System;

using System.Threading;

namespace ThreadSample
{
    class LockSample01
    {
        public static void LockSample()
        {
            Counter count = new Counter();

            ParameterizedThreadStart startrer = new ParameterizedThreadStart(UpdateCount);
            Thread[] _tread = new Thread[10];

            // создаем 10 потоков
            // каждый поток инкременирует _count 10*1000 = 10000
            // каждый поток инкременирует _eventCount только для четных  _count  (500*10 = 5000)
            for (int x = 0; x < 10; ++x)
            {
                _tread[x] = new Thread(startrer);
                _tread[x].Start(count);
            }

            // ждем завершения
            for (int x = 0; x < 10; ++x)
            {
                _tread[x].Join();
            }

            // В теории должно быть 10000 и 5000 (в первом случае второе значение может быть иным)
            Console.WriteLine("Total: {0} - EventCount: {1}", count.Count, count.EventCount);
            Console.ReadLine();
        }

        static void UpdateCount(object param)
        {
            Counter count = (Counter)param;
            for (int x = 0; x < 1000; ++x)
            {
                //count.UpdateCount_v1();
                //count.UpdateCount_v2();
                count.UpdateCount_v3();
                //count.UpdateCount_v4();
                //count.UpdateCount_v5();
            }
        }

        // Если не нужно явно писать код внутри класса для синхронизации, можно использовать аттрибут [Synchronization]
        // В этом случае count.UpdateCount_v1(); будет отлично работать
        //[Synchronization]
        //public class Counter : ContextBoundObject

        public class Counter
        {
            int _count = 0;
            int _eventCount = 0;
            public int Count { get { return _count; } }
            public int EventCount { get { return _eventCount; } }


            public void UpdateCount_v1()
            {
                // Результат непредсказуем (проблема параллелизма)
                _count++;
                if (Count % 2 == 0)
                {
                    _eventCount++; 
                }
            }
            public void UpdateCount_v2()
            {
                // Если использовать атомарные операции из предыдущего примера, мы значение
                // для _count будем получать всегда верное, однако для _eventCount будут
                // иногда проскакаивать ошибочные значения. Это из-за того, что при выполнении потоков
                // проверка четности может не поспевать за операцией инкремента

                Interlocked.Increment(ref _count);
                if (Count % 2 == 0)
                {
                    Interlocked.Increment(ref _eventCount);
                }
            }
            public void UpdateCount_v3()
            {

                // Решение проблемы - синхронизирующая блокировка
                lock (this)  // макер блокировки - текущий поток
                {
                    _count++;
                    if (Count % 2 == 0)
                    {
                        _eventCount++; ;
                    }
                }
            }

            // Так безопаснее (для открытых методов) 
            private object threadLock = new object();  // маркер блокировки
            public void UpdateCount_v4()
            {
                lock (threadLock)
                {
                    _count++;
                    if (Count % 2 == 0)
                    {
                        _eventCount++; 
                    }
                }
            }

            public void UpdateCount_v5()
            {

                // Другой способ - использование класса Monitor
                Monitor.Enter(this);
                try
                {
                    _count++;
                    if (Count % 2 == 0)
                    {
                        _eventCount++; ;
                    }
                }
                finally
                {
                    Monitor.Exit(this);
                }
            }
        }
    }
}
