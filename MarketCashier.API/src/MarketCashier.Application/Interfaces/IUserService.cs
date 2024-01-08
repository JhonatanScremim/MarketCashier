using MarketCashier.Infra.ViewModels;

namespace MarketCashier.Application.Interfaces
{
    public interface IUserService
    {
        public Task<UserViewModel> LoginUser(string username, string password);
        public string GenerateToken(UserViewModel user);
    }
}