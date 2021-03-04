using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQSample
{
    class ToArray
    {
        static string[] presidents = {
        "Adams", "Arthur", "Buchanan", "Bush", "Carter", "Cleveland",
        "Clinton", "Coolidge", "Eisenhower", "Fillmore", "Ford",  "Garfield",
        "Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
        "Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley",
        "Monroe", "Nixon", "Pierce", "Polk", "Reagan", "Roosevelt", "Taft",
        "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"};

        public static void Demo()
        {
            //ToArray() - переделать в массив из строк
            string[] names1 = presidents.OfType<string>().ToArray();
            
            names1.WriteLine();
        }
    }
}
