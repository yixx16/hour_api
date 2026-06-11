using Microsoft.EntityFrameworkCore;
using Horas.Core.Entities;

namespace Horas.Persistence
{
    
    public class HourContext(DbContextOptions dbContextOptions) : DbContext
    {
        private readonly DbContextOptions _options = dbContextOptions;
        
        public DbSet<Hour> Hours {get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
                var connectionString = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString); 
            }

        }
    }
}