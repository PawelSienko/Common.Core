namespace Common.Core.Exceptions
{
    public class ArrayException : ExceptionBase
    {
        public ArrayException(string defaultMessage) : base(defaultMessage)
        {

        }

        public ArrayException(string message, string parameter) : base(message, parameter)
        {

        }
    }
}
