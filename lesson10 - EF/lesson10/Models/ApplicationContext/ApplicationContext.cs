using Microsoft.EntityFrameworkCore;

namespace lesson10.Models.ApplicationContext
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=lesson10_usersdb;Trusted_Connection=True");
        }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
    }
}
