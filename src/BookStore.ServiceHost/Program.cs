using Autofac;
using Autofac.Extensions.DependencyInjection;
using BookStore.Application.Contract.Catalog.BookAggregate.Commands;
using BookStore.Config;
using Common.Api;
using Common.Infrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new ConfigModule());
        containerBuilder.RegisterModule(new BookStoreConfigModule(builder.Configuration));
        containerBuilder.RegisterModule(new PersistenceModule(builder.Configuration));
    });

builder.Services.AddAutofac();

builder.Services.AddCors();

//builder.Services.TryAddTransient(provider => new CancellationTokenSource());

builder.Services.AddControllers(options =>
        options.Conventions.Add(new CqrsModelConvention()))
    .PartManager.ApplicationParts.Add(new AssemblyPart(BookStoreConfigModule.GetAssemblyOfApi()));

builder.Services.AddValidatorsFromAssemblyContaining<DefineBookCommand>()
    .Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ApiVersioning();

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseExceptionMiddleware();

app.UseCors(x => x
    //.WithOrigins(appSettings.Origins)
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetPreflightMaxAge(TimeSpan.FromHours(4)));

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
