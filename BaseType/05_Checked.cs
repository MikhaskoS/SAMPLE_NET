using System;

/*
 * checked - ����� �������� �� �������������
 * unchecked - �� ����� (��-���������).
 * MS Visual Studio -> 
 */
namespace TypeBase
{
    class Sample5
    {
        public static void Demo()
        {
            // ������������������ � ������������ ����� byte [0, 255]
            byte b = 255;

            b = (byte)(b + 2);    // ��-���������, ���������� ����������� b+2 � int
            Console.WriteLine("(byte)(255 + 2) = " + b); // = 1

            // ������ �������� ��-�������
            b = 255;
            try
            {
                b = checked((byte)(b + 2)); // �������� �� ������������
                Console.WriteLine(b);
            }
            catch (OverflowException)
            {
                Console.WriteLine("������ ������������!");
            }

            // ���������� ����� ��������� � ����:
            try
            {
                b = 255;
                checked
                {
                    b = ((byte)(b + 2)); // �������� �� ������������
                    Console.WriteLine(b);
                }
            }
            catch
            {
                Console.WriteLine("������ ������������!");
            }

        }
    }
}