using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionsSample
{
    // Класс HashSet<T> обеспечивает выполнение операций с высокой 
    // производительностью. 
    // Набор — это коллекция, которая не содержит повторяющихся элементов, 
    // элементы которой не имеют определенного порядка.

    class ArraySet
    {
        public static void Demo()
        {
            HashSet<int> A = new HashSet<int> { 1,    3,    5, 7, 11 };
            HashSet<int> B = new HashSet<int> { 1, 2, 3, 4, 5        };


            //Изменяет текущий объект HashSet<T> так, чтобы он содержал только 
            //элементы, которые имеются либо в этом объекте, либо в указанной 
            //коллекции, но не одновременно в них обоих.

            //A.SymmetricExceptWith(B);     // 2 4 7 11

            //Находит объединение множеств, представленных двумя 
            //последовательностями.
            
            //A.Union(B);                   // 1 3 5 7 11

            //A.ExceptWith(B);              // 7 11

            //B.SymmetricExceptWith(A);     // 2 11 4 7

            A.IntersectWith(B);             // 1 3 5

            A.WriteLine();
            B.WriteLine();                

        }
    }


}
