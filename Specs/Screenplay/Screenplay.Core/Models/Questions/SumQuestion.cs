using Screenplay.Core.Models.Actors;

namespace Screenplay.Core.Models.Questions
{
    internal class SumQuestion : IQuestion<long>
    {
        private readonly List<IQuestion<long>> _questions;
        public SumQuestion(List<IQuestion<long>> questions)
        {
            this._questions = questions;
        }
        public long AnsweredBy(Actor actor)
        {
            return this._questions.Sum(question => question.AnsweredBy(actor));
        }
    }
}
