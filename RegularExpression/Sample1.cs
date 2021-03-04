using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RegularExpr
{
    // Применение регулярных выражений
    class Sample1
    {
        static string test =
            "@На одиннадцатый день рождения Гарри узнаёт, что является волшебником и ему" +
            " уготовано место в школе волшебства «Хогвартс», в которой он будет практиковать " +
            "магию под руководством директора Альбуса Дамблдора и других школьных " +
            "профессоров. Также Гарри обнаруживает, что он уже известен во всём " +
            "магическом сообществе романа, и что его судьба связана с судьбой Волан-де-Морта, " +
            "опасного тёмного мага, убившего среди прочих и его родителей — Лили и Джеймса Поттер.";


        public static void Demo()
        {
            //----------------------------------------------------
            // Поиск вхождения
            //----------------------------------------------------
            Match m1 = Regex.Match(test, @"Гарри");

            Console.WriteLine(m1.Success);
            Console.WriteLine(m1.Index);
            Console.WriteLine(m1.Length);
            Console.WriteLine(m1.Value);
            Console.WriteLine(m1.ToString());

            Console.WriteLine(new String('+', 50));
            //----------------------------------------------------
            // следующее совпадение
            //----------------------------------------------------
            Match m2 = m1.NextMatch();
            Console.WriteLine(m2);

            Console.WriteLine(new String('+', 50));

            //----------------------------------------------------
            // все совпадения
            //----------------------------------------------------
            foreach (Match _m in Regex.Matches(test, "он"))
            {
                Console.WriteLine(_m);
            }

            Console.WriteLine(new String('+', 50));
            //----------------------------------------------------
            // Проверка на совпадение 
            //----------------------------------------------------
            string login = "";
            
            Regex pat = new Regex(@"^[^0-9]\w{1,9}$");  // соответствие слову
            Console.WriteLine( pat.IsMatch(login));     // true/false
            //----------------------------------------------------
            // Перечисление флагов
            //----------------------------------------------------
            foreach (Match _m in Regex.Matches(test, "гарри", RegexOptions.IgnoreCase))
            {
                Console.WriteLine(_m);
            }

            Console.WriteLine(new String('+', 50));
            //----------------------------------------------------
            // Компиляция регулярного выражения
            //----------------------------------------------------
            Regex pattern = new Regex(@"что");
            Console.WriteLine(pattern.Match(test));

            Console.WriteLine(new String('+', 50));
            //----------------------------------------------------
            // Замена вхождений
            //----------------------------------------------------
            string test2 = @"Наш кот - настоящая скотина";

            string str = Regex.Replace(test2, @"кот", "КОТ");
            Console.WriteLine(str);                // Наш КОТ - настоящая сКОТина

            Console.WriteLine(new String('+', 50));
            //----------------------------------------------------
            // Разбиение строки (намного мощнее String.Split)
            //----------------------------------------------------
            string test3 = @"a1s8d5f6";

            string[] str3 = Regex.Split(test3, @"\d");
            foreach (string s in str3)
                Console.Write(s + " ");                     // a s d f

            Console.WriteLine("\n");
            Console.WriteLine(new String('+', 50));
            //----------------------------------------------------
            // После каждого нахождения совадения вызывается делегат MatchEvaluator
            // этим можно эффективно пользоваться
            //----------------------------------------------------
            MatchEvaluator myEvaluator = new MatchEvaluator(myAction);

            // Замена вхождений
            string test4 = @"Наш кот - настоящая скотина";

            string str4 = Regex.Replace(test4, @"кот", myEvaluator);
            Console.WriteLine(str4);                // Наш *кот* - настоящая с*кот*ина
        }

        public static string myAction(Match m)
        {
            Console.Beep();                  // бибикнем
            return "*" + m.Value + "*";      // произведем замену
        }
    }
}
