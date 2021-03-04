// Демонстрация работы интерфейса.
// Пример явной реализации интерфейса.

namespace ISample
{
    using S2;

    class Sample2
    {
        public static void Demo()
        {
            Box myBox = new Box(30.0f, 20.0f);

            IDimensions myDimensions = (IDimensions)myBox; //   <- обр. внимание
            /* Так компилятор выдаст ошибку:                   */
            //System.Console.WriteLine("Length: {0}", myBox.Length());
            //System.Console.WriteLine("Width: {0}", myBox.Width());

            System.Console.WriteLine("Length: {0}", myDimensions.Length());
            System.Console.WriteLine("Width: {0}", myDimensions.Width());
        }
    }

    namespace S2
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
            // явное определение методов интерфейса 
            float IDimensions.Length()
            {
                return lengthInches;
            }
            float IDimensions.Width()
            {
                return widthInches;
            }
        }
    }
}


