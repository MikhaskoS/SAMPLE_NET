using System;

namespace Delegate
{
    class Sample1
    {
        delegate string strMod(string str); // делегат ()

        public static void Demo()
        {
            strMod strOp = replaceSpaces;
            // или так:
            // strMod strOp = new strMod(replaceSpaces);
            string str = strOp("Ёто простой текст.");
            Console.WriteLine(str);

            // логичнее, однако, использовать делегат так.  од становитс€
            // смотрибельнее.
            str = editString("Hello delegat!", removeSpaces);
            Console.WriteLine(str);
        }

        static string editString(string str, strMod strDeledat)
        {
            string res = strDeledat(str);
            return res;
        }

        //-------------------------------------------------------
        static string replaceSpaces(string a)
        {
            Console.WriteLine("-> «амена пробелов горизонтальной чертой.");
            return a.Replace(' ', '-');
        }
        static string removeSpaces(string a)
        {
            string temp = "";
            int i;

            Console.WriteLine("-> ”даление пробелов.");
            for (i = 0; i < a.Length; i++)
                if (a[i] != ' ') temp += a[i];

            return temp;
        }
        static string reverse(string a)
        {
            string temp = "";
            int i, j;

            Console.WriteLine("-> –еверсирование строки.");
            for (j = 0, i = a.Length - 1; i >= 0; i--, j++)
                temp += a[i];

            return temp;
        }
        //-------------------------------------------------------
    }
}



