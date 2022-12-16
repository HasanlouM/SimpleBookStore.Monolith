using Common.Domain.Core.Enums;
using Common.Domain.Core.Resources;

namespace Common.Domain.Core.Exceptions
{
    public class NotDigitException: BusinessException
    {
        public NotDigitException(string paramName) 
            : base(BusinessExceptionCode.InvalidData,
                string.Format(ExceptionMessage.NotDigit, paramName))
        {
        }
    }
}