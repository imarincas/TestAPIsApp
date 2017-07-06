using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagement.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Request { get; set; }
        public string Response { get; set;}
        public TimeSpan? ProcessingTime { get; set; }
        public int UserId { get; set; }
        public string Uri { get; set; }
        public string ServiceName { get; set; }
        public string Method { get; set; }
        public string ContentType { get; set; }
        public string Params { get; set; }



    }
}
