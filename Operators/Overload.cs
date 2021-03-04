using System;
using System.Collections.Generic;
using System.Text;

namespace Operators
{
    // Перегрузка операторов
    // https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/operator-overloading

    /*Для объявления оператора используйте ключевое слово operator.
      -- Оно должно включать public и модификатор static.
      -- У унарного оператора один входной параметр. 
         У бинарного оператора два входных параметра. 
         В каждом случае хотя бы один параметр должен иметь тип T или T?, где 
         T — тип, который содержит объявление оператора.
         
         
         Перегрузка операторов ! и != потребует перегрузки метода Equal*/

    // Рациональное число
    public readonly struct Fraction
    {
        private readonly int num;  // числитель
        private readonly int den;  // знаменатель

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю!", nameof(denominator));
            }
            num = numerator;
            den = denominator;
        }

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);

        public static Fraction operator +(Fraction a, Fraction b)
            => new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);

        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);

        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.num * b.num, a.den * b.den);

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.num == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a.num * b.den, a.den * b.num);
        }

        public override string ToString() => $"{num} / {den}";
    }

}
