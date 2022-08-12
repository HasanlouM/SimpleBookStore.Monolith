namespace SimpleFramework.Domain.Exceptions
{
    public class AlreadyExistException : BusinessException
    {
        public AlreadyExistException(string paramName)
            : base(BusinessExceptionCode.AlreadyExist,
                string.Format(ExceptionMessages.AlreadyExist, paramName))
        {
        }
    }
}