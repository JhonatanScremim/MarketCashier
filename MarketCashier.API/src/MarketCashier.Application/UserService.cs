using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using MarketCashier.Application.Interfaces;
using MarketCashier.Infra.ViewModels;
using MarketCashier.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MarketCashier.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;    
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly byte[] _key;

        public UserService(IUserRepository userRepository, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
            _key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("TokenKey") ?? throw new Exception("nothing key found!"));
        }

        public string GenerateToken(UserViewModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key),
                                            SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<UserViewModel> LoginUser(string username, string password)
        {
            var user = _mapper.Map<UserViewModel>(await _userRepository.LoginUser(username, password));

            if (user == null)
                throw new Exception("Invalid username or password");
            
            user.Token = GenerateToken(user);
            user.Password = "";

            return user;
        }
    }
}