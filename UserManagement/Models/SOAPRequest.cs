using SOAPApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Models
{
    public class SoapRequest
    {
        public string EndPoint { get; set; }
        public string XmlData { get; set; }
        public Headers Header { get; set; }
    }
}
