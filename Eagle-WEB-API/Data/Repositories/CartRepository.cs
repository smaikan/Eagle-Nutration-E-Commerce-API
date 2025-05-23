using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Model;
using Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cart?> GetCartAsync(int cartId)
        {
            return await _context.Cart
                .Include(c => c.User)
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.CartId == cartId);
        }

        public async Task<bool> AddCartProductAsync(int productId, int userId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null)
                return false;

            var existingCart = await _context.Cart
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (existingCart == null)
            {
                var cart = new Cart
                {
                    UserId = userId,
                    Products = new List<Product> { product }
                };
                _context.Cart.Add(cart);
            }
            else
            {
                
                    existingCart.Products.Add(product);
                
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveCartProductAsync(int productId, int cartId)
        {
            var cart = await _context.Cart
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.CartId == cartId);

            if (cart != null)
            {
                var productToRemove = cart.Products.FirstOrDefault(p => p.ProductId == productId);
                if (productToRemove != null)
                {
                    cart.Products.Remove(productToRemove);
                    await _context.SaveChangesAsync();
                }
            }

            return true;
        }
    }
}
