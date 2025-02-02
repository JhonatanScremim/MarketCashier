using MarketCashier.Infra.ViewModels;
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;

namespace MarketCashier.Test.IntegrationTests
{
    public class ProductEndpointTests : IClassFixture<CustomWebApplicationFacotry>
    {
        private readonly HttpClient _client;

        public ProductEndpointTests(CustomWebApplicationFacotry factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetProductByBarCode_DeveRetornar200_QuandoProdutoExiste()
        {
            //Arrange 
            long barCode = 123456;

            //Act
            var response = await _client.GetAsync($"/get-by-barcode/{barCode}");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var product = await response.Content.ReadFromJsonAsync<ProductViewModel>();
            Assert.NotNull(product);
        }

        [Fact]
        public async Task GetProductByBarCode_DeveRetornarVazio_QuandoNaoEncontrar()
        {
            // Arrange
            long barcode = -1; // Simulando erro

            // Act
            var response = await _client.GetAsync($"/get-by-barcode/{barcode}");

            // Assert
            var content = await response.Content.ReadAsStringAsync();
            Assert.True(string.IsNullOrWhiteSpace(content), "A resposta da API está vazia.");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
    }
}
