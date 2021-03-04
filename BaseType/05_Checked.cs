using System;

/*
 * checked - нужна проверка на пререполнение
 * unchecked - не нужна (по-умолчанию).
 * MS Visual Studio -> 
 */
namespace TypeBase
{
    class Sample5
    {
        public static void Demo()
        {
            // Поэкспериментируем с элементарным типом byte [0, 255]
            byte b = 255;

            b = (byte)(b + 2);    // По-умолчанию, компилятор преобразует b+2 в int
            Console.WriteLine("(byte)(255 + 2) = " + b); // = 1

            // теперь поступим по-другому
            b = 255;
            try
            {
                b = checked((byte)(b + 2)); // проверка на переполнение
                Console.WriteLine(b);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка переполнения!");
            }

            // Инструкцию можно заключить в блок:
            try
            {
                b = 255;
                checked
                {
                    b = ((byte)(b + 2)); // проверка на переполнение
                    Console.WriteLine(b);
                }
            }
            catch
            {
                Console.WriteLine("Ошибка переполнения!");
            }

        }
    }
}