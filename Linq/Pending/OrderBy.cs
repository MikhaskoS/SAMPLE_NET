using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSample
{
    class OrderBy
    {
        public static void Demo()
        {
            string[] presidents = {
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland",
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley",
        "Monroe", "Nixon", "Pierce", "Polk", "Reagan", "Roosevelt", "Taft",
        "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

            IEnumerable<string> items = presidents.OrderBy(s => s.Length);

            //foreach (string item in items)
            //    Console.WriteLine(item);
            /*
            Bush
            Ford
            Polk
            Taft
            Adams
            Grant
            ...
             */
        }
    }
}
