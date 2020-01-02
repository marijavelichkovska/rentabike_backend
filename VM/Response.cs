using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication20.Models;

namespace WebApplication20.VM
{
  
        public class Response
        {
            public string Status { set; get; }
            public string Message { set; get; }
        public UserTbl User { get; internal set; }
    }
    
}