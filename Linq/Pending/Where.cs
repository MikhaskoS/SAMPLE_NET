using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSample
{
    class Where
    {
        static string[] presidents = {
                "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland",
                "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
                "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
                "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley",
                "Monroe", "Nixon", "Pierce", "Polk", "Reagan", "Roosevelt", "Taft",
                "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

        static int[] numbers = { 0, 4, 7, 4, 8, 0, 7};

        public static void Demo1()
        {

            // Where --------------------------------------------------------------
            // Вывести имена, начинающиеся с буквы "J"
            IEnumerable<string> sequence = presidents.Where(p => p.StartsWith("J"));
            sequence.WriteLine();
            /*
            Jackson
            Jefferson
            Johnson
             */
        }
        public static void Demo2()
        {
            // Where --------------------------------------------------------------
            // Вывести объекты с четными индексами
            IEnumerable<string> sequence = presidents.Where((p, i) => (i & 1) == 1);
            sequence.WriteLine();

            /*
            Arthur
            Bush
            Cleveland
            Coolidge
            Fillmore
            Garfield
            Harding
            Hayes
            Jackson
            Johnson
            Lincoln
            McKinley
            Nixon
            Polk
            Roosevelt
            Taylor
            Tyler
            Washington
            */
        }
    }
}
