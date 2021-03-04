using System;

// ��� ����� ������� � ���������� ������������ �������� �����.
namespace TypeBase
{
    partial class Sample
    {
        public static void CastBase()
        {
            // ��-������, ���������� ��������� ����� � ������� ����������
            // ����� ������������� ������
            int i = 10;
            long l = i;        // <- ������� ����������
            float f = l;       // <- ������� ����������
            byte b = (byte)i;  // <- ����� ����������
            int v = (int)f;
            // ���������: ���������� float � int  ������ ����������� 
            // ����� ���������� �� �������.
            // � C# ������� ����� ������ ������������� (5.3->5 , 5.9->5)

            // ��-������, � ������������ ����� ��������� ����������� ����� ������:
            Console.WriteLine(123.ToString() + 456.ToString());  // "123465"

            // �-�������, ���������, ��������� �� ��������� ����������� �� �����
            // ���������, ��� �������� ������ ����������.
            Console.WriteLine("45 +" + " 45 = " + (45 + 45));

            // �-���������, ���������� ����� ��������� (+,=,*,...) � ������� �� ����������
            Console.WriteLine("2 + 2 * 2 = {0}", 2 + 2 * 2); // =6
        }
    }
}