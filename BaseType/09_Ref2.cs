using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeBase
{
    class Sample9
    {
        // ссылочный тип передается по значению
        public static void SuccValue(W obA)
        {
            // так можно (увеличит на 1)
            obA.a++;
            obA.b++;

            obA = new W(50, 60); // а это ничего не дает, т.к. создаем новый локальный объект!!!

            // и это тоже ничего не даст, поскольку локальный(!) obA
            // уничтожится при выходе из блока
            obA.a++;
            obA.b++;
        }

        // ссылочный тип передается по ссылке
        public static void SuccValue(ref W obA)
        {
            // теперь мы можем указать вообще на новый
            // объект в динамической памяти!!!
            obA = new W(100, 200);

            obA.a++;
            obA.b++;
        }
    }

    

    class W
    {
        public int a;
        public int b;
        public W()
        { }
        public W(int val1, int val2)
        {
            a = val1;
            b = val2;
        }
    }
}
