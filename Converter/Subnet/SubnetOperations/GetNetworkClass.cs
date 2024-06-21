using System;
using System.Collections.Generic;
namespace Converter
{
    public class GetNetworkClass
    {
        private static readonly Dictionary<char, (long start, long end)> NetworkClasses = new Dictionary<char, (long start, long end)>()
        {
            { 'A', (10000000000, 126255255255) },
            { 'B', (128000000000, 191255255255) },
            { 'C', (192000000000, 223255255255) },
            { 'D', (224000000000, 239255255255) },
            { 'E', (240000000000, 254255255255) }
        };
        private static readonly List<(long Start, long End)> PrivateIPRanges = new List<(long Start, long End)>
        {
            (10000000000, 10255255255),    
            (172016000000, 172031255255),  
            (192168000000, 192168255255)   
        };
        public static (char, bool) GetNetWorkClass(string Ipv4Address)
        {
            if (Ipv4Address != null)
            {
                var finalIP = GetFullIp.GetIP(Ipv4Address);

                var splitAddress = finalIP.Replace('.'.ToString(), string.Empty);

                if (splitAddress.Length >= 1)
                {
                    var firstOctet = Convert.ToInt64(splitAddress);
                    var controlBool = false;
                    foreach (var (Start, End) in PrivateIPRanges)
                    {
                        if (firstOctet >= Start && firstOctet <= End)
                        {
                            controlBool = true;
                            break;
                        }
                    }
                    foreach (var networkClass in NetworkClasses)
                    {
                        if (firstOctet >= networkClass.Value.start && firstOctet <= networkClass.Value.end)
                            return (networkClass.Key, controlBool);
                    }
                }
            }
            return (' ', false);
        }
    } 
}
