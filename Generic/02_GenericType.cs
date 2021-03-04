using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

/* � ���� ������� ��������������� �����������
 * ��������� ���� �������� Generic*/
namespace GenericsDemo
{

    class Sample2
    {
        public static void Demo()
        {
            // ������� ������������ �� ���� �����
            Console.WriteLine("������������ �� 56, 45: ");
            Console.WriteLine(GenericType<int>.Max(56, 45));

            GenericType<double>.TMaxValue();
        }
    }

    //where T : struct - �������� ���� ������ ���� ������������ ����, ����� Nullable.
    //where T : class - �������� ���� ������ ����� ��������� ���; ��� �����
    //   ���������������� �� ��� ������ ������, ����������, �������� ��� �������.
    //where T : <base class name> - �������� ���� ������ �������� ��� ����
    //   ����������� �� ���������� �������� ������
    //where T : U - �������� ����, ������������ ��� T, ������ �������� ��� ����
    //   ����������� �� ���������, ������������� ��� U.��� ���������� �����������
    //   ������������ ����
    //where T : new() - ����������� ���������, ��� �������� ������ ���� � ����������
    //   �������������� ������ ������ ����� �������� ����������� ��� ����������.
    //   ������������ ����������� new ����� ������ � ��� ������, ���� ��� �� ��������
    //   �����������


    // ����� �� ��������, ��� ��� �� ����� ���� ����� (����������� �� ���).
    // � ������, �� ������ ������������ ��������� IComparable,
    // ����� ���� ����� ���� ����������.
    class GenericType<T> where T : IComparable<T>
    {
        // ������������ ��������
        public static T Max(T a, T b)
        {
            // ���� a>b
            if (a.CompareTo(b) > 0) return a;
            else return b;
        }

        // ��� ������������ ���� � ������� ��� ������������
        // ��������
        public static void TMaxValue()
        {
            // ������� �������� ��� ��������.
            Type t = typeof(T);

            Console.WriteLine("-----------------");
            FieldInfo fi = t.GetField("MaxValue");
            // ������� ��������� ������� ������

            Console.WriteLine(fi.GetValue(t));

        }
    }
}

