using System;

namespace Strategy
{
    class Program
    {
        // Пример - автомобиль. Его движение завсит от типа двигателя.
        static void Demo()
        {
            Car auto = new Car(4, "Volvo", new PetrolMove());
            auto.Move();
            auto.Movable = new ElectricMove();  // меняем двигатель
            auto.Move();

            Console.ReadLine();
        }
    }
    interface IMoveable
    {
        void Move();
    }

    class PetrolMove : IMoveable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на бензине");
        }
    }

    class ElectricMove : IMoveable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на электричестве");
        }
    }
    class Car
    {
        protected int passengers; // кол-во пассажиров
        protected string model; // модель автомобиля

        public Car(int num, string model, IMoveable mov)
        {
            this.passengers = num;
            this.model = model;
            Movable = mov;
        }
        public IMoveable Movable { private get; set; }
        public void Move()
        {
            Movable.Move();
        }
    }
}
