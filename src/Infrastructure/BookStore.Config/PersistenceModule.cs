using Autofac;
using BookStore.Domain.Catalog.Models.AuthorAggregate;
using BookStore.Domain.Catalog.Models.BookAggregate;
using BookStore.Domain.Catalog.Models.CategoryAggregate;
using BookStore.Domain.Catalog.Models.PublisherAggregate;
using BookStore.Persistence.EF;
using BookStore.Persistence.EF.Catalog.Repositories;
using Common.Persistence.EF;
using Microsoft.EntityFrameworkCore;
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

            RegisterCatalogRepositories(builder);
        }

        private BookStoreDbContext CreateDbContext(IComponentContext arg)
        {
            return DbContextFactory.Create();
        }

        private static void RegisterCatalogRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<BookStoreUnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookRepository>()
                .As<IBookRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>()
                .As<ICategoryRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthorRepository>()
                .As<IAuthorRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PublisherRepository>()
                .As<IPublisherRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
