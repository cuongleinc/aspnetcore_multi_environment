using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISvc.DTOs
{
    public class SuccessMsg
    {
        public SuccessMsg(String code, String message)
        {
            this.Code = code;
            this.Message = message;
        }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
