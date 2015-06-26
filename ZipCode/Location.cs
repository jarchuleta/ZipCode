using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ZipCode
{
    public class Location
    {
        private string city;

        public String City
        {
            get { return city; }
            set { city = value; }
        }

        private string state;

        public String State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
