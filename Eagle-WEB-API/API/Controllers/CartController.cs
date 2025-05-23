using Core.Interfaces;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/cart")]
    [ApiController]

    public class CartController : ControllerBase
    {
        private readonly ICartRepository _repo;
        public CartController(ICartRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")] 
       public async Task<IActionResult> GetCart(int id)
        {
            var cart = await _repo.GetCartAsync(id);
            return Ok(cart);
        }
[HttpPost("{userId}")]
public async Task<IActionResult> AddCart([FromBody]int id,int userId)
{
    bool result = await _repo.AddCartProductAsync(id, userId);
    return result ? Ok("Ürün sepete eklendi.") : BadRequest("Ürün eklenemedi.");
}

[HttpDelete("cartId")]
public async Task<IActionResult> DeleteCart([FromBody] int id,int cartId)
{
    bool result = await _repo.RemoveCartProductAsync(id, cartId);
    return result ? Ok("Ürün silindi.") : BadRequest("Silme işlemi başarısız.");
}

    }
}
