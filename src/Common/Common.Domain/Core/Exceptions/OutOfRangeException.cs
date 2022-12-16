using Common.Domain.Core.Enums;
using Common.Domain.Core.Resources;

namespace Common.Domain.Core.Exceptions
{
    public class OutOfRangeException : BusinessException
    {
        public OutOfRangeException(string name)
            : base(BusinessExceptionCode.OutOfRange,
                string.Format(ExceptionMessage.OutOfRange, name))
        {
        }
    }
}