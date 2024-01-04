using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketCashier.Domain;

namespace MarketCashier.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> LoginUser(string username, string password);
    }
}