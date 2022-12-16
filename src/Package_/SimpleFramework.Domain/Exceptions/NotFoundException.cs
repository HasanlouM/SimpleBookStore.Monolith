namespace SimpleFramework.Domain.Exceptions
{
    public class NotFoundException: BusinessException
    {
        public NotFoundException(string entityName = "Entity") 
            : base(BusinessExceptionCode.NotFound,
                string.Format(ExceptionMessages.NotFound, entityName))
        {
        }
    }
}
