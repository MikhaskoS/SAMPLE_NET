using System;
// �������� ����� �� ������������. is � as
// is  - ������ ��������� (true, false), �� � 7,0 ��� ����� �����������
// as  - �������� �������� (null ���� �� ����������)

namespace TypeBase
{
    // ��������� ��������� ����
    internal class A
    {
        public int id;
        public string name;
    }
    internal class B : A
    {
        public int age;
    }

    class Sample04
    {
        public static void Demo()
        {
            // ����� �� ������ ��������� ���� �� ������������
            A a = new A() { id = 0, name = "����"};
            bool b1 = (a is A);   // true
            bool b2 = (a is B);   // false
            Console.WriteLine("b1= {0}, b2 = {1}", b1, b2);

            // � 7.0 ������� ��������� !!!
            if (a is A ob) // ���� a ����� ��� A - ��������� ��� ob
            {
                Console.WriteLine(ob.name);
            }
            // ������������ ���������� ����
            if (a is A _)
            {
                Console.WriteLine("������ ���-��...");
            }
            
            
            //---------------------------------------------------------
            // ����� �� �� ��������� ���������� �����, ����
            // ��� ��������. �������� ���������� � ����� ��������!!!


            B m = new B();
            a = m as A;    // ���������� ������ �����������
            if (a != null)
            {
                Console.WriteLine("�������� ���������� ������� ���������");
            }
            else
            {
                Console.WriteLine("���������� ����� ����������");
            }

            // as - �������� ����������
            m = a as B;    // ���������� ������ �����������
            if (m != null)
            {
                Console.WriteLine("�������� ���������� ������� ���������");
            }
            else
            {
                Console.WriteLine("���������� ����� ����������");
            }

        }
    }
}