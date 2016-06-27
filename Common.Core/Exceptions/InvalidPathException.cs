using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Validation;

namespace Common.Core.Exceptions
{
    public class InvalidPathException : ExceptionBase
    {
        public InvalidPathException(string message, string parameter)
            : base(message, parameter)
        {
            DefaultMsg = "Path is invalid or not accessible";
        }
    }
}
