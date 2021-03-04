using System;

namespace TypeCreate
{
    sealed class A
    {
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        
        private string dopParam;
        public string DopParam { get => dopParam; set => dopParam = value; }


        // 1 способ применения this
        public A(string fullName, int ID)
        {
            this.fullName = fullName;
            this.id = ID;
        }

        // 2 способ применения this и перегрузка 
        // конструктора.
        public A(string fullName)
            : this(fullName, 1254)
        { }

        // конструктор можно сжать до выражения (C# 7.0)
        public A(int ID) => id = ID ;

        // корструктор с необязательными параметрами
        public A(string fullName = "Вася", int ID = 0, string dop = "" )
        {
            this.fullName = fullName;
            this.id = ID;
            this.dopParam = dop;
        }
    }


    public class Sample6
    {
        static void Demo()
        { }
    }
}