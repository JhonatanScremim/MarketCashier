using MarketCashier.App.Settings;
using RestSharp;
using Newtonsoft.Json;
using MarketCashier.App.Models;

namespace MarketCashier.App.Helpers
{
    public class ApiHelper
    {
        public static async Task GetLoginApi()
        {
            var options = new RestClientOptions(ApiSettings.Url);
            var client = new RestClient(options);
            var body = JsonConvert.SerializeObject(new LoginUser()
            {
                Username = ApiSettings.Username,
                Password = ApiSettings.Password
            });

            var request = new RestRequest($"{ApiSettings.Url}login", Method.Post).AddJsonBody(body);
            var response = await client.ExecuteAsync<LoginUserResponse>(request);

            if (!response.IsSuccessful)
                throw new Exception(response.ErrorMessage ?? "Erro interno no servidor");

            ApiSettings.Token = response?.Data?.Token;
        }
    }
}
