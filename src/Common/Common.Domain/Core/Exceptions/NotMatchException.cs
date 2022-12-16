using Common.Domain.Core.Enums;
using Common.Domain.Core.Resources;

namespace Common.Domain.Core.Exceptions
{
    public class NotMatchException : BusinessException
    {
        public NotMatchException(string firstParam, string secondParam)
            : base(BusinessExceptionCode.InvalidData,
                string.Format(ExceptionMessage.NotMatch, firstParam, secondParam))
        {
        }
    }
}