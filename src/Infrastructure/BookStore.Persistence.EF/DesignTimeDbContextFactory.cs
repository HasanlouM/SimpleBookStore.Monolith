using Common.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookStore.Persistence.EF;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
{
    public BookStoreDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<BaseDbContext>();
        // TODO: read from args
        options.UseSqlServer(
            "Server=.\\SQLSERVER2019;Database=BookStore;User Id=sa;Password=Mm@SQL2019;TrustServerCertificate=True;");
        //options.UseSqlServer("Data Source=;Initial Catalog=BookStore;UID=sa;PWD=Aa123456;Connect Timeout=999;MultipleActiveResultSets=True;Integrated Security=False;TrustServerCertificate=True;");

        return new BookStoreDbContext(options.Options);
    }
}