namespace SimpleFramework.Domain.Exceptions
{
    public class InvalidFileExtensionException: BusinessException
    {
        public InvalidFileExtensionException(string extensionName) 
            : base(BusinessExceptionCode.InvalidFileExtension,
                string.Format(ExceptionMessages.InvalidFile, extensionName))
        {
        }
    }
}