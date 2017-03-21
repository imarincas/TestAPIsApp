using RESTApi;
using SOAPApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //   label1.Text = ConsoleApplication1.SOAPCall.CallSOAPService();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var restClient = new RestClient();
            restClient.EndPoint = txtboxUrlRest.Text;
            restClient.Method = dropdownMethod.Text;
            restClient.PostData = txtboxRestRequest.Text;
            txtboxRestResponse.Text=JsonFormater.FormatJson(restClient.Request(txtboxParams.Text));
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmitsoap_Click(object sender, EventArgs e)
        {
            var soapClient = new SoapClient();
            string soapResult;
            soapClient.EndPoint = txtboxUrlSoap.Text;
            soapClient.XmlData =txtboxSoapRequest.Text;

            using (var soapResponse = soapClient.GetResponse())
            {
                using (StreamReader reader = new StreamReader(soapResponse.GetResponseStream()))
                {
                    soapResult = reader.ReadToEnd();
                }
               // txtboxSoapResponse.Text= Utils.PrettyXml(soapResult);
                txtboxSoapResponse.Text = soapResult;

            }
        }

        private void dropdownMethod_Click(object sender, EventArgs e)
        {
         
        }
    }
}
