using System;

namespace Delegate
{
    class Sample1
    {
        delegate string strMod(string str); // ������� ()

        public static void Demo()
        {
            strMod strOp = replaceSpaces;
            // ��� ���:
            // strMod strOp = new strMod(replaceSpaces);
            string str = strOp("��� ������� �����.");
            Console.WriteLine(str);

            // ��������, ������, ������������ ������� ���. ��� ����������
            // �������������.
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
            Console.WriteLine("-> ������ �������� �������������� ������.");
            return a.Replace(' ', '-');
        }
        static string removeSpaces(string a)
        {
            string temp = "";
            int i;

            Console.WriteLine("-> �������� ��������.");
            for (i = 0; i < a.Length; i++)
                if (a[i] != ' ') temp += a[i];

            return temp;
        }
        static string reverse(string a)
        {
            string temp = "";
            int i, j;

            Console.WriteLine("-> �������������� ������.");
            for (j = 0, i = a.Length - 1; i >= 0; i--, j++)
                temp += a[i];

            return temp;
        }
        //-------------------------------------------------------
    }
}



