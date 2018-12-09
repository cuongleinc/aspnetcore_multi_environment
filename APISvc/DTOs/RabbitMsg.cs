using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISvc.DTOs
{
    public class RabbitMsg
    {
        String vendingCode;
        String message;
        public string VendingCode { get => vendingCode; set => vendingCode = value; }
        public string Message { get => message; set => message = value; }
    }
}
