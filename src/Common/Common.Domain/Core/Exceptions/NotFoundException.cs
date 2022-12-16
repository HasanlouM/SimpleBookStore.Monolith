using Common.Domain.Core.Enums;
using Common.Domain.Core.Resources;

namespace Common.Domain.Core.Exceptions
{
    public class NotFoundException: BusinessException
    {
        public NotFoundException(string entityName) 
            : base(BusinessExceptionCode.NotFound,
                string.Format(ExceptionMessage.NotFound, entityName))
        {
        }
    }
}
