using Common.Domain.Core.Enums;
using Common.Domain.Core.Resources;

namespace Common.Domain.Core.Exceptions
{
    public class MinLengthException: BusinessException
    {
        public MinLengthException(string paramName, int minLength) 
            : base(BusinessExceptionCode.InvalidData,
                string.Format(ExceptionMessage.MinLength, paramName, minLength))
        {
        }
    }
}