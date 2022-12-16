using Microsoft.EntityFrameworkCore;

namespace SimpleFramework.Infrastructure.Persistence.EF
{
    public abstract class BaseDbContext : DbContext
    {
        protected BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
        }
    }
}
