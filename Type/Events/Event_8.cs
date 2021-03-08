using System;

namespace EventsSmple
{
    public class Sample8
    {
        // ������ ��������� ����� ��������� � � ���������
        public static void Demo()
        {
            //��� ����
            //SomeEvent += new MyEventHandler(handler1);
            //������� �����:
            SomeEvent += (n) => Console.WriteLine("���������� �������� : {0}", n);
            // �������
            OnSomeEvent(10);
        }

        //delegate void MyEventHandler(int value); // �������
        //static event MyEventHandler SomeEvent; // �������
        // ��� ��� (������������� ���������� ���������)
        static event Action<int> SomeEvent;



        // �������, ������������ �������
        static void OnSomeEvent(int value)
        {
            if (SomeEvent != null)
                SomeEvent(value);

            // ��� ���
            //SomeEvent.Invoke(value);
        }

        // ����� ��, ��� ������ ��������� � ������ �������
        //static void handler1(int value)
        //{
        //    Console.WriteLine("���������� �������� : {0}", value);
        //}
    }
}
