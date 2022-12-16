using Common.Domain.Core.Enums;
using Common.Domain.Core.Resources;

namespace Common.Domain.Core.Exceptions
{
    public class OperationFailedException: BusinessException
    {
        public OperationFailedException(string operation) 
            : base(BusinessExceptionCode.OperationFail,
                string.Format(ExceptionMessage.OperationFailed, operation))
        {
        }
    }
}