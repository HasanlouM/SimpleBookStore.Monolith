using Common.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistence.EF;

public static class DbContextFactory
{
    //public static BookStoreDbContext Create(DbConnection connection)
    //{
    //    var builder = new DbContextOptionsBuilder<BaseDbContext>();
    //    builder.UseSqlServer(connection);

    //    return new BookStoreDbContext(builder.Options);
    //}

    public static BookStoreDbContext Create(string connectionString)
    {
        var builder = new DbContextOptionsBuilder<BaseDbContext>();
        builder.UseSqlServer(connectionString);

        return new BookStoreDbContext(builder.Options);
    }
}