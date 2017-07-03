﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RESTApi
{
    public class RestClientController
    {
        public string EndPoint { get; set; }
        public string Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }

        public RestClientController()
        {
            EndPoint = "";
            Method = "GET";
            ContentType = "application/JSON";
            PostData = "";
        }

        public RestClientController(string endpoint, string method, string postData, string contentType)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = contentType;
            PostData = postData;
        }

        public Tuple<TimeSpan, string> ProcessRequest(string parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);
            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;


            Stopwatch sw = new Stopwatch();
            sw.Start();
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = string.Format("Failed: Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }
                sw.Stop();
                return new Tuple<TimeSpan, string>(sw.Elapsed, responseValue);
            }
        }
    }
}