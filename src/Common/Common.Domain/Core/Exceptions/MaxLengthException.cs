using Common.Domain.Core.Enums;
using Common.Domain.Core.Resources;

namespace Common.Domain.Core.Exceptions
{
    public class MaxLengthException: BusinessException
    {
        public MaxLengthException(string paramName, int maxLength) 
            : base(BusinessExceptionCode.InvalidData,
                string.Format(ExceptionMessage.MaxLength, paramName, maxLength))
        {
        }
    }
}