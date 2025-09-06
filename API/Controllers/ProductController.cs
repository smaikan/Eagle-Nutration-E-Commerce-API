using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Core.DTOs.ProductDTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound("Ürün bulunamadı.");
            return Ok(product);
        }

        
        [HttpGet("Category/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var products = await _productService.GetByCategoryIdAsync(categoryId);
            return Ok(products);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDTO dto)
        {
            var createdProduct = await _productService.CreateAsync(dto);
            return Ok(createdProduct);
        }

        [HttpPost("bulk")]
public async Task<IActionResult> CreateBulk([FromBody] List<ProductCreateDTO> dtos)
{
    var createdProducts = new List<ProductDTO>();

    foreach (var dto in dtos)
    {
        var created = await _productService.CreateAsync(dto);
        createdProducts.Add(created);
    }

    return Ok(createdProducts);
}

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDTO dto)
        {
            var result = await _productService.UpdateAsync(id, dto);
            if (!result)
                return NotFound("Güncellenecek ürün bulunamadı.");
            return NoContent();
        }


        [HttpPut("Sell/{id}")]
        public async Task<IActionResult> SellProduct(int id, int piece)
        {
            bool Selled = await _productService.DecreaseStock(id, piece);
            if (Selled == false)
                return NotFound("Sorun oluştu");

            return Ok(Selled);
        }
            
            
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (!result)
                return NotFound("Silinecek ürün bulunamadı.");
            return NoContent();
        }
    }
}
