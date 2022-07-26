using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            for (int i = 1; i < 5; i++)
            {
                modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = i,
                    UserName = $"UserName {i}",
                    Password = "12345"
                });
            }
        }

        public DbSet<User> Users { get; set; }
    }
}
