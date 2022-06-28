using Microsoft.EntityFrameworkCore;
using onlineStore.Core.Entities;

namespace onlineStore.Infrastructure.ApplicationContext
{
    public class EFContext : DbContext
    {
        public EFContext()
        {
        }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=db;Database=master;User=sa;Password=30051986;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Item> Items { get; set; }
        
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public  DbSet<UserToken> UserTokens { get; set; }

    }
}
