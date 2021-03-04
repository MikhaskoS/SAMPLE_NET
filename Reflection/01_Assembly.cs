using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReflectionSample
{
    class Sample1
    {
        public static void Demo()
        {
            // сборка, выполяющая текущий код
            Assembly theAssemply = Assembly.GetExecutingAssembly();
            Console.WriteLine("Путь к сборке {0}", theAssemply.Location);
            Console.WriteLine("Имя сборки {0}", theAssemply.FullName);
            Console.WriteLine("Только для отражения? - {0}", theAssemply.ReflectionOnly);
        }
    }
}
