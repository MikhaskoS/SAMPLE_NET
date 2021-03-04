using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeBase
{
    // Пользовательские преобразования
    class Sample3C
    {
        public static void Demo()
        {
            Vector2 v2 = new Vector2(1, 2);
            Vector3 v3 = new Vector3(1, 2, 3);

            Vector2 v = (Vector2)v3; // явное преобразование
            Console.WriteLine(v); 

            Vector3 b = v2;          // неявное преобразование
            Console.WriteLine(b);

            Console.Read();
        }
    }

    public struct Vector2
    {
        public double x;
        public double y;

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            string s = $"x = {x} y = {y}";
            return s;
        }
    }
    public struct Vector3
    {
        public double x;
        public double y;
        public double z;

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // явное преобразование (теряется 3 координата)
        public static explicit operator Vector2(Vector3 d) => new Vector2(d.x, d.y);

        // неявное преобразование (дописывается 0)
        public static implicit operator Vector3(Vector2 d) => new Vector3(d.x, d.y, 0);

        public override string ToString()
        {
            string s = $"x = {x} y = {y} z = {z}";
            return s;
        }
    }
}
