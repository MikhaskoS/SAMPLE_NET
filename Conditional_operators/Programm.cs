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
        }
    }
}
