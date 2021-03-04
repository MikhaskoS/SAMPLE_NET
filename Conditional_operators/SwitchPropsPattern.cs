// условные операторы
using System;

namespace Conditional_operators
{
    class SwitchPropsPattern
    {
        public static void Demo()
        {
            Person pierre = new Person { Language = "french", Status = "user", Name = "Pierre" };
            string message = GetMessage(pierre);
            Console.WriteLine(message);             // Salut, Pierre!

            Person tomas = new Person { Language = "german", Status = "admin", Name = "Tomas" };
            Console.WriteLine(GetMessage(tomas));     // Hallo, admin!

            Person pablo = new Person { Language = "spanish", Status = "user", Name = "Pablo" };
            Console.WriteLine(GetMessage(pablo));     // Unknown language: spanish

            Person bob = null;
            Console.WriteLine(GetMessage(bob));         // null
        }

        class Person
        {
            public string Name { get; set; }        // имя пользователя
            public string Status { get; set; }      // статус пользователя
            public string Language { get; set; }    // язык пользователя
        }

        static string GetMessage(Person p) => p switch
        {
            { Language: "english" } => "Hello!",
            { Language: "german", Status: "admin" } => "Hallo, admin!",
            { Language: "french" } => "Salut!",
            { Language: var lang } => $"Unknown language: {lang}",
            //{ } => "undefined",   // или так, 
            null => "null"
        };
    }
}
