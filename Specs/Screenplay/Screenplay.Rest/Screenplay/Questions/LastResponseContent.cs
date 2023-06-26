using Newtonsoft.Json;
using Screenplay.Core.Models.Actors;
using Screenplay.Core.Models.Questions;
using Screenplay.Rest.Screenplay.Abilities;

namespace Screenplay.Rest.Screenplay.Questions
{
    internal class LastResponseTypedContent<T> : IQuestion<T>
    {
        public T AnsweredBy(Actor actor)
        {
            var apiAbility = actor.FindAbility<CallAnApi>();
            var content = apiAbility.LastResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
