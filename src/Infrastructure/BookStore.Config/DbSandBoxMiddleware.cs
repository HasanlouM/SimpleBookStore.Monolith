using BookStore.Persistence.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookStore.Config;

public class DbSandBoxMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public DbSandBoxMiddleware(
        RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var connectionString = _configuration.GetConnectionString("Default");

        var isProduction = context.RequestServices.GetService<IWebHostEnvironment>().IsProduction();
        if (!isProduction)
        {
            var sandBoxConnection = context.Request.Headers["sandBoxConnection"].FirstOrDefault();
            if (!string.IsNullOrEmpty(sandBoxConnection))
            {
                connectionString = sandBoxConnection;

                DbContextFactory.SetConnectionString(connectionString);
                var dbContext = context.RequestServices.GetService<BookStoreDbContext>();
                await dbContext.Database.MigrateAsync();
            }
        }

        DbContextFactory.SetConnectionString(connectionString);

        await _next(context);
    }
}