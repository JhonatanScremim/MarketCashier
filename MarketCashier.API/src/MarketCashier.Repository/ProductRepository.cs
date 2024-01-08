using MarketCashier.Domain;
using MarketCashier.Infra.Models;
using MarketCashier.Repository.Context;
using MarketCashier.Repository.Interfaces;

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
    }
}