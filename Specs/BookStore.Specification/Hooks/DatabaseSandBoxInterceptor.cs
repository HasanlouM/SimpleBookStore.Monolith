using System.Net.Http;
using Screenplay.Rest.Interception;

namespace BookStore.Test.Specs.Hooks;

public class DatabaseSandBoxInterceptor : IHttpInterceptor
{
    private readonly string _connectionString;

    public DatabaseSandBoxInterceptor(string connectionString)
    {
        _connectionString = connectionString;
    }

    public HttpRequestMessage Intercept(HttpRequestMessage message)
    {
        message.Headers.Add("sandBoxConnection", _connectionString);

        return message;
    }
}