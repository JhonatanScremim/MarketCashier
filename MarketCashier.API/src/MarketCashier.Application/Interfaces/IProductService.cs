using MarketCashier.Infra.DTOs;
using MarketCashier.Infra.Models;
using MarketCashier.Infra.ViewModels;

namespace MarketCashier.Application.Interfaces
{
    public interface IProductService
    {
        Task<PageList<ProductViewModel>>? GetPaginated(PageParams pageParams);
        Task<ProductViewModel>? GetProductByBarCodeAsync(long barCode);
        Task<bool> CreateAsync(ProductDTO dto);
    }
}