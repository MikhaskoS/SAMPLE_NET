﻿namespace OOP.Logger
{
    public abstract class DebugLogger : Logger
    {
        //  Обрати внимание! Абстрактный метод базового класса в абстрактном наследнике
        //  не нужно переопределять!

        public abstract void Log(string Message, string Category);
    }
}
