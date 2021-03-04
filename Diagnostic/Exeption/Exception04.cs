using System;


namespace ExeptionSample
{
    public partial class Sample
    {
        public static void Demo4()
        {
            string input = "7";
            if (Int32.TryParse(input, out var x)) // С версии C# 6.0 мы можем объявлять переменные прямо при передаче в параметр
            {
                x *= x;
                Console.WriteLine("Квадрат числа: " + x);
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }
        }

        // фильтры исключений (С# 6.0)
        public static void Demo5()
        {
            int x = 1;
            int y = 0;
            try
            {
                int result = x / y;
            }
            catch (Exception) when (y == 0)
            {
                Console.WriteLine("y не должен быть равен 0");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
