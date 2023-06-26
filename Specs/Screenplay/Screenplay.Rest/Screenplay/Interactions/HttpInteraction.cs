using Screenplay.Core.Events;
using Screenplay.Core.Models;
using Screenplay.Core.Models.Actors;
using Screenplay.Rest.Events;
using Screenplay.Rest.OAuth;
using Screenplay.Rest.Screenplay.Abilities;

namespace Screenplay.Rest.Screenplay.Interactions
{
    public abstract class HttpInteraction : IInteraction
    {
        protected HttpInteraction()
        {
            RequestBuilder = new HttpRequestBuilder();
        }

        internal HttpRequestBuilder RequestBuilder { get; }

        public void PerformAs<T>(T actor) where T : Actor
        {
            var ability = actor.FindAbility<CallAnApi>();
            var request = RequestBuilder.WithBaseUrl(ability.BaseUrl).Build();
            Broadcaster.Publish(new StartSendingHttpRequestEvent(actor, request));
            if (ActorHasAccessToken(actor)) request = AddAccessTokenToHeader(actor, request);
            ability.SendRequest(request);
            Broadcaster.Publish(new HttpRequestSentEvent(ability.LastResponse));
        }

        private static bool ActorHasAccessToken<T>(T actor) where T : Actor
        {
            return actor.CanRecall(TokenConstants.TokenKey);
        }

        private static HttpRequestMessage AddAccessTokenToHeader<T>(T actor, HttpRequestMessage request) where T : Actor
        {
            var token = actor.Recall<OAuthToken>(TokenConstants.TokenKey);
            request.Headers.Add(HttpHeaders.Authorization, token.ToHeaderValue());
            return request;
        }

        public HttpInteraction WithQueryParameter(string key, string value)
        {
            RequestBuilder.WithQueryParameter(key, value);
            return this;
        }

        public HttpInteraction WithHeader(string key, string value)
        {
            RequestBuilder.WithHeader(key, value);
            return this;
        }
    }
}