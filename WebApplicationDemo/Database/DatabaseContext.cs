using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Database.Entities;

namespace WebApplicationDemo.Database
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("Default"));
        }

        public DbSet<CounterEntity> Counters { get; set; }
    }
}
