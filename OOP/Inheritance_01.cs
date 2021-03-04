using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{

    class Vehicle
    {
        public readonly int maxSpeed;
        private string someData;   // данные закрыты для всех, кто вне этого класса
        protected string ID;       // данные закрыты для всех, кроме наследников


        #region Корнструкторы
        // Несмотря на то что конструкторы обычно определяются как открытые, 
        // производный класс никогда не наследует конструкторы родительского класса !!!
        public Vehicle()
        {
            maxSpeed = 10;
        }
    
        public Vehicle(int max)
        {
            maxSpeed = max;
        }
        #endregion
    }


    // sealed - запечатывет класс. Его уже нельзя наследовать
    internal sealed class Car : Vehicle
    {
        // так можно воспользоваться конструктором базового класса
        public Car(int maxSpeed) : base(maxSpeed)
        { 
        }
    }

    class Moto : Vehicle
    { 
    }
}
