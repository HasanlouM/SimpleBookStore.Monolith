using Screenplay.Core.Models.Actors;

namespace Screenplay.Core.Models.Questions
{
    public interface IQuestion<out TAnswer>
    {
        TAnswer AnsweredBy(Actor actor);
    }
}
