/* -------------------------------------------------------------
 * ��������� �������.
 * 
 * ��� - ����� ���� ����������� ����������������� �����������
 * ������ � ���� ��������. �����, ������������ �������� �������
 * ���������� ����� ���������.
 * -------------------------------------------------------------*/

using System;
namespace Delegate
{
    class Sample5
    {
        delegate string strMod(string str);
        
        static void Demo()
        {
            strMod strOp = delegate(string a)
            {
                string temp = "";
                int i, j;

                Console.WriteLine("-> �������������� ������.");
                for (j = 0, i = a.Length - 1; i >= 0; i--, j++)
                    temp += a[i];

                return temp;
            };  // �������� �������� �� ����� � �������!

            string str = strOp("��� ������� �����.");
            Console.WriteLine(str);
        }
    }
}
//-----------------------------------------------------------
// ��������� ����� �� ����� �������� ������ � ���������� ref
// � out ������������� ������.
//-----------------------------------------------------------