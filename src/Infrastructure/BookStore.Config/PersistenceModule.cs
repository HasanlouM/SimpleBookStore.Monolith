using Autofac;
using BookStore.Domain.Models.Books;
using BookStore.Persistence.EF;
using BookStore.Persistence.EF.Repositories.Books;
using Common.Persistence.EF;
using Microsoft.Extensions.Configuration;

namespace BookStore.Config
{
    public class PersistenceModule : Module
    {
        private readonly IConfiguration _configuration;

        public PersistenceModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(CreateDbContext)
                .InstancePerLifetimeScope();

            RegisterRepositories(builder);

        }

        private BookStoreDbContext CreateDbContext(IComponentContext arg)
        {
            return DbContextFactory.Create(_configuration.GetConnectionString("Default"));
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<BookStoreUnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookRepository>()
                .As<IBookRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookCategoryRepository>()
                .As<IBookCategoryRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
