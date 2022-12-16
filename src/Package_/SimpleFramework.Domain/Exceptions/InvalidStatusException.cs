namespace SimpleFramework.Domain.Exceptions
{
    public class InvalidStatusException : BusinessException
    {
        public InvalidStatusException(string entityName)
            : base(BusinessExceptionCode.InvalidStatus, string.Format(ExceptionMessages.InvalidStatus, entityName))
        {
        }
    }
}