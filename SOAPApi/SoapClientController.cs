
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
                return new Tuple<TimeSpan?, string>(sw.Elapsed, soapResult);
            }
            catch (Exception e)
            {
                return new Tuple<TimeSpan?, string>(null,e.Message);
            }
           
            
        }
    }
}
