using System.Security.Claims;
using MarketCashier.Application.Exceptions;
using MarketCashier.Application.Interfaces;
using MarketCashier.Domain;
using MarketCashier.Infra.Models;
using Microsoft.AspNetCore.Http.HttpResults;

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
                catch(InvalidUserException e){
                    return Results.BadRequest(e.Message);
                }
                catch(Exception e){
                    return Results.BadRequest(e.Message);
                }
            });

            app.MapGet("/get-paginated", async Task<IResult>([AsParameters] PageParams pageParams, IProductService _productService) => 
            {
                try{

                    return Results.Ok(await _productService.GetPaginated(pageParams));
                }
                catch(Exception e){
                    return Results.BadRequest(e.Message);
                }
            }).RequireAuthorization();;
        }
    }
}