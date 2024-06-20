using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class GetFullIp
    {
        public static string GetIP(string Ipv4Address)
        {
            var getZero = Ipv4Address.Split('.');
            Octets octets = new Octets();
            for (int i = 1; i <= 3; i++)
            {
                var single = getZero[i];
                if (single.Equals("0"))
                {
                    single = "000";
                }
                if (Convert.ToInt32(single) <= 9 && Convert.ToInt32(single) >= 1)
                    single = "00" + single;
                if (Convert.ToInt32(single) <= 99 && Convert.ToInt32(single) >= 10)
                    single = "0" + single;
                switch (i)
                {
                    case 1:
                        octets.SecondsOctet = single;
                        break;
                    case 2:
                        octets.ThirdOctet = single;
                        break;
                    case 3:
                        octets.FourthOctet = single;
                        break;
                }
            }

            return getZero[0] + '.' + octets.SecondsOctet + '.' + octets.ThirdOctet + '.' + octets.FourthOctet;
        }
    }
}
