using System;

namespace EventsSmple
{
    public class Sample7
    {
        public static void Demo()
        {
            KeyEvent kevt = new KeyEvent();
            ConsoleKeyInfo key;
            int count = 0;

            kevt.KeyPress += delegate(object sourse, KeyEventArgs arg)
            {
                Console.WriteLine(" - ������ �������: " + "\"" + arg.ch + "\"");
            };
            kevt.KeyPress += delegate(object sourse, KeyEventArgs arg)
            {
                count++;
            };
            do
            {
                key = Console.ReadKey();
                kevt.OnKeyPress(key.KeyChar);
            }
            while (key.KeyChar != '.');
        }
    }

    delegate void KeyHandler(object sourse, KeyEventArgs arg);
    // ������ � �������
    class KeyEventArgs : EventArgs
    {
        public char ch;
    }
    // ���������� �����
    class KeyEvent
    {
        public event KeyHandler KeyPress; // �������
        public void OnKeyPress(char Key)
        {
            KeyEventArgs k = new KeyEventArgs();
            if (KeyPress != null)
            {
                k.ch = Key;
                KeyPress(this, k);
            }
        }
    }
}