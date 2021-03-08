/* -----------------------------------------------------------
 * ������������� ���������.
 * ����� ��������� ����� ������� �������, � ���������� ��
 * �������� ��������������� �����������.
 * �������, ��� ����� �������, ��� ��, ��� ��������� ������� 
 * ������ ����� ��� ������������� �������� - void.
 * -----------------------------------------------------------*/

using System;

namespace Delegate
{
    class Sample2
    {
        // ������������ �������� - void, ������� ������
        // ����������� ��������� - ������
        delegate void strMod(ref string str);

        public static void Demo()
        {
            strMod strOp;
            strMod strOp1 = new strMod(replaceSpaces);
            strMod strOp2 = new strMod(reverse);

            string str = "��� ������� �����.";
            strOp = strOp1;
            strOp += strOp2;

            strOp(ref str);
            Console.WriteLine(str);
        }
        // void!
        static void replaceSpaces(ref string a)
        {
            Console.WriteLine("-> ������ �������� ��������.");
            a = a.Replace(' ', '-');
        }
        // void!
        static void removeSpaces(ref string a)
        {
            string temp = "";
            int i;

            Console.WriteLine("-> �������� ��������.");
            for (i = 0; i < a.Length; i++)
                if (a[i] != ' ') temp += a[i];

            a = temp;
        }

        static void reverse(ref string a)
        {
            string temp = "";
            int i, j;

            Console.WriteLine("-> �������������� ������.");
            for (j = 0, i = a.Length - 1; i >= 0; i--, j++)
                temp += a[i];

            a = temp;
        }
    }
}


