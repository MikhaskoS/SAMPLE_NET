using System;
using System.Threading;

// ������ ������������� �������
/* ������� ������� ��� ����� TimeOut, ������� �������� ���������
 ������������ ������� �������� TimeOut.Infinite   */

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

            // ������� - ������������ �����, �������������� ������ �� ������� Timer.
            TimerCallback timerDelegate = new TimerCallback(CheckStatus);

            // dueTime - ���������� ������� �� ������ ������������� ��������� 
            //           callback, � �������������. ������� ������ ���� 
            //           Timeout.Infinite ��� ����, ����� �� ��������� ������ 
            //           �������. ������� �������� ���� (0) ��� ������������ 
            //           ������� �������.
            // period -  ��������� �������� ����� �������� ��������� callback, 
            //           � �������������. ������� ������ ���� Timeout.Infinite 
            //           ��� ���������� �������������� ����������������. 
            // - �������� �������� �\� ������� � ���������� � �������
            Timer timer = new Timer(timerDelegate, s, 1000, 1000);

            s.tmr = timer;

            while (s.tmr != null)
                Thread.Sleep(0);
            Console.WriteLine("������ � �������� ��������.");
        }

        static void CheckStatus(Object state)
        {
            TimerExampleState s = (TimerExampleState)state;
            s.counter++;
            Console.WriteLine("{0} Checking Status {1}.", DateTime.Now.TimeOfDay, s.counter);
            if (s.counter == 5)
            {
                // ������ ����� ������� � �������� ���� �������� ������ �������.
                // - �������� �������� �\� 5 ������ � ���������� � 0.1 �������
                (s.tmr).Change(5000, 100);
                Console.WriteLine("��������� (5 ���)...");
            }
            if (s.counter == 10)
            {
                Console.WriteLine("������� ������...");
                s.tmr.Dispose();
                s.tmr = null;
            }
        }
    }
}
