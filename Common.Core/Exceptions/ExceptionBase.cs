using System;
using Common.Core.Validation;

namespace Common.Core.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        protected string DefaultMsg;

        // ReSharper disable once InconsistentNaming
        protected readonly string message;
        // ReSharper disable once InconsistentNaming
        protected readonly string parameter;
        
        protected ExceptionBase(string message)
        {
            DefaultMsg = message;
        }

        protected ExceptionBase(string message, string parameter)
        {
            Validator.ValidateNullOrEmpty(message);
            Validator.ValidateNullOrEmpty(parameter);
            this.message = message;
            this.parameter = parameter;
        }
        
        public override string ToString()
        {
            if ((string.IsNullOrEmpty(parameter) && string.IsNullOrEmpty(message)) == false)
            {
                return string.Format(Consts.MessageFormats.ExceptionMessagePattern, parameter, message);
            }

            return DefaultMsg;
        }

        public override string Message => DefaultMsg;
    }
}
