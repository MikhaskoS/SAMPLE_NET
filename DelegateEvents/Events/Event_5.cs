using System;

namespace EventsSmple
{
    // ������������� ������ EventArgs
    delegate void MyEventHandler5(object sourse, MyEventArgs5 arg);//////

    class Sample5
    {
        static void handler(object sourse, MyEventArgs5 arg)  ///////////
        {
            Console.WriteLine("������� ���������!");
            Console.WriteLine("����� �������: " + arg.numEvent);
            Console.WriteLine("������� �� ������: " + sourse);
        }
        
        public static void Demo()
        {
            MyEvents5 evt = new MyEvents5();
            evt.SomeEvent +=new MyEventHandler5(handler);

            // ����� ���
            //evt.SomeEvent += (s, a) => handler(s, a);

            // ��� ������ ��� ��� (������� handler �� �����)
            //evt.SomeEvent += (s, a) => 
            //{
            //    Console.WriteLine("������� ���������!");
            //    Console.WriteLine("����� �������: " + a.numEvent);
            //    Console.WriteLine("������� �� ������: " + s);
            //};

            // �������
            evt.OnSomeEvent();
            evt.OnSomeEvent();
            evt.OnSomeEvent();
            evt.OnSomeEvent();
            evt.OnSomeEvent();
            evt.OnSomeEvent();
        }
    }

    // ������ ���������� ������� ����� ����� ����������. 
    // � ������, �� ����� ���������� ������������ �������.
    class MyEventArgs5 : EventArgs  //////////////////////////////////////
    {
        public int numEvent; // ������� �������
    }

    class MyEvents5
    {
        public event MyEventHandler5 SomeEvent;
        static int count = 0;
        public void OnSomeEvent()
        {
            MyEventArgs5 arg = new MyEventArgs5();  /////////////////////////
            if (SomeEvent != null)
            {
                arg.numEvent = count++;//�������� �������� �� ������� ����������!
                SomeEvent(this, arg);  ///////////////////////////////////  
            }
        }
    }


    

  

    
}