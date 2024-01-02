using System.Security.Claims;
using System.Text;
using MarketCashier.API.Settings;
using MarketCashier.API.TemporariesClasses;
using MarketCashier.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = Encoding.ASCII.GetBytes(Settings.Secret);
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/anonymous", () =>
{
    return Results.Ok("Anonimo");
}).AllowAnonymous();

app.MapGet("/authenticated", (ClaimsPrincipal user) => {
    return Results.Ok($"Autenticado {user.Identity.Name}");
}).RequireAuthorization();

app.MapGet("/authenticatedAdmin", (ClaimsPrincipal user) => {
    return Results.Ok($"Autenticado pelo admin {user.Identity.Name}");
}).RequireAuthorization("Admin");

app.MapPost("/login", (User model) => 
{
    var user = CreateUserStatic.Get(model.Username, model.Password);

    if (user == null)
        return Results.NotFound(new {
            message = "Invalid username or password"
        });
    
    var token = TokenService.GenerateToken(user);
    user.Password = "";

    return Results.Ok(new{
        user = user,
        token = token
    });
});

app.Run();
