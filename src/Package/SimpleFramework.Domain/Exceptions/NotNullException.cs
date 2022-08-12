namespace SimpleFramework.Domain.Exceptions;

public class NotNullException : BusinessException
{
    public NotNullException(string name)
        : base(BusinessExceptionCode.NotNul,
            string.Format(ExceptionMessages.NotNull,name))
    {
    }
}