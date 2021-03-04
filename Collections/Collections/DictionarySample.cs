using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionsSample
{
    class DictionarySample
    {
        public static void Demo()
        {
            var dict = new Dictionary<char, string>();
            dict.Add('r', "Roman");
            dict.Add('i', "Iva");
            dict.Add('v', "Viktor");

            // Перебор коллекции
            foreach (KeyValuePair<char, string> user in dict)
            {
                Console.WriteLine($"{user.Key} - {user.Value}");
            }
            dict['i'] = "Roman"; // Изменяем элемент с ключом i
            dict['t'] = "Roman"; // Добавляем элемент с ключом t

            if (dict.ContainsKey('i')) // Проверяем, имеется ли элемент с ключом  i
            {
                var tempUser = dict['i']; // Получаем элемент по ключу i
            }
            // Перебор ключей
            foreach (var user in dict.Keys)
            {
                Console.WriteLine($"{user}");
            }
            // Перебор по значениям
            foreach (var p in dict.Values)
            {
                Console.WriteLine(p);
            }

            #region C# 5
            Dictionary<int, string> dictionary = new Dictionary<int, string>
            {
                {1,"Roman" },
                {2,"Ivan" },
                {3,"Igor" },
                {4,"Vova" }
            };
            #endregion

            #region C# 6
            Dictionary<int, string> dictionary2 = new Dictionary<int, string>
            {
                [1] = "Roman",
                [2] = "Roman",
                [3] = "Roman",
                [4] = "Roman"
            };
            #endregion
        }


    }
}
