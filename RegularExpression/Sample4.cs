using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

//-----------------------------------
// Соответствие позиций. Границы слов. Привязки.
//-----------------------------------
namespace RegularExpr
{
    class Sample4
    {

        static string test1 = "Кот, который ходит мимо лотка  это не кот, это скотина!";
        static string test2 = "";

        //  \b          граница слова
        //  \B          что угодно, только не граница слова
        //   ^          начало строки (в зависимости от контекста - отрицание НЕ) прямо после \n
        //   $          конец строки  (в зависимости от контекста - маркер группы) прямо перед \n
        //  (?m)        включает многострочный режим. Должен писаться в самом начале рег. выражения

        public static void Demo()
        {

            PrintReplase(test1, "[кК]от", "СОБАКА"); // СОБАКА, СОБАКАорый ходит мимо лотка - настоящая сСОБАКАина!
            Console.WriteLine(new String('+', 50));

            PrintReplase(test1, @"\b[кК]от\b", "СОБАКА"); // СОБАКА, который ходит мимо лотка  это не СОБАКА, это скотина!
            Console.WriteLine(new String('+', 50));

            PrintReplase(test1, @"\Bот\B", "ОТ"); 
            Console.WriteLine(new String('+', 50));    // Кот, кОТорый ходит мимо лОТка  это не кот, это скОТина!

            PrintReplase(test1, @"^[Кк]от", "***");
            Console.WriteLine(new String('+', 50));    // ***, который ходит мимо лотка  это не кот, это скотина!
        }

        
        public static void PrintResult(MatchCollection m)
        {
            Console.Write($"\n");
            foreach (Match _m in m)
            {
                Console.Write($"|{_m}|");
            }
        }

        public static void PrintReplase(string text, string find, string replace)
        {
            string str = Regex.Replace(text, find, replace);
            Console.WriteLine(str);
        }
    }
}
