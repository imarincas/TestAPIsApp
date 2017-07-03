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
        public string EndPoint { get; set; }
        public string XmlData { get; set; }
        public Headers Header { get; set; }
        public string soapResult;


        public SoapClientController()
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

        public Tuple<TimeSpan?, string> Execute()
        {
            string soapResult;
            HttpWebRequest request = Utils.CreateWebRequest(EndPoint, Header);
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml = Utils.CreateSoapEnvelope(XmlData);

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                using (WebResponse response = request.GetResponse())
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
