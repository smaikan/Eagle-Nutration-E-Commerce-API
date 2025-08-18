using Core.DTOs;
using Core.Interfaces;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;

namespace API.Controllers
{[ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }


        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            var cart = await _cartService.GetCartAsync(userId);
            if (cart == null)
                return NotFound("Sepet bulunamadı.");

            var cartItemDtos = cart.CartItems.Select(ci => new CartItemDTO
            {
                CartItemId = ci.CartItemId,
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                UnitPrice = ci.UnitPrice,
                ProductName = ci.Products?.ProductName,
                ProductImage = ci.Products?.ProductImage,
                Aroma = ci.aroma

            }).ToList();
            return Ok(cartItemDtos);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddToCart(int productId, int userId, [FromQuery] string? aroma = "")
        {
            var success = await _cartService.AddCartProductItem(productId, userId, aroma);
            if (!success)
                return BadRequest("Ürün eklenemedi.");

            return Ok("Ürün sepete eklendi.");
        }




        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFromCart([FromQuery] int productId, [FromQuery] int userId, [FromQuery] string? aroma = "")
        {
            var removed = await _cartService.RemoveCartItem(productId, userId, aroma);
            if (!removed)
                return NotFound("Ürün sepetten silinemedi.");

            return Ok("Ürün sepetten silindi.");
        }
        [HttpDelete("decrease")]
        public async Task<IActionResult> DecreaseItemCart([FromQuery] int productId, [FromQuery] int userId, [FromQuery] string? aroma = "")
        {
            var removed = await _cartService.DecreaseCartItem(productId, userId, aroma);
            if (!removed)
                return NotFound("Ürün eksilmedi.");

            return Ok("Ürün sepetten eksildi.");
        }
        [HttpDelete("empty")]
        public async Task<IActionResult> EmptyCart(int userId)
        {
            var empty = await _cartService.EmptyCartAsync(userId);

            if (!empty)
            {
                return NotFound("Sepet boşaltılamadı.");
            }

            return Ok("Sepet boşaltıldı.");
        }
    }
}
