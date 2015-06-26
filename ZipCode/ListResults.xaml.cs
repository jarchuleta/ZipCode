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
using ZipCode.UsZip;

using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace ZipCode
{
    public partial class ListResults : PhoneApplicationPage
    {
        public ListResults()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string value;
            string type;
            NavigationContext.QueryString.TryGetValue("type", out type);
            NavigationContext.QueryString.TryGetValue("value", out value);

            UsZip.USZipSoapClient c = new UsZip.USZipSoapClient();

            USZipSoapClient u = new USZipSoapClient();
            
            switch(type){
                case "Zip":
                    u.GetInfoByZIPAsync(value);
                    u.GetInfoByZIPCompleted += new EventHandler<GetInfoByZIPCompletedEventArgs>(u_GetInfoByZIPCompleted);
                break;
                case "Area":
                    u.GetInfoByAreaCodeAsync(value);
                    u.GetInfoByAreaCodeCompleted += new EventHandler<GetInfoByAreaCodeCompletedEventArgs>(u_GetInfoByAreaCodeCompleted);
                break;

                case "City":
                u.GetInfoByCityAsync(value);
                u.GetInfoByCityCompleted += new EventHandler<GetInfoByCityCompletedEventArgs>(u_GetInfoByCityCompleted);
                break;

                case "State":
                u.GetInfoByStateAsync(value);
                u.GetInfoByStateCompleted += new EventHandler<GetInfoByStateCompletedEventArgs>(u_GetInfoByStateCompleted);
                break;
            }
        }

        void u_GetInfoByStateCompleted(object sender, GetInfoByStateCompletedEventArgs e)
        {
            List(e.Result);
        }

        void u_GetInfoByCityCompleted(object sender, GetInfoByCityCompletedEventArgs e)
        {
            List(e.Result);
        }

        void u_GetInfoByAreaCodeCompleted(object sender, GetInfoByAreaCodeCompletedEventArgs e)
        {
            //Location l = new Location();
            //l.City = e.Result.Value;
            //Results.Items.Add(l);
            List(e.Result);
        }

        void u_GetInfoByZIPCompleted(object sender, GetInfoByZIPCompletedEventArgs e)
        {

            List(e.Result);
           
           
        }

        private void List(XElement e)
        {
            List<StringValuePair> Values = ParseXElement(e,0);
            int allowedDepth = 0;
            string type;
            NavigationContext.QueryString.TryGetValue("type", out type);
            switch (type)
            {
                case "Zip":
                    allowedDepth = 3;
                    break;
                case "Area":
                    allowedDepth = 3;
                    break;

                case "City":
                    allowedDepth = 3;
                    break;

                case "State":
                    allowedDepth = 3;
                    break;
            }

            NavigationContext.QueryString.TryGetValue("type", out type);
            foreach (StringValuePair kvp in Values)
            {
                if(allowedDepth <= kvp.Depth)
                {
                    Results.Items.Add(kvp);
                }
            }
        }


        private List<StringValuePair> ParseXElement(XElement node, int depth)
        {
            List<StringValuePair> returnLVP = new List<StringValuePair>();

            foreach (XElement item in node.Elements())
            {
                returnLVP.AddRange(ParseXElement(item,depth+1));
            }
            returnLVP.Add(new StringValuePair(node.Name.LocalName,node.Value,depth));

            return returnLVP;
        }

       
    }



    
}
