using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Models
{
    public abstract class BaseDbContext<TContext>: DbContext where TContext : DbContext
    {
        public BaseDbContext(DbContextOptions<TContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior =  QueryTrackingBehavior.NoTracking;
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public override DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
