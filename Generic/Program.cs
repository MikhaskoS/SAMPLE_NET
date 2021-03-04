using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пример простого обобщения в методе
            //Sample1.Demo();

            // Обобщенный класс, ограничение метода на тип
            //Sample2.Demo();

            // Обобщенная структура. default<T>
            //Sample3.Demo();

            // Обобщение делегата
            //Sample4.Demo();

            // Конкретный пример обобщения коллекции для
            // сортировки объектов конкретного класса
            Sample5.Demo();
        }
    }
}
