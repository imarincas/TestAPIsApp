using DataAccess.DTO;
using DataAccess.Repositories;
using RESTApi;
using SOAPApi;
using System.Windows;

namespace Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UsersDTO User = new UsersDTO();

        public MainWindow(UsersDTO user)
        {
            InitializeComponent();
            User = user;
            this.Title = "Hello " + user.Firstname + " " + user.Lastname;
        }

        private void btnSubmitSoap_Click(object sender, RoutedEventArgs e)
        {
            var soapClient = new SoapClient();
            soapClient.EndPoint = txtboxUrlSoap.Text;
            if (Utils.ValidateXml(txtboxSoapRequest.Text)== txtboxSoapRequest.Text)
            {
                soapClient.XmlData = txtboxSoapRequest.Text;
                var soapResponse = soapClient.Execute();
                txtboxSoapResponse.Text = Utils.PrettyXml(soapResponse.Item2);
                timeProcessing_Soap.Content = "Processing time: " + soapResponse.Item1;
                var result = new ResultDTO
                {
                    Request = soapClient.XmlData,
                    Response = Utils.PrettyXml(soapResponse.Item2),
                    ProcessingTime = soapResponse.Item1,
                    UserId = User.Id,
                    Uri = soapClient.EndPoint
                };

                var resultsRepo = new ResultsRepository();
                resultsRepo.InsertResultInDB(result);
            }else
            {
                txtboxSoapResponse.Text = Utils.ValidateXml(txtboxSoapRequest.Text);
            }
            
        }
        

        private void btnSubmitRest_Click(object sender, RoutedEventArgs e)
        {
            var restClient = new RestClient();
            restClient.EndPoint = txtboxUrlRest.Text;
            restClient.Method = dropdownMethod.Text;
            restClient.PostData = txtboxRestRequest.Text;
            restClient.ContentType = contentTypeList.Text;
            var response = restClient.ProcessRequest(txtboxParams.Text);
            txtboxRestResponse.Text = JsonFormater.FormatJson(response.Item2);
            timeProcessing_Rest.Content = "Processing time: " + response.Item1;

            var result = new ResultDTO {
                Request = restClient.PostData,
                Response = response.Item2,
                ProcessingTime = response.Item1,
                UserId = User.Id,
                Uri=restClient.EndPoint
            };

            var resultsRepo = new ResultsRepository();
            resultsRepo.InsertResultInDB(result);

        }

        private void tabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
