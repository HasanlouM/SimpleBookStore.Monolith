using Screenplay.Core.Models.Actors;

namespace Screenplay.Core.Models.Questions
{
    internal class MaximumQuestion<T> : IQuestion<T> where T : IComparable<T>
    {
        private readonly List<IQuestion<T>> _questions;

        public MaximumQuestion(List<IQuestion<T>> questions)
        {
            _questions = questions;
        }
        public T AnsweredBy(Actor actor)
        {
            var answers = _questions.Select(a => a.AnsweredBy(actor)).ToList();
            answers.Sort();
            return answers.Last();
        }
    }
}