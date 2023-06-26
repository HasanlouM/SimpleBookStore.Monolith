using Screenplay.Core.Models.Actors;
using Screenplay.Core.Models.Questions;
using Screenplay.Rest.Screenplay.Abilities;

namespace Screenplay.Rest.Screenplay.Questions
{
    internal class LastResponseRaw : IQuestion<HttpResponseMessage>
    {
        public HttpResponseMessage AnsweredBy(Actor actor)
        {
            var callApi = actor.FindAbility<CallAnApi>();
            return callApi.LastResponse;
        }
    }
}