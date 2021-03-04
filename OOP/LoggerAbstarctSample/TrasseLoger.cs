﻿namespace OOP.Logger
{
    // Вывод log информации в студии + возможность добавить свои прослушиваели
    public class TrasseLoger : DebugLogger
    {
        public override void Log(string Message, string Category)
        {
            System.Diagnostics.Trace.WriteLine($">>>>>>>{Message}", Category);
        }

        public override void Log(string Message)
        {
            System.Diagnostics.Trace.WriteLine($">>>>>>>{Message}");
        }
    }
}
