using System;
using OOP.Logger;

namespace OOP
{
    class Program
    {
        static void Main()
        {

            // построение объекта класса без создания локальной переменной
            new Class01() { name = "Вася", age = 25 }.Print();

            //Console.WriteLine("Hello World!");

            //Sample.Demo();

            //SampleLogger.Demo();

            Console.Read();
        }
    }
}
