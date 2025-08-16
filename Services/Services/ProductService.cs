using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.ProductDTOs;
using Core.Interfaces;
using Core.Model;
using Services.Interfaces;
using Core.Exeptions;
namespace Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            if (products == null)
               { throw new NotFoundException("Ürün bulunamadı."); }
            return _mapper.Map<List<ProductDTO>>(products);
        }
        
        public async Task<List<ProductDTO>> GetByCategoryIdAsync(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategoryIdAsync(categoryId);
            return _mapper.Map<List<ProductDTO>>(products);
        }
        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> CreateAsync(ProductCreateDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productRepository.AddAsync(product);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> UpdateAsync(int id, ProductUpdateDTO dto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return false;

            _mapper.Map(dto, product);
            return await _productRepository.UpdateAsync(product);
        }
        public async Task<bool> SelledProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new Exception("Ürün bulunamadı.");

            
            if (product.Stock <= 0)
                throw new Exception("Ürün stoğu tükenmiş.");

            
            product.Stock--;

            
            await _productRepository.UpdateAsync(product);

            
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return false;  

            await _productRepository.DeleteAsync(id);
            return true;
        }

    }
}
