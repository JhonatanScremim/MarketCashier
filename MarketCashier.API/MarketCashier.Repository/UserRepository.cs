using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketCashier.Domain;
using MarketCashier.Repository.Interfaces;

namespace MarketCashier.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> LoginUser(string username, string password)
        {
            var users = new List<User>{   
                new User { Id = 1, Username = "Pedro", Password = "pedro", Role = "manager"},
                new User { Id = 2, Username = "Ana", Password = "ana", Role = "employee"}
            }; 

            return users.Where(x => x.Username.ToLower() == username.ToLower() 
                        && x.Password.ToLower() == password.ToLower()).FirstOrDefault();
        }
    }
}