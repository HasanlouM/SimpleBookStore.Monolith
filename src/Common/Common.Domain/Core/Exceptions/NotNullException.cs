using Common.Domain.Core.Enums;
using Common.Domain.Core.Resources;

namespace Common.Domain.Core.Exceptions
{
    public class NotNullException: BusinessException
    {
        public NotNullException(string paramName) 
            : base(BusinessExceptionCode.NotNul,
                string.Format(ExceptionMessage.NotNull, paramName))
        {
        }
    }
}