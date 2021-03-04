using System;

// ������� ���������� ����������
namespace ISample
{
    using S1;

    public class Sample1
    {
        public static void Demo()
        {
            Box box = new Box(10, 20);
            Console.WriteLine("�����: " + box.Length());
            Console.WriteLine("������: " + box.Width());
        }
    }

    namespace S1
    {
        // ���������
        interface IDimensions
        {
            float Length();
            float Width();
        }
        class Box : IDimensions
        {
            float lengthInches;
            float widthInches;

            public Box(float length, float width)
            {
                lengthInches = length;
                widthInches = width;
            }
            // ��������� ������ ����������.
            // ���� �� �������� �� ��� public, ��������������� �� ����� !!!
            public float Length()
            {
                return lengthInches;
            }

            public float Width()
            {
                return widthInches;
            }
        }
    }
}