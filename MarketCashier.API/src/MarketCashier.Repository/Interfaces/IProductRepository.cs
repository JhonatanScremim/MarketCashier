using MarketCashier.Domain;
using MarketCashier.Infra.Models;

namespace MarketCashier.Repository.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product>? GetPaginated(PageParams pageParams, out int totalCount);
        Task<Product> GetProductByBarCodeAsync(long barCode);
        Task<bool> Create(Product product);
    }
}