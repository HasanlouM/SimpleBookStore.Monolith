namespace SimpleFramework.Domain.Exceptions
{
    public class LengthException: BusinessException
    {
        public LengthException(string paramName, int length) 
            : base(BusinessExceptionCode.InvalidData,
                string.Format(ExceptionMessages.InvalidLength, paramName, length))
        {
        }
    }
}