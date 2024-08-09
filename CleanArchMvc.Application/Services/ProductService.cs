using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
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
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsMap = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsMap);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var product = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productMap = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(productMap);
        }
        public async Task Update(ProductDTO productDTO)
        {
            var productMap = _mapper.Map<Product>(productDTO);
            await _productRepository.UpdateAsync(productMap);
        }

        public async Task Remove(int? id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            await _productRepository.RemoveAsync(product);
        }
    }
}
