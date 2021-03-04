using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RegularExpr
{
    //-----------------------------------
    // Повторения. Квантификаторы.
    //-----------------------------------
    class Sample3
    {
        //  *       ноль или большее число совпадений
        //  +       одно или большее число совпадений
        //  ?       ноль или одно совпадение
        //  {n}     ровно n совпадений
        //  {,n}    по меньшей мере n совпадений
        //  {n,m}   совпадений между n и m
        //
        //  Если квантификатору приписать ? он становится ленивым +?  *? и т.п. 
        //  По умолчанию, они жадные, т.е. пытаются найти все что могут

        public static void Demo()
        {
             string test = "На одиннадцатый mik@yanex.ru день рождения Гарри узнаёт, что является волшебником и ему" +
           " уготовано место в школе волшебства «Хогвартс», в которой он будет практиковать " +
           "магию под руководством директора  opa.mik@mail.ru Альбуса Дамблдора и других школьных " +
           "профессоров. Также .mik@mail.ru Гарри обнаруживает, что он уже известен во всём " +
           "магическом сообществе романа, и что его .mik@mail.bu.ru судьба связана с судьбой Волан-де-Морта, " +
           "опасного тёмного мага, убившего среди прочих и его родителей — Лили и Джеймса Поттер mik@gmail.bu.";

            string test2 = "http://sample.net  https://sample.net http://www.sample.net http://sample.dom.net";

            string test3 = "Использование ленивой версии квантификатора на примере тегов <B>AK</B> и тегов <B>HI</B>";

            Regex pattern = new Regex(@"\w@\w+\.\w+");
            MatchCollection mc = pattern.Matches(test);    // |k@yanex.ru||k@mail.ru||k@mail.ru||k@mail.bu||k@gmail.bu| 
            PrintResult(mc);
            Console.WriteLine(new String('+', 50));

            pattern = new Regex(@"\w+@\w+\.\w+");
            mc = pattern.Matches(test);    // |mik@yanex.ru||mik@mail.ru||mik@mail.ru||mik@mail.bu||mik@gmail.bu|
            PrintResult(mc);
            Console.WriteLine(new String('+', 50));

            // в наборе [\w+.] == [\w+\.]
            pattern = new Regex(@"[\w+.]+@[\w+.]+\.\w+");  
            mc = pattern.Matches(test);    // |mik@yanex.ru||opa.mik@mail.ru||.mik@mail.ru||.mik@mail.bu.ru||mik@gmail.bu|
            PrintResult(mc);
            Console.WriteLine(new String('+', 50));

            pattern = new Regex(@"<[Bb]>.*</[Bb]>");
            mc = pattern.Matches(test3);    //  |<B>AK</B> и тегов <B>HI</B>| т.е. сразу нашли <B>AK</B> и тегов <B>HI
            PrintResult(mc);
            Console.WriteLine(new String('+', 50));

            // добавим "ленивости"
            pattern = new Regex(@"<[Bb]>.*?</[Bb]>");
            mc = pattern.Matches(test3);    //  |<B>AK</B>||<B>HI</B>|
            PrintResult(mc);
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
