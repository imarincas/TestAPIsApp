using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SOAPApi
{
    public class SoapClient
    {
        public string EndPoint { get; set; }
        public string XmlData { get; set; }
        public Headers Header { get; set; }
        public string soapResult;


        public SoapClient()
        {

        }
        public WebResponse GetResponse()
        {
            var soapEnvelopeXml = Utils.CreateSoapEnvelope(XmlData);
            var request = Utils.CreateWebRequest(EndPoint, Header);
            request = Utils.InsertSoapEnvelopeIntoRequest(soapEnvelopeXml, request);

            // begin async call to web request.
            var asyncResult = request.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.

            WebResponse webResponse = request.EndGetResponse(asyncResult);

            return webResponse;
        }

        public string Execute()
        {
            HttpWebRequest request = Utils.CreateWebRequest(EndPoint, Header);
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml= Utils.CreateSoapEnvelope(XmlData);

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    var  soapResult = rd.ReadToEnd();
                  //  Console.WriteLine(soapResult);
                    return soapResult;
                }
            }
        }
    }
}
