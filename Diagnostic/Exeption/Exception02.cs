using System;


namespace ExeptionSample
{
    public partial class Sample
    {
        public static void Demo2()
        {
            var gen = new NumberGenerator();
            int index = 10;
            try
            {
                int value = gen.GetNumber(index);
                Console.WriteLine($"Retrieved {value}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"{e.GetType().Name}: {index} is outside the bounds of the array");

                // Для повторной генерации исключения
                throw;
            }
        }

        public class NumberGenerator
        {
            int[] numbers = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

            public int GetNumber(int index)
            {
                if (index < 0 || index >= numbers.Length)
                {
                    throw new IndexOutOfRangeException(nameof(index)); // исключения уровня системы
                }
                return numbers[index];
            }
        }
    }
}
