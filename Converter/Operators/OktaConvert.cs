using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class OktaConvert
    {
        public static CollectedValues ConvertFromOctal(string octal)
        {
            CollectedValues values = new CollectedValues();
            values.Decimal = Convert.ToInt32(octal, 8);
            values.Binary = Convert.ToString(values.Decimal, 2);
            values.Hex = Convert.ToString(values.Decimal, 16).ToUpper();
            return values;
        }
    }
}
