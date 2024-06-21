using System;
using System.Linq;


namespace Converter
{
    public class SubnetInfo
    {
        public static string Ipv4Address { get; set; } 
        public static string SubnetMask { get;set; }
        public char NetworkClass { get; set; }
        public string NetworkAdress { get; set; } 
        public string BroadCastAddress { get; set; }
        public int TotalHosts {  get; set; }
        public int UsableHosts { get; set; }
        public string BinarySubnetMask {  get; set; }
        public string CIDR {  get; set; }
        public string IPType { get; set; }
        public string WildCard { get; set; }
        public SubnetInfo(string ipv4, string subnetmask)
        {
            Ipv4Address = ipv4;
            SubnetMask = subnetmask;
            
            var item = GetNetworkClass.GetNetWorkClass(Ipv4Address);

            NetworkClass = item.Item1;
            IPType = item.Item2 ? "Private" : "Public";

            var subnetClean = subnetmask.Split('.');
            string concatBinary = string.Empty;
            for (int i = 0; i <= 3; i++)
            {
                var addToBinary = DecimalConvert.ConvertFromDecimal(Convert.ToInt32(subnetClean[i])).Binary;
                var binaryLength = addToBinary.Length;
                for (int j = 1; j <= 8 - binaryLength; j++)
                {
                    addToBinary = '0' + addToBinary;
                }
                concatBinary += addToBinary + " ";
            }
            BinarySubnetMask = concatBinary;
            CIDR = BinarySubnetMask.ToCharArray().Where(x => x.Equals('1')).Count().ToString();

            var ipv4Split = ipv4.Split('.');
            NetworkAdress = $"{ipv4Split[0]}.{ipv4Split[1]}.{ipv4Split[2]}.0";
            BroadCastAddress = $"{ipv4Split[0]}.{ipv4Split[1]}.{ipv4Split[2]}.255";
            TotalHosts = (int)Math.Pow(2, 32 - Convert.ToInt32(CIDR))-2;
            UsableHosts = TotalHosts;

            int index = BinarySubnetMask.IndexOf('0');
            if(index >= 0)
            {
                WildCard = BinarySubnetMask.Substring(0, index).Replace('1', '0') + 
                    BinarySubnetMask.Substring(index).Replace('0','1');
            }    

        }
    }
}
