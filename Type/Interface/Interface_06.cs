using System;

// Демонстрация того, в какой последовательности
// компилятор отыскивает методы. С этим надо быть
// внимательным.

//           I
//          / \
//         A   \     
//        /    /
//       B    /
//        \  /
//         C
//           
namespace ISample
{
    using S6;
    public class Sample6
    {
        public static void Demo()
        {
            B b1 = new B();
            C c1 = new C();
            B b2 = c1;

            b1.Go();
            c1.Go();
            b2.Go();       // A.Go() не помечен как виртуальный
            ((I)b2).Go();  //b2 это c
        }
    }

    namespace S6
    {
        public interface I
        {
            void Go();
        }
        public class A : I
        {
            public void Go()
            {
                Console.WriteLine("A.Go()");
            }
        }
        public class B : A
        {
        }
        public class C : B, I
        {
            public new void Go()
            {
                Console.WriteLine("C.Go()");
            }
        }
    }
   
}
// A.Go()
// C.Go()
// A.Go()
// C.Go()
// Для продолжения нажмите любую клавишу . . .