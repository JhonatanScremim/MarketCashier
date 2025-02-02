using MarketCashier.Domain;
using Microsoft.EntityFrameworkCore;

namespace MarketCashier.Repository.Context.Test
{
    public class ProductDbContextTest : DbContext
    {
        public DbSet<Product> Product { get; set; }
    }
}
