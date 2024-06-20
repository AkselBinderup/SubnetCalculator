using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Converter
{
    public class BinaryConvert
    {
        public static CollectedValues ConvertFromBinary(string binary)
        {
            CollectedValues values = new CollectedValues();
            values.Decimal = Convert.ToInt32(binary, 2);
            values.Okta = Convert.ToString(values.Decimal, 8);
            values.Hex = Convert.ToString(values.Decimal, 16).ToUpper();
            return values;
        }
    }
    
}
