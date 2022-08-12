namespace SimpleFramework.Domain.Exceptions
{
    public class NotDigitException: BusinessException
    {
        public NotDigitException(string paramName) 
            : base(BusinessExceptionCode.InvalidData, string.Format(ExceptionMessages.NotDigit, paramName))
        {
        }
    }
}