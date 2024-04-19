using MarketCashier.Domain;
using MarketCashier.Infra.Models;
using MarketCashier.Repository.Context;
using MarketCashier.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketCashier.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<Product>? GetPaginated(PageParams pageParams, out int totalCount)
        {
            var query = _context.Product;

            totalCount = query.Count();
            return query;
        }
        public async Task<Product> GetProductByBarCodeAsync(long barCode)
        {
            return await _context.Product.FirstOrDefaultAsync(x => x.BarCode == barCode);
        }
        public async Task<bool> Create(Product product)
        {
            _context.Product.Add(product);
            
            return (await _context.SaveChangesAsync() > 0);
        }

    }
}