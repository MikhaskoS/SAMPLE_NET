using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeCreate
{
    class Sample4
    {
        public static void Demo()
        {
            //---------------------------------------------------------------------
            // Параметр out
            //---------------------------------------------------------------------
            int K;
            SampleOut(out K);  Console.WriteLine($"K = {K}");
            // В C# 7 добавлены out-переменные, которые позволяют объявить переменные сразу в вызове метода
            SampleOut(out int L); Console.WriteLine($"L = {L}");
            //---------------------------------------------------------------------
            // Параметр ref
            //---------------------------------------------------------------------


            // Стандартный вызов
            Search("Sue", 22, "New York");
            // Пропустить параметр city.
            Search("Mark", 23);
            // Явно задать имя параметра city.
            Search("Lucy", city: "Cairo");
            // Использовать именованные параметры в обратном порядке.
            Search("Pedro", age: 45, city: "Saigon");
            //-----------------------------------------------------
            Console.WriteLine(Summ(new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(Summ()); // можно ничего не отправлять
            //-------------------------------------------------------
            //----------- Кортежи -----------------------------------
            //-------------------------------------------------------
            // Так можно вернуть до 8-ми параметров (кортеж)
            dynamic t = ReturnParams(3);
            Console.WriteLine(t.Item1);
            Console.WriteLine(t.Item2);
            Console.WriteLine(t.Item3);

            // создание кортежей с версии C# 7.1 (может понадобиться System.ValueTuple)
            (string, int, string) values_typle1 = ("a", 5, "c");
            var values_typle2 = ("a", 5, "c");
            (string FirstLetter, int TheNumber, string SecondLetter) valuesWithNames = ("a", 5, "c");
            var valuesWithNames2 = (FirstLetter: "a", TheNumber: 5, SecondLetter: "c");

            var samples = FillTheseValues();
            Console.WriteLine($"Int is: {samples.a}");
            Console.WriteLine($"Stnng is: {samples.b}");
            Console.WriteLine($"Boolean is: {samples.с}");
        }
        //---------------------------------------------------------------------
        // Параметр ref
        //---------------------------------------------------------------------
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        // а здесь мы возвращаем ссылку на элемент массива!  C# 7.0
        public static ref string SimpleRefReturn(string[] strArray, int position)
        {
            return ref strArray[position];
        }
        //---------------------------------------------------------------------
        // Параметр out
        //---------------------------------------------------------------------
        static void SampleOut(out int k)
        {
            k = 5;
            k = k * k;
            Console.WriteLine($"k = {k}");
        }
        //---------------------------------------------------------------------
        // Метод с именованными и необязательными параметрами
        //---------------------------------------------------------------------
        static void Search(string name, int age = 21, string city = "Pueblo")
        {
            Console.WriteLine("Name = {0} - Age = {1} - City = {2}", name, age, city);
        }
        //---------------------------------------------------------------------
        // метод с переменным числом параметров
        // В объявлении метода ПОСЛЕ ключевого слова params дополнительные параметры не допускаются, 
        // и в объявлении метода допускается только одно ключевое слово params.
        //---------------------------------------------------------------------
        static int Summ(params int[] val)
        {
            int summ = 0;
            if (val != null)
            {
                for (int i = 0; i < val.Length; i++)
                {
                    summ += val[i];
                }
            }
            return summ;
        }
        //---------------------------------------------------------------------
        // Кортеж — это структура данных, которая содержит определенное число и 
        // последовательность элементов (до 8).
        //---------------------------------------------------------------------
        static dynamic ReturnParams(int v)
        {
            // до 8 обьектов различных типов
            dynamic var = Tuple.Create(v * v, Math.Pow(v, 3), Math.Pow(v, 4));
            return var;
        }

        // или так - возвращаем три значения
        static (int a, string b, bool с) FillTheseValues()
        { return (9, "Enjoy your string.", true); }

        //---------------------------------------------------------------------
        // В С# 7.0 можно внутри методов создавать новые методы
        //---------------------------------------------------------------------
        static int MethodInMethod(int a, int b)
        {
            int Add(int x, int y)
            {
                return x + y;
            }

            return Add(a, b);
        }
        //---------------------------------------------------------------------
        // методы могут быть анонимными. Они используются в связке с делегатами
        //---------------------------------------------------------------------
        delegate int Transformer(int i);

        Transformer tr1 = delegate (int x) { return x * x; };
        Transformer tr2 = (int x) => { return x * x; };
        Transformer tr3 = x => x * x;
        //---------------------------------------------------------------------
        // методы с обобщенными параметрами
        //---------------------------------------------------------------------

        //---------------------------------------------------------------------
        // расширяющие методы
        //---------------------------------------------------------------------
    }
}
