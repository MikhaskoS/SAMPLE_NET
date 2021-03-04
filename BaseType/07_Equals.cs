using System;
// System.Object - ������� ����� ��� ���� ������� .NET Framework
// ���� ��������� �������� ��������� ��������
// public static bool ReferenceEquals(object objA, object objB) - ���������� ��� ������. 
//    ���� ���������� �������� ���� ����� false,
//    �.�. ������������ ��������� ��� ��������� � ��������� ��� � ����� ����� ������ ������
//
// public static bool Equals(object objA, object objB)  
//    ������� ���� ����� ��������� ���������� �� ��������� � ���� ������� �� ������������, �� ��������� �� �� null 
//    � ���������� ��������������� �� ���������� ����������������� ������������� ������ Equals.
//
// public virtual bool Equals(object obj)
//    �� ���������, ���� ����� ���� ���� ����� ����� ��� ReferenceEquals. ������ ��� �������� 
//    ����� �� ������������
//
//public static bool operator == (Foo left, Foo right)
//    ��� �������� ����� ������ ������� ��������������, ��� � ����������� Equals(). 
//    ��� ��������� ����� ����� �� ��������������, ���, �� ���������, �� == �� ��������� ����� 
//    ��������� ��������� ��� � ������ ReferenceEquals().

// ������ ����� Equals().
// ���� ����� ���������� ������� �� ��������� �� ����� � ������,
// � �� �� �������� �����. � ������� �����������, ��, ��� �������,
// ��������� ������������� (��������, � System.ValueType)

namespace TypeBase
{
    class Sample7
    {
        double X;

        public static void Demo()
        {
            V1.Vector2D a1 = new V1.Vector2D(1.0f, 2.0f);
            V1.Vector2D a2 = new V1.Vector2D(1.0f, 2.0f);
            V1.Vector2D a3 = new V1.Vector2D(10.0f, 20.0f);

            // �������� ���������� �������
            Console.WriteLine(a1.Equals(a2)); // False (���� v1 = v2)
            Console.WriteLine(a1.Equals(a3)); // False
            Console.WriteLine(a1 == a2); // False
            Console.WriteLine(a1 == a3); // False
            // ���, � ���������, � ��� �������
            Console.WriteLine(a1.GetHashCode()); // 58225482
            Console.WriteLine(a2.GetHashCode()); // 54267293

            // ������ ������� ��������� �� ���� � ���
            // �� ������ � ������
            a3 = a1;
            Console.WriteLine(a3.Equals(a1)); // True
            // � ���, ��� ��� ������:
            Console.WriteLine(a3.X + "--" + a1.X); // 1--1
            a3.X = 5.0f;
            Console.WriteLine(a3.X + "--" + a1.X); // 5--5
            a1.X = 15.0f;
            Console.WriteLine(a3.X + "--" + a1.X); // 15--15

            // ��� ���������
            string s1 = "Hello, World!";
            string s2 = "Hello, World!";
            Console.WriteLine(s1.Equals(s2)); // True 

            //-----------------------------------------------
            // � V2 Equals ��������� �������������
            //-----------------------------------------------
            V2.Vector2D v1 = new V2.Vector2D(1.0f, 2.0f);
            V2.Vector2D v2 = new V2.Vector2D(1.0f, 2.0f);
            V2.Vector2D v3 = new V2.Vector2D(10.0f, 20.0f);
            Console.WriteLine(v1.ToString());
            Console.WriteLine(v2.ToString());
            Console.WriteLine(v3.ToString());

            // �������� ���������� �������
            Console.WriteLine(v1.Equals(v2)); // True (v1 = v2)!!!
            Console.WriteLine(v1.Equals(v3)); // False
            // �������� == ����� ����� ��������������!!!
            Console.WriteLine("v1 == v2 : {0}", v1 == v2); // True
            Console.WriteLine("v1 == v3 : {0}", v1 == v3); // False
            // ������ ����� ���������� ��������
            Console.WriteLine(v1.GetHashCode()); // 
            Console.WriteLine(v2.GetHashCode()); // 

            //-----------------------------------------------
            //-----------------------------------------------
            // � ������� Equals() ������� ���� �����������
            var a = new { _id = 0.0 };
            var b = new { _id = -0.0 };
            Console.WriteLine("a.Equals(b) = {0}", a.Equals(b)); // true
            Console.WriteLine("a._id.Equals(b._id) = {0}", a._id.Equals(b._id)); // true

            
            var A = new Sample7 { X = 0.0 };
            var B = new Sample7 { X = -0.0 };
            Console.WriteLine(A.GetType().IsValueType); // false (�.�. ��� ��������� ���)
            Console.WriteLine("A.Equals(B) = {0}", A.Equals(B)); // false !!! � �����-��������� ����� �����
            Console.WriteLine("A.X.Equals(B.X) = {0}", A.X.Equals(B.X)); // true
            //-----------------------------------------------
            //-----------------------------------------------
        }
    }

    namespace V1
    {
        class Vector2D
        {
            public float X;
            public float Y;
            public Vector2D(float x, float y)
            {
                X = x;
                Y = y;
            }
        }
    }

    namespace V2
    {
        // � ���� ������ ���������� ���������� ���������������
        // ��������� ��������
        class Vector2D
        {
            public static double epsilon = 0.0000001;

            public float X;
            public float Y;
            public Vector2D(float x, float y)
            {
                X = x;
                Y = y;
            }
            public override bool Equals(object obj)
            {
                if (obj != null && obj is Vector2D)
                {
                    Vector2D temp = (Vector2D)obj;
                    if (this.X == temp.X && this.Y == temp.Y)
                        return true;
                    else
                        return false;
                }
                return false;
            }
            public static bool operator ==(Vector2D left, Vector2D right)
            {
                if (System.Math.Abs(left.X - right.X) <= epsilon &&
                    System.Math.Abs(left.Y - right.Y) <= epsilon)
                    return true;
                else return false;
            }
            public static bool operator !=(Vector2D left, Vector2D right)
            {
                if (left == right)
                    return false;
                return true;
            }
            public override int GetHashCode()
            {
                // ��� ��� ��������� �����, ���
                // � ������� ������ (����, ��� �����
                // ���������� ���, ����� �� ��� ��������
                // � ������ ��������. ��������, �������������
                // ToString() � ���� ToString().GetHashCode())
                return ToString().GetHashCode();
            }
            public override string ToString()
            {
                string _s = "(V1, V2) = (" + X + ",\t" + Y + ")";
                return _s;
            }
        }
    }
}
