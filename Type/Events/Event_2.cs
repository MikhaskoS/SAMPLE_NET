using System;

namespace EventsSmple
{
    class Sample2
    {
        static void handler()
        {
            Console.WriteLine("������� ���������!");
        }
        public static void EventsClass()
        {
            MyEvent evt = new MyEvent(); ////////////////
            evt.SomeEvent += new MyEventHandler(handler);

            // �������
            evt.OnSomeEvent();
        }
    }

    delegate void MyEventHandler();
    // ���������� �����
    class MyEvent
    {
        public event MyEventHandler SomeEvent;
        public void OnSomeEvent()
        {
            //if (SomeEvent != null)
            //    SomeEvent();
            SomeEvent?.Invoke(); // ����� ���
        }
    }

   
}