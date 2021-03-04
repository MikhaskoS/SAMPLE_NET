using System;
// Проверка типов на соответствие. is и as
// is  - просто проверяет (true, false), но в 7,0 уже можно присваивать
// as  - пытается привести (null если не получилось)

namespace TypeBase
{
    // определим некоторые типы
    internal class A
    {
        public int id;
        public string name;
    }
    internal class B : A
    {
        public int age;
    }

    class Sample04
    {
        public static void Demo()
        {
            // здесь мы просто проверяем типы на соответствие
            A a = new A() { id = 0, name = "Вася"};
            bool b1 = (a is A);   // true
            bool b2 = (a is B);   // false
            Console.WriteLine("b1= {0}, b2 = {1}", b1, b2);

            // В 7.0 введены новшества !!!
            if (a is A ob) // если a имеет тип A - присвоить его ob
            {
                Console.WriteLine(ob.name);
            }
            // отбрасывание переменных типа
            if (a is A _)
            {
                Console.WriteLine("Делаем что-то...");
            }
            
            
            //---------------------------------------------------------
            // здесь же мы выполняем приведение типов, если
            // это возможно. Оператор неприменим к типам значений!!!


            B m = new B();
            a = m as A;    // приведение вполне осуществимо
            if (a != null)
            {
                Console.WriteLine("Операция приведения успешно проведена");
            }
            else
            {
                Console.WriteLine("Приведение типов невозможно");
            }

            // as - оператор приведения
            m = a as B;    // приведение вполне осуществимо
            if (m != null)
            {
                Console.WriteLine("Операция приведения успешно проведена");
            }
            else
            {
                Console.WriteLine("Приведение типов невозможно");
            }

        }
    }
}