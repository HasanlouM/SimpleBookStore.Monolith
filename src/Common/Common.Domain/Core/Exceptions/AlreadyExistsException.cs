using Common.Domain.Core.Enums;
using Common.Domain.Core.Resources;

namespace Common.Domain.Core.Exceptions
{
    public class AlreadyExistsException : BusinessException
    {
        public AlreadyExistsException(string name)
            : base(BusinessExceptionCode.Duplicate,
                string.Format(ExceptionMessage.AlreadyExist, name))
        {
        }
    }
}