using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public sealed class Class01
    {
        public string name;
        public int age;

        public void Print()
        {
            Console.WriteLine($"name: {name} age: {age}");
        }
    }
}
