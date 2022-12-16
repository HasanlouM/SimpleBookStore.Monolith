using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Common.Application.RequestContext
{
    public class RequestContext : IRequestContext
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public RequestContext(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public HttpRequest Request =>
            _contextAccessor?.HttpContext?.Request;

        public Guid UserId =>
            new (_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public string Email =>
            _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);

        public string Ip =>
            _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

        public bool Authenticated =>
            _contextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public bool HasRole(string role)
        {
            var hasRole = _contextAccessor.HttpContext.User.
                FindAll(ClaimTypes.Role)
                .Select(c => c.Value)
                .Contains(role);

            return hasRole;
        }
    }
}