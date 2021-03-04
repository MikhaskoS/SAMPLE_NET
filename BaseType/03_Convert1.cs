using System;
using System.Globalization;

namespace TypeBase
{
    // �������������� �����
    // �������������� ����� ������ ���� ����� - ����� � �������.
    // ������� �������������� ��������, �����:
    // - ������������� ������������ ���� ��� ������ �������� (int -> float)
    // - ������ ������������� � ������� ��� (�.�. � ���, �� �������� ���������
    // ������������)
    class Sample3
    {
        public static void Demo()
        {
            //------------------------------
            int iA = 10;
            float fA = iA;  // ������� ��������������
            //------------------------------

            //��� ����� � ����������� IConvertable
            float fB = 10.86f;
            int iB0 = (int)fB; // = 10  �����, � ������� ��������
            int iB1 = System.Convert.ToInt32(fB); // = 11 (!!!!!!) - ���������� 

            Console.WriteLine($"a={fB}:\n(int)a = {iB0} \nConvert.ToInt32(a) = {iB1}");
            //------------------------------

            int iC = 20;
            //string sC = (string)iC; // ������
            string sC = iC.ToString(); // �����

            string sD0 = "0,005"; // ���. �������� �� �������
            string sD1 = "0.005";
            try
            {
                float fD1 = float.Parse(sD1);// �� ���������
            }
            catch (FormatException)
            { Console.WriteLine("������ �� ��������������."); }
            float fD = float.Parse(sD0); // ���������
            //------------------------------

            string sE0 = "1,456";
            string sE1 = "1.456";
  
            float.TryParse(sE0, out float fE0);  // = true
            float.TryParse(sE1, out float fE1);  // = false
            //------------------------------

            // � ������ ����� ����� �������: (���� �� ����� �������)
            Object o = new Object();   
            Console.WriteLine(o.GetType()); // System.Object

            A a = new A();
            B b = new B();
            Console.WriteLine(a.GetType()); // A
            Console.WriteLine(b.GetType()); // B

            Object o1 = new A();
            Object o2 = new B();
            Console.WriteLine(o1.GetType()); // A ! �� ��� ��� Object  � ������ �� A
            Console.WriteLine(o2.GetType()); // B ! �� ��� ��� Object  � ������ �� B

            Object o3 = o2;
            Console.WriteLine(o3.GetType()); // B

            A a1 = new B();
            Console.WriteLine(a1.GetType()); // B  ! ��� A � ������ �� B
            // B b1 = new A();   <-  ���

            // B b2 = a1;     // ������ �� ����� ����������
            B b2 = (B)a1;     // a1 ����� ��� B, �� ����� ������� ����, �.�. ��� ����������� ��� ��� A
            Console.WriteLine(b2.GetType()); // B
            B b3 = b2;
            Console.WriteLine(b3.GetType()); // B

            //B b4 = (B)a;  // <- ������ �� ����� ����������
            A a3 = b3; // ������� ��������������
            Console.WriteLine(a3.GetType()); // B

            Console.ReadLine();
        }

        // �������, ��� ��� ���� - ����������� �� System.Object
        class A
        {
        }
        class B : A
        {
        }
    }
}

