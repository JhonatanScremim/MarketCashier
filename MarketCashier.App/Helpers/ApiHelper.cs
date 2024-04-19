using MarketCashier.App.Settings;
using RestSharp;
using Newtonsoft.Json;
using MarketCashier.App.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace MarketCashier.App.Helpers
{
    public class ApiHelper
    {
        private RestClient _client;
        private string _url;

        public ApiHelper() 
        {
            var options = new RestClientOptions(ApiSettings.Url);
            _client = new RestClient(options);
            _url = ApiSettings.Url;
        }

        public async Task GetLoginApi()
        {
            var body = JsonConvert.SerializeObject(new LoginUser()
            {
                Username = ApiSettings.Username,
                Password = ApiSettings.Password
            });

            var request = new RestRequest($"{_url}/login", Method.Post).AddJsonBody(body);
            var response = await _client.ExecuteAsync<LoginUserResponse>(request);

            if (!response.IsSuccessful)
                throw new Exception(response.ErrorMessage ?? "Erro interno no servidor");

            ApiSettings.Token = response?.Data?.Token;
        }
        public async Task<Product> GetProductByBarCode(long barCode)
        {
            var request = new RestRequest($"{_url}/get-by-barCode/{barCode}", Method.Get);
            request.AddHeader("Authorization", $"Bearer {ApiSettings.Token}");

            var response = await _client.ExecuteAsync<Product>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await GetLoginApi();
                await GetProductByBarCode(barCode);
            }

            if (!response.IsSuccessful)
                throw new Exception(response.ErrorMessage ?? "Erro interno no servidor");

            return response.Data;
        }
    }
}
