// условные операторы

using System;

namespace Conditional_operators
{
    class SwitchTyplePattern
    {
        public static void Demo()
        {
            string message = GetWelcome("english", "evening", "user");
            Console.WriteLine(message);  // Good evening

            message = GetWelcome("french", "morning", "admin");
            Console.WriteLine(message);  // Hello, Admin
        }

        static string GetWelcome(string lang, string daytime) => (lang, daytime) switch
        {
            ("english", "morning") => "Good morning",
            ("english", "evening") => "Good evening",
            ("german", "morning") => "Guten Morgen",
            ("german", "evening") => "Guten Abend",
            _ => "Здоров!"
        };


        // В случае, если мы не хотим использовать элемент кортежа, то вместо него ставим прочерк:
        static string GetWelcome(string lang, string daytime, string status) => (lang, daytime, status) switch
        {
            ("english", "morning", _) => "Good morning",
            ("english", "evening", _) => "Good evening",
            ("german", "morning", _) => "Guten Morgen",
            ("german", "evening", _) => "Guten Abend",
            (_, _, "admin") => "Hello, Admin",
            _ => "Здрасьть"
        };
    }
}
