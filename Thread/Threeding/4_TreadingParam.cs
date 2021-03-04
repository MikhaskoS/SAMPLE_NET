using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;  // <--

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

        public static void ParameterizedThreadSample()
        {
            // для того, чтобы передать потоку параметр,
            // используется такой делегат:
            ParameterizedThreadStart operation =
                new ParameterizedThreadStart(SimpleWork);

            Thread theThread = new Thread(operation);
            theThread.Start("Hello World!");
        }
    }
}
