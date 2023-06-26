using Screenplay.Core.Models.Actors;
using Screenplay.Core.Models.Questions;
using Screenplay.Rest.Screenplay.Abilities;

namespace Screenplay.Rest.Screenplay.Questions
{
    internal class LastResponseHeader : IQuestion<string>
    {
        private readonly string _key;
        public LastResponseHeader(string key)
        {
            _key = key;
        }
        public string AnsweredBy(Actor actor)
        {
            var callApi = actor.FindAbility<CallAnApi>();
            return callApi.LastResponse.Headers.FirstOrDefault(a => a.Key == this._key).Value.FirstOrDefault();
        }
    }
}
