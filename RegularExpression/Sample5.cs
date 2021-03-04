using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RegularExpr
{
    //-----------------------------------
    // Группы, подвыражения
    //-----------------------------------
    class Sample5
    {
        static string test = "Такие знаки &nbsp; верстальщики ставят в местах, где недопстим разрыв на строки, например" +
            "Windows&nbsp;&nbsp;2000.";

        //  ()    групировка выражения. Оно будет обрабатываться как один символ.
        //   |    оператор ИЛИ
        //  (?'имя-группы'выражение-группы) или (?<имя-группы>выражение-группы)    назвать группу
        //  \k'имя-группы'   или  \k<имя-группы>                                   сослаться на группу
        public static void Demo()
        {
            Regex pattern = new Regex(@"&nbsp;"); 
            MatchCollection mc = pattern.Matches(test);     //|&nbsp;||&nbsp;||&nbsp;|
            PrintResult(mc);

            // нам нужно только двойное вхождение
            pattern = new Regex(@"(&nbsp;){2,}");
            mc = pattern.Matches(test);                    // |&nbsp;&nbsp;|
            PrintResult(mc);

            string sample = "Телефонные номера США имеют вид: 206-465-1918.";

            pattern = new Regex(@"\d{3}-\d{3}-\d{4}");
            mc = pattern.Matches(sample);
            PrintResult(mc);  // |206-465-1918|

            //----------------------------------------------
            // Групп может быть несколько и их можно извлечь
            //----------------------------------------------
            Match m = Regex.Match(sample, @"(\d{3})-(\d{3}-\d{4})");
            Console.WriteLine("\n" + m);                 //     206-465-1918
            Console.WriteLine("\n" + m.Groups[0]);       //     206-465-1918
            Console.WriteLine("\n" + m.Groups[1]);       //     206
            Console.WriteLine("\n" + m.Groups[2]);       //     465-1918


            //----------------------------------------------
            // на группы можно ссылаться внутри регулярного выражения
            // \1   номер группы в выражении  
            //----------------------------------------------
            string sample1 = "pop deed pope peep";
            pattern = new Regex(@"(\w)ee\1");            //    \1   номер группы в выражении  
            mc = pattern.Matches(sample1);               //     |deed||peep| 
            PrintResult(mc);

            //----------------------------------------------
            // Именованные группы
            //----------------------------------------------

        }

        public static void PrintResult(MatchCollection m)
        {
            Console.Write($"\n");
            foreach (Match _m in m)
            {
                Console.Write($"|{_m}|");
            }
        }
    }
}
