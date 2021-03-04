
#define TESTMODE      // Директивы #define должны находиться в начале файла
#define PLAYMODE      // По соглашению, имена символов записываются в верхнем регистре.
#define LOGGINGMODE  

// Для определения символа на уровне сборки укажите при запуске компилятора ключ /define:
// csc Program.cs /define:TESTMODE, PLAYMODE

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Diagnostic
{
    // Условная компиляция
    class Define
    {
        public static void Demo()
        {
#if TESTMODE
            Console.WriteLine ("in test mode!");
#endif

#if TESTMODE && !PLAYMODE
            Console.WriteLine("in test mode! No PlayMode");
#endif

#if TESTMODE && PLAYMODE
            Console.WriteLine("in test mode! And PlayMode");
#endif
            LogStatus();
        }

        // так работать может быть удобнее. Проверяется наличие #define LOGGINGMODE
        [Conditional("LOGGINGMODE")]
        public static void LogStatus()
        {
            Console.WriteLine("символ LOGGINGMODE определен!");
        }
    }
}
