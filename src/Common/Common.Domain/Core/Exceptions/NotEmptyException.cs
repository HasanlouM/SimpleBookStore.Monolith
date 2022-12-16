using Common.Domain.Core.Enums;
using Common.Domain.Core.Resources;

namespace Common.Domain.Core.Exceptions
{
    public class NotEmptyException: BusinessException
    {
        public NotEmptyException(string paramName) 
            : base(BusinessExceptionCode.NotEmpty,
                string.Format(ExceptionMessage.NotEmpty, paramName))
        {
        }
    }
}