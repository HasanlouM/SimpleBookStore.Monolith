using Common.Api;
using Microsoft.AspNetCore.Builder;

namespace BookStore.Config;

public static class ConfigurationExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}