using AutoMapper;
using MarketCashier.Domain;
using MarketCashier.Infra.ViewModels;

namespace MarketCashier.Application.Mappers
{
    public class DomainToViewModelMapper : Profile
    {
        public DomainToViewModelMapper()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}