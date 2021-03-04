using System;
using System.Globalization;

namespace TypeBase
{
    // Преобразование типов
    // Преобразование типов бывает двух видов - явное и неявное.
    // Неявное проебразование возможно, когда:
    // - преобразуются элементарные типы без потери точности (int -> float)
    // - объект преобразуется в базовый тип (т.е. в тип, от которого произошло
    // наследование)
    class Sample3
    {
        public static void Demo()
        {
            //------------------------------
            int iA = 10;
            float fA = iA;  // неявное преобразование
            //------------------------------

            //для типов с реализацией IConvertable
            float fB = 10.86f;
            int iB0 = (int)fB; // = 10  Явное, с потерей точности
            int iB1 = System.Convert.ToInt32(fB); // = 11 (!!!!!!) - округление 

            Console.WriteLine($"a={fB}:\n(int)a = {iB0} \nConvert.ToInt32(a) = {iB1}");
            //------------------------------

            int iC = 20;
            //string sC = (string)iC; // нельзя
            string sC = iC.ToString(); // можно

            string sD0 = "0,005"; // обр. внимание на запятую
            string sD1 = "0.005";
            try
            {
                float fD1 = float.Parse(sD1);// не получится
            }
            catch (FormatException)
            { Console.WriteLine("Формат не поддерживается."); }
            float fD = float.Parse(sD0); // получится
            //------------------------------

            string sE0 = "1,456";
            string sE1 = "1.456";
  
            float.TryParse(sE0, out float fE0);  // = true
            float.TryParse(sE1, out float fE1);  // = false
            //------------------------------

            // А теперь более общие примеры: (тест из книги Рихтера)
            Object o = new Object();   
            Console.WriteLine(o.GetType()); // System.Object

            A a = new A();
            B b = new B();
            Console.WriteLine(a.GetType()); // A
            Console.WriteLine(b.GetType()); // B

            Object o1 = new A();
            Object o2 = new B();
            Console.WriteLine(o1.GetType()); // A ! но это тип Object  с сылкой на A
            Console.WriteLine(o2.GetType()); // B ! но это тип Object  с сылкой на B

            Object o3 = o2;
            Console.WriteLine(o3.GetType()); // B

            A a1 = new B();
            Console.WriteLine(a1.GetType()); // B  ! тип A с сылкой на B
            // B b1 = new A();   <-  нет

            // B b2 = a1;     // ошибка во время компиляции
            B b2 = (B)a1;     // a1 имеет тип B, но нужно указать явно, т.к. для компилятора это тип A
            Console.WriteLine(b2.GetType()); // B
            B b3 = b2;
            Console.WriteLine(b3.GetType()); // B

            //B b4 = (B)a;  // <- ошибка во время выполнения
            A a3 = b3; // неявное преобразование
            Console.WriteLine(a3.GetType()); // B

            Console.ReadLine();
        }

        // Отметим, что ВСЕ типы - производные от System.Object
        class A
        {
        }
        class B : A
        {
        }
    }
}

