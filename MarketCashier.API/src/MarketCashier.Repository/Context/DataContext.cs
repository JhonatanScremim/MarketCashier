using MarketCashier.Domain;
using Microsoft.EntityFrameworkCore;

namespace MarketCashier.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configuraçaõ de log, utilizado para ver valores de chaves conflitantes em exceptions
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}