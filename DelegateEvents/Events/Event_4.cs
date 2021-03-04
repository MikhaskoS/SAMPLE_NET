using System;

namespace EventsSmple
{
    // ���� �������������� ���������� �� EventArgs �� ������������,
    // ������� ��������������� ���������� ��������� EventHandler.

    class Sample4
    {
        static void handler(object sourse, EventArgs arg)   //!!!!!!!!!!!!!!
        {
            Console.WriteLine("������� ���������!");
        }
        
        public static void Demo()
        {
            MyEvent4 evt = new MyEvent4();
            evt.SomeEvent += new EventHandler(handler);  //!!!!!!!!!!!!!!

            // �������
            evt.OnSomeEvent();
        }
    }

    class MyEvent4
    {
        public event EventHandler SomeEvent;    //!!!!!!!!!!!!!!
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent(this, EventArgs.Empty);
        }
    }
}