using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace ZipCode
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AreaCode.xaml", UriKind.Relative));
        }

        private void hlbZipCode_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ZipCode.xaml", UriKind.Relative));
        }

        private void hlbCity_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/City.xaml", UriKind.Relative));
        }

        private void hlbState_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/State.xaml", UriKind.Relative));
        }
    }
}