using System;
using System.Collections.Generic;
using System.Text;

namespace Template
{

    /*
     Шаблонный метод (Template Method) определяет общий алгоритм поведения подклассов, 
     позволяя им переопределить отдельные шаги этого алгоритма без изменения его структуры*/
    abstract class AbstractClass
    {

        // метод разбивается на части, которые можно
        // переопределять в производных классах
        public void TemplateMethod()
        {
            Operation1();
            Operation2();
        }


        public abstract void Operation1();
        public abstract void Operation2();
    }

    class ConcreteClass : AbstractClass
    {
        public override void Operation1()
        {
        }

        public override void Operation2()
        {
        }
    }
}
