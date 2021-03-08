 using System;

namespace EventsSmple
{
    // ���������� ������� � ����� ������.
    // ���������� ������.
    public class Sample1
    {
        delegate void MyEventHandler(); // �������
        static event MyEventHandler SomeEvent; // �������

        public static void EventsSample()
        {

            SomeEvent += new MyEventHandler(handler1);
            SomeEvent += new MyEventHandler(handler2);
            // ���������� �������
            OnSomeEvent();
        }

        // �������, ������������ �������
        static void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent();
            // ��� ��� (? - ���������������� �����)
            //SomeEvent?.Invoke();
        }
        // ����� ��, ��� ������ ��������� � ������ �������
        // ������� ������������� ��������� ��������
        static void handler1()
        {
            Console.WriteLine("������� ���������!");
        }
        static void handler2()
        {
            Console.WriteLine("�����, �����!");
        } 
    }
}