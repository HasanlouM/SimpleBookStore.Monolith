namespace Common.Domain.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException() { }

        public BusinessException(int code, string message, Exception innerException) :
            base(message, innerException)
        {
            Code = code;
        }

        protected BusinessException(int code, string message) : base(message)
        {
            Code = code;
        }

        protected BusinessException(Enum code, string message)
            : this(Convert.ToInt32(code), message)
        {
        }

        protected BusinessException(Enum code, string message, Exception innerException)
            : this(Convert.ToInt32(code), message, innerException)
        {
        }

        public int Code { get; private set; }
    }
}
