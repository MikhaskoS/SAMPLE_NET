using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LINQSample
{
    class Sample1
    {
        public static void Demo()
        {
            //--------------------------------------------------------
            // Обычно делегат обьявляется так
            Func<int, int> del = x => x + 1;

            // Деревья выражений представляют анонимные функции
            // не как исполняемый код, а как структуру данных.
            Expression<Func<int, int>> exp = x => x + 1; 
            // Теперь, чтобы получить делегат из  структуры данных, пишут
            Func<int, int> del2 = exp.Compile();
            //---------------------------------------------------------
        }
    }
}
