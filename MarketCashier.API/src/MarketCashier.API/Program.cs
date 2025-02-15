using Hangfire;
using MarketCashier.API;
using MarketCashier.Application;
using MarketCashier.Application.Interfaces;
using MarketCashier.Repository;
using MarketCashier.Repository.Context;
using MarketCashier.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MarketCashier-SQLServer")));

AuthConfiguration.AddAuthConfiguration(builder);

//Hangfire
builder.Services.AddHangfire(options => 
{
    options.UseSqlServerStorage(builder.Configuration.GetConnectionString("MarketCashier-SQLServer"));
});
builder.Services.AddHangfireServer();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IRabbitMQMessageConsumer, RabbitMQMessageConsumer>();

//Config order repository
var builderDb = new DbContextOptionsBuilder<DataContext>();
builderDb.UseSqlServer(builder.Configuration.GetConnectionString("MarketCashier-SQLServer"));

builder.Services.AddSingleton(new OrderRepository(builderDb.Options));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  

app.UseHangfireDashboard();
HangfireJobs.Start();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.AddRoutes(builder);

app.Run();

public partial class Program { }