using MarketCashier.Domain;
using MarketCashier.Repository.Context;
using MarketCashier.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketCashier.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User?> LoginUser(string username, string password)
        {
            return await _context.User.Where(x => x.Username.ToLower() == username.ToLower() 
                        && x.Password.ToLower() == password.ToLower()).FirstOrDefaultAsync();
        }
    }
}