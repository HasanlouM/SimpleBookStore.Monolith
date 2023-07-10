using BookStore.Application.Catalog.CategoryAggregate.Commands;
using BookStore.Application.Contract.Catalog.CategoryAggregate.Commands;
using BookStore.Application.Contract.Catalog.CategoryAggregate.Queries;
using BookStore.Application.Test.Integration.Utils;
using BookStore.Persistence.EF;
using BookStore.Persistence.EF.Catalog.Repositories;
using BookStore.Test.Share.TestDoubles;
using Common.Persistence.EF;

namespace BookStore.Application.Test.Integration.Catalog.Tasks
{
    internal class DefineCategory : ITask<DefineCategoryCommand, CategoryQueryModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookStoreDbContext _dbContext;

        public DefineCategory(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _unitOfWork = UnitOfWorkFactory.Create(dbContext);
        }

        public async Task<CategoryQueryModel> Perform(DefineCategoryCommand command)
        {
            var repository = new CategoryRepository(_dbContext);
            var commandHandler = new DefineCategoryCommandHandler(_unitOfWork, repository, StubUtcClock.Default);
            var category = await commandHandler.HandleAsync(command, CancellationToken.None);

            return category;
        }
    }
}
