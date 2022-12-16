using Autofac;
using BookStore.Application.Books.Commands;
using Common.Application;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using BookStore.Admin.Api.Controllers;
using BookStore.Application.Contract.Books.Commands;
using Module = Autofac.Module;

namespace BookStore.Config
{
    public class BookStoreConfigModule : Module
    {
        private readonly IConfiguration _configuration;

        public BookStoreConfigModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            RegisterHandlers(builder);
        }
        private static void RegisterHandlers(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetAssemblyOfCommandHandlers())
                .As(type => type.GetInterfaces().Where(interfaceType =>
                    interfaceType.IsClosedTypeOf(typeof(ICommandHandler<>))))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(GetAssemblyOfCommandHandlers())
                .As(type => type.GetInterfaces().Where(interfaceType =>
                    interfaceType.IsClosedTypeOf(typeof(ICommandHandler<,>))))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(GetAssemblyOfCommandHandlers())
                .As(type => type.GetInterfaces().Where(interfaceType =>
                    interfaceType.IsClosedTypeOf(typeof(IQueryHandler<,>))))
                .InstancePerLifetimeScope();
        }

        public static Assembly GetAssemblyOfCommandHandlers()
        {
            return typeof(DefineBookCommandHandler).Assembly;
        }

        public static Assembly GetAssemblyOfApi()
        {
            return typeof(BooksController).Assembly;
        }

        public static Assembly GetAssemblyOfCommands()
        {
            return typeof(DefineBookCommand).Assembly;
        }
    }
}
