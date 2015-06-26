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
    public class StringValuePair
    {
        private int _Depth;
        public int Depth
        {
            get { return _Depth; }
            set { _Depth = value; }
        }
        private string _key;
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        private string _val;
        public string Val
        {
            get { return _val; }
            set { _val = value; }
        }
        public StringValuePair(string key, string val, int depth)
        {
            _key = key;
            _val = val;
            _Depth = depth;
        }
    }
}
