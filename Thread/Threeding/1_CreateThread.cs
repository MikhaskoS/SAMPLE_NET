using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Windows.Forms;

namespace ThreadSample
{
    class Sample1
    {
        // Процедура создания потока:
        // 1. using System.Threading;
        // 2. Определить метод void SimpleWork(void)
        // 3. Определить делегат ThreadStart operation = new ThreadStart(SimpleWork);
        // 4. Поток: Thread thread1 = new Thread(operation);
        // 5. Запустить поток: thread1.Start();

        // Для ожидания неопределенного количества времени лучше использовать
        // Timeout.Infinite


        // Этот класс позволяет безопасно уведомлять первичный поток о том, завершен вторичный поток или нет
        public static AutoResetEvent waitHandle = new AutoResetEvent(false);


        // Используется делегат ThreadStart
        public static void ThreadStartSample1()
        {

            ThreadStart operation = new ThreadStart(Printer.PrintNumbers);

            Thread thread1 = new Thread(operation);

            thread1.Start();
        }

        public static void ThreadStartSample2()
        {
            Console.WriteLine("***** The Amazing Thread App *****\n");
            Console.Write("Do you want [1] or [2] threads? ");
            string threadCount = Console.ReadLine();

            // Запрос количества потоков
            // Назначить имя текущему потоку. 
            Thread pnmaryThread = Thread.CurrentThread;
            pnmaryThread.Name = "Primary";
            // Вывести информацию о потоке. 
            Console.WriteLine("-> {0} is executing Main ()", Thread.CurrentThread.Name);
            
            // Создать рабочий класс. 
            Printer p = new Printer();
            switch (threadCount)
            {
                case "2": // Создать второй поток. 
                    Thread backgroundThread = new Thread(new ThreadStart(Printer.PrintNumbers)); 
                    backgroundThread.Name = "Secondary"; 
                    backgroundThread.Start (); 
                    break; 
                case "1":
                    Printer.PrintNumbers(); 
                    break; 
                default: 
                    Console.WriteLine ("I don't know what you want...you get 1 thread.");
                    goto case "1"; // Переход к варианту с одним потоком
            } // Выполнить некоторую дополнительную работу. 


            // Если создано 2 потока - сообщение будет выведено
            MessageBox.Show("I'm busy!", "Work on main thread...");
            Console.ReadLine();
        }

        // Используется делегат ParameterizedThreadStart
        public static void ParameterizedThreadStartSample()
        {
            Console.WriteLine("***** Adding with Thread objects *****"); 
            Console.WriteLine("ID of thread in MainO : {0}",
                Thread.CurrentThread.ManagedThreadId);
            
            // Создать объект AddParams для передачи вторичному потоку. 
            AddParams ap = new AddParams(10, 10); 
            Thread t = new Thread(new ParameterizedThreadStart(Printer.Add)); 
            t.Start(ap);

            // Подождать, пока другой поток завершится. 
            //Thread.Sleep(5);  // <- плохой способ


            // Ожидать, пока не поступит уведомление! Блокирует текущий поток.
            waitHandle.WaitOne();

            Console.WriteLine("Работа второго потока завершена!");
            Console.ReadLine();
        }
    }


    public class Printer
    {
        public static void PrintNumbers()
        {
            Console.WriteLine("Действия, выполняемые в потоке.");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("{0}, ", i); Thread.Sleep(2000);
            }

            Console.WriteLine("\nДействия в потоке завершены.");
            Console.ReadLine();
        }

        public static void Add(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine("ID of thread in Add(): {0}", Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams)data; 
                Console.WriteLine("{0} + {1} is {2}", ap.a, ap.b, ap.a + ap.b);

                // Сообщить первому потоку о том, что работа завершена. 
                Sample1.waitHandle.Set();
            }
        }
    }
    class AddParams
    {
        public int a, b;
        public AddParams(int numbl, int numb2)
        {
            a = numbl; b = numb2;
        }
    }
}

