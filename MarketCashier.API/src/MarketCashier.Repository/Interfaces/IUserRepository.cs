using MarketCashier.Domain;

namespace MarketCashier.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> LoginUser(string username, string password);
    }
}