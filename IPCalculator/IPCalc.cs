using System;
using System.Collections.Generic;
using System.Text;

namespace IPCalculator
{
    public class IPCalc
    {
        public static IPInfo Welcome()
        {
            Console.WriteLine("IP калькулятор.");
            IPInfo ip = null;
            string s = "";

            do
            {
                Console.WriteLine("Введите IP адрес.");
                Console.Write("[0-255].[0-255].[0-255].[0-255]/[0-32] :=>");

                s = Console.ReadLine();
                ip = ReadParameters(s);
            }
           
            while (ip == null);

            return ip;
        }


        public static IPInfo ReadParameters(string IP)
        {
            int[] ip = new int[4];
            string[] ip2 = new string[4];
            int prefix = 0;
            if (prefix > 31) prefix = 31;

            return ConvertIPParameterers(IP, ref ip, ref ip2, ref prefix);
        }

        public static IPInfo[] Divide(IPInfo ip)
        {
            int num = 0;
            bool ok = false;
            int ps = 0;               // введеное количество подсетей

            while (!ok)
            {
                try
                {
                    Console.Write("Количество подсетей? [2,4,8,16,... ] :=>");
                    ps = int.Parse(Console.ReadLine());

                    num = Log2(ps);
                    ps = (int)Math.Pow(2, num);
                    Console.WriteLine("Число подсетей: " + ps);

                    if (ip.Prefix + num < 31)
                        ok = true;
                    else
                    {
                        ErrorMessage("Число вне диапазона!");
                        continue;
                    }
                }
                catch
                {
                    ErrorMessage("Некорректный ввод!");
                }
            }

            // новый префикс
            int prefix = ip.Prefix + num;

            IPInfo[] ips = new IPInfo[ps];
            if (ps == 1) { ips[0] = ip; return ips; }


            //новые ip сети
            for (int i = 0; i < ps; i++)
            {
                string ip_new = ip.NetworkBinary[0] + ip.NetworkBinary[1] + ip.NetworkBinary[2] + ip.NetworkBinary[3];

                // позицию адреса с ip.Prefix нужно заменить
                int width = num; // диапазон замены в маске
                string ws = Convert.ToString(i, 2);
                int w_dop = width - ws.Length;
                ws = new string('0', w_dop) + ws;

                ip_new = ip_new.Remove(ip.Prefix, num);
                ip_new = ip_new.Insert(ip.Prefix, ws);

                ips[i] = new IPInfo(
                  ip_new.Substring(0, 8),
                  ip_new.Substring(8, 8),
                  ip_new.Substring(16, 8),
                  ip_new.Substring(24, 8), prefix);

                ips[i].CalculateAddress();

            }

            return ips;
        }
        public static int Log2(int num)
        {
            int n = 0;
            if (num < 2) return 0;
            while (num > 1)
            {
                n++;
                num = num / 2;
            }

            return n;
        }
        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintIPParametersBase(IPInfo ip1, string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new String('+', 50));
            Console.WriteLine(message);
            Console.WriteLine(new String('+', 50));

            Print("Network", ip1.NetworkInt, ip1.NetworkBinary, ip1.Prefix, true);
            Print("HostMin", ip1.NetworkMinInt, ip1.NetworkMinBinary, ip1.Prefix, false);
            Print("HostMax", ip1.NetworkMaxInt, ip1.NetworkMaxBinary, ip1.Prefix, false);
            Print("Broadcast", ip1.BroadcastInt, ip1.BroadcastBinary, ip1.Prefix, false);
        }
        public static void PrintIPParametersAll(IPInfo ip1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new String('+', 50));
            Console.WriteLine("Полная информация");
            Console.WriteLine(new String('+', 50));

            Print("Address", ip1.IpInt, ip1.IpBinary, ip1.Prefix, false);
            Print("Netmask", ip1.MaskInt, ip1.MaskBinary, ip1.Prefix, true);
            Print("Wildcard", ip1.WildcardInt, ip1.WildcardBinary, ip1.Prefix, false);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=>");
            Print("Network", ip1.NetworkInt, ip1.NetworkBinary, ip1.Prefix, true);
            Print("HostMin", ip1.NetworkMinInt, ip1.NetworkMinBinary, ip1.Prefix, false);
            Print("HostMax", ip1.NetworkMaxInt, ip1.NetworkMaxBinary, ip1.Prefix, false);
            Print("Broadcast", ip1.BroadcastInt, ip1.BroadcastBinary, ip1.Prefix, false);


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Hosts/Net: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Math.Pow(2, (32 - ip1.Prefix)) - 2);

        }

        public static void Print(string name, int[] ip_int, string[] ip_bulean, int net_prefix, bool addprefix)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(name + " \t");
            Console.ForegroundColor = ConsoleColor.Blue;

            int _tabspace = 15;

            string _str = IPInfo.ArrayToString(ip_int);
            string _tab = (_str.Length <= _tabspace) ? "\t\t" : "\t";

            if (!addprefix)
                Console.Write(_str + _tab);
            else
            {
                if (name != "Netmask")
                {
                    _str += "/" + net_prefix;
                    _tab = (_str.Length <= _tabspace) ? "\t\t" : "\t";
                    Console.Write(_str + _tab);
                }
                else
                {
                    _str += " = " + net_prefix;
                    _tab = (_str.Length <= _tabspace) ? "\t\t" : "\t";
                    Console.Write(_str + _tab);
                }
            }

            Console.ForegroundColor = (name != "Netmask") ? ConsoleColor.Yellow : ConsoleColor.DarkYellow;
            Console.WriteLine(IPInfo.ArrayToString(ip_bulean, net_prefix));
        }

        /// <summary>
        /// Получение IP в необходимых форматах
        /// </summary>
        /// <param name="IPaddres"></param>
        /// <param name="ip"></param>
        /// <param name="ip2"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static  IPInfo ConvertIPParameterers(string IPaddres, ref int[] ip, ref string[] ip2, ref int prefix)
        {
            char[] ch = { '.', '/' };
            string[] _ip = IPaddres.Split(ch);

            if (_ip.Length > 5) return null;
            IPInfo ip1 = null;

            try  // считываем данные
            {
                for (int i = 0; i <= ip.Length; i++)
                {
                    if (i == 4)
                    {
                        prefix = int.Parse(_ip[i]);
                        if (prefix > 30)
                        {
                            ErrorMessage("Данные введены некорректно!"); return null;
                        }
                    }
                    else
                    {
                        ip[i] = int.Parse(_ip[i]);
                        if (ip[i] > 255)
                        {
                            ErrorMessage("Данные введены некорректно!"); return null;
                        }
                        ip2[i] = Convert.ToString(ip[i], 2);
                        // дополним до нужного количества знаков (8)
                        int n = 8 - ip2[i].Length;
                        string _s = new string('0', n);
                        ip2[i] = _s + ip2[i];
                    }
                }

                ip1 = new IPInfo(ip[0], ip[1], ip[2], ip[3], prefix);  // Введенный адрес
            }
            catch
            {
                ErrorMessage("Данные введены некорректно!");
                return null;
            }

            return ip1; 
        }
    }


    
}
