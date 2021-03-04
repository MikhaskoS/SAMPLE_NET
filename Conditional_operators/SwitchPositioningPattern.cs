// условные операторы

using System;

namespace Conditional_operators
{
    // Похож на вариант с кортежами, но используется деконструктор и сравнение по позиции
    class SwitchPositioningPattern
    {
        public static void Demo()
        {
            MessageDetails details1 = new MessageDetails { Language = "english", DateTime = "evening", Status = "user" };
            string message = GetWelcome(details1);
            Console.WriteLine(message);  // Good evening

            MessageDetails details2 = new MessageDetails { Language = "french", DateTime = "morning", Status = "admin" };
            message = GetWelcome(details2);
            Console.WriteLine(message);  // Hello, Admin
        }

        class MessageDetails
        {
            public string Language { get; set; }    // язык пользователя
            public string DateTime { get; set; }    // время суток
            public string Status { get; set; }      // статус пользователя

            public void Deconstruct(out string lang, out string datetime, out string status)
            {
                lang = Language;
                datetime = DateTime;
                status = Status;
            }
        }

        //static string GetWelcome(MessageDetails details) => details switch
        //{
        //    ("english", "morning", _) => "Good morning",
        //    ("english", "evening", _) => "Good evening",
        //    ("german", "morning", _) => "Guten Morgen",
        //    ("german", "evening", _) => "Guten Abend",
        //    (_, _, "admin") => "Hello, Admin",
        //    _ => "Здрасьть"
        //};

        static string GetWelcome(MessageDetails details) => details switch
        {
            ("english", "morning", _) => "Good morning",
            ("english", "evening", _) => "Good evening",
            ("german", "morning", _) => "Guten Morgen",
            ("german", "evening", _) => "Guten Abend",
            (_, _, "admin") => "Hello, Admin",
            (var lang, var datetime, var status) => $"{lang} not found, {datetime} unknown, {status} undefined",
            _ => "Здрасьть"
        };
    }
}
