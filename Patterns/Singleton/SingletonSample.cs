using System;
using System.Threading;

namespace Sample
{
    class Sample
    {
        static void Demo()
        {
            Console.WriteLine($"Main {DateTime.Now.TimeOfDay}");

            Console.WriteLine(Singleton_a.text);
            //Main 22:07:52.9339242
            //Singleton ctor 22:07:52.9727446
            //hello

            Console.WriteLine(new String('+', 10));

            Console.WriteLine(Singleton_b.text);
            Singleton_b singleton1 = Singleton_b.GetInstance();
            Console.WriteLine(singleton1.Date);


            Console.WriteLine(new String('+', 10));

            Console.WriteLine(LazySingleton.text);
            LazySingleton singleton2 = LazySingleton.GetInstance();
            Console.WriteLine(singleton2.Name);
            Console.Read();
        }
    }


    // В такой реализации при обращении к статическому полю мы автоматически проинициализируем
    // сам сиглтон, что может быть не нужно
    public class Singleton_a
    {
        private static readonly Singleton_a instance = new Singleton_a();
        public static string text = "hello";
        public string Date { get; private set; }

        private Singleton_a()
        {
            Console.WriteLine($"Singleton ctor {DateTime.Now.TimeOfDay}");
            Date = System.DateTime.Now.TimeOfDay.ToString();
        }

        public static Singleton_a GetInstance()
        {
            Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
            Thread.Sleep(500);
            return instance;
        }
    }

    // Полноценная Lazy реализация
    public class Singleton_b
    {
        public static string text = "hello";
        public string Date { get; private set; }

        private Singleton_b()
        {
            Console.WriteLine($"Singleton ctor {DateTime.Now.TimeOfDay}");
            Date = System.DateTime.Now.TimeOfDay.ToString();
        }

        public static Singleton_b GetInstance()
        {
            Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
            Thread.Sleep(500);
            return Nested.instance;   //  <--
        }

        private class Nested  //  <--
        {
            static Nested() { }
            internal static readonly Singleton_b instance = new Singleton_b();    
        }
    }

    // самая мощная реализация (простота + потокобезопасность + «ленивость»!)
    public class LazySingleton
    {
        private static readonly Lazy<LazySingleton> lazy =
            new Lazy<LazySingleton>(() => new LazySingleton());

        public static string text = "hello";

        public string Name { get; private set; }

        private LazySingleton()
        {
            // Уникальный идентификатор
            Name = System.Guid.NewGuid().ToString();
        }

        public static LazySingleton GetInstance()
        {
            return lazy.Value;
        }
    }
}
