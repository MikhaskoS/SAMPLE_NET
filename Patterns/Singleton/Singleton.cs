using System;
using System.Collections.Generic;
using System.Text;

namespace Sample
{
    /*Одиночка (Singleton, Синглтон) - порождающий паттерн, который гарантирует, 
     * что для определенного класса будет создан только один объект, а также предоставит 
     * к этому объекту точку доступа.*/
    class Singleton
    {
        private static Singleton instance;

        private Singleton()
        { }

        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }
}
