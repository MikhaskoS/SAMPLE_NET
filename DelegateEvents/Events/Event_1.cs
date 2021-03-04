 using System;

namespace EventsSmple
{
    // Применение события в одном классе.
    // Простейший случай.
    public class Sample1
    {
        delegate void MyEventHandler(); // делегат
        static event MyEventHandler SomeEvent; // событие

        public static void EventsSample()
        {

            SomeEvent += new MyEventHandler(handler1);
            SomeEvent += new MyEventHandler(handler2);
            // Генерируем событие
            OnSomeEvent();
        }

        // Функция, генерирующая событие
        static void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent();
            // или так (? - потокобезопасный вызов)
            //SomeEvent?.Invoke();
        }
        // Здесь то, что должно произойти в момент события
        // функции соответствуют сигнатуре делегата
        static void handler1()
        {
            Console.WriteLine("Событие произошло!");
        }
        static void handler2()
        {
            Console.WriteLine("Точно, точно!");
        } 
    }
}