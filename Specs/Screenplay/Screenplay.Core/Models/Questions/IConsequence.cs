using NFluent;

namespace Screenplay.Core.Models.Questions
{
    public interface IConsequence<T> : IQuestion<ICheck<T>>
    {
    }
}
