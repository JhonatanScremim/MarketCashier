using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MarketCashier.Application.Interfaces;
using MarketCashier.Domain;

namespace MarketCashier.API
{
    public static class Routes
    {
        public static void AddRoutes(this WebApplication app, WebApplicationBuilder builder)
        {
            
            app.MapGet("/anonymous", () =>
            {
                return Results.Ok("Anonimo");
            }).AllowAnonymous();

            app.MapGet("/authenticated", (ClaimsPrincipal user) => {
                return Results.Ok($"Autenticado {user.Identity!.Name}");
            }).RequireAuthorization();

            app.MapGet("/authenticatedAdmin", (ClaimsPrincipal user) => {
                return Results.Ok($"Autenticado pelo admin {user.Identity!.Name}");
            }).RequireAuthorization("Admin");

            app.MapPost("/login", async Task<IResult>(User model, IUserService userService) => 
            {
                try{
                    return Results.Ok(await userService.LoginUser(model.Username, model.Password));
                }
                catch(Exception e){
                    return Results.BadRequest(e.Message);
                }
            });
        }
    }
}