using System.Net;
using Screenplay.Core.Events;

namespace Screenplay.Rest.Events
{
    public class HttpRequestSentEvent : ISelfDescriptiveEvent
    {
        public HttpRequestSentEvent(HttpResponseMessage response)
        {
            this.ResponseCode = response.StatusCode;
            this.ResponseContent = response.Content?.ReadAsStringAsync().Result;
        }

        public HttpStatusCode ResponseCode { get; private set; }
        public string ResponseContent { get; private set; }
        public string Describe()
        {
            return $"Http response with status code '{ResponseCode}' received.";
        }
    }
}
