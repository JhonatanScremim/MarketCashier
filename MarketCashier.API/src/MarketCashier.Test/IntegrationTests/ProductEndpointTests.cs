using MarketCashier.Infra.ViewModels;
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using MarketCashier.Infra.Models;
using MarketCashier.Domain;
using Moq;

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
        public async Task GetProductPaginated_DeveRetornar200_QuandoEncontrar()
        {
            //Arrange
            var pageParams = new PageParams()
            { PageNumber = 1, PageSize = 10};

            //Act
            var response = await _client.GetAsync($"/get-paginated?pageNumber={pageParams.PageNumber}&pageSize={pageParams.PageSize}");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var products = await response.Content.ReadFromJsonAsync<PageList<ProductViewModel>>();
            Assert.NotNull(products);            
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
