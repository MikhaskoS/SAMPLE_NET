using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsDemo
{
    class Sample3
    {

        public static void Demo()
        {
            Console.WriteLine("***** Демонстрация Generics *****\n");

            // Point<int>
            Point<int> p = new Point<int>(10, 10);
            Console.WriteLine("p.ToString()={0}", p.ToString());
            p.ResetPoint();
            Console.WriteLine("p.ToString()={0}", p.ToString());
            Console.WriteLine();

            // Point<double>
            Point<double> p2 = new Point<double>(5.4, 3.3);
            Console.WriteLine("p2.ToString()={0}", p2.ToString());
            p2.ResetPoint();
            Console.WriteLine("p2.ToString()={0}", p2.ToString());
            Console.WriteLine();

            // Swap 2 Points.
            Point<int> pointA = new Point<int>(50, 40);
            Point<int> pointB = new Point<int>(543, 1);
            Console.WriteLine("До Swap(): {0}, {1}", pointA, pointB);
            Swap<Point<int>>(ref pointA, ref pointB);
            Console.WriteLine("После Swap(): {0}, {1}", pointA, pointB);
            Console.ReadLine();
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("Применяем Swap() метод к {0}",
            typeof(T));
            T temp;
            temp = a;
            a = b;
            b = temp;
        }
    }

    // Структура с примененением Generic. Это обычная точка на плоскости
    // с координатами неопределенного типа
    public struct Point<T>
    {
        // поля.
        private T xPos;
        private T yPos;
        // конструктор.
        public Point(T xVal, T yVal)
        {
            xPos = xVal;
            yPos = yVal;
        }
        // свойства.
        public T X
        {
            get { return xPos; }
            set { xPos = value; }
        }
        public T Y
        {
            get { return yPos; }
            set { yPos = value; }
        }
        public override string ToString()
        {
            return string.Format("[{0}, {1}]", xPos, yPos);
        }
        // сброс к значениям по-умолчанию
        // обращаем внимание на новое ключевое слово default
        // (у каждого типа свое значение по-умолчанию)
        public void ResetPoint()
        {
            xPos = default(T);
            yPos = default(T);
        }
    }
}
