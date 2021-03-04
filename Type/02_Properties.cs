using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeCreate
{
    class Sample2
    {
        // Демонстрация работы с полями и свойствами
        /* Среда Visual Studio предлагает фрагмент кода prop. 
         * Если вы наберете слово prop и два раза нажмете клавишу <ТаЬ>, 
         * то IDE-среда сгенерирует начальный код для нового автоматического свойства. 
         * Затем с помощью клавиши <ТаЬ> можно циклически проходить по всем частям 
         * определения и заполнять необходимые детали. Испытайте описанный прием.*/

        public static void Demo()
        {
            // первый способ
            Employee1 emp1 = new Employee1();
            emp1.Name = "Bob";
            emp1.Id = 1;

            // второй способ
            Employee2 emp2 = new Employee2();
            emp2.Name = "Jane";
            emp2.Id = 2;

            // третий способ (делает тоже, что и первый) - с версии C# 3.0
            Employee3 emp3 = new Employee3 { Name = "Ohhh...", Id = 666 };
        }

        class Employee1
        {
            public string Name;
            public int Id;
        }

        class Employee2
        {
            private string name;
            private int id;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public int Id
            {
                get { return id; }
                set { id = value; }
            }
        }

        class Employee3
        {
            // Автоматические свойства
            public string Name
            {
                get;
                set;
            }
            public int Id
            {
                get;
                set;
            }
        }

        class Employee4
        {
            // Автоматические свойства можно инициализировать
            public string Name { get; set; } = "Вася";
            public int Id { get; set; } = 10;
        }

        class Employee5
        {
           // не самый лучший способ, если нет реализации.
           // Лучше переделать на автоматические свойства (компилятор
           // сам сгенерирует закрытые поля, не видимые нам)
           private  string name;
           private int id;

            public string Name { get => name; set => name = value; }
            public int Id { get => id; set => id = value; }
        }
    }
}
