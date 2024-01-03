using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketCashier.Application.ViewModels;
using MarketCashier.Domain;

namespace MarketCashier.Application.Interfaces
{
    public interface IUserService
    {
        public Task<UserViewModel> LoginUser(string username, string password);
        public string GenerateToken(UserViewModel user);
    }
}