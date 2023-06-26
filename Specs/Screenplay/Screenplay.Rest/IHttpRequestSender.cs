namespace Screenplay.Rest
{
    public interface IHttpRequestSender
    {
        HttpResponseMessage Send(HttpRequestMessage message);
    }
}
