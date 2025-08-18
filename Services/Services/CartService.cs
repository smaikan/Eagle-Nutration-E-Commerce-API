using System.ComponentModel;
using Core.Interfaces;
using Core.Model;

namespace Services
{
    public class CartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {

            _cartRepository = cartRepository;
        }

        public async Task<Cart> GetCartAsync(int userId)
        {
            return await _cartRepository.GetCartAsync(userId);
        }
        public async Task<bool> RemoveCartItem(int productid, int userid, string? aroma = "")
        {
            var remove = await _cartRepository.RemoveCartProductAsync(productid, userid, aroma);
            return remove;
        }
        public async Task<bool> DecreaseCartItem(int productid, int userid, string? aroma = "")
        {
            var remove = await _cartRepository.decreaseCartProductAsync(productid, userid, aroma);
            return remove;
        }
        public async Task<bool> AddCartProductItem(int productid, int userid, string? aroma = "")
        {
            var item = await _cartRepository.AddCartProductAsync(productid, userid, aroma);
            return item;
        }
        public async Task<bool> EmptyCartAsync(int userId)
        {
            return await _cartRepository.EmptyCartAsync(userId);
        }


    }
}