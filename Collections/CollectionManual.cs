using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionsSample
{
    class SampleVector
    {
        public static void Demo()
        {
            //----------------------------------------------
            Step1.Vector v1 = new Step1.Vector(1.0, 2.0, 5.0);
            // однако, foreach применить нельзя
            for (int i = 0; i < v1.Lenght; i++)
            {
                Console.WriteLine(v1[i]);
            }
            //----------------------------------------------
            Step2.Vector v2 = new Step2.Vector(1.0, 2.0, 5.0);
            foreach (double _d in v2)
            {
                Console.WriteLine(_d);
            }
            //----------------------------------------------
            Step3.Vector v3 = new Step3.Vector(1.0, 2.0, 5.0);
            foreach (double _d in v3)
            {
                Console.WriteLine(_d);
            }
            //----------------------------------------------
            Step4.Vector<int> v4 = new Step4.Vector<int>(1, 2, 5);
            foreach (int _d in v4)
            {
                Console.WriteLine(_d);
            }
        }
    }

    namespace Step1
    {
        // 1. Vector имеет конструктор для произвольного числа параметров double
        // 2. К элементам вектора можно обращаться по индексу (индексатор)
        #region
        public struct Vector
        {
            public double[] Coord;

            public Vector(params double[] coord)
            {
                Coord = coord;
            }

            public int Lenght
            {
                get { return Coord.Length; }
            }

            public double this[int i]
            {
                get
                {
                    if (i >= 0 && i < Coord.Length)
                    {
                        return Coord[i];
                    }
                    else
                    {
                        throw new IndexOutOfRangeException(
                           "Attempt to retrieve Vector element" + i);
                    }
                }
                set
                {
                    if (i >= 0 && i < Coord.Length)
                    {
                        Coord[i] = value;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException(
                       "Attempt to set Vector element" + i);
                    }
                }


            }
        }
        #endregion
    }

    namespace Step2
    {
        // 3. Опишем перечислитель Enumerator
        // 4. Определим GetEnumerator(). Определяя этот метод, мы указываем на то, что
        //    коллекция поддерживает интерфейс IEnumerable. Эта функция нужна для того, чтобы
        //    коллекция предоставила свой итератор.

        // Итак, IEnumerator - реализует(!) итератор, для перемещения по коллекции.
        // IEnumerable используется коллекцией для предоставления(!) итератора посредством GetEnumerator()
        #region
        public struct Vector : IEnumerable 
        {
            public double[] Coord;

            public Vector(params double[] coord)
            {
                Coord = coord;
            }

            public int Lenght
            {
                get { return Coord.Length; }
            }

            public double this[int i]
            {
                get
                {
                    if (i >= 0 && i < Coord.Length)
                    {
                        return Coord[i];
                    }
                    else
                    {
                        throw new IndexOutOfRangeException(
                           "Attempt to retrieve Vector element" + i);
                    }
                }
                set
                {
                    if (i >= 0 && i < Coord.Length)
                    {
                        Coord[i] = value;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException(
                       "Attempt to set Vector element" + i);
                    }
                }
            }

            #region реализация интерфейса IEnumerable
            public IEnumerator GetEnumerator()
            {
                return new VectorEnumerator(this);
            }
            #endregion

            private class VectorEnumerator : IEnumerator
            {
                Vector theVector;
                int location;

                public VectorEnumerator(Vector theVector)
                {
                    this.theVector = theVector;
                    location = -1;
                }

                #region реализация интерфейса IEnumerator
                public object Current
                {
                    get
                    {
                        if (location < 0 || location > theVector.Lenght - 1)
                            throw new InvalidOperationException(
                            "The enumerator is either before the first element or " +
                            "after the last element of the Vector");
                        return theVector[location];
                    }

                }

                public bool MoveNext()
                {
                    ++location;
                    return (location > theVector.Lenght - 1) ? false : true;
                }

                public void Reset()
                {
                    location = -1;
                }
                #endregion
            }
        }
        #endregion
    }

    namespace Step3
    {
        // 5. Упростим коллекцию, воспользовавшись оператором yield
        #region
        public struct Vector : IEnumerable
        {
            public double[] Coord;

            public Vector(params double[] coord)
            {
                Coord = coord;
            }

            public int Lenght
            {
                get { return Coord.Length; }
            }

            public double this[int i]
            {
                get
                {
                    if (i >= 0 && i < Coord.Length)
                    {
                        return Coord[i];
                    }
                    else
                    {
                        throw new IndexOutOfRangeException(
                           "Attempt to retrieve Vector element" + i);
                    }
                }
                set
                {
                    if (i >= 0 && i < Coord.Length)
                    {
                        Coord[i] = value;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException(
                       "Attempt to set Vector element" + i);
                    }
                }
            }

            #region реализация интерфейса IEnumerable
            // Нет необходимости описывать итератор. Можно
            // воспользоваться оператором yield. Вот как просто
            // это можно сделать!
            public IEnumerator GetEnumerator()
            {
                foreach (double d in Coord)
                    yield return d;
            }
            #endregion
        }
        #endregion
    }

    namespace Step4
    {
        // 6. Тип сделаем произвольным.
        #region
        struct Vector<T> : IEnumerable<T>, IEnumerable
        {
            public T[] Coord;

            public Vector(params T[] coord)
            {
                Coord = coord;
            }

            public int Lenght
            {
                get { return Coord.Length; }
            }

            public T this[int i]
            {
                get
                {
                    if (i >= 0 && i < Coord.Length)
                    {
                        return Coord[i];
                    }
                    else
                    {
                        throw new IndexOutOfRangeException(
                           "Attempt to retrieve Vector element" + i);
                    }
                }
                set
                {
                    if (i >= 0 && i < Coord.Length)
                    {
                        Coord[i] = value;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException(
                       "Attempt to set Vector element" + i);
                    }
                }


            }

            #region IEnumerable<T> Members

            public IEnumerator<T> GetEnumerator()
            {
                foreach (T d in Coord)
                    yield return d;
            }

            #endregion

            #region IEnumerable Members

            IEnumerator IEnumerable.GetEnumerator()
            {
                foreach (T d in Coord)
                    yield return d;
            }

            #endregion
        }
        #endregion
    }
}
