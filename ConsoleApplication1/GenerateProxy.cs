using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Web.Services.Description;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    class GenerateProxy
    {
        private Assembly Assembly;

        public List<string> GenerateProxyAssembly(string uri)
        {
                 
            //create a WebRequest object and fetch the WSDL file for the web service
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            System.IO.Stream stream = response.GetResponseStream();

            //read the downloaded WSDL file
             ServiceDescription desc = ServiceDescription.Read(stream);
            
         
            //find out the number of operations exposed by the web service
            //store the name of the operations inside the string array
            //iterating only through the first binding exposed as
            //the rest of the bindings will have the same number
            int i = 0;
            Binding binding = desc.Bindings[0];
            OperationBindingCollection opColl = binding.Operations;
            //string[] listOfOperations = new string[opColl.Count];
            List<string> listOfOperations = new List<string>();
            foreach (OperationBinding operation in opColl)
            {
            // Console.WriteLine(operation.Name);
             //   listOfOperations[i++] = operation.Name;
                listOfOperations.Add(operation.Name);
            }

            //initializing a ServiceDescriptionImporter object
            ServiceDescriptionImporter importer = new ServiceDescriptionImporter();

            //set the protocol to SOAP 1.1
            importer.ProtocolName = "Soap12";

            //setting the Style to Client in order to generate client proxy code
            importer.Style = ServiceDescriptionImportStyle.Client;

            //adding the ServiceDescription to the Importer object
            importer.AddServiceDescription(desc, null, null);
            importer.CodeGenerationOptions = CodeGenerationOptions.GenerateNewAsync;

            //Initialize the CODE DOM tree in which we will import the 
            //ServiceDescriptionImporter
            CodeNamespace nm = new CodeNamespace();
            CodeCompileUnit unit = new CodeCompileUnit();
            unit.Namespaces.Add(nm);

            //generating the client proxy code
            ServiceDescriptionImportWarnings warnings = importer.Import(nm, unit);

            if (warnings == 0)
            {
                //set the CodeDOMProvider to C# to generate the code in C#
                System.IO.StringWriter sw = new System.IO.StringWriter();
                CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
                provider.GenerateCodeFromCompileUnit(unit, sw, new CodeGeneratorOptions());

                //creating TempFileCollection
                //the path of the temp folder is hardcoded
                TempFileCollection coll = new TempFileCollection(@"C:\wmpub\tempFiles");
                coll.KeepFiles = false;

                //setting the CompilerParameters for the temporary assembly
                string[] refAssembly = { "System.dll", "System.Data.dll","System.Web.Services.dll", "System.Xml.dll" };
                CompilerParameters param = new CompilerParameters(refAssembly);
                param.GenerateInMemory = true;
                param.TreatWarningsAsErrors = false;
                param.OutputAssembly = "WebServiceReflector.dll";
                param.TempFiles = coll;

                //compile the generated code into an assembly
                //CompilerResults results = provider.CompileAssemblyFromDom(param, unitArr);
                CompilerResults results= provider.CompileAssemblyFromSource(param, sw.ToString());
                this.Assembly = results.CompiledAssembly;
            }

            //return the list of operations exposed by the web service
            return listOfOperations;
        }

        public string returnServiceName(string uri)
        {
            //create a WebRequest object and fetch the WSDL file for the web service
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            System.IO.Stream stream = response.GetResponseStream();

            //read the downloaded WSDL file
            ServiceDescription desc = ServiceDescription.Read(stream);
            Service services = desc.Services[0];
            return services.Name;
        }

        public ParameterInfo[] ReturnInputParameters(string methodName, string uri,string serviceName)
        {
           
            //create an instance of the web service type

            //////////////to do/////////////////////////

            //get the name of the web service dynamically from the wsdl

            Object  o = this.Assembly.CreateInstance(serviceName);

            Type service = o.GetType();

            ParameterInfo[] paramArr = null;

            //get the list of all public methods available in the generated //assembly
            MethodInfo[] infoArr = service.GetMethods();
            foreach (MethodInfo info in infoArr)

            {
                var infoname = info.Name;

                //get the input parameter information for the

                //required web method

                if (infoname.Equals(methodName))

                {

                    paramArr = info.GetParameters();

                }

            }



            return paramArr;

        }


    }
}
