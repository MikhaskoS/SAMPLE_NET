using System;
using System.Threading;  

namespace ThreadSample
{
    class Sample4
    {
        // в параметризованый делегат вставляется функция
        // принимающая параметр типа object
        static void SimpleWork(object obj)
        {
            string str = (string)obj;
            Console.WriteLine(str);
        }

        static void Print(string message, int count, int timeout)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(message);
                Thread.Sleep(timeout);
            }
        }

        public static void ParameterizedThreadSample()
        {
            // для того, чтобы передать потоку параметр,
            // используется такой делегат:
            //ParameterizedThreadStart operation =  new ParameterizedThreadStart(SimpleWork);
            //Thread theThread = new Thread(operation);

            // но можно и просто
            Thread theThread = new Thread(SimpleWork);
            theThread.Start("Hello World!");

            var count = 5;
            var msg = "Hello!";
            var timeout = 100;

            //----------------------------------------------------------
            // рекомендуемый способ - без создания переменной потока (см OOP - Class01)
            //----------------------------------------------------------
            new Thread(() => Print(msg, count, timeout)) { IsBackground = true}.Start();
        }
    }
}
