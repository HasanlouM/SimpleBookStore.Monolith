using System.Net;
using Screenplay.Core.Models.Actors;
using Screenplay.Core.Models.Questions;
using Screenplay.Rest.Screenplay.Abilities;

namespace Screenplay.Rest.Screenplay.Questions
{
    internal class LastResponseStatusCode : IQuestion<HttpStatusCode>
    {
        public HttpStatusCode AnsweredBy(Actor actor)
        {
            var callApi = actor.FindAbility<CallAnApi>();
            return callApi.LastResponse.StatusCode;
        }
    }
}
