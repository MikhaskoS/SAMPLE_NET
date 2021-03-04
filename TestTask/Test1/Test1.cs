using System;


namespace TestTask
{
    class Test1
    {
        public static void Task1()
        {
            int t = 5;
            object o = t;
            Console.WriteLine(o.ToString());
            Console.WriteLine(((int)o).ToString());
        }

        #region Ответ
        #endregion

        public static void Task2()
        {
            object i = 1;
            object j = 1;
            Console.WriteLine(i == j);
            Console.WriteLine(i.Equals(j));
        }

        #region Ответ
        #endregion
    }
}
