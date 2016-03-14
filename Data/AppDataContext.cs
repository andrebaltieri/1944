using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using TodoCore.Models;

namespace TodoCore.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase();
            
            // var builder = new ConfigurationBuilder()
            //     .AddJsonFile("Config/config.json")
            //     .AddEnvironmentVariables();
            // var configuration = builder.Build();
            
            // var sqlConnectionString = 
            //     configuration["DataAccessPostgreSqlProvider:ConnectionString"];
            
            // optionsBuilder.UseNpgsql(sqlConnectionString);
        }
    }
}