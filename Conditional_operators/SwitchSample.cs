using System;


// условные операторы
namespace Conditional_operators
{
    class SwitchSample
    {
        // новинка C# 7.0
        public static void DemoSwitch<T>(T value)
        {
            var choice = value;

            switch (choice)
            {
                case int i when i == 2:
                    Console.WriteLine("Hello int, value = " + i);
                    break;
                case string s when s == "Hello":
                    Console.WriteLine("Hello string, value = " + s);
                    break;
                case float _:  // что угодно типа float
                    Console.WriteLine("Это float!!!");
                    break;
                case null: // Предпринять какое-то действие в случае null, 
                    break;
                default:
                    Console.WriteLine("Ups...");
                    break;
            }
        }

        public static void DemoSwitch2(int k)
        {
            switch (k)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    Console.WriteLine("Число меньше 5");
                    break;
                case 5:
                    Console.WriteLine("Это 5");
                    break;

            }
        }
        //-----------------------------------------
        //   новинка C# 8.0  https://metanit.com/sharp/tutorial/3.45.php
        //-----------------------------------------
        public static int DemoSwitch3(int op, int a, int b)
        {
            switch (op)
            {
                case 1: return a + b;
                case 2: return a - b;
                case 3: return a * b;
                default: throw new ArgumentException("Недопустимый код операции");
            }
        }
        // Эту функцию можно переписать так:
        public static int DemoSwitch4(int op, int a, int b)
        {
            return op switch
            {
                1 => a + b,
                2 => a - b,
                3 => a * b,
                _ => throw new ArgumentException("Недопустимый код операции")
            };
        }
        // Или даже так
        static int DemoSwitch5(int op, int a, int b) => op switch
        {
            1 => a + b,
            2 => a - b,
            3 => a * b,
            _ => throw new ArgumentException("Недопустимый код операции")
        };
    }
}
