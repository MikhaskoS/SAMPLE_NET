using System;
using System.Collections.Generic;
using System.Text;


/*Паттерн Стратегия (Strategy) представляет шаблон проектирования, 
 * который определяет набор алгоритмов, инкапсулирует каждый из них и 
 * обеспечивает их взаимозаменяемость. В зависимости от ситуации мы можем 
 * легко заменить один используемый алгоритм другим. При этом замена 
 * алгоритма происходит независимо от объекта, который использует данный алгоритм.
 
  Реализовать паттерн можно при помощи интерфейсов с наследованием, либо 
  реализвать функциональность путем делегатов*/
namespace Strategy
{
    public interface IStrategy
    {
        void Algorithm();
    }

    public class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm()
        { }
    }

    public class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm()
        { }
    }

    public class Context
    {
        public IStrategy ContextStrategy { get; set; }

        public Context(IStrategy _strategy)
        {
            ContextStrategy = _strategy;
        }

        public void ExecuteAlgorithm()
        {
            ContextStrategy.Algorithm();
        }
    }
}
