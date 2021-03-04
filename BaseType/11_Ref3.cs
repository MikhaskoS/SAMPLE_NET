using System;

namespace TypeBase
{
    class Sample11
    {
        public static void Demo()
        {

            string[] stringArray = { "one", "two", "three" };
            int pos = 1;

            var s1 = SimpleReturn(stringArray, pos);
            Console.WriteLine(s1);   // two
            s1 = "new";              // это не изменит первоначальный массив

            // так можно легко изменить переменную масива
            ref var s2 = ref SimpleRefReturn(stringArray, pos);
            s2 = "new";
            Console.WriteLine("After: {0}, {1}, {2} ", 
                stringArray[0], stringArray[1], stringArray[2]); // After: one, new, three

        }

        // Возвращает значение по позиции в массиве. 
        public static string SimpleReturn(string[] strArray, int position)
        {
            return strArray[position];
        }

        // а здесь мы возвращаем ссылку на элемент массива!  C# 7.0
        public static ref string SimpleRefReturn(string[] strArray, int position)
        {
            return ref strArray[position];
        }
    }
}