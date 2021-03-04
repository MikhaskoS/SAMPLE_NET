using System;

namespace EventsSmple
{
    // ����� �� ������������� �������� .NET Framework
    // � ������, .NET ����������� ����������� ������� ������
    // ����� ���:
    // void handler (object sourse, EventArgs arg)
    // object sourse - ������ �� ������, ������� ���������� �������
    // EventArgs arg - ������ ����������.
    // (���� �� �� ��������� ������)

    class Sample3
    {
        static void handler(object sourse, EventArgs arg)   //!!!!!!!!!!!!!!
        {
            Console.WriteLine("������� ���������!");
        }
        public static void HandlerSample()
        {
            MyEvent3 evt = new MyEvent3();
            evt.SomeEvent += new MyEventHandler3(handler);

            // ���� �����
            //evt.SomeEvent += (s, a) => Console.WriteLine("������� ���������!");             
            
            // �������
            evt.OnSomeEvent();
        }
    }

    // EventArgs � ��� ������� ����� ��� �������, ���������� ������ ��� �������.
    delegate void MyEventHandler3(object sourse, EventArgs arg);  //!!!!!!!!!!!!!!

    class MyEvent3
    {
        public event MyEventHandler3 SomeEvent;
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent(this, EventArgs.Empty);           //!!!!!!!!!!!!!!
            // ��� ���:
            //SomeEvent?.Invoke(this, EventArgs.Empty);
        }
    }

    
}