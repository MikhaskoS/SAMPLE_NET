using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeBase
{
    class Sample3B
    {
        public static void Demo()
        {
            Employee employee = new Employee("Tom", "Microsoft");
            Person person = employee;   // преобразование от Employee к Person (часть данных просто отброшена, но не потеряна)

            //  !!!  TypeBase.Employee,  хотя это тип Person  и поле Company  не доступно  !!!
            // person  хранит ССЫЛКУ на объект Employee
            Console.WriteLine(person.GetType());

            Console.WriteLine(person.Name);
            //Console.WriteLine(person.Company);    // НЕТ

            // однако, так мы можем получить доступ к скрытым полям (явное преобразование)
            Employee employee1 = (Employee)person;
            Console.WriteLine(employee1.Name);
            Console.WriteLine(employee1.Company);

            // А так уже нельзя делать:
            
            //Employee emp = new Person("Tom");   // ! Ошибка

            Person person2 = new Person("Bob");
            //Employee emp2 = (Employee)person;  // ! Ошибка

            Console.ReadKey();
        }
    }
    /*
                         Object
                           |
                         Person
                         /    \
                 Employee      Client
    */

    class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            Name = name;
        }
        public void Display()
        {
            Console.WriteLine($"Person {Name}");
        }
    }

    class Employee : Person
    {
        public string Company { get; set; }
        public Employee(string name, string company) : base(name)
        {
            Company = company;
        }
    }

    class Client : Person
    {
        public string Bank { get; set; }
        public Client(string name, string bank) : base(name)
        {
            Bank = bank;
        }
    }
}
