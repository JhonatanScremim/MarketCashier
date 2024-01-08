using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace MarketCashier.API
{
    public static class AuthConfiguration
    {
        public static void AddAuthConfiguration(WebApplicationBuilder builder)
        {
            var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("TokenKey") ?? throw new Exception("No key found!"));
            builder.Services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            builder.Services.AddAuthorization(opt => {
                opt.AddPolicy("Admin", policy => policy.RequireRole("manager"));
                opt.AddPolicy("Employee", policy => policy.RequireRole("employee"));
            });
        }
    }
}