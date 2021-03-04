using System;

// Демонстрация анонимных типов (появилось в C# 3.0)

namespace TypeCreate
{
    public class Sample1
    {
        public static void Demo()
        {
            var employeeInfo = new { Name = "Bob", Id = 42 };
            var customerInfo = new { Name = "Jane", Id = "E124" };
            var sampleInfo = new { Name = "Ohhh...", Status = "Noob" };

            Console.WriteLine("Name: {0}, Id: {1}", employeeInfo.Name, employeeInfo.Id);
            //Console.WriteLine(employeeInfo.GetType());
            Console.WriteLine(customerInfo.GetType());
            Console.WriteLine(sampleInfo.GetType());

            //-----------------------------------------------------------
            // Данные можно передавать группами (кортежи) 
            var employeeInfoT = (Name: "Bob", Id: 42);  // упрощенная структура данных (значимый тип)
            Console.WriteLine(employeeInfoT.Name);
            var var1 = Tuple.Create("Вася", 12); // до 8 обьектов различных типов
            Console.WriteLine(var1.Item1);
            Console.WriteLine(var1.Item2);
        }
    }
}
// Результат: 
/*
Name: Bob, Id: 42
<>f__AnonymousType0`2[System.String,System.Int32]
<>f__AnonymousType0`2[System.String,System.String]
<>f__AnonymousType1`2[System.String,System.String]  <- тип другой!
Для продолжения нажмите любую клавишу . . .
*/