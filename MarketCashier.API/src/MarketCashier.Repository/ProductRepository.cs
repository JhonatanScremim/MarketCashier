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

        public async Task<(List<Product>, int totalCount)> GetPaginated(PageParams pageParams)
        {
            var products = _context.Product;

            var totalCount = products.Count();
            return (await products
                .AsQueryable()
                .Skip((pageParams.PageNumber - 1) * pageParams.PageSize)
                .Take(pageParams.PageSize).ToListAsync(), totalCount); 
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