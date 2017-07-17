

using AppManagement.Models;
using DataAccess.DTO;
using DataAccess.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RESTApi;
using SOAPApi;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace AppManagement.Controller
{
    public class TestsController
    {
        public static Test GetSOAPResponse(string endpoint, string xml, User user, Models.Headers header)
        {
            var soapClient = new SoapClientController();
            var request = new SOAPApi.SoapRequest()
            {
                EndPoint = endpoint,
                XmlData = xml
            };
            var soapResponse = soapClient.Execute(request);
            var soapResult = SOAPApi.Utils.PrettyXml(soapResponse.Item2);

            var result = new Test
            {
                Request = request.XmlData,
                Response = soapResult,
                ProcessingTime = soapResponse.Item1,
                UserId = user.Id,
                Uri = request.EndPoint,
                ServiceName = user.ServiceName
            };

            return result;

        }
        public static Test GetRESTResponse(Models.RESTRequest request, User user)
        {
            var restClient = new RestClientController()
            {
                EndPoint = request.EndPoint,
                Method = request.Method,
                PostData = request.PostData,
                ContentType = request.ContentType
            };
            var response = restClient.ProcessRequest();
            var resultJson = JsonFormater.FormatJson(response.Item2);
            var testcase = new Test
            {
                Request = request.PostData,
                Response = resultJson,
                ProcessingTime = response.Item1,
                UserId = user.Id,
                Uri = request.EndPoint,
                ServiceName = user.ServiceName
            };

            return testcase;
        }

        public static bool InsertInDB(Test test)
        {
            var testcaseRepo = new ResultsRepository();
            var testcase = new TestsDTO
            {
                Request = test.Request,
                Response = test.Response,
                ProcessingTime = test.ProcessingTime,
                UserId = test.UserId,
                Uri = test.Uri,
                ServiceName = test.ServiceName
            };
            return testcaseRepo.InsertTestcaseInDB(testcase);

        }

        public static byte ValidateResponse(string xpath, string value, string response)
        {
            try
            {
                var document = new XmlDocument();
                document.LoadXml(response);
                var nav = document.CreateNavigator();
                var nsmgr = new XmlNamespaceManager(document.NameTable);

                nav.MoveToFollowing(XPathNodeType.Element);
                IDictionary<string, string> namespaces = nav.GetNamespacesInScope(XmlNamespaceScope.All);

                foreach (KeyValuePair<string, string> ns in namespaces)
                {
                    nsmgr.AddNamespace(ns.Key, ns.Value);

                };
                var node = nav.SelectSingleNode(xpath, nsmgr);
                try
                {
                    var word = node.Value;

                    if (word.Equals(value))
                    {
                        return 1;
                    }
                    else
                        return 0;
                }
                catch (NullReferenceException ex)
                {
                    return 2;
                }


            }
            catch (Exception ex)
            {
                return 2;

            }
        }

        public static byte ValidateResponseREST(string jsonpath, string value, string response)
        {
            try
            {
               // var json = JsonConvert.DeserializeObject(response);
                var json = JObject.Parse(response);
                var tokenValue = json.SelectToken(jsonpath);                           

                if (tokenValue.ToString().Equals(value))
                {
                    return 1;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                return 2;

            }

        }

        public static List<string> GetServiceName()
        {
            var testRepo = new ResultsRepository();
            var serviceList = testRepo.GetServicename();

            return serviceList;
        }

        public static List<Test> GetTests(string servicename)
        {
            var testsList = new List<Test>();
            var testsRepo =new ResultsRepository();
            var testDTO = testsRepo.GetTestsByServiceName(servicename);
            foreach (var item in testDTO){
                var test = new Test
                {
                    Request = item.Request,
                    Response = item.Response,
                    ProcessingTime = item.ProcessingTime,
                    Uri = item.Uri,
                    ServiceName = item.ServiceName,
                    UserId=item.UserId
                                        
                };
                testsList.Add(test);
            }
            return testsList;


        }

    }
}
