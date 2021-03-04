// условные операторы

namespace Conditional_operators
{
    class Programm
    {
        //switch:  https://metanit.com/sharp/tutorial/3.45.php
        static void Main(string[] args)
        {
            SwitchSample.DemoSwitch(54);
            SwitchSample.DemoSwitch(2);
            SwitchSample.DemoSwitch("Hello");
            SwitchSample.DemoSwitch2(3);
            //---------------------------
            SwitchPropsPattern.Demo();
            //---------------------------
            SwitchTyplePattern.Demo();
            //---------------------------
            SwitchPositioningPattern.Demo();
        }
    }

    class SwitchRelational
    {
        public static decimal Demo(decimal sum)
        {
            return sum switch
            {
                <= 0 => 0,              // если sum меньше или равно 0, возвращаем 0
                < 50000 => sum * 0.05m, // если sum меньше 50000, возвращаем sum * 0.05m
                < 100000 => sum * 0.1m, // если sum меньше 100000, возвращаем sum * 0.1m
                _ => sum * 0.2m        // в остальных случаях возвращаем sum * 0.2m
            };
        }
    }

    class SwitchLogical
    {
        public static string Demo(int age)
        {
            return age switch
            {
                < 1 or > 110 => "Недействительный возраст",   // если age больше 110 и меньше 1
                >= 1 and < 18 => "Доступ запрещен",           // если age равно или больше 1 и меньше 18
                _ => "Доступ разрешен"                      // в остальных случаях
            };
        }
    }
}
