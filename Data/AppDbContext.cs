
using Guardian.Models;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;

namespace Guardian.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<UserApplications> UserApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // optionsBuilder.UseInMemoryDatabase();
            
            var builder = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            var configuration = builder.Build();
 
            var sqlConnectionString = 
               configuration["DataAccessPostgreSqlProvider:ConnectionString"];
 
            optionsBuilder.UseNpgsql(sqlConnectionString);

        }
    }
}