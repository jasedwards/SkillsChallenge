using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Models
{
    public class PersonContext : BaseDbContext<PersonContext>
    {
        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var x = builder.Entity<Person>(config =>
            {
                config.ToTable("People");
            });
        }
    }
}