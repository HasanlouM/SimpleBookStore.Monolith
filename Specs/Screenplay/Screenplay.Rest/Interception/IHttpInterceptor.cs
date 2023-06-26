namespace Screenplay.Rest.Interception
{
    public interface IHttpInterceptor
    {
        HttpRequestMessage Intercept(HttpRequestMessage message);
    }
}