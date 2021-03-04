using System;

namespace EventsSmple
{
    // Использование класса EventArgs
    delegate void MyEventHandler5(object sourse, MyEventArgs5 arg);//////

    class Sample5
    {
        static void handler(object sourse, MyEventArgs5 arg)  ///////////
        {
            Console.WriteLine("Событие произошло!");
            Console.WriteLine("номер события: " + arg.numEvent);
            Console.WriteLine("вызвано из класса: " + sourse);
        }
        
        public static void Demo()
        {
            MyEvents5 evt = new MyEvents5();
            evt.SomeEvent +=new MyEventHandler5(handler);

            // можно так
            //evt.SomeEvent += (s, a) => handler(s, a);

            // или вообще вот так (функция handler не нужна)
            //evt.SomeEvent += (s, a) => 
            //{
            //    Console.WriteLine("Событие произошло!");
            //    Console.WriteLine("номер события: " + a.numEvent);
            //    Console.WriteLine("вызвано из класса: " + s);
            //};

            // Событие
            evt.OnSomeEvent();
            evt.OnSomeEvent();
            evt.OnSomeEvent();
            evt.OnSomeEvent();
            evt.OnSomeEvent();
            evt.OnSomeEvent();
        }
    }

    // Теперь обработчик событий имеет нечто конкретное. 
    // А именно, он знает количество произршедших событий.
    class MyEventArgs5 : EventArgs  //////////////////////////////////////
    {
        public int numEvent; // счетчик событий
    }

    class MyEvents5
    {
        public event MyEventHandler5 SomeEvent;
        static int count = 0;
        public void OnSomeEvent()
        {
            MyEventArgs5 arg = new MyEventArgs5();  /////////////////////////
            if (SomeEvent != null)
            {
                arg.numEvent = count++;//обратите внимание на порядок следования!
                SomeEvent(this, arg);  ///////////////////////////////////  
            }
        }
    }


    

  

    
}