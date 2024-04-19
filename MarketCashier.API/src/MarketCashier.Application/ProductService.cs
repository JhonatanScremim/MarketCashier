using AutoMapper;
using MarketCashier.Application.Interfaces;
using MarketCashier.Domain;
using MarketCashier.Infra.DTOs;
using MarketCashier.Infra.Models;
using MarketCashier.Infra.ViewModels;
using MarketCashier.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketCashier.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PageList<ProductViewModel>>? GetPaginated(PageParams pageParams)
        {
            var queryPaginated = _productRepository.GetPaginated(pageParams, out int totalCount);
            var products = new List<ProductViewModel>();  
            if (queryPaginated != null)
                products = _mapper.Map<List<ProductViewModel>>(await queryPaginated.ToListAsync());

            return new PageList<ProductViewModel>(pageParams.PageNumber, pageParams.PageSize, totalCount, products);
        }
        public async Task<bool> CreateAsync(ProductDTO dto)
        {
            return await _productRepository.Create(_mapper.Map<Product>(dto));
        }
    }
}