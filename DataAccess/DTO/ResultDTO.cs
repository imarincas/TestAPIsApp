﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ResultDTO
    {
        public int Id { get; set; }
        public string Request { get; set; }
        public string Response { get; set;}
        public TimeSpan? ProcessingTime { get; set; }
        public int UserId { get; set; }
        public string Uri { get; set; }


    }
}