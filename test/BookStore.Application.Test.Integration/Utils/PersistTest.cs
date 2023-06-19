using System.Transactions;
using BookStore.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookStore.Application.Test.Integration.Utils;

/// <summary>
/// In XUnit test frameworks
/// Constructor considered as a hook of before test 
/// and Dispose considered as a hook of after test
/// </summary>

// Test-case supperClass
public abstract class PersistTest : IDisposable
{
    private readonly TransactionScope _transactionScope;
    protected readonly BookStoreDbContext DbContext;

    protected PersistTest()
    {
        var connection = Configuration.GetConfiguration().GetConnectionString("Default");
        _transactionScope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);
        DbContext = DbContextFactory.Create(connection);
    }

    public void Dispose()
    {
        DbContext.Dispose();
        _transactionScope.Dispose();
    }
}