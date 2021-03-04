using System;
using System.Collections.Generic;
using System.Text;

namespace ExeptionSample
{
    public partial class Sample
    {
        /// <summary>
        /// Свойство System.Exception.TargetSite позволяет выяснить разнообразные детали о методе, 
        /// который сгенерировал заданное исключение.
        /// </summary>
        public static void Demo1()
        {
            // обработка ошибки
            try
            {
                GenerateExeption();
            }
            catch (Exception e) // это перехват всех возможных исключений
            {
                Console.WriteLine("\n*** Error! ***"); // ошибка 
                Console.WriteLine("Method: {0}", e.TargetSite); // метод 
                Console.WriteLine("Class defining member: {0}", e.TargetSite.DeclaringType) ; // класс, определяющий член
                Console.WriteLine("Message: {0} ", e.Message); // сообщение 
                Console.WriteLine("Source: {0}", e.Source); // источник

                Console.WriteLine("Member type: {0}", e.TargetSite.MemberType); // тип члена

                Console.WriteLine("Help Link: {0}", e.HelpLink);

                Console.WriteLine("Исключение: {0}", e);
            }
            finally // срабатывает всегда
            {
                Console.WriteLine("--- END ----");
            }
        }

        public static void GenerateExeption()
        {

            for (int k = 0; k < 1000; k++)
            {
                if (k > 10)
                {
                    // генерируем ошибку
                    //throw new Exception("ОШИБКА!!!");

                    // или так -  с указанием аргумента
                    //throw new ArgumentOutOfRangeException(nameof(k));

                    // или так
                    Exception ex = new Exception("ОШИБКА!!!");
                    ex.HelpLink = "https://www.google.ru/";

                    throw ex;
                }
            }
        }
    }
}
