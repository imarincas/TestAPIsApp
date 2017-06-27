using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace SOAPApi
{
    public class Utils
    {

        public static TimeSpan Time(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public static string PrettyXml(string xml)
        {
            try
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
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public static  XmlDocument CreateSoapEnvelope(string xml)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(xml);
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
                request.Headers.Add(header.Name, header.Value);
            }
           
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            request.Method = "POST";
            return request;
        }

        public static string ValidateXml(string doc)
        {
            ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
            try
            {
                var xml = new XmlDocument();
                xml.LoadXml(doc);
                xml.Validate(eventHandler);
                return doc;
            }catch (Exception ex)
            {
                return ex.Message;
            }
          
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }

        }
    }
}
