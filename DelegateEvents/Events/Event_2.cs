using System;

namespace EventsSmple
{
    class Sample2
    {
        static void handler()
        {
            Console.WriteLine("Событие произошло!");
        }
        public static void EventsClass()
        {
            MyEvent evt = new MyEvent(); ////////////////
            evt.SomeEvent += new MyEventHandler(handler);

            // Событие
            evt.OnSomeEvent();
        }
    }

    delegate void MyEventHandler();
    // Событийный класс
    class MyEvent
    {
        public event MyEventHandler SomeEvent;
        public void OnSomeEvent()
        {
            //if (SomeEvent != null)
            //    SomeEvent();
            SomeEvent?.Invoke(); // лучше так
        }
    }

   
}