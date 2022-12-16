using Microsoft.AspNetCore.Http;

namespace Common.Application.RequestContext
{
    public interface IRequestContext
    {
        Guid UserId { get; }
        string Email { get; }
        string Ip { get; }
        bool Authenticated { get; }
        bool HasRole(string role);
        HttpRequest Request { get; }
    }
}