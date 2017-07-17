
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web;
using System.Xml;

namespace SOAPApi
{
    public class SoapClientController
    {
        public SoapClientController()
        {

        }
        public Tuple<TimeSpan?, string> Execute(SoapRequest request)
        {
            string soapResult;
            HttpWebRequest httpRequest = Utils.CreateWebRequest(request.EndPoint, request.Header);
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml = Utils.CreateSoapEnvelope(request.XmlData);

            using (Stream stream = httpRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                using (WebResponse response = httpRequest.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {

                        soapResult = rd.ReadToEnd();
                        //  Console.WriteLine(soapResult);
                        //return soapResult;
                    }
                }
                sw.Stop();
                var xml = HttpUtility.HtmlDecode(soapResult);
                return new Tuple<TimeSpan?, string>(sw.Elapsed, xml);
            }
            catch (Exception e)
            {
                return new Tuple<TimeSpan?, string>(null,e.Message);
            }
           
            
        }
    }
}
