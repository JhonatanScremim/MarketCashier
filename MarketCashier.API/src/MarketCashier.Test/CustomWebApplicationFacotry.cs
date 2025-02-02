using MarketCashier.Repository.Interfaces;
using MarketCashier.Repository.Mocks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;

namespace MarketCashier.Test
{
    public class CustomWebApplicationFacotry : WebApplicationFactory<Program>
    {
        // Aqui você pode substituir os serviços reais por mocks para os testes
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing"); // Define o ambiente de teste

            builder.ConfigureServices(services =>
            {
                // Substituindo o IProductRepository real por um mock
                services.AddScoped<IProductRepository, MockProductRepository>();

                services.RemoveAll(typeof(IAuthenticationSchemeProvider));

                // Adiciona autenticação fake para testes
                services.AddAuthentication("Test")
                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => { });
            });
        }
    }
}
