using System;

namespace Converter
{   
    public class ChosenOperatorTaxi
    {
        public static CollectedValues ChooseCalculation(Choice choice)
        {
            CollectedValues CollectedValues = new CollectedValues();

            switch (choice.ChosenOperator)
            {
                case "Binary":
                    CollectedValues = BinaryConvert.ConvertFromBinary(choice.Text);
                    CollectedValues.Binary = (choice.Text);
                    break;
                case "Decimal":
                    CollectedValues = DecimalConvert.ConvertFromDecimal(Convert.ToInt32(choice.Text));
                    CollectedValues.Decimal = (Convert.ToInt32(choice.Text));
                    break;
                case "Hex":
                    CollectedValues = HexConverter.ConvertFromHexadecimal(choice.Text);
                    CollectedValues.Hex = (choice.Text);
                    break;
                case "Okta":
                    CollectedValues = OktaConvert.ConvertFromOctal(choice.Text);
                    CollectedValues.Okta = (choice.Text);
                    break;
            }        
            return CollectedValues;
        }
    }
}

