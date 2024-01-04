using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MarketCashier.Application.ViewModels;
using MarketCashier.Domain;

namespace MarketCashier.Application.Mappers
{
    public class DomainToViewModelMapper : Profile
    {
        public DomainToViewModelMapper()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}