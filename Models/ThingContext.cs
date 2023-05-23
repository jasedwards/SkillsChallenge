using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Models
{
    public class ThingContext : BaseDbContext<ThingContext>
    {
        public ThingContext(DbContextOptions<ThingContext> options)
            : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var x = builder.Entity<Thing>(config =>
            {
                config.ToTable("Things");
            });
        }
    }
}