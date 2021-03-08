using System;

namespace TypeCreate
{
    class ReferenceSample
    {
        public static void Demo1()
        {
            PointStruct p1 = new PointStruct(1, 2);
            PointStruct p2 = p1;
            p2.x = 10;
            p1.Print();   // x = 1 y = 2
            p2.Print();   // x = 10 y = 2
            //---------------------------------------
            PointClass pc1 = new PointClass(1, 2);
            PointClass pc2 = pc1;
            pc2.x = 10;
            pc1.Print();   // x = 10 y = 2
            pc2.Print();   // x = 10 y = 2
            //---------------------------------------
            PointClass p3 = new PointClass(1, 2);
            ChangesParam(p3);
            p3.Print();   // x = 100 y = 2
            //---------------------------------------
            PointClass p4 = new PointClass(1, 2);
            ChangesParam(ref p4);
            p4.Print();   // x = 50 y = 50

            Console.Read();
        }

        // Передача ссылки по значению
        static void ChangesParam(PointClass p)
        {
            p.x = 100;

            p = new PointClass(50, 50); // !!! не сработает  !!!
        }
        // Передача ссылки по ссылке
        static void ChangesParam(ref PointClass p)
        {
            p.x = 100;

            p = new PointClass(50, 50); // теперь сработает
        }
    }

    

    struct PointStruct
    {
        public int x;
        public int y;

        public PointStruct(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Print()
        {
            Console.WriteLine($"x = {x} y = {y}");
        }
    }

    class PointClass
    {
        public int x;
        public int y;

        public PointClass(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Print()
        {
            Console.WriteLine($"x = {x} y = {y}");
        }
    }
}
