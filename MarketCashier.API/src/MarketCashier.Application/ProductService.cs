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
            var (products, totalCount) = await _productRepository.GetPaginated(pageParams);
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);

            return new PageList<ProductViewModel>(pageParams.PageNumber, pageParams.PageSize, totalCount, productsViewModel);
        }

        public async Task<ProductViewModel>? GetProductByBarCodeAsync(long barCode)
        {
            var product = await _productRepository.GetProductByBarCodeAsync(barCode);
            return _mapper.Map<ProductViewModel>(product);
        }
        public async Task<bool> CreateAsync(ProductDTO dto)
        {
            return await _productRepository.Create(_mapper.Map<Product>(dto));
        }
    }
}