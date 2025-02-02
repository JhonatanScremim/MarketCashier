using MarketCashier.Domain;
using MarketCashier.Infra.Models;
using MarketCashier.Repository.Interfaces;

namespace MarketCashier.Repository.Mocks
{

    public class MockProductRepository : IProductRepository
    {
        // Simulando dados no repositório
        private readonly List<Product> _products = new List<Product>
    {
        new Product { BarCode = 123456, Name = "Produto Teste 1" },
        new Product { BarCode = 654321, Name = "Produto Teste 2" }
    };

        public Task<Product> GetProductByBarCodeAsync(long barCode)
        {
            // Simula o comportamento do repositório real
            var product = _products.Find(p => p.BarCode == barCode);
            return Task.FromResult(product);
        }

        public IQueryable<Product>? GetPaginated(PageParams pageParams, out int totalCount)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(Product product)
        {
            throw new NotImplementedException();
        }
    }

}
