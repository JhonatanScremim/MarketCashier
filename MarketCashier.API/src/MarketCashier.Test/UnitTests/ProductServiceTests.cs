using AutoMapper;
using MarketCashier.Application;
using MarketCashier.Domain;
using MarketCashier.Infra.ViewModels;
using MarketCashier.Repository.Interfaces;
using Moq;
using Xunit;
using System.Threading.Tasks;

namespace MarketCashier.Test.UnitTests
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly IMapper _mapper;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>();
            });
            _mapper = config.CreateMapper();
            _productService = new ProductService(_productRepositoryMock.Object, _mapper);
        }

        [Theory]
        [InlineData(1234, "Produto Teste")]
        [InlineData(5678, "Outro Produto")]
        public async Task GetProductByBarCodeAsync_DeveRetornarProduto_QuandoEncontrado(long barcode, string name)
        {
            // Arrange 
            var product = new Product()
            {
                BarCode = barcode,
                Name = name
            };

            _productRepositoryMock.Setup(repo => repo.GetProductByBarCodeAsync(barcode))
                .ReturnsAsync(product);

            // Act 
            var result = await _productService.GetProductByBarCodeAsync(barcode);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(barcode, result.BarCode);
            Assert.Equal(name, result.Name);
        }

        [Fact]
        public async Task GetProductByBarCodeAsync_DeveRetornarNulo_QuandoProdutoNaoEncontrado()
        {
            // Arrange
            var barcode = 999999;
            _productRepositoryMock.Setup(repo => repo.GetProductByBarCodeAsync(barcode))
                                  .ReturnsAsync((Product)null);

            // Act
            var result = await _productService.GetProductByBarCodeAsync(barcode);

            // Assert
            Assert.Null(result);
        }
    }
}
