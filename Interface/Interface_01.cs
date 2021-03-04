using System;

// Неявная реализация интерфейса
namespace ISample
{
    using S1;

    public class Sample1
    {
        public static void Demo()
        {
            Box box = new Box(10, 20);
            Console.WriteLine("Длина: " + box.Length());
            Console.WriteLine("Ширина: " + box.Width());
        }
    }

    namespace S1
    {
        // интерфейс
        interface IDimensions
        {
            float Length();
            float Width();
        }
        class Box : IDimensions
        {
            float lengthInches;
            float widthInches;

            public Box(float length, float width)
            {
                lengthInches = length;
                widthInches = width;
            }
            // Реализуем методы интерфейса.
            // Если не пометить их как public, компилироваться не будет !!!
            public float Length()
            {
                return lengthInches;
            }

            public float Width()
            {
                return widthInches;
            }
        }
    }
}