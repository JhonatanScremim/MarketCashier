using MarketCashier.Domain;
using MarketCashier.Infra.Models;

namespace MarketCashier.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<(List<Product>, int totalCount)> GetPaginated(PageParams pageParams);
        Task<Product> GetProductByBarCodeAsync(long barCode);
        Task<bool> Create(Product product);
    }
}