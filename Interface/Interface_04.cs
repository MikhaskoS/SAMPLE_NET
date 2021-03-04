using System;


namespace ISample
{
    using S4;
   
    // из трех фигур - треугольник, линия, условный знак
    // последний не рисуется в пространстве. Попытаемся понять
    // это програмным способом.
    class Sample4
    {
        public static void Demo()
        {
            Triangle tr = new Triangle("Треугольник");
            Line ln = new Line("Линия");
            Sign sg = new Sign("Знак");

            Console.WriteLine(new string('-', 30));

            // Один интерфейс могут реализовывать объекты совершенно
            // разной природы. Это позволяет обращаться с ними полиморфно.
            IPoints[] PointsOb = { tr, ln, sg };

            for (int i = 0; i < PointsOb.Length; i++)
            {
                Console.WriteLine("Объект {0} имеет {1} вершин", ((Shape)PointsOb[i]).name,
                    PointsOb[i].NumPoints());
            }

            Console.WriteLine(new string('-', 30));
            // Смотрим, что можно рисовать в пространстве:
            // (конечно, это можно реализовать аналогично)
            Shape[] s = { tr, ln, sg };

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] is IDraw3D) // посмотрим, реализован ли интерфейс в данном классе
                Console.WriteLine("Объект {0} - может", s[i].name);
                else
                Console.WriteLine("Объект {0} - не может", s[i].name);
            } 
        }
    }
    namespace S4
    {
        // число точек в фигуре
        interface IPoints
        { int NumPoints(); }
        // рисование на плоскости
        interface IDraw
        { void Draw();}
        // рисование в пространстве
        interface IDraw3D
        { void Draw3D();    }
        public class Shape
        {
            public string name;
            public Shape()
            { }
            public Shape(string n)
            {
                name = n;
            }
        }
        public class Triangle : Shape, IDraw, IPoints, IDraw3D
        {
            public Triangle(string val)
                : base(val)
            { }

            public void Draw()
            {
                Console.WriteLine("Рисуется треугольник на плоскости.");
            }
            public int NumPoints()
            {
                return 3;
            }
            public void Draw3D()
            {
                Console.WriteLine("Рисуется треугольник в пространстве.");
            }
        }
        public class Line : Shape, IPoints, IDraw, IDraw3D
        {
            public Line(string val)
                : base(val)
            { }

            public void Draw()
            {
                Console.WriteLine("Рисуется линия на плоскости.");
            }
            public int NumPoints()
            {
                return 2;
            }
            public void Draw3D()
            {
                Console.WriteLine("Рисуется линия в пространстве.");
            }
        }
        public class Sign : Shape, IPoints, IDraw
        {
            public Sign(string val)
                : base(val)
            { }

            public int NumPoints()
            {
                return 1;
            }
            public void Draw()
            {
                Console.WriteLine("Рисуется условный знак на плоскости.");
            }
        }
    }
}

//------------------------------
// Объект Треугольник имеет 3 вершин
// Объект Линия имеет 2 вершин
// Объект Знак имеет 1 вершин
// ------------------------------
// Объект Треугольник - может
// Объект Линия - может
// Объект Знак - не может