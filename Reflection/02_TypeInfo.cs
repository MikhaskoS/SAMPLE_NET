using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReflectionSample
{
    // Способы получения различной информации о типах и методах
    class Sample2
    {
        public static void Demo()
        {
            //------------------------------------------------------------
            // Методы класса
            //------------------------------------------------------------
            Type t = typeof(DemoClass);
            Console.WriteLine("Проанализируем методы класса {0}", t.Name);
            // MethodInfo[]-GetMethods()----------------------------------
            Console.WriteLine(new String('-', 30));
            PrintMethods(t); // методы класса (статические методы не выводятся)
            Console.WriteLine(new String('-', 30));
            //------------------------------------------------------------
            // выыод с конкретными условиями (только нашего класса, непубличные и статические)
            PrintMethods(t, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            Console.WriteLine(new String('-', 30));
            // Аналогично получаются данные о полях и свойствах
            // MethodInfo[]-GetMembers()------MethodInfo[]-GetProperties()
            //------------------------------------------------------------
            // Вызов методов Invoke()
            //------------------------------------------------------------
            DemoClass _demo = new DemoClass();
            
            // вывод конкретного метода
            MethodInfo mi = t.GetMethod("Multiple");
            object[] args = { 8, 9 };
            Console.WriteLine("Multiple(8,9) = {0}",  mi.Invoke(_demo, args));
            
            // вывод перегруженного метода с необходимым типом параметров
            MethodInfo[] miAr = t.GetMethods();
            foreach (MethodInfo m in miAr)
            {
                ParameterInfo[] pi = m.GetParameters();
                if (m.Name.CompareTo("Summ") == 0 && pi[0].ParameterType == typeof(string))
                {
                    object[] args1 = { "Hello ", "World!" };
                    string _s = m.Invoke(_demo, args1).ToString();
                    Console.WriteLine("Summ(string, string) = {0}", _s);
                    break;
                }
            }
            // использование лямбда выражений для поиска
            //var _v = miAr.Select(r => r.Name.CompareTo("Summ") == 0 && 
            //    (r.GetParameters())[0].ParameterType == typeof(string)).First();

            // Вызвать можно и статический и даже закрытый метод!
            mi = t.GetMethod("PrintHello", BindingFlags.Static | BindingFlags.NonPublic);
            Console.WriteLine("PrintHello: {0}", mi.Invoke(_demo, null));
            Console.WriteLine(new String('-', 30));
            //------------------------------------------------------------
            // Информация о конструкторах
            //------------------------------------------------------------
            ConstructorInfo[] ci = t.GetConstructors();

            Console.WriteLine("Доступные конструкторы: ");
            foreach (ConstructorInfo c in ci)
            {
                // Имя и тип. 
                Console.Write("   " + t.Name + "(");

                // Параметры. 
                ParameterInfo[] pi = c.GetParameters();

                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name +
                                  " " + pi[i].Name);
                    if (i + 1 < pi.Length) Console.Write(", ");
                }

                Console.WriteLine(")");
            }
            Console.WriteLine();
            // Ищем подходящий конструктор
            int x;
            for (x = 0; x < ci.Length; x++)
            {
                ParameterInfo[] pi = ci[x].GetParameters();
                if (pi.Length == 2 && pi[0].ParameterType == typeof(string)) break;
            }

            object[] consargs = new object[2];
            consargs[0] = "Привет ";
            consargs[1] = "Мир!";
            object reflectOb = ci[x].Invoke(consargs); // вызвали конструктор

            // вызываем метод, который использует данные конструктора
            mi = t.GetMethod("ConcatString");
            Console.WriteLine("ConcatString: {0}", mi.Invoke(reflectOb, null));
            Console.WriteLine(new String('-', 30));

        }

        public static void PrintMethods(Type t)
        {
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
            {
                // Возвращаемый тип
                Console.Write(" " + m.ReturnType.Name + " " + m.Name + "(");
                ParameterInfo[] pi = m.GetParameters();
                // параметры метода
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name +
                                  " " + pi[i].Name);
                    if (i + 1 < pi.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }
        public static void PrintMethods(Type t, BindingFlags flags)
        {
            MethodInfo[] mi = t.GetMethods(flags);
            foreach (MethodInfo m in mi)
            {
                // Возвращаемый тип
                Console.Write(" " + m.ReturnType.Name + " " + m.Name + "(");
                ParameterInfo[] pi = m.GetParameters();
                // параметры метода
                for (int i = 0; i < pi.Length; i++)
                {
                    Console.Write(pi[i].ParameterType.Name +
                                  " " + pi[i].Name);
                    if (i + 1 < pi.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }
    }

    // В этом классе мы реализуем различные составляющие, с целью
    // выяснения их свойств
    class DemoClass
    {
        public int valIntPublic1;
        public int valIntPublic2;
        public string valStringPublic1;
        public string valStringPublic2;

        public DemoClass() { }
        public DemoClass(int a, int b) { valIntPublic1 = a; valIntPublic2 = b; }
        public DemoClass(string a, string b) { valStringPublic1 = a; valStringPublic2 = b; }

        public int Summ(int a, int b)
        {
            return a + b;
        }
        public string Summ(string a, string b)
        {
            return String.Concat(a, b);
        }
        public string ConcatString()
        {
            return String.Concat(valStringPublic1, valStringPublic2);
        }
        public int Multiple(int a, int b)
        {
            return a * b;
        }
        static string PrintHello()
        {
            return "Hello World!";
        }
        static void Swap<T>(ref T a, ref T b)
        {
             T temp;
            temp = a;
            a = b;
            b = temp;
        }
    }
}
