using System;
using System.Threading;


namespace HelloWorld
{
    public partial class SampleProgram
    {
        public static void SampleReadKey()
        {
            Console.WriteLine("Press any combination of CTL, ALT, and SHIFT, and a console key.");
            Console.WriteLine("Press the Escape (Esc) key to quit: \n");

            Console.TreatControlCAsInput = true;

            // Отображение нажатых клавиш
            ConsoleKeyInfo cki;
            do
            {
                // доступно ли нажатие клавиш во входном потоке
                while (Console.KeyAvailable == false)
                    Thread.Sleep(250); 

                cki = Console.ReadKey();  // Console.ReadKey(true) - не отображать нажатый символ
                Console.Write(" --- You pressed ");
                if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
                if ((cki.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
                if ((cki.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTL+");
                Console.WriteLine(cki.Key.ToString());
            }
            while (cki.Key != ConsoleKey.Escape);
        }
    }
}
