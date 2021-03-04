using System;


namespace ISample
{
    using S4;
   
    // �� ���� ����� - �����������, �����, �������� ����
    // ��������� �� �������� � ������������. ���������� ������
    // ��� ���������� ��������.
    class Sample4
    {
        public static void Demo()
        {
            Triangle tr = new Triangle("�����������");
            Line ln = new Line("�����");
            Sign sg = new Sign("����");

            Console.WriteLine(new string('-', 30));

            // ���� ��������� ����� ������������� ������� ����������
            // ������ �������. ��� ��������� ���������� � ���� ����������.
            IPoints[] PointsOb = { tr, ln, sg };

            for (int i = 0; i < PointsOb.Length; i++)
            {
                Console.WriteLine("������ {0} ����� {1} ������", ((Shape)PointsOb[i]).name,
                    PointsOb[i].NumPoints());
            }

            Console.WriteLine(new string('-', 30));
            // �������, ��� ����� �������� � ������������:
            // (�������, ��� ����� ����������� ����������)
            Shape[] s = { tr, ln, sg };

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] is IDraw3D) // ���������, ���������� �� ��������� � ������ ������
                Console.WriteLine("������ {0} - �����", s[i].name);
                else
                Console.WriteLine("������ {0} - �� �����", s[i].name);
            } 
        }
    }
    namespace S4
    {
        // ����� ����� � ������
        interface IPoints
        { int NumPoints(); }
        // ��������� �� ���������
        interface IDraw
        { void Draw();}
        // ��������� � ������������
        interface IDraw3D
        { void Draw3D();    }
        public class Shape
        {
            public string name;
            public Shape()
            { }
            public Shape(string n)
            {
                name = n;
            }
        }
        public class Triangle : Shape, IDraw, IPoints, IDraw3D
        {
            public Triangle(string val)
                : base(val)
            { }

            public void Draw()
            {
                Console.WriteLine("�������� ����������� �� ���������.");
            }
            public int NumPoints()
            {
                return 3;
            }
            public void Draw3D()
            {
                Console.WriteLine("�������� ����������� � ������������.");
            }
        }
        public class Line : Shape, IPoints, IDraw, IDraw3D
        {
            public Line(string val)
                : base(val)
            { }

            public void Draw()
            {
                Console.WriteLine("�������� ����� �� ���������.");
            }
            public int NumPoints()
            {
                return 2;
            }
            public void Draw3D()
            {
                Console.WriteLine("�������� ����� � ������������.");
            }
        }
        public class Sign : Shape, IPoints, IDraw
        {
            public Sign(string val)
                : base(val)
            { }

            public int NumPoints()
            {
                return 1;
            }
            public void Draw()
            {
                Console.WriteLine("�������� �������� ���� �� ���������.");
            }
        }
    }
}

//------------------------------
// ������ ����������� ����� 3 ������
// ������ ����� ����� 2 ������
// ������ ���� ����� 1 ������
// ------------------------------
// ������ ����������� - �����
// ������ ����� - �����
// ������ ���� - �� �����