/* --------------------------------------------------------
 * ����� �����������, ��� �����, ������������ ��������
 * ������ ����� ������������ ��� � ��������� ��� � ��������.
 * ������, ��� ������� ����������� � ����� ������ - � ������,
 * � ������ ������������ ������, ����� ����������� �
 * ������������ ��������� ����� ������� �������
 * --------------------------------------------------------*/
using System;

namespace Delegate
{

    class X
    {
        public int val;
    }
    class Y : X
    { }

    class Sample3
    {
        // ������� ��������� ������ Y � ���������� X
        delegate X Incr(Y obj);

        public static void Demo()
        {
            X x = new X();
            Y y = new Y();
            Console.WriteLine("Xob= {0} Yob= {1}", x.val, y.val);

            // ������ Y ������ ��������� �
            // (������������������)
            Incr delegIncr = IncrX;
            x = delegIncr(y);

            // ������ ������������� � ���������� Y
            // (��������������)
            delegIncr = IncrY;
            y = (Y)delegIncr(y);
            Console.WriteLine("Xob= {0} Yob= {1}", x.val, y.val);

        }

        static X IncrX(X obj)
        {
            X temp = new X();
            temp.val = obj.val + 1;
            return temp;
        }
        static Y IncrY(Y obj)
        {
            Y temp = new Y();
            temp.val = obj.val + 1;
            return temp;
        }
    }
}
//----------------------------------------------
//Xob= 0 Yob= 0
//Xob= 1 Yob= 1
//----------------------------------------------