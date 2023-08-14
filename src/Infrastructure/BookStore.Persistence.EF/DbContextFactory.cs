using Common.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Persistence.EF;

public static class DbContextFactory
{
    private static string _connectionString;

    public static BookStoreDbContext Create(string connectionString)
    {
        var builder = new DbContextOptionsBuilder<BaseDbContext>();
        builder.UseSqlServer(connectionString);

        return new BookStoreDbContext(builder.Options);
    }
    public static BookStoreDbContext Create()
    {
        if (string.IsNullOrEmpty(_connectionString))
        {
            throw new NotImplementedException();
        }

        return Create(_connectionString);
    }

    public static void SetConnectionString(string connectionString)
    {
        _connectionString = connectionString;
    }
}