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
using System.Windows.Shapes;

namespace Converter
{
    /// <summary>
    /// Interaction logic for ShowInfo.xaml
    /// </summary>
    public partial class ShowInfo : Window
    {
        public static string info { private get; set; }
        public ShowInfo()
        {
            InitializeComponent();
            TextBoxCHANGEPls();
        }
        public void TextBoxCHANGEPls()
        {
            TextBoxCHANGE.Text = info;
        }
        private void GoMainMenu(object sender, RoutedEventArgs e) 
        {
            SubnetWindow window = new SubnetWindow();
            Hide();
            window.Show();
        }
    }
}
