using System;

namespace EventsSmple
{
    public class Sample8
    {
        // Лямбда выражения можно применять и с событиями
        public static void Demo()
        {
            //так было
            //SomeEvent += new MyEventHandler(handler1);
            //сделаем иначе:
            SomeEvent += (n) => Console.WriteLine("Переданное значение : {0}", n);
            // Событие
            OnSomeEvent(10);
        }

        //delegate void MyEventHandler(int value); // делегат
        //static event MyEventHandler SomeEvent; // событие
        // или так (воспользуемся встроенным делегатом)
        static event Action<int> SomeEvent;



        // Функция, генерирующая событие
        static void OnSomeEvent(int value)
        {
            if (SomeEvent != null)
                SomeEvent(value);

            // Или так
            //SomeEvent.Invoke(value);
        }

        // Здесь то, что должно произойти в момент события
        //static void handler1(int value)
        //{
        //    Console.WriteLine("Переданное значение : {0}", value);
        //}
    }
}
