namespace SimpleFramework.Domain.Exceptions
{
    public class MinLengthException: BusinessException
    {
        public MinLengthException(string paramName, int minLength) 
            : base(BusinessExceptionCode.InvalidData,
                string.Format(ExceptionMessages.MinLength, paramName, minLength))
        {
        }
    }
}