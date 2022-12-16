namespace SimpleFramework.Domain.Exceptions
{
    public class InvalidEmailException: BusinessException
    {
        public InvalidEmailException(string paramName) 
            : base(BusinessExceptionCode.InvalidData, 
                string.Format(ExceptionMessages.InvalidEmail, paramName))
        {
        }
    }
}