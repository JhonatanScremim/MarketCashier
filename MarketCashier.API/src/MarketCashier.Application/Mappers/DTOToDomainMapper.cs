using AutoMapper;
using MarketCashier.Domain;
using MarketCashier.Infra.DTOs;

namespace MarketCashier.Application.Mappers
{
    public class DTOToDomainMapper : Profile
    {
        public DTOToDomainMapper()
        {
            CreateMap<ProductDTO, Product>();
        }
    }
}