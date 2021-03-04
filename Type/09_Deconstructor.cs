using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeCreate
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Deconstruct(out string name, out int age)
        {
            name = this.Name;
            age = this.Age;
        }
    }
    class DeconstructorSample
    {
        // Деконструкторы позволяют выполнить декомпозицию объекта на отдельные части.
        public static void Demo()
        {
            Person person = new Person { Name = "Tom", Age = 33 };

            (string name, int age) = person;

            Console.WriteLine(name);    // Tom
            Console.WriteLine(age);     // 33
        }
    }
}
