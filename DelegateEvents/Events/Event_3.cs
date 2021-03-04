using System;

namespace EventsSmple
{
    // Здесь мы воспользуемся канонами .NET Framework
    // А именно, .NET совместимые обработчики событий должны
    // иметь вид:
    // void handler (object sourse, EventArgs arg)
    // object sourse - ссылка на объект, который генерирует событие
    // EventArgs arg - прочая информация.
    // (пока мы не реализуем ничего)

    class Sample3
    {
        static void handler(object sourse, EventArgs arg)   //!!!!!!!!!!!!!!
        {
            Console.WriteLine("Событие произошло!");
        }
        public static void HandlerSample()
        {
            MyEvent3 evt = new MyEvent3();
            evt.SomeEvent += new MyEventHandler3(handler);

            // тоже самое
            //evt.SomeEvent += (s, a) => Console.WriteLine("Событие произошло!");             
            
            // Событие
            evt.OnSomeEvent();
        }
    }

    // EventArgs — это базовый класс для классов, содержащих данные для события.
    delegate void MyEventHandler3(object sourse, EventArgs arg);  //!!!!!!!!!!!!!!

    class MyEvent3
    {
        public event MyEventHandler3 SomeEvent;
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent(this, EventArgs.Empty);           //!!!!!!!!!!!!!!
            // Или так:
            //SomeEvent?.Invoke(this, EventArgs.Empty);
        }
    }

    
}