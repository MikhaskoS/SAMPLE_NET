using System;
using System.Collections.Generic;
using System.Text;

namespace IPCalculator
{
    public class IPInfo
    {
        int a;
        int b;
        int c;
        int d;
        int prefix;
        int[] ip;
        string[] ip2;
        
        private int[] _maskInt;
        private string[] _maskBinary;
        private int[] _wildcardInt;
        private string[] _wildcardBinary;
        private int[] _networkInt;
        private string[] _networkBinary;
        private int[] _networkMinInt;
        private string[] _networkMinBinary;
        private int[] _networkMaxInt;
        private string[] _networkMaxBinary;
        private int[] _broadcastInt;
        private string[] _broadcastBinary;

        public int[] MaskInt { get => _maskInt; }
        public string[] MaskBinary { get => _maskBinary; }
        public int[] WildcardInt { get => _wildcardInt;  }
        public string[] WildcardBinary { get => _wildcardBinary; }
        public int[] NetworkInt { get => _networkInt;  }
        public string[] NetworkBinary { get => _networkBinary; }
        public int[] NetworkMinInt { get => _networkMinInt; }
        public string[] NetworkMinBinary { get => _networkMinBinary;  }
        public int[] NetworkMaxInt { get => _networkMaxInt; }
        public string[] NetworkMaxBinary { get => _networkMaxBinary; }
        public int[] BroadcastInt { get => _broadcastInt; set => _broadcastInt = value; }
        public string[] BroadcastBinary { get => _broadcastBinary;  }


        public int Prefix { get => prefix; set => prefix = value; }
        public int[] IpInt { get => ip; set => ip = value; }
        public string[] IpBinary { get => ip2; set => ip2 = value; }

        public IPInfo(string Ia, string Ib, string Ic, string Id, int prefix)
        {
            a = Convert.ToInt32( Ia, 2);
            b = Convert.ToInt32(Ib, 2);
            c = Convert.ToInt32(Ic, 2);
            d = Convert.ToInt32(Id, 2);
            this.prefix = prefix;

            ip = new int[] { a, b, c, d };
            ip2 = new string[] {Ia, Ib, Ic, Id };
            // добавим нули слева

            for (int i = 0; i < ip2.Length; i++)
            {
                int n = 8 - ip2[i].Length;
                string _s = new string('0', n);
                ip2[i] = _s + ip2[i];
            }
        }

        public IPInfo(int Ia, int Ib, int Ic, int Id, int prefix)
        {
            a = Ia;
            b = Ib;
            c = Ic;
            d = Id;
            this.prefix = prefix;

            ip = new int[] { Ia, Ib, Ic, Id };
            ip2 = new string[] {
                Convert.ToString(Ia, 2),
                Convert.ToString(Ib, 2) ,
                Convert.ToString(Ic, 2) ,
                Convert.ToString(Id, 2) };
            // добавим нули слева

            for (int i = 0; i < ip2.Length; i++)
            {
                int n = 8 - ip2[i].Length;
                string _s = new string('0', n);
                ip2[i] = _s + ip2[i];
            }
        }


        public bool CalculateAddress()
        {
            SolveMask();
            SolveWildCard();
            SolveNetwork();
            SolveMinHost();
            SolveBroadcact();
            SolveMaxHost();

            return true;
        }


        private void SolveMask()
        {
            string _mask2 = new string('1', prefix) + new string('0', 32 - prefix);
            _maskBinary = new string[4];
            _maskInt = new int[4];

            for (int i = 0; i < _mask2.Length; i++)
            {
                int n = i / 8;
                _maskBinary[n] = _maskBinary[n] + _mask2[i];
            }

            for (int i = 0; i < _maskBinary.Length; i++)
            {
                _maskInt[i] = Convert.ToInt32(_maskBinary[i], 2);
            }
        }
        
        private void SolveWildCard()
        {
            _wildcardBinary = new string[4];
            _wildcardInt = new int[4];

            for (int i = 0; i < _maskBinary.Length; i++)
            {
                _wildcardBinary[i] = _maskBinary[i].Replace('0', '*');
                _wildcardBinary[i] = _wildcardBinary[i].Replace('1', '0');
                _wildcardBinary[i] = _wildcardBinary[i].Replace('*', '1');
            }
            for (int i = 0; i < _wildcardBinary.Length; i++)
            {
                _wildcardInt[i] = Convert.ToInt32(_wildcardBinary[i], 2);
            }
        }

        private void SolveNetwork()
        {
            _networkBinary = Insert(ip2, prefix, '0');
            _networkInt = BinaryToInt(_networkBinary);
        }
        
        private void SolveMinHost()
        {
            // после положения префикса должны быть нули и последняя -1
            _networkMinBinary = (string[])_networkBinary.Clone();
            _networkMinBinary[3] = _networkMinBinary[3].Remove(7);
            _networkMinBinary[3] += "1";

            _networkMinInt = BinaryToInt(_networkMinBinary);
        }
        
        private void SolveMaxHost()
        {
            _networkMaxBinary = (string[])_broadcastBinary.Clone();
            _networkMaxBinary[3] = _networkMaxBinary[3].Remove(7);
            _networkMaxBinary[3] += "0";

            _networkMaxInt = BinaryToInt(_networkMaxBinary);
        }
        
        private void SolveBroadcact()
        {
            _broadcastBinary= Insert(ip2, prefix, '1');

            _broadcastInt = BinaryToInt(_broadcastBinary);
        }

        public static string ArrayToString(int[] array)
        {
            return array[0] + "." + array[1] + "." + array[2] + "." + array[3];
        }
        
        public static string ArrayToString(string[] array, int prefix)
        {
            string _s = array[0] + "." + array[1] + "." + array[2] + "." + array[3];
            int points = prefix / 8; // число точек
            _s = _s.Insert(prefix + points, " ");

            return _s;
        }

        public static int[] BinaryToInt(string[] binary)
        {
            int[] i_array = new int[binary.Length];

            for (int i = 0; i < binary.Length; i++)
            {
                i_array[i] = Convert.ToInt32(binary[i], 2);
            }

            return i_array;
        }
        // замена после префикса
        public static string[] Insert(string[] array, int prefix, char ch)
        {
            string[] result = new string[4];

            int _t = 0;
            string _s = "";
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    _t++;

                    if (_t > prefix)
                        _s += ch;
                    else _s += array[i][j];
                }
            }
            result[0] = _s.Substring(0, 8);
            result[1] = _s.Substring(8, 8);
            result[2] = _s.Substring(16, 8);
            result[3] = _s.Substring(24, 8);

            return result;
        }
    }
}
