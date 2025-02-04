using MarketCashier.Domain;
using MarketCashier.Infra.Models;
using MarketCashier.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public Task<(List<Product>, int totalCount)> GetPaginated(PageParams pageParams)
        {

            var totalCount = _products.Count();
            var products = _products
                .AsQueryable() // Converte a lista para IQueryable
                .Skip((pageParams.PageNumber - 1) * pageParams.PageSize) // Pula os itens das páginas anteriores
                .Take(pageParams.PageSize).ToList(); // Retorna apenas os itens da página atual

            return Task.FromResult((products, totalCount));
        }

        public Task<bool> Create(Product product)
        {
            throw new NotImplementedException();
        }
    }

}
