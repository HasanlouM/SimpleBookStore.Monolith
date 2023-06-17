using Microsoft.Extensions.Configuration;

namespace BookStore.Application.Test.Integration.Utils;

public class Configuration
{
    private static readonly IConfiguration _configuration;

    static Configuration()
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        var fileName = $"appsettings.{env}.json";

        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(fileName)
            .Build();
    }

    public static IConfiguration GetConfiguration()
    {
        return _configuration;
    }
}