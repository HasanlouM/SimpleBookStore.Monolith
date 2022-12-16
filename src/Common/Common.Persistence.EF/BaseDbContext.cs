using Microsoft.EntityFrameworkCore;

namespace Common.Persistence.EF
{
    public class BaseDbContext: DbContext
    {
        protected BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
        }
    }
}