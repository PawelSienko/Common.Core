using System;
using System.Net.Configuration;
using System.Net.Http;

namespace Common.Core.Exceptions
{
    public class InvalidStatementException : Exception
    {
        private const string DefaultMsg = "The statement doesn't match to conditions.";
        private readonly string message;
        private readonly string parameter;
        
        public InvalidStatementException()
        {   
        }

        public InvalidStatementException(string message, string parameter)
        {
            this.parameter = parameter;
            this.message = message;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(parameter) && string.IsNullOrEmpty(message))
            {
                return string.Format(Consts.MessageFormats.ExceptionMessagePattern, parameter, message);
            }
            return DefaultMsg;
        }

        public override string Message
        {
            get { return DefaultMsg; }
        }
    }
}