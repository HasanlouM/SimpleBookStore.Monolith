namespace SimpleFramework.Domain.Exceptions
{
    public class InvalidRangeException : BusinessException
    {
        public InvalidRangeException(string name,object from, object to)
            : base(BusinessExceptionCode.OutOfRange,
                string.Format(ExceptionMessages.InvalidRange,name, from, to))
        {
        }
    }
}