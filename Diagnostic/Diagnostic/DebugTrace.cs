using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Diagnostic
{
    class DebugTrace
    {
        public static void Demo()
        {
            Debug.Write("===> Data: "); 
            Debug.WriteLine($"===>{23 * 34}");
            Trace.WriteLine($"===>{23 * 34}");
            int x = 5, y = 3; 
            Debug.WriteIf(x > y, "x is greater than y");

            Debug.Fail("File data.txt does not exist!");

            // Классы Debug и Trace имеют свойство Listeners, которое является статической 
            // коллекцией экземпляров TraceListener. Можно добавлять свои прослушиватели
            // По умолчанию коллекция Listeners в обоих классах включает единственный прослушиватель (DefaultTraceListener).
            //  Прослушиватели трассировки можно написать с нуля (создавая подкласс класса TraceListener) 
            //  или воспользоваться одним из предопределенных типов:
            //• TextWriterTraceListener записывает в Stream или TextWriter либо добавляет в файл;
            //      Класс TextWriterTraceListener имеет подклассы 
            //      ConsoleTraceListener, DelimitedListTraceListener, XmlWriterTraceListener и EventSchemaTraceListener.
            //• EventLogTraceListener записывает в журнал событий Windows; 
            //• EventProviderTraceListener записывает в подсистему трассировки событий для Windows(Event Tracing for Windows — ETW) в Windows Vista и последующих версиях;
            //• WebPageTraceListener записывает на веб-страницу ASP.NET.
            //  >>> Ни один из перечисленных выше прослушивателей не отображает диалоговое окно, 
            //  >>> когда вызывается метод Fail — таким поведением обладает только класс DefaultTraceListener.

        }
    }
}
