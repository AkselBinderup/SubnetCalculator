using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BinaryFocus(object sender, RoutedEventArgs e)
        {
            if(BinaryTextBox.Text.Equals("Indtast tal"))
            BinaryTextBox.Text = string.Empty;
        }

        private void DecimalFocus(object sender, RoutedEventArgs e)
        {
            if (DecimalTextBox.Text.Equals("Indtast tal"))
                DecimalTextBox.Text = string.Empty;
        }

        private void HexaFocus(object sender, RoutedEventArgs e)
        {
            if (HexTextBox.Text.Equals("Indtast tal"))
                HexTextBox.Text = string.Empty;
        }
        private void OktaFocus(object sender, RoutedEventArgs e)
        {
            if (OktaTextBox.Text.Equals("Indtast tal"))
                OktaTextBox.Text = string.Empty;    
        }

        private void Switchtonewpagepls(object sender, RoutedEventArgs e)
        {
            SubnetWindow window = new SubnetWindow();
            Hide();
            window.Show();



        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Choice text = new Choice();

            if (!BinaryTextBox.Text.Equals(string.Empty) && !BinaryTextBox.Text.Equals("Indtast tal"))
            {
                text.Text = BinaryTextBox.Text;
                text.ChosenOperator = "Binary";
            }
            else if (!DecimalTextBox.Text.Equals(string.Empty) && !DecimalTextBox.Text.Equals("Indtast tal"))
            {
                text.Text = DecimalTextBox.Text;
                text.ChosenOperator = "Decimal";
            }
            else if (!HexTextBox.Text.Equals(string.Empty) && !HexTextBox.Text.Equals("Indtast tal"))
            {
                text.Text = HexTextBox.Text;
                text.ChosenOperator = "Hex";
            }
            else if (!OktaTextBox.Text.Equals(string.Empty) && !OktaTextBox.Text.Equals("Indtast tal"))
            {
                text.Text = OktaTextBox.Text;
                text.ChosenOperator = "Okta";
            }
            else
            {
                text.Text = string.Empty;
                text.ChosenOperator = string.Empty;
            }

            var values = ChosenOperatorTaxi.ChooseCalculation(text);
            BinaryTextBox.Text = values.Binary;
            DecimalTextBox.Text = values.Decimal.ToString() ;
            OktaTextBox.Text = values.Okta;
            HexTextBox.Text = values.Hex;
        }

    }


}
