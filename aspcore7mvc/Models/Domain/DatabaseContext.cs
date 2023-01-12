using Microsoft.EntityFrameworkCore;

namespace aspcore7mvc.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
        {

        }

        public DbSet<Person> Person { get; set; }

        public DbSet<PersonLocation> PersonLocation { get; set; }
    }
}
