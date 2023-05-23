using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Models
{
    public class PlaceContext : BaseDbContext<PlaceContext>
    {
        public PlaceContext(DbContextOptions<PlaceContext> options)
            : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var x = builder.Entity<Place>(config =>
            {
                config.ToTable("Places");
            });
        }
    }
}