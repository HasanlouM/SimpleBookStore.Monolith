using NFluent;
using Screenplay.Core.Models.Actors;

namespace Screenplay.Core.Models.Questions
{
    public abstract class Consequence<T> : IConsequence<T>
    {
        public ICheck<T> AnsweredBy(Actor actor)
        {
            return Check.That(Answer(actor));
        }

        protected abstract T Answer(Actor actor);
    }
}