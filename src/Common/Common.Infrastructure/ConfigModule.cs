using Autofac;
using Common.Application;
using Common.Application.RequestContext;
using Microsoft.AspNetCore.Http;

namespace Common.Infrastructure
{
    public class ConfigModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandBus>()
                .As<ICommandBus>()
                .InstancePerLifetimeScope();

            builder.RegisterType<QueryBus>()
                .As<IQueryBus>()
                .InstancePerLifetimeScope();

            builder.RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RequestContext>().
                As<IRequestContext>()
                .InstancePerLifetimeScope();
        }
    }
}