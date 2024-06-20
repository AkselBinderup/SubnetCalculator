using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class DecimalConvert
    {
        public static CollectedValues ConvertFromDecimal(int decimalValue)
        {
            CollectedValues values = new CollectedValues();
            values.Binary = Convert.ToString(decimalValue, 2);
            values.Okta = Convert.ToString(decimalValue, 8);
            values.Hex = Convert.ToString(decimalValue, 16).ToUpper();

            return values;
        }
    }
}

