using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSample
{
    class Select
    {
        static string[] presidents = {
                "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland",
                "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
                "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
                "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley",
                "Monroe", "Nixon", "Pierce", "Polk", "Reagan", "Roosevelt", "Taft",
                "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

        public static void Demo1()
        {
            // Select -------------------------------------------------------------
            // Вывести длины слов
            //IEnumerable<int> nameLengths = presidents.Select(p => p.Length);
            //nameLengths.WriteLine();
            /*
            5
            6
            8
            4
            6
            ...
            */

            // Select -------------------------------------------------------------
            //var nameObjs0 = presidents.Select(p => new { p, p.Length });
            //nameObjs0.WriteLine();
            /*
             { p = Adams, Length = 5 }
             { p = Arthur, Length = 6 }
             { p = Buchanan, Length = 8 }
             ...
             */

            // Select -------------------------------------------------------------
            //var nameObjs1 = presidents.Select(p => new { LastName = p, Length = p.Length });
            //foreach (var item in nameObjs1)
            //    Console.WriteLine("{0} is {1} characters long.", item.LastName, item.Length);
            /*
             Adams is 5 characters long.
             Arthur is 6 characters long.
             Buchanan is 8 characters long.
             Bush is 4 characters long.
            ...
             */
              
            // Select -------------------------------------------------------------
            //var nameObjs4 = presidents.Select((p, i) => new { Index = i, LastName = p });
            //foreach (var item in nameObjs4)
            //    Console.WriteLine("{0}.  {1}", item.Index + 1, item.LastName);
            /*
             1.  Adams
             2.  Arthur
             3.  Buchanan
             4.  Bush
            ...
             */

            //---------------------------------------------------------------------
           
        }
    }
}
