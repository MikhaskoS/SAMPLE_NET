using System;

public enum Color /* : byte */ {
    qwe,         // присвоено значение 0
    Red,         // присвоено значение 1
    Green,       // присвоено значение 2
    Blue,        // присвоено значение 3
    Orange,      // присвоено значение 4
}

public static class EnumSample
{
    public static void Sample()
    {
        // Этот метод возвращает базовый тип, используемый для
        // хранения значения перечислимого типа
        Console.WriteLine("Базовый тип: " + Enum.GetUnderlyingType(typeof(Color))); //Базовый тип: System.Int32

        // Создаем переменную типа Color и инициализируем ее значением Blue
        Color c = Color.Blue;
        Console.WriteLine(c);               // "Blue" (General format)
        Console.WriteLine(c.ToString());    // "Blue" (General format)
        Console.WriteLine(c.ToString("G")); // "Blue" (General format)
        Console.WriteLine(c.ToString("D")); // "3"    (Десятичный формат)
        Console.WriteLine(c.ToString("X")); // "03"   (Шестнадцатеричный)

        // Использование статического метода Format для того же
        Console.WriteLine(Enum.Format(typeof(Color), 3, "G"));     // "Blue"

        //-----------------------------------------------------
        //  Получение значений из перечисления
        //-----------------------------------------------------
        // Получение массива из перечисления
        // Value Symbol
        // -----  --------
        //    0   qwe
        //    1   Red
        //    2   Green
        //    3   Blue
        //    4   Orange
        Color[] colors = (Color[])Enum.GetValues(typeof(Color));
        Console.WriteLine("Number of symbols defined: " + colors.Length);
        Console.WriteLine("Value\tSymbol\n-----\t------");
        foreach (Color color in colors)
        {
            // Отображаем содержимое в разных форматах.
            Console.WriteLine("{0,5:D}\t{0:G}", color);
        }

        // Другой способ получения значений
        //Name: qwe, Value: 0
        //Name: Red, Value: 1
        //Name: Green, Value: 2
        //Name: Blue, Value: 3
        //Name: Orange, Value: 4
        for (int i = 0; i < colors.Length; i++) 
        {
            Console.WriteLine("Name : {0}, Value: {0:D}", colors.GetValue(i)); 
        }

        // Т.к. Orange определен как 4, 'c' получит значение 4.
        c = (Color)Enum.Parse(typeof(Color), "orange", true);

        //-----------------------------------------------------
        //  Обработка ошибки
        //-----------------------------------------------------
        // Генерируем ошибку ArgumentException.
        try
        {
            c = (Color)Enum.Parse(typeof(Color), "Brown", false);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Brown не определен!");
        }

        //-----------------------------------------------------
        //  Создание экземпляра перечисления
        //-----------------------------------------------------
        // Создаем экземпляр перечисления Color со значением 1
        c = (Color)Enum.Parse(typeof(Color), "1", false);

        // Создаем экземпляр перечисления Color со значением 23
        c = (Color)Enum.Parse(typeof(Color), "23", false);


        //-----------------------------------------------------
        //  Проверить наличие значения или имени в перечислении
        //-----------------------------------------------------
        // = "True" т.к. в Color Red = 1
        Console.WriteLine(Enum.IsDefined(typeof(Color), 1));

        // = "True" т.к. Color White = 0
        Console.WriteLine(Enum.IsDefined(typeof(Color), "White"));

        // = "False" поскольку регистр проверяется
        Console.WriteLine(Enum.IsDefined(typeof(Color), "white"));

        // = "False" нет идентификатора со значением 10
        Console.WriteLine(Enum.IsDefined(typeof(Color), 10));


        SetColor((Color)3);  // Blue
        try
        {
            SetColor((Color)547);  // Not a defined color
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("Ошибка: {0}", e);
        }
    }

    public static void SetColor(Color c)
    {
        if (!Enum.IsDefined(typeof(Color), c))
        {
            throw (new ArgumentOutOfRangeException(nameof(c), c,
                "You didn't pass a valid Color"));
        }
        // Установить цвет в Red, Green, Blue, или Orange...
    }
}
