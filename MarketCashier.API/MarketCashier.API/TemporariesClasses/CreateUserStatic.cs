using MarketCashier.Domain;

namespace MarketCashier.API.TemporariesClasses
{
    public static class CreateUserStatic
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>{   
                new User { Id = 1, Username = "Pedro", Password = "pedro", Role = "manager"},
                new User { Id = 2, Username = "Ana", Password = "ana", Role = "employee"}
            }; 

            return users.Where(x => x.Username.ToLower() == username.ToLower() && 
                x.Password.ToLower() == password.ToLower()).FirstOrDefault();
        }
    }
} 