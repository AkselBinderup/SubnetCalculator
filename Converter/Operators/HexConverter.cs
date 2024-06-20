using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class HexConverter
    {

        public static CollectedValues ConvertFromHexadecimal(string hex)
        {
            CollectedValues values = new CollectedValues();
            values.Decimal = Convert.ToInt32(hex, 16);
            values.Binary = Convert.ToString(values.Decimal, 2);
            values.Okta = Convert.ToString(values.Decimal, 8);
            return values;
        }
    }
}
