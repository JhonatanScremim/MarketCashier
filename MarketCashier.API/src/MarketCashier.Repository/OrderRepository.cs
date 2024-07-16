using MarketCashier.Domain;
using MarketCashier.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MarketCashier.Repository
{
    public class OrderRepository
    {
        private readonly DbContextOptions<DataContext> _context;

        public OrderRepository(DbContextOptions<DataContext> context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Order order)
        {
            await using var _db = new DataContext(_context);
            _db.Add(order);

            return (await _db.SaveChangesAsync() > 0);
        }
    }
}