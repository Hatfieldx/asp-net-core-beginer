using Microsoft.EntityFrameworkCore;

namespace losson10_2.Models.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            
        }
    }
}
