namespace SimpleFramework.Domain.Exceptions;

public class NotEmptyException : BusinessException
{
    public NotEmptyException(string name)
        : base(BusinessExceptionCode.NotEmpty,
            string.Format(ExceptionMessages.NotEmpty,name))
    {
    }
}