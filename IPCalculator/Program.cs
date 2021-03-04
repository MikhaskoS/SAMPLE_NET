using System;

namespace IPCalculator
{
    class Programm
    {

        static void Main(string[] args)
        {
            while (true)
            {

                Console.ForegroundColor = ConsoleColor.White;
                IPInfo ip = IPCalc.Welcome();
                ip.CalculateAddress();

                IPCalc.PrintIPParametersAll(ip);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(new String('*', 50));
                Console.Write("Разбить на подсети? [0 - Выход] :=>");

                string div = Console.ReadLine();
                if (div == "0") return;

                IPInfo[] ips = IPCalc.Divide(ip);

                for (int i = 0; i < ips.Length; i++)
                {
                    IPCalc.PrintIPParametersBase(ips[i], "Подсеть: " + (i + 1));
                }

                Console.Write("Продолжить? [0 - Выход] :=>");
                string res = Console.ReadLine();
                if (res == "0") break;

                Console.Clear();
            }
        }

   }
}
