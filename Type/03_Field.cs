using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeCreate
{
    class Sample3
    {
        public static readonly StringBuilder Name = new StringBuilder("Sergio");

        public static void Demo()
        {
            // Если поле объявлено с модификатором readonly (только для чтения), 
            // то это не значит, что его
            // нельзя изменить. Это верно лишь для неизменяемых типов
            Sample3.Name.Remove(0, 6).Append("Бу...");
            Console.WriteLine(Sample3.Name); // Изменили!!!
        }
    }
}
