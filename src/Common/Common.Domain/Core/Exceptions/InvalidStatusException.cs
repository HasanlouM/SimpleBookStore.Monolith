using Common.Domain.Core.Enums;
using Common.Domain.Core.Resources;

namespace Common.Domain.Core.Exceptions
{
    public class InvalidStatusException : BusinessException
    {
        public InvalidStatusException(string entityName)
            : base(BusinessExceptionCode.InvalidStatus,
                string.Format(ExceptionMessage.InvalidStatus, entityName))
        {
        }
    }
}