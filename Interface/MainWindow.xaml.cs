using RESTApi;
using SOAPApi;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Interface
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

        private void btnSubmitSoap_Click(object sender, RoutedEventArgs e)
        {
            var soapClient = new SoapClient();
            soapClient.EndPoint = txtboxUrlSoap.Text;
            soapClient.XmlData = txtboxSoapRequest.Text;

            var soapResponse = soapClient.Execute();
            txtboxSoapResponse.Text = Utils.PrettyXml(soapResponse);
        }
        

        private void btnSubmitRest_Click(object sender, RoutedEventArgs e)
        {
            var restClient = new RestClient();
            restClient.EndPoint = txtboxUrlRest.Text;
            restClient.Method = dropdownMethod.Text;
            restClient.PostData = txtboxRestRequest.Text;
            restClient.ContentType = contentTypeList.Text;
            txtboxRestResponse.Text = JsonFormater.FormatJson(restClient.Request(txtboxParams.Text));
        }
    }
}
