﻿using DataAccess.Repositories;
using RESTApi;
using SOAPApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MainProgram
    {

        static void Main(string[] args)
        {


            var userRepo = new UsersRepository();
            var user = userRepo.GetUser("ionel");


            //var restClient = new RestClient();
            //restClient.EndPoint = @"https://httpbin.org";
            //restClient.Method = Verb.GET;
            //// var pdata = client.PostData;
            //var restResponse = restClient.Request("/get");
            //Console.WriteLine(restResponse);
            //Console.ReadKey();


            //var soapclient = new soapclient();
            //soapclient.endpoint = @"http://www.webservicex.com/globalweather.asmx";
            //soapclient.xmldata = @"<soapenv:envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:web=""http://www.webservicex.net"">
            //                       <soapenv:header/>
            //                       <soapenv:body>
            //                       <web:getcitiesbycountry>
            //                       <!--optional:-->
            //                       <web:countryname>romania</web:countryname>
            //                       </web:getcitiesbycountry>
            //                       </soapenv:body>
            //                       </soapenv:envelope>";


            //var response = soapclient.execute();
            //console.writeline(utils.prettyxml(response));
            //console.readkey();





            //List<string> metode = new List<string>();
            //GenerateProxy proxy = new GenerateProxy();
            //// string wsdlAddress = "http://localhost:55728/WebService.asmx?wsdl";           
            //string wsdlAddress = "http://www.webservicex.com/globalweather.asmx?wsdl";
            //// string wsdlAddress = "http://www.webservicex.net/whois.asmx?WSDL";
            //metode = proxy.GenerateProxyAssembly(wsdlAddress);
            ////Console.WriteLine(metode.ToArray());

            //foreach (string methodName in metode)
            //{
            //    Console.WriteLine(methodName);
            //    var parametru = proxy.ReturnInputParameters(methodName, wsdlAddress, proxy.returnServiceName(wsdlAddress));
            //    foreach (ParameterInfo param in parametru)
            //    {
            //        Console.WriteLine(param.Name + " " + param.ParameterType);
            //        //  Console.WriteLine(para.ParameterType);
            //    }
            //}
            //Console.ReadKey();
            //SOAPCall.CallSOAPService(wsdlAddress);
            //Console.ReadKey();

        }
    }
}
