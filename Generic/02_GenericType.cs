using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

/* В этом примере демонстрируется возможность
 * сравнения двух объектов Generic*/
namespace GenericsDemo
{

    class Sample2
    {
        public static void Demo()
        {
            // получим максимальное из двух чисел
            Console.WriteLine("Максимальное из 56, 45: ");
            Console.WriteLine(GenericType<int>.Max(56, 45));

            GenericType<double>.TMaxValue();
        }
    }

    //where T : struct - аргумент типа должен быть структурного типа, кроме Nullable.
    //where T : class - аргумент типа должен иметь ссылочный тип; это также
    //   распространяется на тип любого класса, интерфейса, делегата или массива.
    //where T : <base class name> - аргумент типа должен являться или быть
    //   производным от указанного базового класса
    //where T : U - аргумент типа, поставляемый для T, должен являться или быть
    //   производным от аргумента, поставляемого для U.Это называется неприкрытым
    //   ограничением типа
    //where T : new() - ограничение указывает, что аргумент любого типа в объявлении
    //   универсального класса должен иметь открытый конструктор без параметров.
    //   Использовать ограничение new можно только в том случае, если тип не является
    //   абстрактным


    // Здесь мы указыаем, что тип не может быть любым (ограничение на тип).
    // А именно, он должен поддерживать интерфейс IComparable,
    // чтобы типы можно было сравнивать.
    class GenericType<T> where T : IComparable<T>
    {
        // максимальное значение
        public static T Max(T a, T b)
        {
            // если a>b
            if (a.CompareTo(b) > 0) return a;
            else return b;
        }

        // Для неизвестного типа Т вывести его максимальное
        // значение
        public static void TMaxValue()
        {
            // получим реальный тип значения.
            Type t = typeof(T);

            Console.WriteLine("-----------------");
            FieldInfo fi = t.GetField("MaxValue");
            // получим параметры каждого метода

            Console.WriteLine(fi.GetValue(t));

        }
    }
}

