using System;

namespace EventsSmple
{
    // Если дополнительная информация из EventArgs не используется,
    // разумно воспользоваться встроенным делегатом EventHandler.

    class Sample4
    {
        static void handler(object sourse, EventArgs arg)   //!!!!!!!!!!!!!!
        {
            Console.WriteLine("Событие произошло!");
        }
        
        public static void Demo()
        {
            MyEvent4 evt = new MyEvent4();
            evt.SomeEvent += new EventHandler(handler);  //!!!!!!!!!!!!!!

            // Событие
            evt.OnSomeEvent();
        }
    }

    class MyEvent4
    {
        public event EventHandler SomeEvent;    //!!!!!!!!!!!!!!
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent(this, EventArgs.Empty);
        }
    }
}