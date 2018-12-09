using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISvc.Exceptions
{
    public class NotFoundException : Exception
    {
        private string code = string.Empty;

        public string Code { get { return code; } set { code = value; } }

        public NotFoundException() : base() { }

        public NotFoundException(string exceptionMessage) : base(exceptionMessage)
        {
            code = exceptionMessage;
        }

        public NotFoundException(string exceptionMessage, string message) : base(message)
        {
            code = exceptionMessage;
        }

        public NotFoundException(string exceptionMessage, string message, Exception innerException) : base(message, innerException)
        {
            code = exceptionMessage;
        }
    }
}
