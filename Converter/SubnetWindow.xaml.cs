using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;

namespace Converter
{
    public partial class SubnetWindow : Window
    {
        public SubnetWindow()
        {
            InitializeComponent();
        }
        private void IpAddressField(object sender, RoutedEventArgs e)
        {
            if(subnet.Text == "Insert IP Address")
                subnet.Text = string.Empty;
        }
        private static Dictionary<char, string> SubnetDictionary = new Dictionary<char, string>()
        {
            {'A', "255.0.0.0" },
            {'B', "255.255.0.0" },
            {'C', "255.255.255.0" }
        };
        private bool IPIsValid()
        {
            Regex ipv4Regex = new Regex(@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
            return ipv4Regex.IsMatch(subnet.Text);
            
        }
        private void SubnetField(object sender, RoutedEventArgs e)
        {
            if(IPIsValid())
            {
                char item = GetNetworkClass.GetNetWorkClass(subnet.Text).Item1;
                subnet_Copy.Text = SubnetDictionary.TryGetValue(item, out var subnetMask) ? subnetMask : "Invalid network class.";
            }
            else
            {
                subnet_Copy.Text = "Invalid IP Address";
            }
        }
        private void GoMainMenu(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Hide();
            window.Show();
        }
        private void buttonClickSubnetIPGET(object sender, RoutedEventArgs e)
        {
            if (IPIsValid())
            {
                var IpAddress = subnet.Text;
                var subnetMask = subnet_Copy.Text;
                SubnetInfo info = new SubnetInfo(IpAddress, subnetMask);
                string exMessage = $@"";
                var properties = info.GetType().GetProperties();
                foreach (var property in properties)
                {
                    string name = property.Name;
                    object value = property.GetValue(info);
                    exMessage += $"{name}={value} \n";
                }
                ShowInfo.info = exMessage;
                Debug.WriteLine(exMessage);
                ShowInfo showInfo = new ShowInfo();
                Hide();
                showInfo.Show();

            }
        }
    }
}
