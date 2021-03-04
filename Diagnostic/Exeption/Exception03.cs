using System;


namespace ExeptionSample
{
    public partial class Sample
    {
        public static void Demo3()
        {
            GetNumber(30);
        }


        public static int GetNumber(int index)
        {
            int[] numbers = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

            if (index < 0 || index >= numbers.Length)
            {
                //throw new MyException();   // наши исключения
                //throw new MyException("Фигня какая-то!");   // наши исключения
                throw new MyException("Фигня какая-то!", new IndexOutOfRangeException());   // наши исключения
            }
            return numbers[index];
        }

        // Visual Studio предлагает быстрый способ построения нового класса исключений
        // нужно набрать Exception и щелкнуть 2 раза Tab. Этот класс выполняет все рекомендации .NET
        [Serializable]
        public class MyException : Exception
        {
            public MyException() { }
            public MyException(string message) : base(message) { }
            public MyException(string message, Exception inner) : base(message, inner) { }
            protected MyException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
