using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    // примеры построения объектов

    class Classes
    {
        public static void Demo()
        {
            // обязательно наличие конструктора по-умолчанию  public Student() если есть другой
            Student a = new Student { Name = "Вася", Age = 18 };
            Student b = new Student("Петя", 20) { ID = 100 };

            // если класс небольшой - нет смысла его где-то создавать (анонимный тип)
            var sudent = new { Name = "Bob", Id = 42 };

            // или даже так - одновременно инициализировать и вызвать метод
            new Student() { Name = "Вася", Age = 23 }.PrintMessage("Hello!");
        }
    }

    class Student
    {
        public int ID;
        private string name;
        private int age;

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public Student()
        { }

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void PrintMessage(string msg)
        {
            Console.WriteLine($"{Name } said {msg}");
        }
    }
}
