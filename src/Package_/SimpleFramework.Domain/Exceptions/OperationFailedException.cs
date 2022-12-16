namespace SimpleFramework.Domain.Exceptions
{
    public class OperationFailedException: BusinessException
    {
        public OperationFailedException(string operation) 
            : base(BusinessExceptionCode.OperationFailed,
                string.Format(ExceptionMessages.OperationFailed, operation))
        {
        }
    }
}