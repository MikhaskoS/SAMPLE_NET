using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeBase
{
    class Sample12
    {
        public static void Demo()
        {
            double average;
            average = CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
            Console.WriteLine("Average of data is: {0}", average);

            // ... или передать массив значении double.
            double[] data = { 4.0, 3.2, 5.7 };
            average = CalculateAverage(data);
            Console.WriteLine("Average of data is: {0}", average);

            Console.WriteLine("***** Fun with Methods *****");
            //-------------------------------
            EnterLogData("Oh no! Grid can't find data");
            EnterLogData("Oh no! I can’t find the payroll data", "CFO");
            Console.ReadLine();
            //-------------------------------
            Console.WriteLine("***** Fun with Methods *****");


            // Именованные параметры можно вызывать в любом порядке, но только после обычных
            DisplayFancyMessage(
                message: "Wow! Very Fancy indeed!", 
                textColor: ConsoleColor.DarkRed, 
                backgroundColor: ConsoleColor.White);

            DisplayFancyMessage(
                backgroundColor: ConsoleColor.Green, 
                message: "Testing...", 
                textColor: ConsoleColor.DarkBlue);
            
            // Именованные параметры имеет смысл использовать в сочетании с необязательными параметрами
            DisplayFancyMessage2(message: "Ups!");
        }

        // Возвращение среднего из некоторого количества значений double, 
        // количество параметров может быть любым
        static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("You sent me {0} doubles.", values.Length);

            double sum = 0;
            if (values.Length == 0) return sum;
            for (int i = 0; i < values.Length; i++)
                sum += values[i];
            return (sum / values.Length);
        }


        // Необязательный параметр
        static void EnterLogData(string message, string owner = "Programmer")
        {
            Console.Beep();
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
        }

        static void DisplayFancyMessage(ConsoleColor textColor, ConsoleColor backgroundColor, string message)
        {
            // Сохранить старые цвета для их восстановления после вывода сообщения. 
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldbackgroundColor = Console.BackgroundColor;
            // Установить новые цвета и вывести сообщение. 
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor; Console.WriteLine(message);
            // Восстановить предыдущие цвета. 
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldbackgroundColor;

        }

        static void DisplayFancyMessage2(ConsoleColor textColor = ConsoleColor.Red, 
            ConsoleColor backgroundColor = ConsoleColor.Green, string message = "Hello!")
        {
            // Сохранить старые цвета для их восстановления после вывода сообщения.  
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldbackgroundColor = Console.BackgroundColor;
            // Установить новые цвета и вывести сообщение. 
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor; Console.WriteLine(message);
            // Восстановить предыдущие цвета. 
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldbackgroundColor;
        }
    }
}
    
