using System;

// "“ип" в .NET это общий термин, используемый дл€ обозначени€ 
// любого элемента из множества: 
// {класс, структура, интерфейс, перечисление, делегат}


// —правка: типы в .NET Framework бывают значимыми и ссылочными.
// «начимые типы, в свою очередь, бывают
// - встроенными (int, float, ...) - (это встроенные структуры)
// - пользовательскими (структуры, созданные пользователем)
// - перечислимыми (наборы св€занных символов с фиксированными значени€ми)
namespace TypeBase
{
    partial class Sample
    {
        public static void MinMaxValue()
        {
            // —ледует иметь ввиду, что не все типы FCL совместимы с CLS,
            // а именно, несовместимы: sbyte, ushort, uint, ulong

            //  роме того, можно не использовать упрощенный синтаксис C#,
            // а примен€ть названи€ типов FCL
            /*  -- соответственно:
                System.SByte;
                System.Byte;
                System.Int16;
                System.UInt16;
                System.Int32;
                System.UInt32;
                System.Int64;
                System.UInt64;
                System.Single;
                System.Double;
                System.Decimal;
            */
            Console.WriteLine("sbyte:   {0} to {1}", sbyte.MinValue,
                                                               sbyte.MaxValue);
            Console.WriteLine("byte:    {0} to {1}", byte.MinValue,
                                                              byte.MaxValue);
            Console.WriteLine("short:   {0} to {1}", short.MinValue,
                                                              short.MaxValue);
            Console.WriteLine("ushort:  {0} to {1}", ushort.MinValue,
                                                              ushort.MaxValue);
            Console.WriteLine("int:     {0} to {1}", int.MinValue,
                                                              int.MaxValue);
            Console.WriteLine("uint:    {0} to {1}", uint.MinValue,
                                                              uint.MaxValue);
            Console.WriteLine("long:    {0} to {1}", long.MinValue,
                                                              long.MaxValue);
            Console.WriteLine("ulong:   {0} to {1}", ulong.MinValue,
                                                              ulong.MaxValue);
            Console.WriteLine("float:   {0} to {1}", float.MinValue,
                                                              float.MaxValue);
            Console.WriteLine("double:  {0} to {1}", double.MinValue,
                                                              double.MaxValue);
            Console.WriteLine("decimal: {0} to {1}", decimal.MinValue,
                                                              decimal.MaxValue);


            float f = float.NaN;
            Console.WriteLine(float.IsNaN(f));  // true

            double dPI = double.PositiveInfinity;
            double dNI = double.NegativeInfinity;

            Console.WriteLine(double.IsInfinity(dPI));
            Console.WriteLine(double.IsNegativeInfinity(dNI));

            //float s = 5 / 0;   // error





            // ѕомимо этих типов есть еще 
            // System.Char;
            // System.Boolean;
            // System.Object;
            // System.String;
        }
    }
}