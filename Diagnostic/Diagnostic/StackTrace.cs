using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Diagnostic
{
    class StackTraceSample
    {
        public static void Demo()
        {
            // StackFrame - nредоставляет сведения об объекте StackFrame, 
            //   который представляет вызов функции в стеке вызовов для текущего потока.
            // StackTrace - упорядоченный набор из одного или нескольких кадров стека (StackFtrame).
            

            StackTrace s = new StackTrace(true);
            Console.WriteLine("Total frames: " + s.FrameCount); // Всего фреймов

            Console.WriteLine("Current method: " + s.GetFrame(0).GetMethod().Name);  // Текущий метод 
            Console.WriteLine("Calling method: " + s.GetFrame(1).GetMethod().Name);  // Вызывающий метод 
            Console.WriteLine("Entry method: " + s.GetFrame // Входной метод 
                (s.FrameCount - 1).GetMethod().Name); Console.WriteLine("Call Stack:"); // Стек вызовов 
            foreach (StackFrame f in s.GetFrames())
                Console.WriteLine(" File: " + f.GetFileName() + /* Файл */
                    " Line: " + f.GetFileLineNumber() + /* Строка */
                    " Col: " + f.GetFileColumnNumber() + /* Колонка */
                    " Offset: " + f.GetILOffset() + /* Смещение */
                    " Method: " + f.GetMethod().Name); /* Метод */
        }
    }
}
