using System;



namespace TypeCreate
{
    /*
         Лямбда-выражение — это неименованный метод, записанный вместо экземпляра делегата. 
         Компилятор немедленно преобразует лямбда-выражение в одну из следующих двух конструкций.
         • Экземпляр делегата. 
         • Дерево выражения, которое имеет тип Expression<TDelegate>
           и представляет код внутри лямбда-выражения в виде поддерживающей обход объектной модели. 
           Дерево выражения позволяет лямбда-выражению интерпретироваться позже во время выполнения 
    */
    class LambdaSample
    {
        public static void Demo()
        {

            // Захват внешних переменных
            int factor = 2;
            Func<int, int> multiplier = n => n * factor;
            Console.WriteLine(multiplier(3)); // 6

            factor = 10;
            Console.WriteLine(multiplier(3)); // 30

            // Лямбда-выражения сами могут обновлять захваченные переменные:
            int seed = 0;
            Func<int> natural = () => seed++;
            Console.WriteLine(natural()); // 0 
            Console.WriteLine(natural()); // 1 
            Console.WriteLine(seed); // 2


            // Поскольку переменная seed была захвачена, время жизни этой переменной 
            // расширяется до времени жизни захватившего ее делегата !!!
            Func<int> nat = Natural();
            Console.WriteLine(nat()); // 0 
            Console.WriteLine(nat()); // 1

            // захват итерационной переменной
            Action[] actions = new Action[3];
            for (int i = 0; i < 3; i++)
                actions[i] = () => Console.Write(i);
            foreach (Action a in actions) a(); // 333  !!!
            //  Вот как это работает (захвтывается одна и та же переменная):
            //Action[] actions = new Action[3]; 
            //int i = 0; 
            //actions[0] = () => Console.Write(i);
            //i = 1;
            //actions[1] = () => Console.Write(i); 
            //i = 2; 
            //actions[2] = () => Console.Write(i);
            //i = 3; 
            //foreach (Action a in actions) a(); // 333


            // Исправим
            actions = new Action[3];
            for (int i = 0; i < 3; i++)
            {
                int loopScopedi = i;
                actions[i] = () => Console.Write(loopScopedi);
            }
            foreach (Action a in actions) a(); // 012


        }
        //------------------------------------------------
        delegate int Transformer(int i);
        Transformer tr1 = delegate (int x) { return x * x; };
        Transformer tr2 = (int x) => { return x * x; };
        Transformer tr3 = x => x * x;

        //------------------------------------------------
        // Лямбда-выражения чаще всего применяются с делегатами Fun и Action
        Func<int, int> sqr = х => х * х;
        Func<string, string, int> totalLength = (si, s2) => si.Length + s2.Length;

        static Func<int> Natural()
        {
            int seed = 0;
            return () => seed++; // Возвращает замыкание 
        }

    }
}
