using MarketCashier.Domain;
using MarketCashier.Repository.Context;
using MarketCashier.Repository;
using Microsoft.EntityFrameworkCore;

namespace MarketCashier.Test.UnitTests
{
    public class ProductRepositoryTests
    {
        private DataContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            return new DataContext(options);
        }

        [Fact]
        public async Task GetProductByBarCodeAsync_DeveRetornarProduto_QuandoExiste()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            var repository = new ProductRepository(context);

            var product = new Product { BarCode = 123456, Name = "Produto Teste" };
            context.Product.Add(product);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetProductByBarCodeAsync(123456);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Produto Teste", result.Name);
        }

        [Fact]
        public async Task GetProductByBarCodeAsync_DeveRetornarNulo_QuandoNaoExiste()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            var repository = new ProductRepository(context);

            // Act
            var result = await repository.GetProductByBarCodeAsync(999999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Create_DeveAdicionarProduto_QuandoChamado()
        {
            // Arrange
            var context = CreateInMemoryDbContext();
            var repository = new ProductRepository(context);

            var product = new Product { BarCode = 654321, Name = "Novo Produto" };

            // Act
            var result = await repository.Create(product);
            var productFromDb = await context.Product.FirstOrDefaultAsync(p => p.BarCode == 654321);

            // Assert
            Assert.True(result);
            Assert.NotNull(productFromDb);
            Assert.Equal("Novo Produto", productFromDb.Name);
        }
    }
}
