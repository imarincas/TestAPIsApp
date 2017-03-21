using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SOAPApi
{
    public class Utils
    {
        public static string PrettyXml(string xml)
        {
            var stringBuilder = new StringBuilder();

            var element = XElement.Parse(xml);

            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                element.Save(xmlWriter);
            }

            return stringBuilder.ToString();
        }

        public static  XmlDocument CreateSoapEnvelope(string xml)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(PrettyXml(xml));
            return soapEnvelop;
        }

        public static HttpWebRequest InsertSoapEnvelopeIntoRequest(XmlDocument soapEnvelopeXml, HttpWebRequest Request)
        {
            using (Stream stream = Request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
            return Request;
        }

        public static HttpWebRequest CreateWebRequest(string url, Headers header)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (header != null)
            {
                request.Headers.Add(header.Header, header.Value);
            }
           
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            request.Method = "POST";
            return request;
        }
    }
}
