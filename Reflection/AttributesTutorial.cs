// Пример использования атрибутов класса и метода.

using System;
using System.Reflection;
using System.Collections;

namespace ReflectionSample
{
    // Создаются пользовательские аттрибуты.
    // [Author]  - автор класса или имя тестировщика класса
    // [IsTested] - протестирован ли метод

    class SampleAttribute
    {
        // проверка - имеется ли аттрибут [IsTested] у метода
        private static bool IsMemberTested(MemberInfo member)
        {
            foreach (object attribute in member.GetCustomAttributes(true))
            {
                if (attribute is IsTestedAttribute)
                {
                    return true;
                }
            }
            return false;
        }

        // Перечисление пользовательских аттрибутов, использованных в классе
        private static void DumpAttributes(MemberInfo member)
        {
            Console.WriteLine("Attributes for : " + member.Name);
            foreach (object attribute in member.GetCustomAttributes(true))
            {
                Console.WriteLine(attribute);
            }
        }

        public static void Demo()
        {
            // отображение атрибутов для класса Account
            DumpAttributes(typeof(Account));
            Console.WriteLine(new String('+', 50));

            // отображение списка протестированных членов
            foreach (MethodInfo method in (typeof(Account)).GetMethods())
            {
                if (IsMemberTested(method))
                {
                    Console.WriteLine("Member {0} is tested!", method.Name);
                }
                else
                {
                    Console.WriteLine("Member {0} is NOT tested!", method.Name);
                }
            }
            Console.WriteLine();

            // отображение атрибутов для класса Order
            DumpAttributes(typeof(Order));
            Console.WriteLine(new String('+', 50));

            // отображение атрибутов для методов класса Order
            foreach (MethodInfo method in (typeof(Order)).GetMethods())
            {
                if (IsMemberTested(method))
                {
                    Console.WriteLine("Member {0} is tested!", method.Name);
                }
                else
                {
                    Console.WriteLine("Member {0} is NOT tested!", method.Name);
                }
            }
            Console.WriteLine();
        }
    }

    #region Определение пользовательских аттрибутов
    // Класс IsTested = IsTestedAttribute -- это определенный пользователем  класс особых атрибутов.
    // Его можно применить к любому объявлению, включая
    //  - типы (структура, класс, перечисление, делегат)
    //  - члены (методы, поля, события, свойства, индексаторы)
    // Он используется без аргументов.
    public class IsTestedAttribute : Attribute
    {
        public override string ToString()
        {
            return "Is Tested";
        }
    }

    // Класс AuthorAttribute = Author -- это определенный пользователем класс атрибута.
    // Его можно применить только к объявлениям классов и структур !!! (AttributeUsage).
    // Он принимает один неименованный строковый аргумент (имя автора).
    // У него есть один необязательный именованный аргумент Version, тип которого -- int.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class AuthorAttribute : Attribute
    {
        // Этот конструктор определяет неименованные аргументы для класса атрибута.
        public AuthorAttribute(string name)
        {
            this.name = name;
            this.version = 0;
        }

        // Это свойство доступно только для чтения (у него нет метода доступа SET),
        // поэтому его нельзя применять к данному атрибуту в качестве именованного аргумента.
        public string Name
        {
            get
            {
                return name;
            }
        }

        // Это свойство доступно для чтения и записи (у него есть метод доступа SET),
        // поэтому его можно использовать как именованный аргумент, когда данный
        // класс применяется как класс атрибута.
        public int Version
        {
            get
            {
                return version;
            }
            set
            {
                version = value;
            }
        }

        public override string ToString()
        {
            string value = "Author : " + Name;
            if (version != 0)
            {
                value += " Version : " + Version.ToString();
            }
            return value;
        }

        private string name;
        private int version;
    }
    #endregion


    #region Применение аттрибутов к конкретным классам
    // Здесь выполняется присоединение определенного пользователем атрибута AuthorAttribute к 
    // классу Account. Неименованный строковый аргумент передается в 
    // конструктор класса AuthorAttribute при создании атрибутов.
    [Author("Joe Programmer")]
    class Account
    {
        private ArrayList orders = new ArrayList();
        
        // Присоединение пользовательского атрибута IsTestedAttribute к данному методу.
        [IsTested]
        public void AddOrder(Order orderToAdd)
        {
            orders.Add(orderToAdd);
        }
    }

    // Присоединение пользовательских атрибутов AuthorAttribute и IsTestedAttribute 
    // к данному классу.
    // Обратите внимание на использование именованного аргумента 'Version' для AuthorAttribute.
    // IsTested = IsTested()
    [Author("Jane Programmer", Version = 2), IsTested()]
    class Order
    {
        // сюда можно добавить нужные материалы ...
    }
    #endregion
}


