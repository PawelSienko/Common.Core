using System;
using System.Net.Configuration;
using System.Net.Http;
using Common.Core.Validation;

namespace Common.Core.Exceptions
{
    public class InvalidStatementException : ExceptionBase
    {
        public InvalidStatementException() : base("Statement doesn't match. Invalid statement.")
        {
        }

        public InvalidStatementException(string message, string parameter) : base(message, parameter)
        {
        }
    }
}