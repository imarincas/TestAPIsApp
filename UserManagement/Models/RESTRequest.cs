using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Models
{
    public class RESTRequest
    {
        public string EndPoint { get; set; }
        public string Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }
    }
}
