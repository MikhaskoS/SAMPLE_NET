using System;
using System.Threading;

// ѕример использовани€ “аймера
/* —ледует помнить про класс TimeOut, который содержит константу
 бесконечного времени ожидани€ TimeOut.Infinite   */

namespace TimeSample
{
    class TimerExampleState
    {
        public int counter = 0;
        public Timer tmr;
    }

    class Sample3
    {
        public static void TimerCallbackSample()
        {
            TimerExampleState s = new TimerExampleState();

            // ƒелегат - представл€ет метод, обрабатывающий вызовы от событи€ Timer.
            TimerCallback timerDelegate = new TimerCallback(CheckStatus);

            // dueTime - количество времени до начала использовани€ параметра 
            //           callback, в миллисекундах. —ледует задать поле 
            //           Timeout.Infinite дл€ того, чтобы не допустить запуск 
            //           таймера. «адайте значение ноль (0) дл€ немедленного 
            //           запуска таймера.
            // period -  временной интервал между вызовами параметра callback, 
            //           в миллисекундах. —ледует задать поле Timeout.Infinite 
            //           дл€ отключени€ периодического сигнализировани€. 
            // - начинаем работать ч\з секунду с интервалом в секунду
            Timer timer = new Timer(timerDelegate, s, 1000, 1000);

            s.tmr = timer;

            while (s.tmr != null)
                Thread.Sleep(0);
            Console.WriteLine("ѕример с таймером завершен.");
        }

        static void CheckStatus(Object state)
        {
            TimerExampleState s = (TimerExampleState)state;
            s.counter++;
            Console.WriteLine("{0} Checking Status {1}.", DateTime.Now.TimeOfDay, s.counter);
            if (s.counter == 5)
            {
                // ћен€ет врем€ запуска и интервал межу вызовами метода таймера.
                // - начинаем работать ч\з 5 секунд с интервалом в 0.1 секунду
                (s.tmr).Change(5000, 100);
                Console.WriteLine("подождите (5 сек)...");
            }
            if (s.counter == 10)
            {
                Console.WriteLine("”дал€ем таймер...");
                s.tmr.Dispose();
                s.tmr = null;
            }
        }
    }
}
