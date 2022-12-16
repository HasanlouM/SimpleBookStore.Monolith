using Autofac;
using Microsoft.Extensions.Configuration;
using SimpleFramework.Application;

namespace SimpleFramework.Infrastructure.Config
{
    public class ConfigModule : Module
    {
        private readonly IConfiguration _configuration;

        public ConfigModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandBus>()
                .As<ICommandBus>()
                .InstancePerLifetimeScope();

            builder.RegisterType<QueryBus>()
                .As<IQueryBus>()
                .InstancePerLifetimeScope();
        }
    }
}