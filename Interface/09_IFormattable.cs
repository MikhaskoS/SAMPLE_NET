using System;
//using System.Collections;
using System.Text;

// Здесь показано, как с использованием интерфейса IFormattable
// можно добиваться произвольного форматирования векторов

namespace ISample
{
    class Sample9
    {
        public static void Demo()
        {
            Vector Vect1 = new Vector(1.0, 2.0, 5.0);
            Vector Vect2 = new Vector(1.0, 2.0, 5.0);
            Console.WriteLine(Vect1.GetHashCode());
            Console.WriteLine(Vect2.GetHashCode());

                           
            Console.WriteLine("{0, 20:IJK}", Vect1); //  1 i + 2 j + 5 k
            Console.WriteLine(Vect1.ToString());     // ( 1 , 2 , 5 )
            Console.WriteLine(Vect1[0]);  //1
            Console.WriteLine(Vect1[1]);  //2
            Console.WriteLine(Vect1[2]);  //3
            Console.ReadLine();
        }
    }
    // Чтобы написать свое собственное форматирование, 
    // перопределим методы интерфейса IFormattable, указав
    // при этом, что наш вектор - форматируемый
    struct Vector : IFormattable
    {
        public double x, y, z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Вот, собствено, новая функция с учетом форматирования
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
                return ToString();
            string formatUpper = format.ToUpper();
            switch (formatUpper)
            {
                case "N":
                    return "|| " + Norm().ToString() + " ||";
                case "VE":
                    return String.Format("( {0:E}, {1:E}, {2:E} )", x, y, z);
                case "IJK":
                    StringBuilder sb = new StringBuilder(x.ToString(), 30);
                    sb.Append(" i + ");
                    sb.Append(y.ToString());
                    sb.Append(" j + ");
                    sb.Append(z.ToString());
                    sb.Append(" k");
                    return sb.ToString();
                default:
                    return ToString();
            }
        }

        public Vector(Vector rhs)
        {
            x = rhs.x;
            y = rhs.y;
            z = rhs.z;
        }

        public override string ToString()
        {
            return "( " + x + " , " + y + " , " + z + " )";
        }

        // доступ к компонентам вектора по индексу
        public double this[uint i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    case 2:
                        return z;
                    default:
                        throw new IndexOutOfRangeException(
                           "Attempt to retrieve Vector element" + i);
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    case 2:
                        z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException(
                           "Attempt to set Vector element" + i);
                }
            }
        }

        // погрешность, в пределах которой координаты вектора
        // считаются равными (это вводится из-за дискретности
        // машинных вычислений)
        private const double Epsilon = 0.0000001;

        // перегружаем оператор. Перегрузка оператора равенства
        // потребует переопределить методы GetHashCode()
        // и Equals()
        public static bool operator ==(Vector lhs, Vector rhs)
        {
            if (System.Math.Abs(lhs.x - rhs.x) < Epsilon &&
               System.Math.Abs(lhs.y - rhs.y) < Epsilon &&
               System.Math.Abs(lhs.z - rhs.z) < Epsilon)
                return true;
            else
                return false;
        }
        public static bool operator !=(Vector lhs, Vector rhs)
        {
            return !(lhs == rhs);
        }
        public static Vector operator +(Vector lhs, Vector rhs)
        {
            Vector Result = new Vector(lhs);
            Result.x += rhs.x;
            Result.y += rhs.y;
            Result.z += rhs.z;
            return Result;
        }
        public static Vector operator *(double lhs, Vector rhs)
        {
            return new Vector(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }
        public static Vector operator *(Vector lhs, double rhs)
        {
            return rhs * lhs;
        }
        public static double operator *(Vector lhs, Vector rhs)
        {
            return lhs.x * rhs.x + lhs.y + rhs.y + lhs.z * rhs.z;
        }

        // Главное требование - уникальность хэш кода.
        public override int GetHashCode()
        {
            // При таком подходе один хэш код имеют
            // равные векторы, что нормально для большинства задач
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            // убедимся, что посылающая строна посылает 
            // действительный объект Vector
            if (obj != null && obj is Vector)
            {
                Vector temp = (Vector)obj;
                if (System.Math.Abs(this.x - temp.x) < Epsilon &&
                    System.Math.Abs(this.y - temp.y) < Epsilon &&
                    System.Math.Abs(this.z - temp.z) < Epsilon)
                    return true;
                else return false;
            }
            return false;
        }
        public double Norm()
        {
            return x * x + y * y + z * z;
        }

    }
}