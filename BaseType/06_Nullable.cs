using System;

// ¬ведение допустимости значени€ null продиктовано
// свойством баз данных, которые, как известно, допускают
// в своих таблицах значение NULL вне зависимости от
// типа значений столбца.

namespace TypeBase
{
    class Sample6
    {
        public static void Demo()
        {
            // теперь тип int помимо своих значений
            // может принимать значение null. ≈сли не
            // использовать ?, пришлось бы об€зательно
            // присваивать значение.
            int? b = null;
            Console.WriteLine("b = " + b);

            // var присвоит значение b. Ќо если оно = null то
            // присвоитс€ альтернативное значение. ?? - оператор null объединени€
            int v = b ?? 100;
            Console.WriteLine("v = " + v);

            // “ак можно проверить, было ли присвоено значение
            // переменной b. ƒл€ этой цели можно использовать
            // свойства HasValue и Value
            if (b.HasValue)
                Console.WriteLine(b.Value);
            else
                Console.WriteLine("«начение не присвоено!");

            // можно определ€ть и так
            Nullable<int> test1 = 5;
            Nullable<double> test2 = 3.14;
            Nullable<bool> isEnable = null;


            // ƒемонстраци€ элвис оператора (v > 6.0)

        }

        private static string GetCityInPast (Pers person) 
        {
            // ƒо C# 6.0  
            string city = String.Empty;
            
            //city = person?.Adress?.City;
            if (person !=  null ) 
            {
                //city = person.Adress?.City; <-- провер€ем тип null
                if (person.Adress != null )
                {
                    city = person.Adress.City;
                }
            } 
            return city;
        }

        private static string GetCityInPresent (Pers person)
        {
            // ? провер€ет тип на null 
            // ?? если null вернет Empty если нет вернет значение 
            
            return person?.Adress?.City ?? "" ;  // Ќачина€ с C# 6.0  
        } 
    }

    class Pers { public Adress Adress; }
    class Adress { public string City; }
}
//-----------------------------------------------
//b =
//v = 100
//«начение не присвоено!
//ƒл€ продолжени€ нажмите любую клавишу . . .
//-----------------------------------------------