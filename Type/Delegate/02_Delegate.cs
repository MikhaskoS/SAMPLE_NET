/* -----------------------------------------------------------
 * ћножественна€ адресаци€.
 * ћожно создавать целую цепочку методов, и подключать их
 * обычными алгебраическими выражени€ми.
 * √лавное, что нужно помнить, это то, что групповой делегат 
 * должен иметь тип возвращаемого значени€ - void.
 * -----------------------------------------------------------*/

using System;

namespace Delegate
{
    class Sample2
    {
        // возвращаемое значение - void, поэтому теперь
        // потребуютс€ параметры - ссылки
        delegate void strMod(ref string str);

        public static void Demo()
        {
            strMod strOp;
            strMod strOp1 = new strMod(replaceSpaces);
            strMod strOp2 = new strMod(reverse);

            string str = "Ёто простой текст.";
            strOp = strOp1;
            strOp += strOp2;

            strOp(ref str);
            Console.WriteLine(str);
        }
        // void!
        static void replaceSpaces(ref string a)
        {
            Console.WriteLine("-> «амена пробелов дефисами.");
            a = a.Replace(' ', '-');
        }
        // void!
        static void removeSpaces(ref string a)
        {
            string temp = "";
            int i;

            Console.WriteLine("-> ”даление пробелов.");
            for (i = 0; i < a.Length; i++)
                if (a[i] != ' ') temp += a[i];

            a = temp;
        }

        static void reverse(ref string a)
        {
            string temp = "";
            int i, j;

            Console.WriteLine("-> –еверсирование строки.");
            for (j = 0, i = a.Length - 1; i >= 0; i--, j++)
                temp += a[i];

            a = temp;
        }
    }
}


