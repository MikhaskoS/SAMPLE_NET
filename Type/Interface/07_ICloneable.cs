using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISample
{
    public class P : ICloneable
    {
        public int p_i;
        public string p_s;
        public P(int i, string s)
        {
            p_i = i;
            p_s = s;
        }

        #region Члены ICloneable

        public object Clone()
        {
            return new P(this.p_i, this.p_s);
        }

        #endregion
    }

    class Sample7
    {
        public static void Demo()
        {
            P p1 = new P(1, "один");
            P p2 = p1;

            p1.p_i = 2;
            Console.WriteLine(p1.p_i); // 2
            Console.WriteLine(p2.p_i); // 2

            P p3 = (P)p1.Clone();
            p1.p_i = 3;
            Console.WriteLine(p1.p_i); // 3
            Console.WriteLine(p3.p_i); // 2
        }
    }
}

