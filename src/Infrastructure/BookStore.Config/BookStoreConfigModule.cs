using Autofac;
using BookStore.Admin.Api.Controllers;
using BookStore.Application.Catalog.BookAggregate.Commands;
using BookStore.Application.Contract.Catalog.BookAggregate.Commands;
using BookStore.Persistence.EF;
using Common.Application;
using Common.Persistence.EF;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Common.Domain.Utils;
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
            builder.RegisterType<Clock>()
                .As<IClock>()
                .SingleInstance();

            RegisterHandlers(builder);
        }

        private static void RegisterHandlers(ContainerBuilder builder)
        {
            #region Catalog

            

            #endregion


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
