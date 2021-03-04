using System;

// �������� ������������ �������� null ������������
// ��������� ��� ������, �������, ��� ��������, ���������
// � ����� �������� �������� NULL ��� ����������� ��
// ���� �������� �������.

namespace TypeBase
{
    class Sample6
    {
        public static void Demo()
        {
            // ������ ��� int ������ ����� ��������
            // ����� ��������� �������� null. ���� ��
            // ������������ ?, �������� �� �����������
            // ����������� ��������.
            int? b = null;
            Console.WriteLine("b = " + b);

            // var �������� �������� b. �� ���� ��� = null ��
            // ���������� �������������� ��������. ?? - �������� null �����������
            int v = b ?? 100;
            Console.WriteLine("v = " + v);

            // ��� ����� ���������, ���� �� ��������� ��������
            // ���������� b. ��� ���� ���� ����� ������������
            // �������� HasValue � Value
            if (b.HasValue)
                Console.WriteLine(b.Value);
            else
                Console.WriteLine("�������� �� ���������!");

            // ����� ���������� � ���
            Nullable<int> test1 = 5;
            Nullable<double> test2 = 3.14;
            Nullable<bool> isEnable = null;


            // ������������ ����� ��������� (v > 6.0)

        }

        private static string GetCityInPast (Pers person) 
        {
            // �� C# 6.0  
            string city = String.Empty;
            
            //city = person?.Adress?.City;
            if (person !=  null ) 
            {
                //city = person.Adress?.City; <-- ��������� ��� null
                if (person.Adress != null )
                {
                    city = person.Adress.City;
                }
            } 
            return city;
        }

        private static string GetCityInPresent (Pers person)
        {
            // ? ��������� ��� �� null 
            // ?? ���� null ������ Empty ���� ��� ������ �������� 
            
            return person?.Adress?.City ?? "" ;  // ������� � C# 6.0  
        } 
    }

    class Pers { public Adress Adress; }
    class Adress { public string City; }
}
//-----------------------------------------------
//b =
//v = 100
//�������� �� ���������!
//��� ����������� ������� ����� ������� . . .
//-----------------------------------------------