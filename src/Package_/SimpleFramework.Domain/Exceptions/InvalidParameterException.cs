namespace SimpleFramework.Domain.Exceptions
{
    public class InvalidParameterException: BusinessException
    {
        public InvalidParameterException(string paramName) 
            : base(BusinessExceptionCode.InvalidData, string.Format(ExceptionMessages.InvalidParameter, paramName))
        {
        }
    }
}