
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APISvc.DTOs
{
    public class ErrorMsg
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public ErrorMsg(string code, string message)
        {
            this.Code = code;
            this.Message = message;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
