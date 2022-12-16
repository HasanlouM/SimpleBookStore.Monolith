using Common.Domain.Core.Enums;
using Common.Domain.Core.Resources;

namespace Common.Domain.Core.Exceptions
{
    public class InvalidParameterException : BusinessException
    {
        public InvalidParameterException(string paramName)
            : base(BusinessExceptionCode.InvalidData,
                string.Format(ExceptionMessage.InvalidData, paramName))
        {
        }
    }
}
