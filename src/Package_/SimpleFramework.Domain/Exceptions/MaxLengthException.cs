namespace SimpleFramework.Domain.Exceptions
{
    public class MaxLengthException: BusinessException
    {
        public MaxLengthException(string paramName, int maxLength) 
            : base(BusinessExceptionCode.InvalidData,
                string.Format(ExceptionMessages.MaxLength, paramName, maxLength))
        {
        }
    }
}